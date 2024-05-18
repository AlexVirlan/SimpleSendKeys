using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleSendKeys.Utils
{
    public class Check4UpdateGH
    {
        #region Properties
        #region Public
        public string Owner { get; set; }
        public string Repo { get; set; }
        public CheckSettings CheckSettings { get; set; }
        public UpdateCheckResult UpdateCheckResult { get; set; } = new();
        #endregion

        #region Private
        private bool Initialized = false;
        private string APIUrl = "https://api.github.com/repos";
        private HttpClient HttpClient = new();
        private Assembly Assembly = Assembly.GetExecutingAssembly();
        #endregion
        #endregion

        #region Constructors
        public Check4UpdateGH()
        {
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(Assembly.Location);
            Owner = fileVersionInfo.CompanyName?.Replace(" ", string.Empty) ?? string.Empty;
            Repo = fileVersionInfo.ProductName?.Replace(" ", string.Empty) ?? string.Empty;
            CheckSettings = new();
            Initialize();
        }

        public Check4UpdateGH(string owner, string repo)
        {
            Owner = owner;
            Repo = repo;
            CheckSettings = new();
            Initialize();
        }

        public Check4UpdateGH(string owner, string repo, CheckSettings checkSettings)
        {
            Owner = owner;
            Repo = repo;
            CheckSettings = checkSettings;
            Initialize();
        }
        #endregion

        #region Methods
        #region Public
        public UpdateCheckResult Check()
        {
            if (string.IsNullOrEmpty(Owner)) { return UpdateCheckResult = new UpdateCheckResult("The 'Owner' field is empty."); }
            if (string.IsNullOrEmpty(Repo)) { return UpdateCheckResult = new UpdateCheckResult("The 'Repo' field is empty."); }

            try
            {
                if (!Initialized) { Initialize(); }
                HttpResponseMessage response = HttpClient.GetAsync($"{APIUrl}/{Owner}/{Repo}/releases?per_page=1").Result;
                if (response.IsSuccessStatusCode)
                {
                    #region Processing the API response
                    GitHubRelease gitHubRelease = new GitHubRelease();
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    List<GitHubRelease>? gitHubReleases = JsonConvert.DeserializeObject<List<GitHubRelease>>(responseString);

                    if (gitHubReleases is not null && gitHubReleases.Count > 0) { gitHubRelease = gitHubReleases[0]; }
                    else { return UpdateCheckResult = new UpdateCheckResult(success: true, message: "There are no releases available."); }
                    #endregion

                    #region Version check
                    bool versionSuccess = false;
                    string versionStr = string.Empty;
                    Version? latestGHVersion = null;
                    Version? currentVersion = null;
                    switch (CheckSettings.CheckVersionFrom)
                    {
                        case CheckVersionFrom.ReleaseName: versionStr = gitHubRelease.Name; break;
                        case CheckVersionFrom.TagName: versionStr = gitHubRelease.TagName; break;
                        case CheckVersionFrom.FirstAssetName: versionStr = gitHubRelease.Assets.FirstOrDefault()?.Name ?? string.Empty; break;
                    }
                    if (!string.IsNullOrEmpty(versionStr))
                    {
                        Match match = Regex.Match(versionStr, @"\d+(\.\d+|\-\d+){2,3}", RegexOptions.IgnoreCase);
                        if (match.Success)
                        {
                            List<string> tokens = versionStr.Split('.', StringSplitOptions.RemoveEmptyEntries).ToList();
                            if (tokens.Count == 3) { tokens.Add("0"); }

                            if (int.TryParse(tokens[0], out int major) &&
                                int.TryParse(tokens[1], out int minor) &&
                                int.TryParse(tokens[2], out int build) &&
                                int.TryParse(tokens[3], out int revision))
                            {
                                latestGHVersion = new Version(major, minor, build, revision);
                                currentVersion = GetCurrentVersion();
                                if (currentVersion is not null && latestGHVersion > currentVersion)
                                {
                                    versionSuccess = true;
                                }
                            }
                        }
                    }
                    #endregion

                    #region Time check
                    bool timeSuccess = false;
                    DateTime? currentTimeStamp = GetCurrentTimestamp();
                    if (currentTimeStamp is not null && gitHubRelease.PublishedAt > currentTimeStamp)
                    {
                        timeSuccess = true;
                    }
                    #endregion

                    #region Computing result
                    if (CheckSettings.CheckType == CheckType.VersionThenTime)
                    {
                        if (versionSuccess) { return UpdateCheckResult = new UpdateCheckResult(currentVersion, latestGHVersion, gitHubRelease); }
                        else if (timeSuccess) { return UpdateCheckResult = new UpdateCheckResult(newVersionAvailable: true); }
                        else { return UpdateCheckResult = new UpdateCheckResult(newVersionAvailable: false); }
                    }
                    else if (CheckSettings.CheckType == CheckType.OnlyVersion)
                    {
                        if (versionSuccess) { return UpdateCheckResult = new UpdateCheckResult(currentVersion, latestGHVersion, gitHubRelease); }
                        else { return UpdateCheckResult = new UpdateCheckResult(newVersionAvailable: false); }
                    }
                    else if (CheckSettings.CheckType == CheckType.OnlyTime)
                    {
                        if (timeSuccess) { return UpdateCheckResult = new UpdateCheckResult(newVersionAvailable: true); }
                        else { return UpdateCheckResult = new UpdateCheckResult(newVersionAvailable: false); }
                    }
                    else { return UpdateCheckResult = new UpdateCheckResult(newVersionAvailable: false); }
                    #endregion
                }
                else
                {
                    return UpdateCheckResult = new UpdateCheckResult($"The GitHub API responded with {(int)response.StatusCode} status code ({response.StatusCode}).");
                }
            }
            catch (Exception ex)
            {
                return UpdateCheckResult = new UpdateCheckResult(ex.Message);
            }
        }

        public async Task<(bool DownloadSuccess, string? DownloadError)> DownloadAsync(dynamic assetIndexOrName, string path = "", bool openFile = true, bool overwrite = false)
        {
            try
            {
                if (string.IsNullOrEmpty(path) || !Directory.Exists(path)) { path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); }

                GitHubAsset? asset = null;
                if (assetIndexOrName is int)
                {
                    if ((int)assetIndexOrName > UpdateCheckResult.GitHubRelease?.Assets.Count - 1)
                    { return (false, $"Could not find the asset from index {assetIndexOrName}."); }
                    asset = UpdateCheckResult.GitHubRelease?.Assets[(int)assetIndexOrName];
                }
                else if (assetIndexOrName is string)
                {
                    asset = UpdateCheckResult.GitHubRelease?.Assets
                        .Where(a => a.Name.Contains((string)assetIndexOrName, StringComparison.OrdinalIgnoreCase))
                        .FirstOrDefault();
                    if (asset is null) { return (false, $"Could not find an asset that contains '{assetIndexOrName}' in its name."); }
                }
                else
                {
                    return (false, "The 'assetIndexOrName' parameter must be of type 'int' or 'string'.");
                }

                string filePath = Path.Combine(path, asset.Name);
                if (!overwrite)
                {
                    int index = 0;
                    string filePathOnly = Path.GetDirectoryName(filePath);
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                    string fileExtension = Path.GetExtension(filePath);
                    while (File.Exists(filePath))
                    {
                        index++;
                        filePath = Path.Combine(filePathOnly, $"{fileNameWithoutExtension} ({index}){fileExtension}");
                    }
                }

                using HttpClient httpClient = new HttpClient();
                using Stream stream = await httpClient.GetStreamAsync(asset.BrowserDownloadUrl);
                using FileStream fileStream = new(filePath, FileMode.OpenOrCreate);
                await stream.CopyToAsync(fileStream);
                await fileStream.DisposeAsync();
                await stream.DisposeAsync();
                Thread.Sleep(100);

                if (openFile) { Process.Start(filePath); }
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public Version? GetCurrentVersion()
        {
            return Assembly.GetName().Version;
        }

        public DateTime? GetCurrentTimestamp()
        {
            if (!File.Exists(Assembly.Location)) { return null; }
            FileInfo fileInfo = new(Assembly.Location);
            return fileInfo.LastWriteTimeUtc;
        }
        #endregion

        #region Private
        private void Initialize()
        {
            HttpClient.DefaultRequestHeaders.Clear();
            HttpClient.DefaultRequestHeaders.Add("Accept", "*/*");
            HttpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
            HttpClient.DefaultRequestHeaders.Add("Host", "api.github.com");
            HttpClient.DefaultRequestHeaders.Add("User-Agent", "SimpleSendKeys");

            new Thread(TryConnection).Start();
            Initialized = true;
        }

        private void TryConnection()
        {
            try { _ = HttpClient.GetAsync("https://api.github.com").Result; }
            catch (Exception) { }
        }
        #endregion
        #endregion
    }

    #region CheckSettings, CheckType, CheckFrom, UpdateCheckResult
    public class CheckSettings
    {
        #region Properties
        public CheckType CheckType { get; set; }
        public CheckVersionFrom CheckVersionFrom { get; set; }
        #endregion

        #region Constructors
        public CheckSettings()
        {
            CheckType = CheckType.VersionThenTime;
            CheckVersionFrom = CheckVersionFrom.TagName;
        }
        #endregion
    }

    public enum CheckType
    {
        VersionThenTime = 0,
        OnlyVersion = 1,
        OnlyTime = 2
    }

    public enum CheckVersionFrom
    {
        ReleaseName = 0,
        TagName = 1,
        FirstAssetName = 2
    }

    public class UpdateCheckResult
    {
        #region Properties
        public bool Success { get; set; }
        public bool NewVersionAvailable { get; set; }
        public string? Message { get; set; }
        public Version? CurrentVersion { get; set; }
        public Version? NewVersion { get; set; }
        public GitHubRelease? GitHubRelease { get; set; }
        #endregion

        #region Constructors
        public UpdateCheckResult() { }

        public UpdateCheckResult(string errorMessage)
        {
            Success = false;
            Message = errorMessage;
        }

        public UpdateCheckResult(bool newVersionAvailable)
        {
            Success = true;
            NewVersionAvailable = newVersionAvailable;
        }

        public UpdateCheckResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public UpdateCheckResult(Version? currentVersion, Version? newVersion, GitHubRelease gitHubRelease)
        {
            Success = newVersion is null ? false : true;
            NewVersionAvailable = newVersion is null ? false : true;
            CurrentVersion = currentVersion;
            NewVersion = newVersion;
            GitHubRelease = gitHubRelease;
        }
        #endregion
    }
    #endregion

    #region GitHubRelease, GitHubAsset, GitHubAuthor
    public class GitHubRelease
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("html_url")]
        public Uri HtmlUrl { get; set; }

        [JsonProperty("assets_url")]
        public Uri AssetsUrl { get; set; }

        [JsonProperty("upload_url")]
        public string UploadUrl { get; set; }

        [JsonProperty("tarball_url")]
        public Uri TarballUrl { get; set; }

        [JsonProperty("zipball_url")]
        public Uri ZipballUrl { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("node_id")]
        public string NodeId { get; set; }

        [JsonProperty("tag_name")]
        public string TagName { get; set; }

        [JsonProperty("target_commitish")]
        public string TargetCommitish { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("draft")]
        public bool Draft { get; set; }

        [JsonProperty("prerelease")]
        public bool Prerelease { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("published_at")]
        public DateTimeOffset PublishedAt { get; set; }

        [JsonProperty("author")]
        public GitHubAuthor Author { get; set; }

        [JsonProperty("assets")]
        public List<GitHubAsset> Assets { get; set; }
    }

    public class GitHubAsset
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("browser_download_url")]
        public Uri BrowserDownloadUrl { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("node_id")]
        public string NodeId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("download_count")]
        public long DownloadCount { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("uploader")]
        public GitHubAuthor Uploader { get; set; }
    }

    public class GitHubAuthor
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("node_id")]
        public string NodeId { get; set; }

        [JsonProperty("avatar_url")]
        public Uri AvatarUrl { get; set; }

        [JsonProperty("gravatar_id")]
        public string GravatarId { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("html_url")]
        public Uri HtmlUrl { get; set; }

        [JsonProperty("followers_url")]
        public Uri FollowersUrl { get; set; }

        [JsonProperty("following_url")]
        public string FollowingUrl { get; set; }

        [JsonProperty("gists_url")]
        public string GistsUrl { get; set; }

        [JsonProperty("starred_url")]
        public string StarredUrl { get; set; }

        [JsonProperty("subscriptions_url")]
        public Uri SubscriptionsUrl { get; set; }

        [JsonProperty("organizations_url")]
        public Uri OrganizationsUrl { get; set; }

        [JsonProperty("repos_url")]
        public Uri ReposUrl { get; set; }

        [JsonProperty("events_url")]
        public string EventsUrl { get; set; }

        [JsonProperty("received_events_url")]
        public Uri ReceivedEventsUrl { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("site_admin")]
        public bool SiteAdmin { get; set; }
    }
    #endregion
}
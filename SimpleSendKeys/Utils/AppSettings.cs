using Newtonsoft.Json;
using SimpleSendKeys.Entities;
using SimpleSendKeys.Utils.KeyboardHook;

namespace SimpleSendKeys.Utils
{
    public class Settings
    {
        public static bool RunOnStartup = false;
        public static bool MinimizeToTray = true;
        public static bool ClipboardSync = false;
        public static bool MaskText = false;
        public static bool ClearCbAfterSending = false;

        public static int DelayBeforeSending = 5;
        public static int DelayBetweenChars = 50;

        public static int HotKey = 45;
        public static List<ModifierKeys> ModifierKeys = new();

        public static int AppRuns = 0;
    }

    [Serializable]
    public class AppSettings : Settings
    {
        #region Properties
        [JsonProperty("RunOnStartup")]
        public bool runOnStartup { get { return RunOnStartup; } set { RunOnStartup = value; } }

        [JsonProperty("MinimizeToTray")]
        public bool minimizeToTray { get { return MinimizeToTray; } set { MinimizeToTray = value; } }

        [JsonProperty("ClipboardSync")]
        public bool clipboardSync { get { return ClipboardSync; } set { ClipboardSync = value; } }

        [JsonProperty("MaskText")]
        public bool maskText { get { return MaskText; } set { MaskText = value; } }

        [JsonProperty("ClearCbAfterSending")]
        public bool clearCbAfterSending { get { return ClearCbAfterSending; } set { ClearCbAfterSending = value; } }

        [JsonProperty("DelayBeforeSending")]
        public int delayBeforeSending { get { return DelayBeforeSending; } set { DelayBeforeSending = value; } }

        [JsonProperty("DelayBetweenChars")]
        public int delayBetweenChars { get { return DelayBetweenChars; } set { DelayBetweenChars = value; } }

        [JsonProperty("HotKey")]
        public int hotKey { get { return HotKey; } set { HotKey = value; } }

        [JsonProperty("ModifierKeys")]
        public List<ModifierKeys> modifierKeys { get { return ModifierKeys; } set { ModifierKeys = value; } }

        [JsonProperty("AppRuns")]
        public int appRuns { get { return AppRuns; } set { AppRuns = value; } }
        #endregion

        #region Methods
        public static FunctionResponse Save(string fileName = "App.set")
        {
            try
            {
                string settingsData = JsonConvert.SerializeObject(new AppSettings(), Formatting.Indented);
                File.WriteAllText(fileName.CombineWithStartupPath(), settingsData);
                return new FunctionResponse(error: false, message: "Settings saved successfully.");
            }
            catch (Exception ex)
            {
                return new FunctionResponse(ex);
            }
        }

        public static FunctionResponse Load(string fileName = "App.set")
        {
            string fileFullPath = fileName.CombineWithStartupPath();
            if (!File.Exists(fileFullPath))
            {
                return new FunctionResponse(error: true, message: $"The settings file ({fileName}) is missing.");
            }
            try
            {
                string settingsData = File.ReadAllText(fileFullPath);
                JsonConvert.DeserializeObject<AppSettings>(settingsData,
                    new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace });
                return new FunctionResponse(error: false, message: "Settings loaded successfully.");
            }
            catch (Exception ex)
            {
                return new FunctionResponse(ex);
            }
        }
        #endregion
    }
}

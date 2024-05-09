using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSendKeys.Utils
{
    public class Check4UpdateGH
    {
        #region Properties
        #region Public
        public string Owner { get; set; }
        public string Repo { get; set; }
        public CheckType CheckType { get; set; }
        #endregion

        #region Private
        private Assembly Assembly = Assembly.GetExecutingAssembly();
        private string APIUrl = "https://api.github.com/repos/";
        #endregion
        #endregion

        #region Constructors
        public Check4UpdateGH(string owner, string repo)
        {
            Owner = owner;
            Repo = repo;
            CheckType = CheckType.VersionThenTime;
        }

        public Check4UpdateGH(string owner, string repo, CheckType checkType)
        {
            Owner = owner;
            Repo = repo;
            CheckType = checkType;
        }
        #endregion

        #region Methods
        #region Public
        public UpdateCheckResult Check()
        {
            return new UpdateCheckResult();
        }
        #endregion

        #region Private
        private Version? GetCurrentVersion()
        {
            return Assembly.GetName().Version;
        }

        private DateTime? GetCurrentTimestamp()
        {
            if (!File.Exists(Assembly.Location)) { return null; }
            FileInfo fileInfo = new(Assembly.Location);
            return fileInfo.LastWriteTime;
        }
        #endregion
        #endregion
    }

    #region Others
    public enum CheckType
    {
        VersionThenTime = 0,
        OnlyVersion = 1,
        OnlyTime = 2
    }

    public class UpdateCheckResult
    {
        #region Properties
        public bool Success { get; set; }
        public bool NewVersionAvailable { get; set; }
        public string? Error { get; set; }

        // old v
        // new v
        #endregion

        #region Constructors
        public UpdateCheckResult()
        {
            
        }
        #endregion
    }
    #endregion
}
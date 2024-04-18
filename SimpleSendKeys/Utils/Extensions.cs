using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSendKeys.Utils
{
    public static class Extensions
    {
        #region String
        public static bool INOE(this string str) => string.IsNullOrEmpty(str);

        public static string CombineWithStartupPath(this string fileName)
        {
            if (fileName.INOE()) { return fileName; }
            string file = Path.GetFileName(fileName);
            string fullPath = Path.Combine(Application.StartupPath, file);
            if (File.Exists(fullPath)) { return fullPath; }
            else { return fileName; }
        }
        #endregion

        #region Bool
        public static bool Invert(ref this bool @bool) => @bool = !@bool;
        #endregion
    }
}

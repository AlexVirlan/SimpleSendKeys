using Microsoft.Win32;
using SimpleSendKeys.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSendKeys.Utils
{
    public static class Helpers
    {
        public static FunctionResponse SetStartup(bool active = true, string args = "")
        {
            RegistryKey? rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (rk is null) { return new FunctionResponse(error: true, message: "The registry key is null."); }
            if (active) { rk.SetValue("Simple Send Keys", $@"""{Application.ExecutablePath}""" + (args.INOE() ? "" : $" {args}")); }
            else { rk.DeleteValue("Simple Send Keys", throwOnMissingValue: false); }
            return new FunctionResponse(error: false);
        }

        public static string GetCopyPath(string path)
        {
            if (string.IsNullOrEmpty(path)) { return path; }

            string? filePathOnly = Path.GetDirectoryName(path);
            if (filePathOnly is null) { return path; }
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
            string fileExtension = Path.GetExtension(path);

            int index = 0;
            string result = string.Empty;
            while (File.Exists(path))
            {
                index++;
                result = Path.Combine(filePathOnly, $"{fileNameWithoutExtension} ({index}){fileExtension}");
            }
            return result;
        }
    }
}

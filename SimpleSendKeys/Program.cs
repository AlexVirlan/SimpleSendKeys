using SimpleSendKeys.Forms;
using SimpleSendKeys.Utils;
using System.Runtime.InteropServices;

namespace SimpleSendKeys
{
    internal static class Program
    {
        #region Variables and dll Imports
        private const int HWND_BROADCAST = 0xFFFF;
        private static readonly int WM_SSK_SHOW = RegisterWindowMessage("WM_SSK_SHOW");
        private static readonly int WM_SSK_SEND = RegisterWindowMessage("WM_SSK_SEND");

        [DllImport("user32")]
        private static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImport("user32")]
        private static extern int RegisterWindowMessage(string message);
        #endregion

        [STAThread]
        static void Main()
        {
            List<string> args = Environment.GetCommandLineArgs().Skip(1).ToList();
            args.ForEach(arg => arg = arg.Replace("-", string.Empty));

            Mutex mutex = new Mutex(true, "AlexVirlan.SimpleSendKeys", out bool newInstance);
            if (newInstance)
            {
                ApplicationConfiguration.Initialize();
                frmMain frmMain = new(args);
                frmMain.Show();
                Application.Run();
            }
            else
            {
                int wmMessage = args.Contains("send", StringComparer.OrdinalIgnoreCase) ? WM_SSK_SEND : WM_SSK_SHOW;
                PostMessage((IntPtr)HWND_BROADCAST, wmMessage, new IntPtr(0xCDCD), new IntPtr(0xEFEF));
                Environment.Exit(0);
            }
            mutex.ReleaseMutex();
        }

        static Program()
        {
            try { Environment.CurrentDirectory = Application.StartupPath; }
            catch (Exception) { }

            string missingDlls = "";
            string[] requiredDlls = { "Newtonsoft.Json.dll" };
            foreach (string dll in requiredDlls)
            {
                if (!File.Exists(dll.CombineWithStartupPath())) { missingDlls += $"• {dll + Environment.NewLine}"; }
            }
            if (!missingDlls.INOE())
            {
                MessageBox.Show("The following dlls are missing:" + Environment.NewLine + missingDlls + Environment.NewLine + "Exting...",
                    "Simple Send Keys - missing dlls", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }
    }
}
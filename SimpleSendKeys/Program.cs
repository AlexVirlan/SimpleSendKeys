using SimpleSendKeys.Forms;
using SimpleSendKeys.Utils;

namespace SimpleSendKeys
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Mutex mutex = new Mutex(true, "SimpleSendKeys", out bool newRun);
            if (!newRun) { return; }

            ApplicationConfiguration.Initialize();

            List<string>? args = Environment.GetCommandLineArgs().Skip(1).ToList();
            frmMain frmMain = new(args);
            frmMain.Show();
            Application.Run();
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
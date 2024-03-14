using SimpleSendKeys.Forms;

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

            frmMain frmMain = new();
            frmMain.Show();
            Application.Run();
        }
    }
}
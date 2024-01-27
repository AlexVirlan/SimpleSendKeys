namespace SimpleSendKeys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSendKeys_Click(object sender, EventArgs e)
        {
            Thread.Sleep(2500);
            //SendKeys.SendWait("A");
            //SendKeys.SendWait("AvA");
            //SendKeys.SendWait(" ");
            //SendKeys.SendWait(".");

            foreach (char c in txtText.Text)
            {
                if (c == ' ') { SendKeys.SendWait(" "); }
                else { SendKeys.SendWait($"{{{c}}}"); }
                Thread.Sleep(100);
            }
            SendKeys.Flush();
        }
    }
}

// https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.sendkeys?view=windowsdesktop-7.0
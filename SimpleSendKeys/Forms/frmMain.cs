using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleSendKeys.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void TestVoid(object sender, EventArgs e)
        {
            Thread.Sleep(2500);
            //SendKeys.SendWait("A");
            //SendKeys.SendWait("AvA");
            //SendKeys.SendWait(" ");
            //SendKeys.SendWait(".");

            foreach (char c in "Test")
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
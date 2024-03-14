using SimpleSendKeys.Utils;
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
        #region Variables
        private GlobalKeyboardHook _globalKeyboardHook;
        #endregion

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //_globalKeyboardHook = new GlobalKeyboardHook();
            _globalKeyboardHook = new GlobalKeyboardHook(new Keys[] { Keys.Insert, Keys.Escape });
            _globalKeyboardHook.KeyboardPressed += OnKeyPressed;
        }

        private void OnKeyPressed(object sender, GlobalKeyboardHookEventArgs e)
        {
            if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
            {
                Keys loggedKey = e.KeyboardData.Key;
                int loggedVkCode = e.KeyboardData.VirtualCode;
                // log/use the key
            }
        }

        private void TestVoid(object sender, EventArgs e)
        {
            Thread.Sleep(2500);

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
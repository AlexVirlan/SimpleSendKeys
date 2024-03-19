using SimpleSendKeys.Entities;
using SimpleSendKeys.Utils;
using SimpleSendKeys.Utils.KeyboardHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private bool _sending = false;
        private string _appTitle = "Simple Send Keys";
        private string _NL = Environment.NewLine;
        private KeyboardHookManager _keyboardHookManager;
        private Action _kbStartAction;
        private Action _kbStopAction;
        //private GlobalKeyboardHook _globalKeyboardHook;
        #endregion

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _kbStartAction = () => OnKbStart();
            _kbStopAction = () => OnKbStop();

            _keyboardHookManager = new KeyboardHookManager();
            _keyboardHookManager.Start();

            _keyboardHookManager.RegisterHotkey(0x60, _kbStartAction);
            _keyboardHookManager.RegisterHotkey(0x61, _kbStopAction);
        }

        private void OnKbStart()
        {
            if (_sending || txtPayload.Text.INOE()) { return; }
            Sleep(120);
            SendPayload(txtPayload.Text, (int)numBetweenDelay.Value);
        }

        private void OnKbStop()
        {

        }

        private void OnKeyPressed(object sender)//, GlobalKeyboardHookEventArgs e)
        {

            // (!GlobalKeyboardHook.RegisteredKeys.Contains(e.KeyboardData.Key)) { return; }

            // seems, not needed in the life.
            //if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.SysKeyDown &&
            //    e.KeyboardData.Flags == GlobalKeyboardHook.LlkhfAltdown)
            //{
            //    MessageBox.Show("Alt + Print Screen");
            //    e.Handled = true;
            //}
            //else

            //if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
            //{
            //    MessageBox.Show("Print Screen");
            //    e.Handled = true;
            //}

            //txtPayload.Text += _NL + e.KeyboardData.Key.ToString() +_NL + e.KeyboardData.Flags + _NL;


            return;

            //if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
            //{
            //    Keys loggedKey = e.KeyboardData.Key;
            //    int loggedVkCode = e.KeyboardData.VirtualCode;

            //    switch (e.KeyboardData.Key)
            //    {
            //        case Keys.Insert:
            //            if (_sending || txtPayload.Text.INOE()) { return; }
            //            Sleep(120);
            //            SendPayload(txtPayload.Text, (int)numBetweenDelay.Value);
            //            break;

            //        case Keys.Escape:
            //            // TO DO
            //            break;
            //    }
            //}
        }

        private void SendPayload(string text, int charDelay)
        {
            try
            {
                _sending = true;
                foreach (char c in text)
                {
                    switch (c)
                    {
                        case ' ':
                            SendKeys.SendWait(" ");
                            break;

                        case '\r':
                            continue;

                        case '\n':
                            SendKeys.SendWait("{ENTER}");
                            break;

                        default:
                            SendKeys.SendWait($"{{{c}}}");
                            break;
                    }
                    Thread.Sleep(charDelay);
                }
                SendKeys.Flush();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (Variables.ClearCbAfterSending) { Clipboard.Clear(); }
                _sending = false;
            }
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            showToolStripMenuItem_Click(sender, EventArgs.Empty);
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Environment.Exit(0);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (Variables.MinimizeToTray && WindowState == FormWindowState.Minimized) { Hide(); }
        }

        private void chkMinimizeToTray_CheckedChanged(object sender, EventArgs e)
        {
            Variables.MinimizeToTray = chkMinimizeToTray.Checked;
        }

        private void lblPaste_Click(object sender, EventArgs e)
        {
            txtPayload.Text = Clipboard.GetText();
        }

        private void chkClipboardSync_CheckedChanged(object sender, EventArgs e)
        {
            txtPayload.ReadOnly = chkClipboardSync.Checked;
            tmrCbSync.Enabled = chkClipboardSync.Checked;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtPayload.Text.INOE())
            { ShowMessage("The text payload is empty.", MessageBoxIcon.Warning); }
            Sleep((int)numBeforeDelay.Value * 1000);
            SendPayload(txtPayload.Text, (int)numBetweenDelay.Value);
        }

        private void tmrCbSync_Tick(object sender, EventArgs e)
        {
            txtPayload.Text = Clipboard.GetText();
        }

        private void txtPayload_TextChanged(object sender, EventArgs e)
        {
            SetSendText();
        }

        private void SetSendText()
        {
            int txtLength = txtPayload.Text.Length;
            double duration = Convert.ToDouble((txtLength * 100) + (txtLength * numBetweenDelay.Value));
            string durStr = duration < 1000d ? $"{duration} ms" : $"{Math.Round(duration / 1000d, 2, MidpointRounding.AwayFromZero)} sec.";
            btnSend.Text = $"Send {txtLength} characters{_NL}(in {durStr})";
        }

        private void chkMask_CheckedChanged(object sender, EventArgs e)
        {
            txtPayload.PasswordChar = chkMask.Checked ? '*' : '\0';
        }

        private void numBetweenDelay_ValueChanged(object sender, EventArgs e)
        {
            SetSendText();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            trayIcon.Visible = false;
            Environment.Exit(0);
        }

        private void ShowMessage(string message, MessageBoxIcon icon = MessageBoxIcon.Information, string title = "")
        {
            if (message.INOE()) { return; }
            if (title.INOE()) { title = _appTitle; }
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, icon);
        }

        private void Sleep(int interval)
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < interval)
            {
                Application.DoEvents();
            }
            stopwatch.Stop();
        }

        private void chkClearCbAfterSending_CheckedChanged(object sender, EventArgs e)
        {
            Variables.ClearCbAfterSending = chkClearCbAfterSending.Checked;
        }
    }
}

// https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.sendkeys?view=windowsdesktop-7.0
﻿using SimpleSendKeys.Entities;
using SimpleSendKeys.Utils;
using SimpleSendKeys.Utils.KeyboardHook;
using System.Diagnostics;
using static SimpleSendKeys.Entities.Enums;

namespace SimpleSendKeys.Forms
{
    public partial class frmMain : Form
    {
        #region Variables
        private bool _sending = false;
        private bool _forceStop = false;
        private string _appTitle = "Simple Send Keys";
        private string _NL = Environment.NewLine;
        private Action _kbStartAction;
        private Action _kbStopAction;
        private KeyboardHookManager _keyboardHookManager;
        private Guid _startHkGuid;
        private List<string>? _args = null;
        private ViewType _viewType = ViewType.Main;
        #endregion

        public frmMain(List<string>? args = null)
        {
            InitializeComponent();
            _args = args;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (File.Exists(Variables.SettingsFileName.CombineWithStartupPath()))
            {
                FunctionResponse frLoad = AppSettings.Load();
                if (frLoad.Error)
                {
                    FunctionResponse frSaveDefault = AppSettings.Save();
                    if (frSaveDefault.Error)
                    {
                        ShowMessage($"Error saving the default settings:{_NL + frSaveDefault.Message + _NL + _NL}Exiting...", MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }
                }
            }
            else
            {
                FunctionResponse fr = AppSettings.Save();
                if (fr.Error)
                {
                    ShowMessage($"Error saving settings:{_NL + fr.Message + _NL + _NL}Exiting...", MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }

            Settings.AppRuns++;
            lblRuns.Text = $"Runs: {Settings.AppRuns}";
            ApplySettingsToUI();

            _kbStartAction = () => OnKbStart();
            _kbStopAction = () => OnKbStop();

            _keyboardHookManager = new KeyboardHookManager();
            _keyboardHookManager.Start();

            _startHkGuid = _keyboardHookManager.RegisterHotkey(Settings.ModifierKeys.ToArray(), Settings.HotKey, _kbStartAction);
            _keyboardHookManager.RegisterHotkey((int)Keys.Escape, _kbStopAction);

            ucModifierKeys.ModifiersUpdated += OnModifierKeysUpdated;
            ucKeySelector.KeyUpdated += OnMainKeyUpdated;
        }

        private void ApplySettingsToUI()
        {
            chkRunOnStartup.Checked = Settings.RunOnStartup;
            chkMinimizeToTray.Checked = Settings.MinimizeToTray;
            chkClipboardSync.Checked = Settings.ClipboardSync;
            chkMask.Checked = Settings.MaskText;
            chkClearCbAfterSending.Checked = Settings.ClearCbAfterSending;
            numBeforeDelay.Value = Settings.DelayBeforeSending;
            numBetweenDelay.Value = Settings.DelayBetweenChars;
            bool mainKeySet = ucKeySelector.SetKey(Settings.HotKey, invokeEventHandler: false);
            bool modKeysSet = ucModifierKeys.SetKeys(Settings.ModifierKeys, invokeEventHandler: false);
            if (!mainKeySet || !modKeysSet)
            {
                ShowMessage("An issue occurred when trying to set the hotkey." + _NL +
                    "Please try to set it manually or reset it.", MessageBoxIcon.Warning);
            }
        }

        private void OnKbStart()
        {
            if (_sending || txtPayload.Text.INOE()) { return; }
            Sleep(640);
            SendPayload(txtPayload.Text, (int)numBetweenDelay.Value);
        }

        private void OnKbStop()
        {
            _forceStop = true;
        }

        private void OnModifierKeysUpdated(object? sender, List<ModifierKeys> modifiers)
        {
            UpdateHotKeys(modifiers.ToArray(), ucKeySelector.VirtualKeyCode);
        }

        private void OnMainKeyUpdated(object? sender, int keyCode)
        {
            UpdateHotKeys(ucModifierKeys.Modifiers.ToArray(), keyCode);
        }

        private void UpdateHotKeys(ModifierKeys[] modifierKeys, int mainKey)
        {
            try
            {
                _keyboardHookManager.UnregisterHotkey(_startHkGuid);
                _startHkGuid = _keyboardHookManager.RegisterHotkey(modifierKeys, mainKey, _kbStartAction);
                Settings.HotKey = mainKey;
                Settings.ModifierKeys = modifierKeys.ToList();
            }
            catch (Exception ex)
            {
                ShowMessage($"Error while registering the hotkeys:{_NL + ex.Message + _NL + _NL}" +
                    "You can still use the 'Send' button in the meantime." + _NL +
                    "Please contact the developer via the GitHub page for help.", MessageBoxIcon.Error);
            }
        }

        private void SendPayload(string text, int charDelay)
        {
            try
            {
                SetControlEnabled(pnlMain, false);
                _sending = true;
                _forceStop = false;
                int index = 0;
                foreach (char c in text)
                {
                    if (_forceStop) { break; }
                    index++;
                    UpdateStatus($"Sending char {index}/{text.Length}: {c}");
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
                ShowMessage("Error:" + _NL + ex.Message, MessageBoxIcon.Error);
            }
            finally
            {
                _sending = false;
                SetControlEnabled(pnlMain, true);
                UpdateStatus();
                if (Settings.ClearCbAfterSending) { Clipboard.Clear(); }
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
            FunctionResponse fr = AppSettings.Save();
            if (fr.Error)
            {
                ShowMessage($"Error saving settings:{_NL + fr.Message}", MessageBoxIcon.Error);
            }

            trayIcon.Visible = false;
            Environment.Exit(0);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (Settings.MinimizeToTray && WindowState == FormWindowState.Minimized) { Hide(); }
        }

        private void chkMinimizeToTray_CheckedChanged(object sender, EventArgs e)
        {
            Settings.MinimizeToTray = chkMinimizeToTray.Checked;
        }

        private void lblPaste_Click(object sender, EventArgs e)
        {
            txtPayload.Text = Clipboard.GetText();
        }

        private void chkClipboardSync_CheckedChanged(object sender, EventArgs e)
        {
            txtPayload.ReadOnly = chkClipboardSync.Checked;
            tmrCbSync.Enabled = chkClipboardSync.Checked;
            Settings.ClipboardSync = chkClipboardSync.Checked;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtPayload.Text.INOE())
            {
                ShowMessage("The text to send is empty.", MessageBoxIcon.Warning);
                return;
            }

            if (_sending) { return; }

            SetControlEnabled(pnlMain, false);
            int delayValue = (int)numBeforeDelay.Value;
            for (int i = 0; i < delayValue; i++)
            {
                UpdateStatus($"Sending in {delayValue - i} seconds...");
                Sleep(1000);
            }
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
            Settings.MaskText = chkMask.Checked;
        }

        private void numBetweenDelay_ValueChanged(object sender, EventArgs e)
        {
            SetSendText();
            Settings.DelayBetweenChars = (int)numBetweenDelay.Value;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            FunctionResponse fr = AppSettings.Save();
            if (fr.Error)
            {
                ShowMessage($"Error saving settings:{_NL + fr.Message}", MessageBoxIcon.Error);
            }

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
            Settings.ClearCbAfterSending = chkClearCbAfterSending.Checked;
        }

        private void UpdateStatus(string? status = null)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                lblStatus.Text = status.INOE() ? "Idle" : status.ToString();
            }));
        }

        private void SetControlEnabled(Control control, bool enabled)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                control.Enabled = enabled;
            }));
        }

        private void numBetweenDelay_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void lblResetHK_Click(object sender, EventArgs e)
        {
            ucModifierKeys.Reset(invokeEventHandler: false);
            ucKeySelector.Reset(invokeEventHandler: false);
            UpdateHotKeys(ucModifierKeys.Modifiers.ToArray(), ucKeySelector.VirtualKeyCode);
        }

        private void lblStopInfo_Click(object sender, EventArgs e)
        {
            ShowMessage("To stop an ongoing sending, just press the 'Escape' key.");
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            if (_args is not null)
            {
                foreach (string arg in _args)
                {
                    switch (arg)
                    {
                        case string mnm when mnm.Contains("minimized", StringComparison.OrdinalIgnoreCase):
                            Hide();
                            break;
                    }
                }
            }

            if (Settings.AppRuns < 2)
            {
                ShowMessage("Welcome, and thank you for using this app!" + _NL + _NL +
                    "For more info, you can visit the GitHub page  - you can find a link to it in the settings panel. " +
                    "While you're there, check out the 'Recommended settings' button for info about the best way to use this app." + _NL + _NL +
                    "Don't forget to give it a star on GitHub if you find it useful!" + _NL + "Thanks!");
            }
        }

        private void SetView(ViewType viewType)
        {
            _viewType = viewType;
            pnlMain.Visible = pnlSettings.Visible = false;
            switch (viewType)
            {
                case ViewType.Main:
                    pnlMain.Visible = true;
                    break;

                case ViewType.Settings:
                    pnlSettings.Visible = true;
                    break;
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (_viewType == ViewType.Main)
            {
                SetView(ViewType.Settings);
                btnSettings.Text = "< Back";
            }
            else
            {
                SetView(ViewType.Main);
                btnSettings.Text = "Settings";
            }
        }

        private void lblGitHubInfo_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://github.com/AlexVirlan/SimpleSendKeys");
        }

        private void chkRunOnStartup_CheckedChanged(object sender, EventArgs e)
        {
            Settings.RunOnStartup = chkRunOnStartup.Checked;
            Helpers.SetStartup(active: Settings.RunOnStartup, args: "minimized");
        }

        private void numBeforeDelay_ValueChanged(object sender, EventArgs e)
        {
            Settings.DelayBeforeSending = (int)numBeforeDelay.Value;
            sendin5SecToolStripMenuItem.Text = $"Send (in {Settings.DelayBeforeSending} sec.)";
        }

        private void btnResetSet_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(this, "Resetting settings, are you sure?", _appTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Settings.RunOnStartup = false;
                Settings.MinimizeToTray = true;
                Settings.ClipboardSync = false;
                Settings.MaskText = false;
                Settings.ClearCbAfterSending = false;
                Settings.DelayBeforeSending = 5;
                Settings.DelayBetweenChars = 50;
                Settings.HotKey = 45;
                Settings.ModifierKeys = new();

                ApplySettingsToUI();
                UpdateHotKeys(ucModifierKeys.Modifiers.ToArray(), ucKeySelector.VirtualKeyCode);
            }
        }

        private void btnRecSet_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(this, "These are the recommended settings:" + _NL +
                "Run on startup = on" + _NL + "Minimize to tray = on" + _NL + "Clipboard sync = on" + _NL + _NL +
                "No other setting will be changed. This way, the app will run in the background at startup (accessible via the tray icon) " +
                "and everything you have in the clipboard will be ready to be inserted just by using the hotkey." + _NL + _NL +
                "Do you want to apply this?", _appTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Settings.RunOnStartup = true;
                Settings.MinimizeToTray = true;
                Settings.ClipboardSync = true;
                ApplySettingsToUI();
                UpdateHotKeys(ucModifierKeys.Modifiers.ToArray(), ucKeySelector.VirtualKeyCode);
            }
        }

        private void sendin5SecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSend_Click(sender, e);
        }
    }
}
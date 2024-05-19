using SimpleSendKeys.Entities;
using SimpleSendKeys.Utils;
using SimpleSendKeys.Utils.KeyboardHook;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static SimpleSendKeys.Entities.Enums;

namespace SimpleSendKeys.Forms
{
    public partial class frmMain : Form
    {
        #region Variables
        private bool _sending = false;
        private bool _forceStop = false;
        private bool _updatingUI = false;
        private string _appTitle = "Simple Send Keys";
        private string _NL = Environment.NewLine;
        private Action _kbStartAction;
        private Action _kbStopAction;
        private List<string>? _args = null;
        private KeyboardHookManager _keyboardHookManager;
        private Guid _startHkGuid;
        private ViewType _viewType = ViewType.Main;
        private Check4UpdateGH _check4UpdateGH = new Check4UpdateGH();
        #endregion

        #region Dll imports
        private static readonly int WM_SSK_SHOW = RegisterWindowMessage("WM_SSK_SHOW");
        private static readonly int WM_SSK_SEND = RegisterWindowMessage("WM_SSK_SEND");

        [DllImport("user32")]
        private static extern int RegisterWindowMessage(string message);
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
            ApplySettingsToUI();

            _kbStartAction = () => OnKbStart();
            _kbStopAction = () => OnKbStop();

            _keyboardHookManager = new KeyboardHookManager();
            _keyboardHookManager.Start();

            _startHkGuid = _keyboardHookManager.RegisterHotkey(Settings.ModifierKeys.ToArray(), Settings.HotKey, _kbStartAction, Settings.BlockHotkeyPropagation);
            _keyboardHookManager.RegisterHotkey((int)Keys.Escape, _kbStopAction, blocking: false);

            ucModifierKeys.ModifiersUpdated += OnModifierKeysUpdated;
            ucKeySelector.KeyUpdated += OnMainKeyUpdated;

            this.Text += $" ({_check4UpdateGH.GetCurrentVersion()?.ToString(3)})";
            lblStatus.MouseWheel += new MouseEventHandler(StatusMouseWheelEvent);
        }

        private void ApplySettingsToUI()
        {
            _updatingUI = true;
            chkRunOnStartup.Checked = Settings.RunOnStartup;
            chkMinimizeToTray.Checked = Settings.MinimizeToTray;
            chkBlockHotkeyPropagation.Checked = Settings.BlockHotkeyPropagation;
            chkClipboardSync.Checked = Settings.ClipboardSync;
            chkMask.Checked = Settings.MaskText;
            chkClearCbAfterSending.Checked = Settings.ClearCbAfterSending;
            chkKeepOnTop.Checked = Settings.KeepOnTop;
            numBeforeDelay.Value = Settings.DelayBeforeSending;
            numBetweenDelay.Value = Settings.DelayBetweenChars;
            bool mainKeySet = ucKeySelector.SetKey(Settings.HotKey, invokeEventHandler: false);
            bool modKeysSet = ucModifierKeys.SetKeys(Settings.ModifierKeys, invokeEventHandler: false);
            if (!mainKeySet || !modKeysSet)
            {
                ShowMessage("An issue occurred when trying to set the hotkey." + _NL +
                    "Please try to set it manually or reset it.", MessageBoxIcon.Warning);
            }
            UpdateTrayHotkeyInfo();
            _updatingUI = false;
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
                _startHkGuid = _keyboardHookManager.RegisterHotkey(modifierKeys, mainKey, _kbStartAction, Settings.BlockHotkeyPropagation);
                Settings.HotKey = mainKey;
                Settings.ModifierKeys = modifierKeys.ToList();

                UpdateTrayHotkeyInfo();
            }
            catch (Exception ex)
            {
                ShowMessage($"Error while registering the hotkeys:{_NL + ex.Message + _NL + _NL}" +
                    "You can still use the 'Send' button in the meantime." + _NL +
                    "Please contact the developer via the GitHub page for help.", MessageBoxIcon.Error);
            }
        }

        private void UpdateTrayHotkeyInfo()
        {
            string modK = ucModifierKeys.ModifiersText.INOE() ? "" : $"{_NL + ucModifierKeys.ModifiersText} + ";
            hotkeyInsertToolStripMenuItem.Text = $"Hotkey: {modK}{(Keys)ucKeySelector.VirtualKeyCode}";
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
                    Settings.CharsSent++;
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

        protected override void WndProc(ref Message m)
        {
            // if ((m.WParam.ToInt32() == 0xCDCD) && (m.LParam.ToInt32() == 0xEFEF))
            if (m.Msg == WM_SSK_SHOW) { showToolStripMenuItem_Click(this, EventArgs.Empty); }
            else if (m.Msg == WM_SSK_SEND) { OnKbStart(); }
            base.WndProc(ref m);
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            showToolStripMenuItem_Click(sender, EventArgs.Empty);
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMain_FormClosing(sender, new FormClosingEventArgs(CloseReason.UserClosing, cancel: false));
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (Settings.MinimizeToTray && WindowState == FormWindowState.Minimized) { Hide(); }
        }

        private void chkMinimizeToTray_CheckedChanged(object sender, EventArgs e)
        {
            Settings.MinimizeToTray = chkMinimizeToTray.Checked;
        }

        private void lblPaste_MouseClick(object sender, MouseEventArgs e)
        {
            if (!Settings.ClipboardSync)
            {
                string cpText = Clipboard.GetText();
                if (e.Button == MouseButtons.Left) { txtPayload.Text = cpText; }
                else if (e.Button == MouseButtons.Right) { txtPayload.Text += cpText; }
            }
        }

        private void chkClipboardSync_CheckedChanged(object sender, EventArgs e)
        {
            txtPayload.ReadOnly = chkClipboardSync.Checked;
            tmrCbSync.Enabled = chkClipboardSync.Checked;
            lblPaste.Enabled = lblClear.Enabled = !chkClipboardSync.Checked;
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
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialogResult = MessageBox.Show(this, "Are you sure that you want to exit the app?", _appTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    FunctionResponse fr = AppSettings.Save();
                    if (fr.Error)
                    {
                        ShowMessage($"Error saving settings:{_NL + fr.Message}", MessageBoxIcon.Error);
                    }

                    trayIcon.Visible = false;
                    Environment.Exit(0);
                }
                e.Cancel = true;
            }
            else
            {
                AppSettings.Save();
            }
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

            this.Opacity = 1;

            if (Settings.AppRuns < 2)
            {
                ShowMessage("Welcome, and thank you for using this app!" + _NL + _NL +
                    "Please click the 'More HK info' label (upper right corner) to learn more about hotkeys." + _NL + _NL +
                    "For more info, you can visit the GitHub page  - you can find a link to it in the settings panel. " +
                    "While you're there, check out the 'Recommended settings' button for info about the best way to use this app." + _NL + _NL +
                    "Don't forget to give it a star on GitHub if you find it useful!" + _NL + "Thanks!");
                trayIcon.ShowBalloonTip(12000, _appTitle, "You can also find me in the system tray! :)", ToolTipIcon.Info);
            }

            new Thread(Check4Update).Start();
        }

        private void Check4Update()
        {
            UpdateCheckResult updateCheckResult = _check4UpdateGH.Check();
            if (updateCheckResult.Success && updateCheckResult.NewVersionAvailable)
            {
                while (!this.Visible) { Thread.Sleep(640); }
                this.Invoke(new MethodInvoker(delegate ()
                {
                    lblUpdate.Visible = true;
                    if (MessageBox.Show(this,
                        $"There is a new version available: {updateCheckResult.NewVersion?.ToString(3)}" + _NL +
                        "Do you want to download the new version?", _appTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (updateCheckResult.GitHubRelease is not null)
                        {
                            Task.Run(() => DownloadAndRunUpdate());
                        }
                        else
                        {
                            ShowMessage("Could not get the GitHub release data.");
                        }
                    }
                }));
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
                    lblRuns.Text = $"Runs: {Settings.AppRuns + Environment.NewLine}Chars: {Settings.CharsSent}";
                    pnlSettings.Visible = true;
                    break;
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (_viewType == ViewType.Main && Form.ModifierKeys.HasFlag(Keys.Control))
            {
                btnRecSet_Click(sender, e);
                return;
            }

            if (_viewType == ViewType.Main)
            {
                SetView(ViewType.Settings);
                btnSettings.Text = "< Back";
                toolTips.SetToolTip(btnSettings, string.Empty);
            }
            else
            {
                SetView(ViewType.Main);
                btnSettings.Text = "Settings";
                toolTips.SetToolTip(btnSettings, "Click to go to the settings panel.\r\nCtrl + click to apply the recommended settings.");
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
            sendinXSecToolStripMenuItem.Text = $"Send (in {Settings.DelayBeforeSending} sec.)";
        }

        private void btnResetSet_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(this, "Resetting settings, are you sure?", _appTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Settings.RunOnStartup = false;
                Settings.MinimizeToTray = true;
                Settings.BlockHotkeyPropagation = false;
                Settings.ClipboardSync = false;
                Settings.MaskText = false;
                Settings.ClearCbAfterSending = false;
                Settings.KeepOnTop = false;
                Settings.DelayBeforeSending = 5;
                Settings.DelayBetweenChars = 25;
                Settings.HotKey = 45;
                Settings.ModifierKeys = new();

                ApplySettingsToUI();
                UpdateHotKeys(ucModifierKeys.Modifiers.ToArray(), ucKeySelector.VirtualKeyCode);
            }
        }

        private void btnRecSet_Click(object sender, EventArgs e)
        {
            if (Settings.RunOnStartup && Settings.MinimizeToTray && Settings.ClipboardSync)
            {
                ShowMessage("It looks like you already have the recommended settings applied. Nice! :)");
                return;
            }

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

        private void sendinXSecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSend_Click(sender, e);
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {
            if (lblStatus.Text.Equals("Idle", StringComparison.OrdinalIgnoreCase))
            { lblStatus.Text = $"Runs: {Settings.AppRuns}, Chars: {Settings.CharsSent}"; }
            else { lblStatus.Text = "Idle"; }
        }

        private void StatusMouseWheelEvent(object? sender, MouseEventArgs e)
        {
            double opacity = this.Opacity;
            if (e.Delta > 0)
            {
                opacity += 0.1d;
                if (opacity > 1d) { opacity = 1d; }
                this.Opacity = opacity;
            }
            else
            {
                opacity -= 0.1d;
                if (opacity < 0.1) { opacity = 0.1; }
                this.Opacity = opacity;
            }
        }

        private void lblDBCinfo_Click(object sender, EventArgs e)
        {
            ShowMessage("You might have noticed that even if you set the 'delay between chars' to 1ms, if you enter only one char, the sending time will be 101ms." + _NL + _NL +
                "That's because each char takes on average 100ms to be sent on its own - so that value is 'baked in' when the sending time is calculated." + _NL + _NL +
                "The value you set here, will be added to that 100ms average.");
        }

        private void lblHKInfo_Click(object sender, EventArgs e)
        {
            ShowMessage("You can set whatever hotkey you want, but please be aware that some of them might be used or affected by other apps or OS functionalities. " +
                "So keep it simple and unique." + _NL + _NL +
                "To stop an ongoing sending, just press the 'Escape' key." + _NL + _NL +
                "Important: when you use your hotkey, release it quickly (don't keep it pressed) because some key combinations " +
                "might interfere with the app you're trying to send the data to.");
        }

        private void chkBlockHotkeyPropagation_CheckedChanged(object sender, EventArgs e)
        {
            if (_updatingUI) { return; }
            Settings.BlockHotkeyPropagation = chkBlockHotkeyPropagation.Checked;
            UpdateHotKeys(ucModifierKeys.Modifiers.ToArray(), ucKeySelector.VirtualKeyCode);
        }

        private void lblBlockHKPInfo_Click(object sender, EventArgs e)
        {
            ShowMessage("This app uses a low-level keyboard hook for hotkeys, meaning that the hotkeys you set are not blocked and they can be `simultaneously` " +
                "used by other apps or the OS." + _NL + _NL +
                "For example, if you set the hotkey as Ctrl + V and press that key combination, the OS will process that and paste whatever you have in the clipboard, " +
                "and at the same time SSK will start to send the characters." + _NL + _NL +
                "This option allows you to control this hotkey propagation behavior. So (using the above example) if you enable this option and then press Ctrl + V, " +
                "the OS will NOT paste anything and only SSK will start to send the characters.");
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            if (!Settings.ClipboardSync) { txtPayload.Clear(); }
        }

        private void lblCheck4Update_Click(object sender, EventArgs e)
        {
            UpdateCheckResult updateCheckResult = _check4UpdateGH.Check();
            if (updateCheckResult.Success)
            {
                if (updateCheckResult.NewVersionAvailable)
                {
                    lblUpdate.Visible = true;
                    if (MessageBox.Show(this,
                        $"There is a new version available: {updateCheckResult.NewVersion?.ToString(3)}" + _NL +
                        "Do you want to download the new version?", _appTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (updateCheckResult.GitHubRelease is not null)
                        {
                            Task.Run(() => DownloadAndRunUpdate());
                        }
                        else
                        {
                            ShowMessage("Could not get the GitHub release data.");
                        }
                    }
                }
                else
                {
                    ShowMessage($"There is no new version available.{_NL}You're using the latest one.");
                }
            }
            else
            {
                string details = string.IsNullOrEmpty(updateCheckResult.Message) ? "" : (_NL + updateCheckResult.Message);
                ShowMessage("The update check failed." + details);
            }
        }

        private async Task DownloadAndRunUpdate()
        {
            (bool downloadSuccess, string? downloadError) = await _check4UpdateGH.DownloadAsync("setup");
            if (downloadSuccess) { Application.Exit(); }
            else { MessageBox.Show("The download failed." + _NL + downloadError, _appTitle, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void lblUpdate_Click(object sender, EventArgs e)
        {
            lblCheck4Update_Click(sender, e);
        }

        private void chkKeepOnTop_CheckedChanged(object sender, EventArgs e)
        {
            Settings.KeepOnTop = chkKeepOnTop.Checked;
            this.TopMost = Settings.KeepOnTop;
        }
    }
}
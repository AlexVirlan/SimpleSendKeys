namespace SimpleSendKeys.Forms
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            txtPayload = new TextBox();
            chkClipboardSync = new CheckBox();
            lblPaste = new Label();
            label1 = new Label();
            btnSend = new Button();
            label2 = new Label();
            numBeforeDelay = new NumericUpDown();
            label3 = new Label();
            toolTips = new ToolTip(components);
            label6 = new Label();
            lblRuns = new Label();
            lblDBCinfo = new Label();
            lblBlockHKPInfo = new Label();
            lblStatus = new Label();
            btnSettings = new Button();
            ucModifierKeys = new Controls.ucModifierKeys();
            trayIcon = new NotifyIcon(components);
            trayContextMenu = new ContextMenuStrip(components);
            showToolStripMenuItem = new ToolStripMenuItem();
            sendinXSecToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            hotkeyInsertToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            chkMinimizeToTray = new CheckBox();
            pnlMain = new Panel();
            numBetweenDelay = new NumericUpDown();
            chkKeepOnTop = new CheckBox();
            chkClearCbAfterSending = new CheckBox();
            label5 = new Label();
            chkMask = new CheckBox();
            label4 = new Label();
            lblClear = new Label();
            tmrCbSync = new System.Windows.Forms.Timer(components);
            pnkHotKey = new Panel();
            ucKeySelector = new Controls.ucKeySelector();
            label7 = new Label();
            lblHKInfo = new Label();
            lblResetHK = new Label();
            pnlSettings = new Panel();
            chkBlockHotkeyPropagation = new CheckBox();
            chkRunOnStartup = new CheckBox();
            btnRecSet = new Button();
            btnResetSet = new Button();
            lblCheck4Update = new Label();
            lblGitHubInfo = new Label();
            label10 = new Label();
            label8 = new Label();
            lblUpdate = new Label();
            ((System.ComponentModel.ISupportInitialize)numBeforeDelay).BeginInit();
            trayContextMenu.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numBetweenDelay).BeginInit();
            pnkHotKey.SuspendLayout();
            pnlSettings.SuspendLayout();
            SuspendLayout();
            // 
            // txtPayload
            // 
            txtPayload.BackColor = Color.FromArgb(17, 17, 17);
            txtPayload.BorderStyle = BorderStyle.FixedSingle;
            txtPayload.ForeColor = Color.White;
            txtPayload.Location = new Point(10, 26);
            txtPayload.Multiline = true;
            txtPayload.Name = "txtPayload";
            txtPayload.ScrollBars = ScrollBars.Vertical;
            txtPayload.Size = new Size(411, 143);
            txtPayload.TabIndex = 0;
            txtPayload.TextChanged += txtPayload_TextChanged;
            // 
            // chkClipboardSync
            // 
            chkClipboardSync.AutoSize = true;
            chkClipboardSync.ForeColor = Color.White;
            chkClipboardSync.Location = new Point(236, 7);
            chkClipboardSync.Name = "chkClipboardSync";
            chkClipboardSync.Size = new Size(105, 19);
            chkClipboardSync.TabIndex = 1;
            chkClipboardSync.Text = "Clipboard sync";
            toolTips.SetToolTip(chkClipboardSync, "Syncs the textbox below with your clipboard.");
            chkClipboardSync.UseVisualStyleBackColor = true;
            chkClipboardSync.CheckedChanged += chkClipboardSync_CheckedChanged;
            // 
            // lblPaste
            // 
            lblPaste.AutoSize = true;
            lblPaste.Cursor = Cursors.Hand;
            lblPaste.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            lblPaste.Location = new Point(120, 8);
            lblPaste.Name = "lblPaste";
            lblPaste.Size = new Size(35, 15);
            lblPaste.TabIndex = 2;
            lblPaste.Text = "Paste";
            toolTips.SetToolTip(lblPaste, "Left click to paste.\r\nRight click to append.");
            lblPaste.MouseClick += lblPaste_MouseClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 8);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 3;
            label1.Text = "Text to send:";
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.FromArgb(33, 33, 33);
            btnSend.Cursor = Cursors.Hand;
            btnSend.FlatAppearance.BorderColor = Color.Gray;
            btnSend.FlatAppearance.MouseDownBackColor = Color.FromArgb(120, 120, 120);
            btnSend.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Location = new Point(253, 176);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(168, 51);
            btnSend.TabIndex = 4;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 178);
            label2.Name = "label2";
            label2.Size = new Size(121, 15);
            label2.TabIndex = 3;
            label2.Text = "Delay before sending:";
            toolTips.SetToolTip(label2, "Used only when using the \"Send\" button.\r\nWhen using the keyboard shortcut, the sending will start almost instantly.\r\n");
            // 
            // numBeforeDelay
            // 
            numBeforeDelay.BackColor = Color.FromArgb(17, 17, 17);
            numBeforeDelay.BorderStyle = BorderStyle.FixedSingle;
            numBeforeDelay.ForeColor = Color.White;
            numBeforeDelay.Location = new Point(130, 175);
            numBeforeDelay.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numBeforeDelay.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numBeforeDelay.Name = "numBeforeDelay";
            numBeforeDelay.Size = new Size(67, 23);
            numBeforeDelay.TabIndex = 5;
            numBeforeDelay.TextAlign = HorizontalAlignment.Center;
            toolTips.SetToolTip(numBeforeDelay, "Used only when using the \"Send\" button.\r\nWhen using the keyboard shortcut, the sending will start almost instantly.");
            numBeforeDelay.Value = new decimal(new int[] { 5, 0, 0, 0 });
            numBeforeDelay.ValueChanged += numBeforeDelay_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(199, 178);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 3;
            label3.Text = "sec.";
            // 
            // toolTips
            // 
            toolTips.AutomaticDelay = 26;
            toolTips.AutoPopDelay = 12000;
            toolTips.InitialDelay = 260;
            toolTips.ReshowDelay = 100;
            toolTips.ToolTipIcon = ToolTipIcon.Info;
            toolTips.ToolTipTitle = "Info";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 9);
            label6.Name = "label6";
            label6.Size = new Size(48, 15);
            label6.TabIndex = 9;
            label6.Text = "Hotkey:";
            toolTips.SetToolTip(label6, "The global hotkey for sending the text.");
            // 
            // lblRuns
            // 
            lblRuns.Location = new Point(308, 219);
            lblRuns.Name = "lblRuns";
            lblRuns.Size = new Size(117, 32);
            lblRuns.TabIndex = 9;
            lblRuns.Text = "Runs: 0\r\nChars: 0";
            lblRuns.TextAlign = ContentAlignment.MiddleCenter;
            toolTips.SetToolTip(lblRuns, "This shows how many times you ran this app,\r\nand how many characters the app has sent in total.");
            // 
            // lblDBCinfo
            // 
            lblDBCinfo.AutoSize = true;
            lblDBCinfo.Cursor = Cursors.Hand;
            lblDBCinfo.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            lblDBCinfo.ForeColor = Color.Silver;
            lblDBCinfo.Location = new Point(220, 207);
            lblDBCinfo.Name = "lblDBCinfo";
            lblDBCinfo.Size = new Size(20, 15);
            lblDBCinfo.TabIndex = 3;
            lblDBCinfo.Text = "(?)";
            toolTips.SetToolTip(lblDBCinfo, "Click for more info about the\r\ndelay between characters.");
            lblDBCinfo.Click += lblDBCinfo_Click;
            // 
            // lblBlockHKPInfo
            // 
            lblBlockHKPInfo.AutoSize = true;
            lblBlockHKPInfo.Cursor = Cursors.Hand;
            lblBlockHKPInfo.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            lblBlockHKPInfo.Location = new Point(168, 154);
            lblBlockHKPInfo.Name = "lblBlockHKPInfo";
            lblBlockHKPInfo.Size = new Size(20, 15);
            lblBlockHKPInfo.TabIndex = 10;
            lblBlockHKPInfo.Text = "(?)";
            toolTips.SetToolTip(lblBlockHKPInfo, "Click for more info about the\r\nhotkey propagation.");
            lblBlockHKPInfo.Click += lblBlockHKPInfo_Click;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(12, 329);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(432, 16);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Idle";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            toolTips.SetToolTip(lblStatus, "Click to toggle the statistics.\r\nScroll to adjust the transparency.");
            lblStatus.Click += lblStatus_Click;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.FromArgb(33, 33, 33);
            btnSettings.Cursor = Cursors.Hand;
            btnSettings.FlatAppearance.BorderColor = Color.Gray;
            btnSettings.FlatAppearance.MouseDownBackColor = Color.FromArgb(120, 120, 120);
            btnSettings.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Location = new Point(23, 324);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(64, 26);
            btnSettings.TabIndex = 4;
            btnSettings.Text = "Settings";
            toolTips.SetToolTip(btnSettings, "Click to go to the settings panel.\r\nCtrl + click to apply the recommended settings.");
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += btnSettings_Click;
            // 
            // ucModifierKeys
            // 
            ucModifierKeys.BackColor = Color.FromArgb(26, 26, 26);
            ucModifierKeys.Location = new Point(65, 20);
            ucModifierKeys.Name = "ucModifierKeys";
            ucModifierKeys.Size = new Size(120, 21);
            ucModifierKeys.SortModifiers = true;
            ucModifierKeys.TabIndex = 8;
            // 
            // trayIcon
            // 
            trayIcon.BalloonTipIcon = ToolTipIcon.Info;
            trayIcon.BalloonTipText = "I'm here! :)";
            trayIcon.BalloonTipTitle = "Simple Send Keys";
            trayIcon.ContextMenuStrip = trayContextMenu;
            trayIcon.Icon = (Icon)resources.GetObject("trayIcon.Icon");
            trayIcon.Text = "Simple Send Keys";
            trayIcon.Visible = true;
            trayIcon.MouseDoubleClick += trayIcon_MouseDoubleClick;
            // 
            // trayContextMenu
            // 
            trayContextMenu.Items.AddRange(new ToolStripItem[] { showToolStripMenuItem, sendinXSecToolStripMenuItem, toolStripSeparator1, hotkeyInsertToolStripMenuItem, toolStripSeparator2, exitToolStripMenuItem });
            trayContextMenu.Name = "trayContextMenu";
            trayContextMenu.Size = new Size(154, 104);
            // 
            // showToolStripMenuItem
            // 
            showToolStripMenuItem.Image = (Image)resources.GetObject("showToolStripMenuItem.Image");
            showToolStripMenuItem.Name = "showToolStripMenuItem";
            showToolStripMenuItem.Size = new Size(153, 22);
            showToolStripMenuItem.Text = "Show";
            showToolStripMenuItem.Click += showToolStripMenuItem_Click;
            // 
            // sendinXSecToolStripMenuItem
            // 
            sendinXSecToolStripMenuItem.Image = (Image)resources.GetObject("sendinXSecToolStripMenuItem.Image");
            sendinXSecToolStripMenuItem.Name = "sendinXSecToolStripMenuItem";
            sendinXSecToolStripMenuItem.Size = new Size(153, 22);
            sendinXSecToolStripMenuItem.Text = "Send (in 5 sec.)";
            sendinXSecToolStripMenuItem.Click += sendinXSecToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(150, 6);
            // 
            // hotkeyInsertToolStripMenuItem
            // 
            hotkeyInsertToolStripMenuItem.Enabled = false;
            hotkeyInsertToolStripMenuItem.Name = "hotkeyInsertToolStripMenuItem";
            hotkeyInsertToolStripMenuItem.Size = new Size(153, 22);
            hotkeyInsertToolStripMenuItem.Text = "Hotkey: Insert";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(150, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Image = (Image)resources.GetObject("exitToolStripMenuItem.Image");
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(153, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // chkMinimizeToTray
            // 
            chkMinimizeToTray.AutoSize = true;
            chkMinimizeToTray.Checked = true;
            chkMinimizeToTray.CheckState = CheckState.Checked;
            chkMinimizeToTray.ForeColor = Color.White;
            chkMinimizeToTray.Location = new Point(11, 127);
            chkMinimizeToTray.Name = "chkMinimizeToTray";
            chkMinimizeToTray.Size = new Size(112, 19);
            chkMinimizeToTray.TabIndex = 1;
            chkMinimizeToTray.Text = "Minimize to tray";
            chkMinimizeToTray.UseVisualStyleBackColor = true;
            chkMinimizeToTray.CheckedChanged += chkMinimizeToTray_CheckedChanged;
            // 
            // pnlMain
            // 
            pnlMain.BorderStyle = BorderStyle.FixedSingle;
            pnlMain.Controls.Add(numBetweenDelay);
            pnlMain.Controls.Add(numBeforeDelay);
            pnlMain.Controls.Add(btnSend);
            pnlMain.Controls.Add(chkKeepOnTop);
            pnlMain.Controls.Add(chkClearCbAfterSending);
            pnlMain.Controls.Add(lblDBCinfo);
            pnlMain.Controls.Add(label5);
            pnlMain.Controls.Add(chkMask);
            pnlMain.Controls.Add(label4);
            pnlMain.Controls.Add(label3);
            pnlMain.Controls.Add(label2);
            pnlMain.Controls.Add(label1);
            pnlMain.Controls.Add(lblClear);
            pnlMain.Controls.Add(lblPaste);
            pnlMain.Controls.Add(chkClipboardSync);
            pnlMain.Controls.Add(txtPayload);
            pnlMain.Location = new Point(12, 58);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(432, 259);
            pnlMain.TabIndex = 6;
            // 
            // numBetweenDelay
            // 
            numBetweenDelay.BackColor = Color.FromArgb(17, 17, 17);
            numBetweenDelay.BorderStyle = BorderStyle.FixedSingle;
            numBetweenDelay.ForeColor = Color.White;
            numBetweenDelay.Location = new Point(130, 204);
            numBetweenDelay.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numBetweenDelay.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numBetweenDelay.Name = "numBetweenDelay";
            numBetweenDelay.Size = new Size(67, 23);
            numBetweenDelay.TabIndex = 5;
            numBetweenDelay.TextAlign = HorizontalAlignment.Center;
            numBetweenDelay.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numBetweenDelay.ValueChanged += numBetweenDelay_ValueChanged;
            numBetweenDelay.KeyPress += numBetweenDelay_KeyPress;
            // 
            // chkKeepOnTop
            // 
            chkKeepOnTop.AutoSize = true;
            chkKeepOnTop.ForeColor = Color.White;
            chkKeepOnTop.Location = new Point(253, 232);
            chkKeepOnTop.Name = "chkKeepOnTop";
            chkKeepOnTop.Size = new Size(90, 19);
            chkKeepOnTop.TabIndex = 1;
            chkKeepOnTop.Text = "Keep on top";
            chkKeepOnTop.UseVisualStyleBackColor = true;
            chkKeepOnTop.CheckedChanged += chkKeepOnTop_CheckedChanged;
            // 
            // chkClearCbAfterSending
            // 
            chkClearCbAfterSending.AutoSize = true;
            chkClearCbAfterSending.ForeColor = Color.White;
            chkClearCbAfterSending.Location = new Point(11, 232);
            chkClearCbAfterSending.Name = "chkClearCbAfterSending";
            chkClearCbAfterSending.Size = new Size(198, 19);
            chkClearCbAfterSending.TabIndex = 1;
            chkClearCbAfterSending.Text = "Clear the clipboard after sending";
            chkClearCbAfterSending.UseVisualStyleBackColor = true;
            chkClearCbAfterSending.CheckedChanged += chkClearCbAfterSending_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(199, 207);
            label5.Name = "label5";
            label5.Size = new Size(23, 15);
            label5.TabIndex = 3;
            label5.Text = "ms";
            // 
            // chkMask
            // 
            chkMask.AutoSize = true;
            chkMask.ForeColor = Color.White;
            chkMask.Location = new Point(349, 7);
            chkMask.Name = "chkMask";
            chkMask.Size = new Size(77, 19);
            chkMask.TabIndex = 1;
            chkMask.Text = "Mask text";
            chkMask.UseVisualStyleBackColor = true;
            chkMask.CheckedChanged += chkMask_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 207);
            label4.Name = "label4";
            label4.Size = new Size(118, 15);
            label4.TabIndex = 3;
            label4.Text = "Delay between chars:";
            // 
            // lblClear
            // 
            lblClear.AutoSize = true;
            lblClear.Cursor = Cursors.Hand;
            lblClear.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            lblClear.Location = new Point(162, 8);
            lblClear.Name = "lblClear";
            lblClear.Size = new Size(34, 15);
            lblClear.TabIndex = 2;
            lblClear.Text = "Clear";
            lblClear.Click += lblClear_Click;
            // 
            // tmrCbSync
            // 
            tmrCbSync.Tick += tmrCbSync_Tick;
            // 
            // pnkHotKey
            // 
            pnkHotKey.BorderStyle = BorderStyle.FixedSingle;
            pnkHotKey.Controls.Add(ucKeySelector);
            pnkHotKey.Controls.Add(label7);
            pnkHotKey.Controls.Add(label6);
            pnkHotKey.Controls.Add(lblHKInfo);
            pnkHotKey.Controls.Add(lblResetHK);
            pnkHotKey.Location = new Point(12, 12);
            pnkHotKey.Name = "pnkHotKey";
            pnkHotKey.Size = new Size(432, 37);
            pnkHotKey.TabIndex = 9;
            // 
            // ucKeySelector
            // 
            ucKeySelector.BackColor = Color.FromArgb(26, 26, 26);
            ucKeySelector.ForeColor = Color.White;
            ucKeySelector.Location = new Point(190, 7);
            ucKeySelector.Name = "ucKeySelector";
            ucKeySelector.Size = new Size(90, 21);
            ucKeySelector.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(174, 9);
            label7.Name = "label7";
            label7.Size = new Size(15, 15);
            label7.TabIndex = 9;
            label7.Text = "+";
            // 
            // lblHKInfo
            // 
            lblHKInfo.AutoSize = true;
            lblHKInfo.Cursor = Cursors.Hand;
            lblHKInfo.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            lblHKInfo.ForeColor = Color.Silver;
            lblHKInfo.Location = new Point(343, 9);
            lblHKInfo.Name = "lblHKInfo";
            lblHKInfo.Size = new Size(78, 15);
            lblHKInfo.TabIndex = 2;
            lblHKInfo.Text = "More HK info";
            lblHKInfo.Click += lblHKInfo_Click;
            // 
            // lblResetHK
            // 
            lblResetHK.AutoSize = true;
            lblResetHK.Cursor = Cursors.Hand;
            lblResetHK.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            lblResetHK.Location = new Point(286, 9);
            lblResetHK.Name = "lblResetHK";
            lblResetHK.Size = new Size(35, 15);
            lblResetHK.TabIndex = 2;
            lblResetHK.Text = "Reset";
            lblResetHK.Click += lblResetHK_Click;
            // 
            // pnlSettings
            // 
            pnlSettings.BorderStyle = BorderStyle.FixedSingle;
            pnlSettings.Controls.Add(lblBlockHKPInfo);
            pnlSettings.Controls.Add(chkBlockHotkeyPropagation);
            pnlSettings.Controls.Add(chkRunOnStartup);
            pnlSettings.Controls.Add(chkMinimizeToTray);
            pnlSettings.Controls.Add(lblRuns);
            pnlSettings.Controls.Add(btnRecSet);
            pnlSettings.Controls.Add(btnResetSet);
            pnlSettings.Controls.Add(lblCheck4Update);
            pnlSettings.Controls.Add(lblGitHubInfo);
            pnlSettings.Controls.Add(label10);
            pnlSettings.Controls.Add(label8);
            pnlSettings.Location = new Point(12, 58);
            pnlSettings.Name = "pnlSettings";
            pnlSettings.Size = new Size(432, 259);
            pnlSettings.TabIndex = 10;
            pnlSettings.Visible = false;
            // 
            // chkBlockHotkeyPropagation
            // 
            chkBlockHotkeyPropagation.AutoSize = true;
            chkBlockHotkeyPropagation.ForeColor = Color.White;
            chkBlockHotkeyPropagation.Location = new Point(11, 153);
            chkBlockHotkeyPropagation.Name = "chkBlockHotkeyPropagation";
            chkBlockHotkeyPropagation.Size = new Size(162, 19);
            chkBlockHotkeyPropagation.TabIndex = 1;
            chkBlockHotkeyPropagation.Text = "Block hotkey propagation";
            chkBlockHotkeyPropagation.UseVisualStyleBackColor = true;
            chkBlockHotkeyPropagation.CheckedChanged += chkBlockHotkeyPropagation_CheckedChanged;
            // 
            // chkRunOnStartup
            // 
            chkRunOnStartup.AutoSize = true;
            chkRunOnStartup.ForeColor = Color.White;
            chkRunOnStartup.Location = new Point(11, 101);
            chkRunOnStartup.Name = "chkRunOnStartup";
            chkRunOnStartup.Size = new Size(104, 19);
            chkRunOnStartup.TabIndex = 1;
            chkRunOnStartup.Text = "Run on startup";
            chkRunOnStartup.UseVisualStyleBackColor = true;
            chkRunOnStartup.CheckedChanged += chkRunOnStartup_CheckedChanged;
            // 
            // btnRecSet
            // 
            btnRecSet.BackColor = Color.FromArgb(33, 33, 33);
            btnRecSet.Cursor = Cursors.Hand;
            btnRecSet.FlatAppearance.BorderColor = Color.Gray;
            btnRecSet.FlatAppearance.MouseDownBackColor = Color.FromArgb(120, 120, 120);
            btnRecSet.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            btnRecSet.FlatStyle = FlatStyle.Flat;
            btnRecSet.Location = new Point(11, 222);
            btnRecSet.Name = "btnRecSet";
            btnRecSet.Size = new Size(196, 26);
            btnRecSet.TabIndex = 4;
            btnRecSet.Text = "Apply the recommended settings";
            btnRecSet.UseVisualStyleBackColor = false;
            btnRecSet.Click += btnRecSet_Click;
            // 
            // btnResetSet
            // 
            btnResetSet.BackColor = Color.FromArgb(33, 33, 33);
            btnResetSet.Cursor = Cursors.Hand;
            btnResetSet.FlatAppearance.BorderColor = Color.Gray;
            btnResetSet.FlatAppearance.MouseDownBackColor = Color.FromArgb(120, 120, 120);
            btnResetSet.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            btnResetSet.FlatStyle = FlatStyle.Flat;
            btnResetSet.Location = new Point(213, 222);
            btnResetSet.Name = "btnResetSet";
            btnResetSet.Size = new Size(90, 26);
            btnResetSet.TabIndex = 4;
            btnResetSet.Text = "Reset settings";
            btnResetSet.UseVisualStyleBackColor = false;
            btnResetSet.Click += btnResetSet_Click;
            // 
            // lblCheck4Update
            // 
            lblCheck4Update.AutoSize = true;
            lblCheck4Update.Cursor = Cursors.Hand;
            lblCheck4Update.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            lblCheck4Update.Location = new Point(142, 193);
            lblCheck4Update.Name = "lblCheck4Update";
            lblCheck4Update.Size = new Size(114, 15);
            lblCheck4Update.TabIndex = 2;
            lblCheck4Update.Text = "Check for an update";
            lblCheck4Update.Click += lblCheck4Update_Click;
            // 
            // lblGitHubInfo
            // 
            lblGitHubInfo.AutoSize = true;
            lblGitHubInfo.Cursor = Cursors.Hand;
            lblGitHubInfo.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            lblGitHubInfo.Location = new Point(10, 193);
            lblGitHubInfo.Name = "lblGitHubInfo";
            lblGitHubInfo.Size = new Size(126, 15);
            lblGitHubInfo.TabIndex = 2;
            lblGitHubInfo.Text = "Open the GitHub page";
            lblGitHubInfo.Click += lblGitHubInfo_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.Silver;
            label10.Location = new Point(9, 28);
            label10.Name = "label10";
            label10.Size = new Size(416, 60);
            label10.TabIndex = 3;
            label10.Text = resources.GetString("label10.Text");
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            label8.Location = new Point(9, 10);
            label8.Name = "label8";
            label8.Size = new Size(49, 15);
            label8.TabIndex = 3;
            label8.Text = "Settings";
            // 
            // lblUpdate
            // 
            lblUpdate.AutoSize = true;
            lblUpdate.Cursor = Cursors.Hand;
            lblUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            lblUpdate.ForeColor = Color.FromArgb(192, 255, 255);
            lblUpdate.Location = new Point(397, 330);
            lblUpdate.Name = "lblUpdate";
            lblUpdate.Size = new Size(48, 15);
            lblUpdate.TabIndex = 2;
            lblUpdate.Text = "Update!";
            lblUpdate.Visible = false;
            lblUpdate.Click += lblUpdate_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            ClientSize = new Size(456, 357);
            Controls.Add(lblUpdate);
            Controls.Add(btnSettings);
            Controls.Add(ucModifierKeys);
            Controls.Add(pnkHotKey);
            Controls.Add(lblStatus);
            Controls.Add(pnlMain);
            Controls.Add(pnlSettings);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmMain";
            Opacity = 0D;
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "";
            Text = "Simple Send Keys - AvA.Soft";
            FormClosing += frmMain_FormClosing;
            Load += frmMain_Load;
            Shown += frmMain_Shown;
            Resize += frmMain_Resize;
            ((System.ComponentModel.ISupportInitialize)numBeforeDelay).EndInit();
            trayContextMenu.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numBetweenDelay).EndInit();
            pnkHotKey.ResumeLayout(false);
            pnkHotKey.PerformLayout();
            pnlSettings.ResumeLayout(false);
            pnlSettings.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPayload;
        private CheckBox chkClipboardSync;
        private Label lblPaste;
        private Label label1;
        private Button btnSend;
        private Label label2;
        private NumericUpDown numBeforeDelay;
        private Label label3;
        private ToolTip toolTips;
        private NotifyIcon trayIcon;
        private ContextMenuStrip trayContextMenu;
        private ToolStripMenuItem showToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private CheckBox chkMinimizeToTray;
        private Panel pnlMain;
        private System.Windows.Forms.Timer tmrCbSync;
        private CheckBox chkMask;
        private NumericUpDown numBetweenDelay;
        private Label label5;
        private Label label4;
        private Label lblStatus;
        private CheckBox chkClearCbAfterSending;
        private Controls.ucModifierKeys ucModifierKeys;
        private Panel pnkHotKey;
        private Label label6;
        private Label label7;
        private Controls.ucKeySelector ucKeySelector;
        private Label lblResetHK;
        private Label lblHKInfo;
        private Panel pnlSettings;
        private Button btnSettings;
        private Label lblGitHubInfo;
        private Label label8;
        private CheckBox chkRunOnStartup;
        private Label label10;
        private Button btnResetSet;
        private Label lblRuns;
        private Button btnRecSet;
        private ToolStripMenuItem sendinXSecToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private Label lblDBCinfo;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem hotkeyInsertToolStripMenuItem;
        private CheckBox chkBlockHotkeyPropagation;
        private Label lblBlockHKPInfo;
        private Label lblClear;
        private Label lblCheck4Update;
        private Label lblUpdate;
        private CheckBox chkKeepOnTop;
    }
}
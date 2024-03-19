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
            trayIcon = new NotifyIcon(components);
            trayContextMenu = new ContextMenuStrip(components);
            showToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            chkMinimizeToTray = new CheckBox();
            pnlMain = new Panel();
            numBetweenDelay = new NumericUpDown();
            chkClearCbAfterSending = new CheckBox();
            label5 = new Label();
            chkMask = new CheckBox();
            label4 = new Label();
            tmrCbSync = new System.Windows.Forms.Timer(components);
            lblStatus = new Label();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)numBeforeDelay).BeginInit();
            trayContextMenu.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numBetweenDelay).BeginInit();
            SuspendLayout();
            // 
            // txtPayload
            // 
            txtPayload.BackColor = Color.FromArgb(17, 17, 17);
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
            chkClipboardSync.Location = new Point(208, 7);
            chkClipboardSync.Name = "chkClipboardSync";
            chkClipboardSync.Size = new Size(105, 19);
            chkClipboardSync.TabIndex = 1;
            chkClipboardSync.Text = "Clipboard sync";
            toolTips.SetToolTip(chkClipboardSync, "Syncs the textbox to your clipboard.");
            chkClipboardSync.UseVisualStyleBackColor = true;
            chkClipboardSync.CheckedChanged += chkClipboardSync_CheckedChanged;
            // 
            // lblPaste
            // 
            lblPaste.AutoSize = true;
            lblPaste.Cursor = Cursors.Hand;
            lblPaste.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point);
            lblPaste.Location = new Point(89, 8);
            lblPaste.Name = "lblPaste";
            lblPaste.Size = new Size(35, 15);
            lblPaste.TabIndex = 2;
            lblPaste.Text = "Paste";
            lblPaste.Click += lblPaste_Click;
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
            btnSend.Location = new Point(253, 175);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(168, 52);
            btnSend.TabIndex = 4;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 178);
            label2.Name = "label2";
            label2.Size = new Size(121, 15);
            label2.TabIndex = 3;
            label2.Text = "Delay before sending:";
            toolTips.SetToolTip(label2, "Used only when using the \"Send\" button.\r\nWhen using the keyboard shortcut, the sending will start instantly.");
            // 
            // numBeforeDelay
            // 
            numBeforeDelay.BackColor = Color.FromArgb(17, 17, 17);
            numBeforeDelay.BorderStyle = BorderStyle.FixedSingle;
            numBeforeDelay.ForeColor = Color.White;
            numBeforeDelay.Location = new Point(132, 175);
            numBeforeDelay.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            numBeforeDelay.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numBeforeDelay.Name = "numBeforeDelay";
            numBeforeDelay.Size = new Size(67, 23);
            numBeforeDelay.TabIndex = 5;
            numBeforeDelay.TextAlign = HorizontalAlignment.Center;
            toolTips.SetToolTip(numBeforeDelay, "Used only when using the \"Send\" button.\r\nWhen using the keyboard shortcut, the sending will start instantly.");
            numBeforeDelay.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(202, 178);
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
            trayContextMenu.Items.AddRange(new ToolStripItem[] { showToolStripMenuItem, exitToolStripMenuItem });
            trayContextMenu.Name = "trayContextMenu";
            trayContextMenu.Size = new Size(104, 48);
            // 
            // showToolStripMenuItem
            // 
            showToolStripMenuItem.Name = "showToolStripMenuItem";
            showToolStripMenuItem.Size = new Size(103, 22);
            showToolStripMenuItem.Text = "Show";
            showToolStripMenuItem.Click += showToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(103, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // chkMinimizeToTray
            // 
            chkMinimizeToTray.AutoSize = true;
            chkMinimizeToTray.Checked = true;
            chkMinimizeToTray.CheckState = CheckState.Checked;
            chkMinimizeToTray.ForeColor = Color.White;
            chkMinimizeToTray.Location = new Point(23, 277);
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
            pnlMain.Controls.Add(chkClearCbAfterSending);
            pnlMain.Controls.Add(label5);
            pnlMain.Controls.Add(chkMask);
            pnlMain.Controls.Add(label4);
            pnlMain.Controls.Add(label3);
            pnlMain.Controls.Add(label2);
            pnlMain.Controls.Add(label1);
            pnlMain.Controls.Add(lblPaste);
            pnlMain.Controls.Add(chkClipboardSync);
            pnlMain.Controls.Add(txtPayload);
            pnlMain.Location = new Point(12, 12);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(432, 259);
            pnlMain.TabIndex = 6;
            // 
            // numBetweenDelay
            // 
            numBetweenDelay.BackColor = Color.FromArgb(17, 17, 17);
            numBetweenDelay.BorderStyle = BorderStyle.FixedSingle;
            numBetweenDelay.ForeColor = Color.White;
            numBetweenDelay.Location = new Point(132, 204);
            numBetweenDelay.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numBetweenDelay.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numBetweenDelay.Name = "numBetweenDelay";
            numBetweenDelay.Size = new Size(67, 23);
            numBetweenDelay.TabIndex = 5;
            numBetweenDelay.TextAlign = HorizontalAlignment.Center;
            numBetweenDelay.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numBetweenDelay.ValueChanged += numBetweenDelay_ValueChanged;
            // 
            // chkClearCbAfterSending
            // 
            chkClearCbAfterSending.AutoSize = true;
            chkClearCbAfterSending.Checked = true;
            chkClearCbAfterSending.CheckState = CheckState.Checked;
            chkClearCbAfterSending.ForeColor = Color.White;
            chkClearCbAfterSending.Location = new Point(13, 232);
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
            label5.Location = new Point(202, 207);
            label5.Name = "label5";
            label5.Size = new Size(23, 15);
            label5.TabIndex = 3;
            label5.Text = "ms";
            // 
            // chkMask
            // 
            chkMask.AutoSize = true;
            chkMask.ForeColor = Color.White;
            chkMask.Location = new Point(330, 7);
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
            label4.Location = new Point(10, 207);
            label4.Name = "label4";
            label4.Size = new Size(118, 15);
            label4.TabIndex = 3;
            label4.Text = "Delay between chars:";
            // 
            // tmrCbSync
            // 
            tmrCbSync.Tick += tmrCbSync_Tick;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(141, 278);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(303, 16);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Idle";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(490, 120);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(147, 23);
            comboBox1.TabIndex = 8;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            ClientSize = new Size(693, 303);
            Controls.Add(comboBox1);
            Controls.Add(lblStatus);
            Controls.Add(pnlMain);
            Controls.Add(chkMinimizeToTray);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Simple Send Keys - AvA.Soft";
            FormClosing += frmMain_FormClosing;
            Load += frmMain_Load;
            Resize += frmMain_Resize;
            ((System.ComponentModel.ISupportInitialize)numBeforeDelay).EndInit();
            trayContextMenu.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numBetweenDelay).EndInit();
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
        private ComboBox comboBox1;
    }
}
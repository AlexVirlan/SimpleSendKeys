namespace SimpleSendKeys.Controls
{
    partial class ucModifierKeys
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblInfo = new Label();
            chkAlt = new CheckBox();
            chkControl = new CheckBox();
            chkShift = new CheckBox();
            chkWin = new CheckBox();
            pnlMain = new Panel();
            pnlControls = new Panel();
            toolTips = new ToolTip(components);
            pnlMain.SuspendLayout();
            pnlControls.SuspendLayout();
            SuspendLayout();
            // 
            // lblInfo
            // 
            lblInfo.Cursor = Cursors.Hand;
            lblInfo.Dock = DockStyle.Fill;
            lblInfo.ForeColor = Color.White;
            lblInfo.Location = new Point(0, 0);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(117, 19);
            lblInfo.TabIndex = 0;
            lblInfo.Text = "Alt, Ctrl, Shift, Win";
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            toolTips.SetToolTip(lblInfo, "Click to set the modifier keys.");
            lblInfo.Click += lblInfo_Click;
            // 
            // chkAlt
            // 
            chkAlt.AutoSize = true;
            chkAlt.ForeColor = Color.White;
            chkAlt.Location = new Point(6, 5);
            chkAlt.Name = "chkAlt";
            chkAlt.Size = new Size(41, 19);
            chkAlt.TabIndex = 0;
            chkAlt.Tag = "Alt";
            chkAlt.Text = "Alt";
            chkAlt.UseVisualStyleBackColor = true;
            chkAlt.CheckedChanged += CheckboxChanged;
            // 
            // chkControl
            // 
            chkControl.AutoSize = true;
            chkControl.ForeColor = Color.White;
            chkControl.Location = new Point(6, 30);
            chkControl.Name = "chkControl";
            chkControl.Size = new Size(45, 19);
            chkControl.TabIndex = 1;
            chkControl.Tag = "Ctrl";
            chkControl.Text = "Ctrl";
            chkControl.UseVisualStyleBackColor = true;
            chkControl.CheckedChanged += CheckboxChanged;
            // 
            // chkShift
            // 
            chkShift.AutoSize = true;
            chkShift.ForeColor = Color.White;
            chkShift.Location = new Point(66, 5);
            chkShift.Name = "chkShift";
            chkShift.Size = new Size(50, 19);
            chkShift.TabIndex = 2;
            chkShift.Tag = "Shift";
            chkShift.Text = "Shift";
            chkShift.UseVisualStyleBackColor = true;
            chkShift.CheckedChanged += CheckboxChanged;
            // 
            // chkWin
            // 
            chkWin.AutoSize = true;
            chkWin.ForeColor = Color.White;
            chkWin.Location = new Point(66, 30);
            chkWin.Name = "chkWin";
            chkWin.Size = new Size(47, 19);
            chkWin.TabIndex = 3;
            chkWin.Tag = "Win";
            chkWin.Text = "Win";
            chkWin.UseVisualStyleBackColor = true;
            chkWin.CheckedChanged += CheckboxChanged;
            // 
            // pnlMain
            // 
            pnlMain.BorderStyle = BorderStyle.FixedSingle;
            pnlMain.Controls.Add(lblInfo);
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(119, 21);
            pnlMain.TabIndex = 2;
            // 
            // pnlControls
            // 
            pnlControls.BorderStyle = BorderStyle.FixedSingle;
            pnlControls.Controls.Add(chkAlt);
            pnlControls.Controls.Add(chkControl);
            pnlControls.Controls.Add(chkWin);
            pnlControls.Controls.Add(chkShift);
            pnlControls.Location = new Point(0, 21);
            pnlControls.Name = "pnlControls";
            pnlControls.Size = new Size(119, 54);
            pnlControls.TabIndex = 3;
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
            // ucModifierKeys
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            Controls.Add(pnlControls);
            Controls.Add(pnlMain);
            Name = "ucModifierKeys";
            Size = new Size(119, 21);
            Load += ucModifierKeys_Load;
            Leave += ucModifierKeys_Leave;
            pnlMain.ResumeLayout(false);
            pnlControls.ResumeLayout(false);
            pnlControls.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblInfo;
        private CheckBox chkAlt;
        private CheckBox chkControl;
        private CheckBox chkShift;
        private CheckBox chkWin;
        private Panel pnlMain;
        private Panel pnlControls;
        private ToolTip toolTips;
    }
}

namespace SimpleSendKeys.Controls
{
    partial class ucKeySelector
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
            pnlMain = new Panel();
            toolTips = new ToolTip(components);
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // lblInfo
            // 
            lblInfo.Cursor = Cursors.Hand;
            lblInfo.Dock = DockStyle.Fill;
            lblInfo.Location = new Point(0, 0);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(88, 19);
            lblInfo.TabIndex = 0;
            lblInfo.Text = "-";
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            toolTips.SetToolTip(lblInfo, "Click then press a single key to set the global hotkey.\r\nClick again (or anywhere else on the window) to cancel.");
            lblInfo.Click += lblInfo_Click;
            lblInfo.PreviewKeyDown += lblInfo_PreviewKeyDown;
            // 
            // pnlMain
            // 
            pnlMain.BorderStyle = BorderStyle.FixedSingle;
            pnlMain.Controls.Add(lblInfo);
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(90, 21);
            pnlMain.TabIndex = 1;
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
            // ucKeySelector
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            Controls.Add(pnlMain);
            ForeColor = Color.White;
            Name = "ucKeySelector";
            Size = new Size(90, 21);
            Load += ucKeySelector_Load;
            Leave += ucKeySelector_Leave;
            pnlMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblInfo;
        private Panel pnlMain;
        private ToolTip toolTips;
    }
}

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
            lblInfo = new Label();
            chkAlt = new CheckBox();
            chkControl = new CheckBox();
            chkShift = new CheckBox();
            chkWin = new CheckBox();
            SuspendLayout();
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(33, 34);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(12, 15);
            lblInfo.TabIndex = 0;
            lblInfo.Text = "-";
            // 
            // chkAlt
            // 
            chkAlt.AutoSize = true;
            chkAlt.Location = new Point(33, 71);
            chkAlt.Name = "chkAlt";
            chkAlt.Size = new Size(41, 19);
            chkAlt.TabIndex = 1;
            chkAlt.Tag = "1";
            chkAlt.Text = "Alt";
            chkAlt.UseVisualStyleBackColor = true;
            chkAlt.CheckedChanged += CheckboxChanged;
            // 
            // chkControl
            // 
            chkControl.AutoSize = true;
            chkControl.Location = new Point(33, 96);
            chkControl.Name = "chkControl";
            chkControl.Size = new Size(45, 19);
            chkControl.TabIndex = 1;
            chkControl.Tag = "2";
            chkControl.Text = "Ctrl";
            chkControl.UseVisualStyleBackColor = true;
            chkControl.CheckedChanged += CheckboxChanged;
            // 
            // chkShift
            // 
            chkShift.AutoSize = true;
            chkShift.Location = new Point(96, 71);
            chkShift.Name = "chkShift";
            chkShift.Size = new Size(50, 19);
            chkShift.TabIndex = 1;
            chkShift.Tag = "4";
            chkShift.Text = "Shift";
            chkShift.UseVisualStyleBackColor = true;
            chkShift.CheckedChanged += CheckboxChanged;
            // 
            // chkWin
            // 
            chkWin.AutoSize = true;
            chkWin.Location = new Point(96, 96);
            chkWin.Name = "chkWin";
            chkWin.Size = new Size(47, 19);
            chkWin.TabIndex = 1;
            chkWin.Tag = "8";
            chkWin.Text = "Win";
            chkWin.UseVisualStyleBackColor = true;
            chkWin.CheckedChanged += CheckboxChanged;
            // 
            // ucModifierKeys
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(chkWin);
            Controls.Add(chkShift);
            Controls.Add(chkControl);
            Controls.Add(chkAlt);
            Controls.Add(lblInfo);
            Name = "ucModifierKeys";
            Size = new Size(339, 172);
            Load += ucModifierKeys_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblInfo;
        private CheckBox chkAlt;
        private CheckBox chkControl;
        private CheckBox chkShift;
        private CheckBox chkWin;
    }
}

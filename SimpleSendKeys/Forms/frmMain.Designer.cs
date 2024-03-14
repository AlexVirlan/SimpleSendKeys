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
            txtPayload = new TextBox();
            chkClipboardSync = new CheckBox();
            lblPaste = new Label();
            label1 = new Label();
            btnSend = new Button();
            label2 = new Label();
            numDelay = new NumericUpDown();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)numDelay).BeginInit();
            SuspendLayout();
            // 
            // txtPayload
            // 
            txtPayload.BackColor = Color.FromArgb(17, 17, 17);
            txtPayload.ForeColor = Color.White;
            txtPayload.Location = new Point(126, 144);
            txtPayload.Multiline = true;
            txtPayload.Name = "txtPayload";
            txtPayload.Size = new Size(350, 143);
            txtPayload.TabIndex = 0;
            // 
            // chkClipboardSync
            // 
            chkClipboardSync.AutoSize = true;
            chkClipboardSync.ForeColor = Color.White;
            chkClipboardSync.Location = new Point(371, 125);
            chkClipboardSync.Name = "chkClipboardSync";
            chkClipboardSync.Size = new Size(105, 19);
            chkClipboardSync.TabIndex = 1;
            chkClipboardSync.Text = "Clipboard sync";
            chkClipboardSync.UseVisualStyleBackColor = true;
            // 
            // lblPaste
            // 
            lblPaste.AutoSize = true;
            lblPaste.Cursor = Cursors.Hand;
            lblPaste.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point);
            lblPaste.Location = new Point(265, 126);
            lblPaste.Name = "lblPaste";
            lblPaste.Size = new Size(35, 15);
            lblPaste.TabIndex = 2;
            lblPaste.Text = "Paste";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(126, 126);
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
            btnSend.Location = new Point(369, 293);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(107, 23);
            btnSend.TabIndex = 4;
            btnSend.Text = "S E N D";
            btnSend.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(126, 296);
            label2.Name = "label2";
            label2.Size = new Size(121, 15);
            label2.TabIndex = 3;
            label2.Text = "Delay before sending:";
            // 
            // numDelay
            // 
            numDelay.BackColor = Color.FromArgb(17, 17, 17);
            numDelay.BorderStyle = BorderStyle.FixedSingle;
            numDelay.ForeColor = Color.White;
            numDelay.Location = new Point(248, 293);
            numDelay.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            numDelay.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDelay.Name = "numDelay";
            numDelay.Size = new Size(67, 23);
            numDelay.TabIndex = 5;
            numDelay.TextAlign = HorizontalAlignment.Center;
            numDelay.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(318, 296);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 3;
            label3.Text = "sec.";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            ClientSize = new Size(800, 450);
            Controls.Add(numDelay);
            Controls.Add(btnSend);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblPaste);
            Controls.Add(chkClipboardSync);
            Controls.Add(txtPayload);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SimpleSendKeys";
            Load += frmMain_Load;
            ((System.ComponentModel.ISupportInitialize)numDelay).EndInit();
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
        private NumericUpDown numDelay;
        private Label label3;
    }
}
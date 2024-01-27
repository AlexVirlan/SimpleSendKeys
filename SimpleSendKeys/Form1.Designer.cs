namespace SimpleSendKeys
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtText = new TextBox();
            btnSendKeys = new Button();
            SuspendLayout();
            // 
            // txtText
            // 
            txtText.Location = new Point(119, 161);
            txtText.Name = "txtText";
            txtText.Size = new Size(309, 23);
            txtText.TabIndex = 0;
            // 
            // btnSendKeys
            // 
            btnSendKeys.Location = new Point(443, 143);
            btnSendKeys.Name = "btnSendKeys";
            btnSendKeys.Size = new Size(77, 56);
            btnSendKeys.TabIndex = 1;
            btnSendKeys.Text = "button1";
            btnSendKeys.UseVisualStyleBackColor = true;
            btnSendKeys.Click += btnSendKeys_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSendKeys);
            Controls.Add(txtText);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtText;
        private Button btnSendKeys;
    }
}
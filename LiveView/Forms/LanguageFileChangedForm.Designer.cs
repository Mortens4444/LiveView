namespace LiveView.Forms
{
    partial class LanguageFileChangedForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(LanguageFileChangedForm));
            chkDoNotShowAgain = new System.Windows.Forms.CheckBox();
            btnOk = new System.Windows.Forms.Button();
            btnRestoreOriginal = new System.Windows.Forms.Button();
            lblFileChanged = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // chkDoNotShowAgain
            // 
            chkDoNotShowAgain.AutoSize = true;
            chkDoNotShowAgain.Location = new System.Drawing.Point(12, 44);
            chkDoNotShowAgain.Name = "chkDoNotShowAgain";
            chkDoNotShowAgain.Size = new System.Drawing.Size(150, 19);
            chkDoNotShowAgain.TabIndex = 0;
            chkDoNotShowAgain.Text = "Do not show this again.";
            chkDoNotShowAgain.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.Location = new System.Drawing.Point(12, 69);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(75, 23);
            btnOk.TabIndex = 1;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += BtnOk_Click;
            // 
            // btnRestoreOriginal
            // 
            btnRestoreOriginal.Location = new System.Drawing.Point(93, 69);
            btnRestoreOriginal.Name = "btnRestoreOriginal";
            btnRestoreOriginal.Size = new System.Drawing.Size(364, 23);
            btnRestoreOriginal.TabIndex = 2;
            btnRestoreOriginal.Text = "Restore original language file.";
            btnRestoreOriginal.UseVisualStyleBackColor = true;
            btnRestoreOriginal.Click += BtnRestoreOriginal_Click;
            // 
            // lblFileChanged
            // 
            lblFileChanged.AutoSize = true;
            lblFileChanged.Font = (System.Drawing.Font)resources.GetObject("lblFileChanged.Font");
            lblFileChanged.Location = new System.Drawing.Point(93, 9);
            lblFileChanged.Name = "lblFileChanged";
            lblFileChanged.Size = new System.Drawing.Size(290, 21);
            lblFileChanged.TabIndex = 3;
            lblFileChanged.Text = "The language file has been changed!";
            // 
            // LanguageFileChangedForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(469, 104);
            Controls.Add(lblFileChanged);
            Controls.Add(btnRestoreOriginal);
            Controls.Add(btnOk);
            Controls.Add(chkDoNotShowAgain);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(485, 143);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(485, 143);
            Name = "LanguageFileChangedForm";
            Shown += LanguageFileChangedForm_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox chkDoNotShowAgain;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnRestoreOriginal;
        private System.Windows.Forms.Label lblFileChanged;
    }
}
namespace LiveView.Forms
{
    partial class EnterPass
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(EnterPass));
            gb_PleaseEnterMSSQLAdministratorPasswordOrSSC = new System.Windows.Forms.GroupBox();
            btn_OK = new System.Windows.Forms.Button();
            tbSziltechSecurityCode = new System.Windows.Forms.TextBox();
            rb_SziltechSecurityCode = new System.Windows.Forms.RadioButton();
            tb_DatabaseSaPassword = new Mtf.Controls.PasswordBox();
            rb_DatabaseSaPassword = new System.Windows.Forms.RadioButton();
            gb_PleaseEnterMSSQLAdministratorPasswordOrSSC.SuspendLayout();
            SuspendLayout();
            // 
            // gb_PleaseEnterMSSQLAdministratorPasswordOrSSC
            // 
            gb_PleaseEnterMSSQLAdministratorPasswordOrSSC.Controls.Add(btn_OK);
            gb_PleaseEnterMSSQLAdministratorPasswordOrSSC.Controls.Add(tbSziltechSecurityCode);
            gb_PleaseEnterMSSQLAdministratorPasswordOrSSC.Controls.Add(rb_SziltechSecurityCode);
            gb_PleaseEnterMSSQLAdministratorPasswordOrSSC.Controls.Add(tb_DatabaseSaPassword);
            gb_PleaseEnterMSSQLAdministratorPasswordOrSSC.Controls.Add(rb_DatabaseSaPassword);
            gb_PleaseEnterMSSQLAdministratorPasswordOrSSC.Dock = System.Windows.Forms.DockStyle.Fill;
            gb_PleaseEnterMSSQLAdministratorPasswordOrSSC.Location = new System.Drawing.Point(0, 0);
            gb_PleaseEnterMSSQLAdministratorPasswordOrSSC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_PleaseEnterMSSQLAdministratorPasswordOrSSC.Name = "gb_PleaseEnterMSSQLAdministratorPasswordOrSSC";
            gb_PleaseEnterMSSQLAdministratorPasswordOrSSC.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_PleaseEnterMSSQLAdministratorPasswordOrSSC.Size = new System.Drawing.Size(341, 173);
            gb_PleaseEnterMSSQLAdministratorPasswordOrSSC.TabIndex = 1;
            gb_PleaseEnterMSSQLAdministratorPasswordOrSSC.TabStop = false;
            gb_PleaseEnterMSSQLAdministratorPasswordOrSSC.Text = "Please enter MSSQL administrator password or SSC";
            // 
            // btn_OK
            // 
            btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            btn_OK.Location = new System.Drawing.Point(239, 135);
            btn_OK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_OK.Name = "btn_OK";
            btn_OK.Size = new System.Drawing.Size(88, 27);
            btn_OK.TabIndex = 4;
            btn_OK.Text = "OK";
            btn_OK.UseVisualStyleBackColor = true;
            btn_OK.Click += Btn_OK_Click;
            // 
            // tbSziltechSecurityCode
            // 
            tbSziltechSecurityCode.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbSziltechSecurityCode.Enabled = false;
            tbSziltechSecurityCode.Location = new System.Drawing.Point(14, 105);
            tbSziltechSecurityCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbSziltechSecurityCode.Name = "tbSziltechSecurityCode";
            tbSziltechSecurityCode.Size = new System.Drawing.Size(312, 23);
            tbSziltechSecurityCode.TabIndex = 3;
            // 
            // rb_SziltechSecurityCode
            // 
            rb_SziltechSecurityCode.AutoSize = true;
            rb_SziltechSecurityCode.Location = new System.Drawing.Point(14, 78);
            rb_SziltechSecurityCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rb_SziltechSecurityCode.Name = "rb_SziltechSecurityCode";
            rb_SziltechSecurityCode.Size = new System.Drawing.Size(169, 19);
            rb_SziltechSecurityCode.TabIndex = 2;
            rb_SziltechSecurityCode.Text = "Sziltech security code (SSC)";
            rb_SziltechSecurityCode.UseVisualStyleBackColor = true;
            // 
            // tb_DatabaseSaPassword
            // 
            tb_DatabaseSaPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_DatabaseSaPassword.Location = new System.Drawing.Point(14, 48);
            tb_DatabaseSaPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_DatabaseSaPassword.Name = "tb_DatabaseSaPassword";
            tb_DatabaseSaPassword.Password = "";
            tb_DatabaseSaPassword.PasswordChar = '*';
            tb_DatabaseSaPassword.ShowRealPasswordLength = false;
            tb_DatabaseSaPassword.Size = new System.Drawing.Size(312, 23);
            tb_DatabaseSaPassword.TabIndex = 1;
            // 
            // rb_DatabaseSaPassword
            // 
            rb_DatabaseSaPassword.AutoSize = true;
            rb_DatabaseSaPassword.Checked = true;
            rb_DatabaseSaPassword.Location = new System.Drawing.Point(14, 22);
            rb_DatabaseSaPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rb_DatabaseSaPassword.Name = "rb_DatabaseSaPassword";
            rb_DatabaseSaPassword.Size = new System.Drawing.Size(140, 19);
            rb_DatabaseSaPassword.TabIndex = 0;
            rb_DatabaseSaPassword.TabStop = true;
            rb_DatabaseSaPassword.Text = "Database sa password";
            rb_DatabaseSaPassword.UseVisualStyleBackColor = true;
            // 
            // EnterPass
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(341, 173);
            Controls.Add(gb_PleaseEnterMSSQLAdministratorPasswordOrSSC);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "EnterPass";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Please enter password";
            gb_PleaseEnterMSSQLAdministratorPasswordOrSSC.ResumeLayout(false);
            gb_PleaseEnterMSSQLAdministratorPasswordOrSSC.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox gb_PleaseEnterMSSQLAdministratorPasswordOrSSC;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.TextBox tbSziltechSecurityCode;
        private System.Windows.Forms.RadioButton rb_SziltechSecurityCode;
        private Mtf.Controls.PasswordBox tb_DatabaseSaPassword;
        private System.Windows.Forms.RadioButton rb_DatabaseSaPassword;
    }
}
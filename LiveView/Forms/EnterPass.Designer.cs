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
            gbPleaseEnterMSSQLAdministratorPasswordOrSSC = new System.Windows.Forms.GroupBox();
            btnOK = new System.Windows.Forms.Button();
            tbSziltechSecurityCode = new System.Windows.Forms.TextBox();
            rbSziltechSecurityCode = new System.Windows.Forms.RadioButton();
            tbDatabaseSaPassword = new Mtf.Controls.PasswordBox();
            rbDatabaseSaPassword = new System.Windows.Forms.RadioButton();
            gbPleaseEnterMSSQLAdministratorPasswordOrSSC.SuspendLayout();
            SuspendLayout();
            // 
            // gbPleaseEnterMSSQLAdministratorPasswordOrSSC
            // 
            gbPleaseEnterMSSQLAdministratorPasswordOrSSC.Controls.Add(btnOK);
            gbPleaseEnterMSSQLAdministratorPasswordOrSSC.Controls.Add(tbSziltechSecurityCode);
            gbPleaseEnterMSSQLAdministratorPasswordOrSSC.Controls.Add(rbSziltechSecurityCode);
            gbPleaseEnterMSSQLAdministratorPasswordOrSSC.Controls.Add(tbDatabaseSaPassword);
            gbPleaseEnterMSSQLAdministratorPasswordOrSSC.Controls.Add(rbDatabaseSaPassword);
            gbPleaseEnterMSSQLAdministratorPasswordOrSSC.Dock = System.Windows.Forms.DockStyle.Fill;
            gbPleaseEnterMSSQLAdministratorPasswordOrSSC.Location = new System.Drawing.Point(0, 0);
            gbPleaseEnterMSSQLAdministratorPasswordOrSSC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbPleaseEnterMSSQLAdministratorPasswordOrSSC.Name = "gbPleaseEnterMSSQLAdministratorPasswordOrSSC";
            gbPleaseEnterMSSQLAdministratorPasswordOrSSC.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbPleaseEnterMSSQLAdministratorPasswordOrSSC.Size = new System.Drawing.Size(341, 173);
            gbPleaseEnterMSSQLAdministratorPasswordOrSSC.TabIndex = 1;
            gbPleaseEnterMSSQLAdministratorPasswordOrSSC.TabStop = false;
            gbPleaseEnterMSSQLAdministratorPasswordOrSSC.Text = "Please enter MSSQL administrator password or SSC";
            // 
            // btnOK
            // 
            btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOK.Location = new System.Drawing.Point(239, 135);
            btnOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnOK.Name = "btnOK";
            btnOK.Size = new System.Drawing.Size(88, 27);
            btnOK.TabIndex = 4;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += BtnOK_Click;
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
            // rbSziltechSecurityCode
            // 
            rbSziltechSecurityCode.AutoSize = true;
            rbSziltechSecurityCode.Location = new System.Drawing.Point(14, 78);
            rbSziltechSecurityCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rbSziltechSecurityCode.Name = "rbSziltechSecurityCode";
            rbSziltechSecurityCode.Size = new System.Drawing.Size(169, 19);
            rbSziltechSecurityCode.TabIndex = 2;
            rbSziltechSecurityCode.Text = "Sziltech security code (SSC)";
            rbSziltechSecurityCode.UseVisualStyleBackColor = true;
            // 
            // tbDatabaseSaPassword
            // 
            tbDatabaseSaPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbDatabaseSaPassword.Location = new System.Drawing.Point(14, 48);
            tbDatabaseSaPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbDatabaseSaPassword.Name = "tbDatabaseSaPassword";
            tbDatabaseSaPassword.Password = "";
            tbDatabaseSaPassword.PasswordChar = '*';
            tbDatabaseSaPassword.ShowRealPasswordLength = false;
            tbDatabaseSaPassword.Size = new System.Drawing.Size(312, 23);
            tbDatabaseSaPassword.TabIndex = 1;
            // 
            // rbDatabaseSaPassword
            // 
            rbDatabaseSaPassword.AutoSize = true;
            rbDatabaseSaPassword.Checked = true;
            rbDatabaseSaPassword.Location = new System.Drawing.Point(14, 22);
            rbDatabaseSaPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rbDatabaseSaPassword.Name = "rbDatabaseSaPassword";
            rbDatabaseSaPassword.Size = new System.Drawing.Size(140, 19);
            rbDatabaseSaPassword.TabIndex = 0;
            rbDatabaseSaPassword.TabStop = true;
            rbDatabaseSaPassword.Text = "Database sa password";
            rbDatabaseSaPassword.UseVisualStyleBackColor = true;
            // 
            // EnterPass
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(341, 173);
            Controls.Add(gbPleaseEnterMSSQLAdministratorPasswordOrSSC);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "EnterPass";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Please enter password";
            Shown += EnterPass_Shown;
            gbPleaseEnterMSSQLAdministratorPasswordOrSSC.ResumeLayout(false);
            gbPleaseEnterMSSQLAdministratorPasswordOrSSC.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox gbPleaseEnterMSSQLAdministratorPasswordOrSSC;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tbSziltechSecurityCode;
        private System.Windows.Forms.RadioButton rbSziltechSecurityCode;
        private Mtf.Controls.PasswordBox tbDatabaseSaPassword;
        private System.Windows.Forms.RadioButton rbDatabaseSaPassword;
    }
}
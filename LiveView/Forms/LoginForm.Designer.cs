namespace LiveView.Forms
{
    partial class LoginForm
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
            pMain = new System.Windows.Forms.Panel();
            gbPrimaryLogin = new System.Windows.Forms.GroupBox();
            tbPassword = new Mtf.Controls.PasswordBox();
            lblPassword = new System.Windows.Forms.Label();
            tbUsername = new System.Windows.Forms.TextBox();
            lblUsername = new System.Windows.Forms.Label();
            btnClose = new System.Windows.Forms.Button();
            btnOk = new System.Windows.Forms.Button();
            pMain.SuspendLayout();
            gbPrimaryLogin.SuspendLayout();
            SuspendLayout();
            // 
            // pMain
            // 
            pMain.Controls.Add(gbPrimaryLogin);
            pMain.Controls.Add(btnClose);
            pMain.Controls.Add(btnOk);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(300, 173);
            pMain.TabIndex = 0;
            // 
            // gbPrimaryLogin
            // 
            gbPrimaryLogin.Controls.Add(tbPassword);
            gbPrimaryLogin.Controls.Add(lblPassword);
            gbPrimaryLogin.Controls.Add(tbUsername);
            gbPrimaryLogin.Controls.Add(lblUsername);
            gbPrimaryLogin.Dock = System.Windows.Forms.DockStyle.Top;
            gbPrimaryLogin.Location = new System.Drawing.Point(0, 0);
            gbPrimaryLogin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbPrimaryLogin.Name = "gbPrimaryLogin";
            gbPrimaryLogin.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbPrimaryLogin.Size = new System.Drawing.Size(300, 136);
            gbPrimaryLogin.TabIndex = 4;
            gbPrimaryLogin.TabStop = false;
            gbPrimaryLogin.Text = "Secondary login";
            // 
            // tbPassword
            // 
            tbPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbPassword.Location = new System.Drawing.Point(7, 96);
            tbPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbPassword.MaxLength = 100;
            tbPassword.Name = "tbPassword";
            tbPassword.Password = "";
            tbPassword.PasswordChar = '*';
            tbPassword.ShowRealPasswordLength = true;
            tbPassword.Size = new System.Drawing.Size(281, 23);
            tbPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new System.Drawing.Point(4, 74);
            lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(57, 15);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password";
            // 
            // tbUsername
            // 
            tbUsername.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbUsername.Location = new System.Drawing.Point(7, 45);
            tbUsername.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbUsername.MaxLength = 100;
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new System.Drawing.Size(281, 23);
            tbUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new System.Drawing.Point(4, 23);
            lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new System.Drawing.Size(60, 15);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username";
            // 
            // btnClose
            // 
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.Location = new System.Drawing.Point(200, 142);
            btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(88, 27);
            btnClose.TabIndex = 7;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            // 
            // btnOk
            // 
            btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOk.Location = new System.Drawing.Point(105, 142);
            btnOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(88, 27);
            btnOk.TabIndex = 6;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += BtnOk_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(300, 173);
            Controls.Add(pMain);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(316, 212);
            Name = "LoginForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Secondary login";
            TopMost = true;
            Shown += LoginForm_Shown;
            pMain.ResumeLayout(false);
            gbPrimaryLogin.ResumeLayout(false);
            gbPrimaryLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.GroupBox gbPrimaryLogin;
        private Mtf.Controls.PasswordBox tbPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
    }
}
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            pMain = new System.Windows.Forms.Panel();
            gb_SecondaryLogin = new System.Windows.Forms.GroupBox();
            chk_SecondaryLogin = new System.Windows.Forms.CheckBox();
            tbSecondaryPassword = new Mtf.Controls.PasswordBox();
            lblSecondaryPassword = new System.Windows.Forms.Label();
            tbSecondaryUsername = new System.Windows.Forms.TextBox();
            lblSecondaryUsername = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            tbPassword = new Mtf.Controls.PasswordBox();
            lblPassword = new System.Windows.Forms.Label();
            tbUsername = new System.Windows.Forms.TextBox();
            lblUsername = new System.Windows.Forms.Label();
            btnClose = new System.Windows.Forms.Button();
            btnOk = new System.Windows.Forms.Button();
            pMain.SuspendLayout();
            gb_SecondaryLogin.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pMain
            // 
            pMain.Controls.Add(gb_SecondaryLogin);
            pMain.Controls.Add(groupBox1);
            pMain.Controls.Add(btnClose);
            pMain.Controls.Add(btnOk);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(400, 310);
            pMain.TabIndex = 0;
            // 
            // gb_SecondaryLogin
            // 
            gb_SecondaryLogin.Controls.Add(chk_SecondaryLogin);
            gb_SecondaryLogin.Controls.Add(tbSecondaryPassword);
            gb_SecondaryLogin.Controls.Add(lblSecondaryPassword);
            gb_SecondaryLogin.Controls.Add(tbSecondaryUsername);
            gb_SecondaryLogin.Controls.Add(lblSecondaryUsername);
            gb_SecondaryLogin.Dock = System.Windows.Forms.DockStyle.Top;
            gb_SecondaryLogin.Location = new System.Drawing.Point(0, 136);
            gb_SecondaryLogin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_SecondaryLogin.Name = "gb_SecondaryLogin";
            gb_SecondaryLogin.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_SecondaryLogin.Size = new System.Drawing.Size(400, 136);
            gb_SecondaryLogin.TabIndex = 5;
            gb_SecondaryLogin.TabStop = false;
            gb_SecondaryLogin.Text = " ";
            // 
            // chk_SecondaryLogin
            // 
            chk_SecondaryLogin.AutoSize = true;
            chk_SecondaryLogin.Location = new System.Drawing.Point(14, 0);
            chk_SecondaryLogin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chk_SecondaryLogin.Name = "chk_SecondaryLogin";
            chk_SecondaryLogin.Size = new System.Drawing.Size(111, 19);
            chk_SecondaryLogin.TabIndex = 0;
            chk_SecondaryLogin.Text = "Secondary login";
            chk_SecondaryLogin.UseVisualStyleBackColor = true;
            // 
            // tbSecondaryPassword
            // 
            tbSecondaryPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbSecondaryPassword.Enabled = false;
            tbSecondaryPassword.Location = new System.Drawing.Point(7, 105);
            tbSecondaryPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbSecondaryPassword.MaxLength = 100;
            tbSecondaryPassword.Name = "tbSecondaryPassword";
            tbSecondaryPassword.Password = "";
            tbSecondaryPassword.PasswordChar = '*';
            tbSecondaryPassword.ShowRealPasswordLength = false;
            tbSecondaryPassword.Size = new System.Drawing.Size(381, 23);
            tbSecondaryPassword.TabIndex = 4;
            // 
            // lblSecondaryPassword
            // 
            lblSecondaryPassword.AutoSize = true;
            lblSecondaryPassword.Enabled = false;
            lblSecondaryPassword.Location = new System.Drawing.Point(4, 83);
            lblSecondaryPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSecondaryPassword.Name = "lblSecondaryPassword";
            lblSecondaryPassword.Size = new System.Drawing.Size(57, 15);
            lblSecondaryPassword.TabIndex = 3;
            lblSecondaryPassword.Text = "Password";
            // 
            // tbSecondaryUsername
            // 
            tbSecondaryUsername.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbSecondaryUsername.Enabled = false;
            tbSecondaryUsername.Location = new System.Drawing.Point(7, 54);
            tbSecondaryUsername.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbSecondaryUsername.MaxLength = 100;
            tbSecondaryUsername.Name = "tbSecondaryUsername";
            tbSecondaryUsername.Size = new System.Drawing.Size(381, 23);
            tbSecondaryUsername.TabIndex = 2;
            // 
            // lblSecondaryUsername
            // 
            lblSecondaryUsername.AutoSize = true;
            lblSecondaryUsername.Enabled = false;
            lblSecondaryUsername.Location = new System.Drawing.Point(4, 32);
            lblSecondaryUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSecondaryUsername.Name = "lblSecondaryUsername";
            lblSecondaryUsername.Size = new System.Drawing.Size(60, 15);
            lblSecondaryUsername.TabIndex = 1;
            lblSecondaryUsername.Text = "Username";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbPassword);
            groupBox1.Controls.Add(lblPassword);
            groupBox1.Controls.Add(tbUsername);
            groupBox1.Controls.Add(lblUsername);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox1.Location = new System.Drawing.Point(0, 0);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(400, 136);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Primary login";
            // 
            // tbPassword
            // 
            tbPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbPassword.Location = new System.Drawing.Point(7, 105);
            tbPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbPassword.MaxLength = 100;
            tbPassword.Name = "tbPassword";
            tbPassword.Password = "";
            tbPassword.PasswordChar = '*';
            tbPassword.ShowRealPasswordLength = false;
            tbPassword.Size = new System.Drawing.Size(381, 23);
            tbPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new System.Drawing.Point(4, 83);
            lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(57, 15);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password";
            // 
            // tbUsername
            // 
            tbUsername.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbUsername.Location = new System.Drawing.Point(7, 54);
            tbUsername.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbUsername.MaxLength = 100;
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new System.Drawing.Size(381, 23);
            tbUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new System.Drawing.Point(4, 32);
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
            btnClose.Location = new System.Drawing.Point(300, 275);
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
            btnOk.Location = new System.Drawing.Point(205, 275);
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
            ClientSize = new System.Drawing.Size(400, 310);
            Controls.Add(pMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "LoginForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Change user";
            TopMost = true;
            pMain.ResumeLayout(false);
            gb_SecondaryLogin.ResumeLayout(false);
            gb_SecondaryLogin.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.GroupBox gb_SecondaryLogin;
        private System.Windows.Forms.CheckBox chk_SecondaryLogin;
        private Mtf.Controls.PasswordBox tbSecondaryPassword;
        private System.Windows.Forms.Label lblSecondaryPassword;
        private System.Windows.Forms.TextBox tbSecondaryUsername;
        private System.Windows.Forms.Label lblSecondaryUsername;
        private System.Windows.Forms.GroupBox groupBox1;
        private Mtf.Controls.PasswordBox tbPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
    }
}
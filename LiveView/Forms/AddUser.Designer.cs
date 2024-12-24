namespace LiveView.Forms
{
    partial class AddUser
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
            components = new System.ComponentModel.Container();
            niIcon = new System.Windows.Forms.NotifyIcon(components);
            tbEmail = new System.Windows.Forms.TextBox();
            lblEmail = new System.Windows.Forms.Label();
            tbPassword = new Mtf.Controls.PasswordBox();
            lblPassword = new System.Windows.Forms.Label();
            tbUsername = new System.Windows.Forms.TextBox();
            btnCreate = new System.Windows.Forms.Button();
            nudNeededSecondaryLogonPriority = new System.Windows.Forms.NumericUpDown();
            lblPriority = new System.Windows.Forms.Label();
            btnClose = new System.Windows.Forms.Button();
            chkLoginSupervisorsRequiredPriority = new System.Windows.Forms.CheckBox();
            gbLoginSupervisorsRequiredPriority = new System.Windows.Forms.GroupBox();
            nudSecondaryLogonPriority = new System.Windows.Forms.NumericUpDown();
            lblPriority2 = new System.Windows.Forms.Label();
            chkLoginSupervisingPriority = new System.Windows.Forms.CheckBox();
            gbLoginSupervisingPriority = new System.Windows.Forms.GroupBox();
            pMain = new System.Windows.Forms.Panel();
            gbLoginDetails = new System.Windows.Forms.GroupBox();
            lblUsername = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)nudNeededSecondaryLogonPriority).BeginInit();
            gbLoginSupervisorsRequiredPriority.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSecondaryLogonPriority).BeginInit();
            gbLoginSupervisingPriority.SuspendLayout();
            pMain.SuspendLayout();
            gbLoginDetails.SuspendLayout();
            SuspendLayout();
            // 
            // niIcon
            // 
            niIcon.Text = "ni_Icon";
            // 
            // tbEmail
            // 
            tbEmail.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbEmail.Location = new System.Drawing.Point(158, 68);
            tbEmail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbEmail.MaxLength = 100;
            tbEmail.Name = "tbEmail";
            tbEmail.PasswordChar = '*';
            tbEmail.Size = new System.Drawing.Size(182, 23);
            tbEmail.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new System.Drawing.Point(14, 72);
            lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new System.Drawing.Size(84, 15);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "E-mail address";
            // 
            // tbPassword
            // 
            tbPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbPassword.Location = new System.Drawing.Point(158, 42);
            tbPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbPassword.MaxLength = 100;
            tbPassword.Name = "tbPassword";
            tbPassword.Password = "";
            tbPassword.PasswordChar = '*';
            tbPassword.ShowRealPasswordLength = false;
            tbPassword.Size = new System.Drawing.Size(182, 23);
            tbPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new System.Drawing.Point(14, 45);
            lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(57, 15);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password";
            // 
            // tbUsername
            // 
            tbUsername.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbUsername.Location = new System.Drawing.Point(158, 15);
            tbUsername.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbUsername.MaxLength = 100;
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new System.Drawing.Size(182, 23);
            tbUsername.TabIndex = 1;
            // 
            // btnCreate
            // 
            btnCreate.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnCreate.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnCreate.Location = new System.Drawing.Point(158, 209);
            btnCreate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new System.Drawing.Size(88, 27);
            btnCreate.TabIndex = 1;
            btnCreate.Text = "Add";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += BtnCreate_Click;
            // 
            // nudNeededSecondaryLogonPriority
            // 
            nudNeededSecondaryLogonPriority.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudNeededSecondaryLogonPriority.Enabled = false;
            nudNeededSecondaryLogonPriority.Location = new System.Drawing.Point(158, 22);
            nudNeededSecondaryLogonPriority.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudNeededSecondaryLogonPriority.Name = "nudNeededSecondaryLogonPriority";
            nudNeededSecondaryLogonPriority.Size = new System.Drawing.Size(183, 23);
            nudNeededSecondaryLogonPriority.TabIndex = 2;
            // 
            // lblPriority
            // 
            lblPriority.AutoSize = true;
            lblPriority.Enabled = false;
            lblPriority.Location = new System.Drawing.Point(14, 24);
            lblPriority.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new System.Drawing.Size(45, 15);
            lblPriority.TabIndex = 1;
            lblPriority.Text = "Priority";
            // 
            // btnClose
            // 
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.Location = new System.Drawing.Point(253, 209);
            btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(88, 27);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            // 
            // chkLoginSupervisorsRequiredPriority
            // 
            chkLoginSupervisorsRequiredPriority.AutoSize = true;
            chkLoginSupervisorsRequiredPriority.Location = new System.Drawing.Point(13, 1);
            chkLoginSupervisorsRequiredPriority.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkLoginSupervisorsRequiredPriority.Name = "chkLoginSupervisorsRequiredPriority";
            chkLoginSupervisorsRequiredPriority.Size = new System.Drawing.Size(209, 19);
            chkLoginSupervisorsRequiredPriority.TabIndex = 0;
            chkLoginSupervisorsRequiredPriority.Text = "Login supervisor's required priority";
            chkLoginSupervisorsRequiredPriority.UseVisualStyleBackColor = true;
            // 
            // gbLoginSupervisorsRequiredPriority
            // 
            gbLoginSupervisorsRequiredPriority.Controls.Add(nudNeededSecondaryLogonPriority);
            gbLoginSupervisorsRequiredPriority.Controls.Add(lblPriority);
            gbLoginSupervisorsRequiredPriority.Controls.Add(chkLoginSupervisorsRequiredPriority);
            gbLoginSupervisorsRequiredPriority.Dock = System.Windows.Forms.DockStyle.Top;
            gbLoginSupervisorsRequiredPriority.Location = new System.Drawing.Point(0, 98);
            gbLoginSupervisorsRequiredPriority.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbLoginSupervisorsRequiredPriority.Name = "gbLoginSupervisorsRequiredPriority";
            gbLoginSupervisorsRequiredPriority.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbLoginSupervisorsRequiredPriority.Size = new System.Drawing.Size(348, 52);
            gbLoginSupervisorsRequiredPriority.TabIndex = 3;
            gbLoginSupervisorsRequiredPriority.TabStop = false;
            gbLoginSupervisorsRequiredPriority.Text = " ";
            // 
            // nudSecondaryLogonPriority
            // 
            nudSecondaryLogonPriority.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudSecondaryLogonPriority.Enabled = false;
            nudSecondaryLogonPriority.Location = new System.Drawing.Point(158, 22);
            nudSecondaryLogonPriority.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudSecondaryLogonPriority.Name = "nudSecondaryLogonPriority";
            nudSecondaryLogonPriority.Size = new System.Drawing.Size(183, 23);
            nudSecondaryLogonPriority.TabIndex = 3;
            // 
            // lblPriority2
            // 
            lblPriority2.AutoSize = true;
            lblPriority2.Enabled = false;
            lblPriority2.Location = new System.Drawing.Point(14, 24);
            lblPriority2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPriority2.Name = "lblPriority2";
            lblPriority2.Size = new System.Drawing.Size(45, 15);
            lblPriority2.TabIndex = 2;
            lblPriority2.Text = "Priority";
            // 
            // chkLoginSupervisingPriority
            // 
            chkLoginSupervisingPriority.AutoSize = true;
            chkLoginSupervisingPriority.Location = new System.Drawing.Point(13, 1);
            chkLoginSupervisingPriority.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkLoginSupervisingPriority.Name = "chkLoginSupervisingPriority";
            chkLoginSupervisingPriority.Size = new System.Drawing.Size(160, 19);
            chkLoginSupervisingPriority.TabIndex = 1;
            chkLoginSupervisingPriority.Text = "Login supervising priority";
            chkLoginSupervisingPriority.UseVisualStyleBackColor = true;
            // 
            // gbLoginSupervisingPriority
            // 
            gbLoginSupervisingPriority.Controls.Add(nudSecondaryLogonPriority);
            gbLoginSupervisingPriority.Controls.Add(lblPriority2);
            gbLoginSupervisingPriority.Controls.Add(chkLoginSupervisingPriority);
            gbLoginSupervisingPriority.Dock = System.Windows.Forms.DockStyle.Top;
            gbLoginSupervisingPriority.Location = new System.Drawing.Point(0, 150);
            gbLoginSupervisingPriority.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbLoginSupervisingPriority.Name = "gbLoginSupervisingPriority";
            gbLoginSupervisingPriority.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbLoginSupervisingPriority.Size = new System.Drawing.Size(348, 52);
            gbLoginSupervisingPriority.TabIndex = 4;
            gbLoginSupervisingPriority.TabStop = false;
            gbLoginSupervisingPriority.Text = " ";
            // 
            // pMain
            // 
            pMain.Controls.Add(gbLoginSupervisingPriority);
            pMain.Controls.Add(gbLoginSupervisorsRequiredPriority);
            pMain.Controls.Add(btnClose);
            pMain.Controls.Add(btnCreate);
            pMain.Controls.Add(gbLoginDetails);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(348, 240);
            pMain.TabIndex = 1;
            // 
            // gbLoginDetails
            // 
            gbLoginDetails.Controls.Add(tbEmail);
            gbLoginDetails.Controls.Add(lblEmail);
            gbLoginDetails.Controls.Add(tbPassword);
            gbLoginDetails.Controls.Add(lblPassword);
            gbLoginDetails.Controls.Add(tbUsername);
            gbLoginDetails.Controls.Add(lblUsername);
            gbLoginDetails.Dock = System.Windows.Forms.DockStyle.Top;
            gbLoginDetails.Location = new System.Drawing.Point(0, 0);
            gbLoginDetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbLoginDetails.Name = "gbLoginDetails";
            gbLoginDetails.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbLoginDetails.Size = new System.Drawing.Size(348, 98);
            gbLoginDetails.TabIndex = 0;
            gbLoginDetails.TabStop = false;
            gbLoginDetails.Text = "Login details";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new System.Drawing.Point(14, 18);
            lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new System.Drawing.Size(60, 15);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username";
            // 
            // AddUser
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(348, 240);
            Controls.Add(pMain);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(354, 265);
            Name = "AddUser";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Add user";
            TopMost = true;
            Shown += AddUser_Shown;
            ((System.ComponentModel.ISupportInitialize)nudNeededSecondaryLogonPriority).EndInit();
            gbLoginSupervisorsRequiredPriority.ResumeLayout(false);
            gbLoginSupervisorsRequiredPriority.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSecondaryLogonPriority).EndInit();
            gbLoginSupervisingPriority.ResumeLayout(false);
            gbLoginSupervisingPriority.PerformLayout();
            pMain.ResumeLayout(false);
            gbLoginDetails.ResumeLayout(false);
            gbLoginDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.NotifyIcon niIcon;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label lblEmail;
        private Mtf.Controls.PasswordBox tbPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.NumericUpDown nudNeededSecondaryLogonPriority;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkLoginSupervisorsRequiredPriority;
        private System.Windows.Forms.GroupBox gbLoginSupervisorsRequiredPriority;
        private System.Windows.Forms.NumericUpDown nudSecondaryLogonPriority;
        private System.Windows.Forms.Label lblPriority2;
        private System.Windows.Forms.CheckBox chkLoginSupervisingPriority;
        private System.Windows.Forms.GroupBox gbLoginSupervisingPriority;
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.GroupBox gbLoginDetails;
        private System.Windows.Forms.Label lblUsername;
    }
}
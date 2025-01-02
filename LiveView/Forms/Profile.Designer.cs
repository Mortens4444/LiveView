namespace LiveView.Forms
{
    partial class Profile
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
            tbCurrentPassword = new Mtf.Controls.PasswordBox();
            lblCurrentPassword = new System.Windows.Forms.Label();
            tbNewPassword = new System.Windows.Forms.TextBox();
            lblNewPassword = new System.Windows.Forms.Label();
            lblUsername = new System.Windows.Forms.Label();
            gbCredentials = new System.Windows.Forms.GroupBox();
            tbUsername = new System.Windows.Forms.TextBox();
            tbLicensePlate = new System.Windows.Forms.TextBox();
            lblLicensePlate = new System.Windows.Forms.Label();
            lblOtherInformation = new System.Windows.Forms.Label();
            tbOtherInformation = new System.Windows.Forms.TextBox();
            tbTelephoneNumber = new System.Windows.Forms.TextBox();
            lblTelephoneNumber = new System.Windows.Forms.Label();
            tbEmailAddress = new System.Windows.Forms.TextBox();
            lblEmailAddress = new System.Windows.Forms.Label();
            tbAddress = new System.Windows.Forms.TextBox();
            lblAddress = new System.Windows.Forms.Label();
            tbFullName = new System.Windows.Forms.TextBox();
            lblFullName = new System.Windows.Forms.Label();
            pbPicture = new Mtf.Controls.MtfPictureBox();
            lblSizeMode = new System.Windows.Forms.Label();
            cbSizeMode = new System.Windows.Forms.ComboBox();
            btnSelectPicture = new System.Windows.Forms.Button();
            btnClose = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            gbPicture = new System.Windows.Forms.GroupBox();
            gbPersonalDetails = new System.Windows.Forms.GroupBox();
            pMain = new System.Windows.Forms.Panel();
            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            gbCredentials.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPicture).BeginInit();
            gbPicture.SuspendLayout();
            gbPersonalDetails.SuspendLayout();
            pMain.SuspendLayout();
            SuspendLayout();
            // 
            // tbCurrentPassword
            // 
            tbCurrentPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbCurrentPassword.Location = new System.Drawing.Point(197, 42);
            tbCurrentPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbCurrentPassword.MaxLength = 100;
            tbCurrentPassword.Name = "tbCurrentPassword";
            tbCurrentPassword.Password = "";
            tbCurrentPassword.PasswordChar = '*';
            tbCurrentPassword.ShowRealPasswordLength = false;
            tbCurrentPassword.Size = new System.Drawing.Size(176, 23);
            tbCurrentPassword.TabIndex = 3;
            // 
            // lblCurrentPassword
            // 
            lblCurrentPassword.AutoSize = true;
            lblCurrentPassword.Location = new System.Drawing.Point(10, 45);
            lblCurrentPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCurrentPassword.MaximumSize = new System.Drawing.Size(176, 15);
            lblCurrentPassword.Name = "lblCurrentPassword";
            lblCurrentPassword.Size = new System.Drawing.Size(100, 15);
            lblCurrentPassword.TabIndex = 2;
            lblCurrentPassword.Text = "Current password";
            // 
            // tbNewPassword
            // 
            tbNewPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbNewPassword.Location = new System.Drawing.Point(197, 68);
            tbNewPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbNewPassword.MaxLength = 100;
            tbNewPassword.Name = "tbNewPassword";
            tbNewPassword.PasswordChar = '*';
            tbNewPassword.Size = new System.Drawing.Size(176, 23);
            tbNewPassword.TabIndex = 5;
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Location = new System.Drawing.Point(10, 72);
            lblNewPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblNewPassword.MaximumSize = new System.Drawing.Size(176, 15);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new System.Drawing.Size(84, 15);
            lblNewPassword.TabIndex = 4;
            lblNewPassword.Text = "New password";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new System.Drawing.Point(10, 18);
            lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblUsername.MaximumSize = new System.Drawing.Size(176, 15);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new System.Drawing.Size(60, 15);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username";
            // 
            // gbCredentials
            // 
            gbCredentials.Controls.Add(tbCurrentPassword);
            gbCredentials.Controls.Add(lblCurrentPassword);
            gbCredentials.Controls.Add(tbNewPassword);
            gbCredentials.Controls.Add(lblNewPassword);
            gbCredentials.Controls.Add(tbUsername);
            gbCredentials.Controls.Add(lblUsername);
            gbCredentials.Location = new System.Drawing.Point(0, 3);
            gbCredentials.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbCredentials.Name = "gbCredentials";
            gbCredentials.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbCredentials.Size = new System.Drawing.Size(380, 102);
            gbCredentials.TabIndex = 0;
            gbCredentials.TabStop = false;
            gbCredentials.Text = "Credentials";
            // 
            // tbUsername
            // 
            tbUsername.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbUsername.Location = new System.Drawing.Point(197, 15);
            tbUsername.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbUsername.MaxLength = 100;
            tbUsername.Name = "tbUsername";
            tbUsername.ReadOnly = true;
            tbUsername.Size = new System.Drawing.Size(176, 23);
            tbUsername.TabIndex = 1;
            tbUsername.TabStop = false;
            // 
            // tbLicensePlate
            // 
            tbLicensePlate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbLicensePlate.Location = new System.Drawing.Point(197, 125);
            tbLicensePlate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbLicensePlate.MaxLength = 50;
            tbLicensePlate.Name = "tbLicensePlate";
            tbLicensePlate.Size = new System.Drawing.Size(176, 23);
            tbLicensePlate.TabIndex = 11;
            // 
            // lblLicensePlate
            // 
            lblLicensePlate.AutoSize = true;
            lblLicensePlate.Location = new System.Drawing.Point(10, 128);
            lblLicensePlate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblLicensePlate.MaximumSize = new System.Drawing.Size(176, 15);
            lblLicensePlate.Name = "lblLicensePlate";
            lblLicensePlate.Size = new System.Drawing.Size(77, 15);
            lblLicensePlate.TabIndex = 10;
            lblLicensePlate.Text = "License-plate";
            // 
            // lblOtherInformation
            // 
            lblOtherInformation.AutoSize = true;
            lblOtherInformation.Location = new System.Drawing.Point(10, 155);
            lblOtherInformation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblOtherInformation.Name = "lblOtherInformation";
            lblOtherInformation.Size = new System.Drawing.Size(103, 15);
            lblOtherInformation.TabIndex = 8;
            lblOtherInformation.Text = "Other information";
            // 
            // tbOtherInformation
            // 
            tbOtherInformation.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbOtherInformation.Location = new System.Drawing.Point(7, 173);
            tbOtherInformation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbOtherInformation.Multiline = true;
            tbOtherInformation.Name = "tbOtherInformation";
            tbOtherInformation.Size = new System.Drawing.Size(366, 128);
            tbOtherInformation.TabIndex = 9;
            // 
            // tbTelephoneNumber
            // 
            tbTelephoneNumber.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbTelephoneNumber.Location = new System.Drawing.Point(197, 98);
            tbTelephoneNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbTelephoneNumber.MaxLength = 50;
            tbTelephoneNumber.Name = "tbTelephoneNumber";
            tbTelephoneNumber.Size = new System.Drawing.Size(176, 23);
            tbTelephoneNumber.TabIndex = 7;
            // 
            // lblTelephoneNumber
            // 
            lblTelephoneNumber.AutoSize = true;
            lblTelephoneNumber.Location = new System.Drawing.Point(10, 102);
            lblTelephoneNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTelephoneNumber.MaximumSize = new System.Drawing.Size(176, 15);
            lblTelephoneNumber.Name = "lblTelephoneNumber";
            lblTelephoneNumber.Size = new System.Drawing.Size(107, 15);
            lblTelephoneNumber.TabIndex = 6;
            lblTelephoneNumber.Text = "Telephone number";
            // 
            // tbEmailAddress
            // 
            tbEmailAddress.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbEmailAddress.Location = new System.Drawing.Point(197, 72);
            tbEmailAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbEmailAddress.MaxLength = 200;
            tbEmailAddress.Name = "tbEmailAddress";
            tbEmailAddress.Size = new System.Drawing.Size(176, 23);
            tbEmailAddress.TabIndex = 5;
            // 
            // lblEmailAddress
            // 
            lblEmailAddress.AutoSize = true;
            lblEmailAddress.Location = new System.Drawing.Point(10, 75);
            lblEmailAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblEmailAddress.MaximumSize = new System.Drawing.Size(176, 15);
            lblEmailAddress.Name = "lblEmailAddress";
            lblEmailAddress.Size = new System.Drawing.Size(84, 15);
            lblEmailAddress.TabIndex = 4;
            lblEmailAddress.Text = "E-mail address";
            // 
            // tbAddress
            // 
            tbAddress.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbAddress.Location = new System.Drawing.Point(197, 45);
            tbAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbAddress.MaxLength = 200;
            tbAddress.Name = "tbAddress";
            tbAddress.Size = new System.Drawing.Size(176, 23);
            tbAddress.TabIndex = 3;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new System.Drawing.Point(10, 48);
            lblAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblAddress.MaximumSize = new System.Drawing.Size(176, 15);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new System.Drawing.Size(49, 15);
            lblAddress.TabIndex = 2;
            lblAddress.Text = "Address";
            // 
            // tbFullName
            // 
            tbFullName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbFullName.Location = new System.Drawing.Point(197, 18);
            tbFullName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbFullName.MaxLength = 100;
            tbFullName.Name = "tbFullName";
            tbFullName.Size = new System.Drawing.Size(176, 23);
            tbFullName.TabIndex = 1;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new System.Drawing.Point(10, 22);
            lblFullName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblFullName.MaximumSize = new System.Drawing.Size(176, 15);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new System.Drawing.Size(59, 15);
            lblFullName.TabIndex = 0;
            lblFullName.Text = "Full name";
            // 
            // pbPicture
            // 
            pbPicture.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pbPicture.BackColor = System.Drawing.SystemColors.AppWorkspace;
            pbPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pbPicture.Location = new System.Drawing.Point(7, 68);
            pbPicture.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pbPicture.Name = "pbPicture";
            pbPicture.OriginalSize = new System.Drawing.Size(100, 50);
            pbPicture.RepositioningAndResizingControlsOnResize = false;
            pbPicture.Size = new System.Drawing.Size(244, 341);
            pbPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbPicture.TabIndex = 5;
            pbPicture.TabStop = false;
            // 
            // lblSizeMode
            // 
            lblSizeMode.AutoSize = true;
            lblSizeMode.Location = new System.Drawing.Point(7, 18);
            lblSizeMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSizeMode.Name = "lblSizeMode";
            lblSizeMode.Size = new System.Drawing.Size(61, 15);
            lblSizeMode.TabIndex = 3;
            lblSizeMode.Text = "Size mode";
            // 
            // cbSizeMode
            // 
            cbSizeMode.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbSizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbSizeMode.FormattingEnabled = true;
            cbSizeMode.Location = new System.Drawing.Point(7, 42);
            cbSizeMode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbSizeMode.Name = "cbSizeMode";
            cbSizeMode.Size = new System.Drawing.Size(244, 23);
            cbSizeMode.TabIndex = 4;
            // 
            // btnSelectPicture
            // 
            btnSelectPicture.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSelectPicture.Location = new System.Drawing.Point(142, 13);
            btnSelectPicture.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSelectPicture.Name = "btnSelectPicture";
            btnSelectPicture.Size = new System.Drawing.Size(110, 27);
            btnSelectPicture.TabIndex = 2;
            btnSelectPicture.Text = "Select image";
            btnSelectPicture.UseVisualStyleBackColor = true;
            btnSelectPicture.Click += BtnSelectPicture_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.Location = new System.Drawing.Point(559, 427);
            btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(88, 27);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSave.Location = new System.Drawing.Point(464, 427);
            btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(88, 27);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += BtnSave_Click;
            // 
            // gbPicture
            // 
            gbPicture.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gbPicture.Controls.Add(pbPicture);
            gbPicture.Controls.Add(lblSizeMode);
            gbPicture.Controls.Add(cbSizeMode);
            gbPicture.Controls.Add(btnSelectPicture);
            gbPicture.Location = new System.Drawing.Point(387, 3);
            gbPicture.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbPicture.Name = "gbPicture";
            gbPicture.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbPicture.Size = new System.Drawing.Size(259, 417);
            gbPicture.TabIndex = 2;
            gbPicture.TabStop = false;
            gbPicture.Text = "Picture";
            // 
            // gbPersonalDetails
            // 
            gbPersonalDetails.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            gbPersonalDetails.Controls.Add(tbLicensePlate);
            gbPersonalDetails.Controls.Add(lblLicensePlate);
            gbPersonalDetails.Controls.Add(lblOtherInformation);
            gbPersonalDetails.Controls.Add(tbOtherInformation);
            gbPersonalDetails.Controls.Add(tbTelephoneNumber);
            gbPersonalDetails.Controls.Add(lblTelephoneNumber);
            gbPersonalDetails.Controls.Add(tbEmailAddress);
            gbPersonalDetails.Controls.Add(lblEmailAddress);
            gbPersonalDetails.Controls.Add(tbAddress);
            gbPersonalDetails.Controls.Add(lblAddress);
            gbPersonalDetails.Controls.Add(tbFullName);
            gbPersonalDetails.Controls.Add(lblFullName);
            gbPersonalDetails.Location = new System.Drawing.Point(0, 111);
            gbPersonalDetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbPersonalDetails.Name = "gbPersonalDetails";
            gbPersonalDetails.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbPersonalDetails.Size = new System.Drawing.Size(380, 309);
            gbPersonalDetails.TabIndex = 1;
            gbPersonalDetails.TabStop = false;
            gbPersonalDetails.Text = "Personal details";
            // 
            // pMain
            // 
            pMain.Controls.Add(btnClose);
            pMain.Controls.Add(btnSave);
            pMain.Controls.Add(gbPicture);
            pMain.Controls.Add(gbPersonalDetails);
            pMain.Controls.Add(gbCredentials);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(654, 458);
            pMain.TabIndex = 1;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "ProfilePicture.jpg";
            openFileDialog.Filter = "BMP files|*.bmp|JPG files|*.jpg";
            // 
            // Profile
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(654, 458);
            Controls.Add(pMain);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(661, 432);
            Name = "Profile";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Profile";
            TopMost = true;
            Shown += Profile_Shown;
            gbCredentials.ResumeLayout(false);
            gbCredentials.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPicture).EndInit();
            gbPicture.ResumeLayout(false);
            gbPicture.PerformLayout();
            gbPersonalDetails.ResumeLayout(false);
            gbPersonalDetails.PerformLayout();
            pMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Mtf.Controls.PasswordBox tbCurrentPassword;
        private System.Windows.Forms.Label lblCurrentPassword;
        private Mtf.Controls.PasswordBox tbConfirmNewPassword;
        private System.Windows.Forms.Label lblConfirmNewPassword;
        private System.Windows.Forms.TextBox tbNewPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.GroupBox gbCredentials;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbLicensePlate;
        private System.Windows.Forms.Label lblLicensePlate;
        private System.Windows.Forms.Label lblOtherInformation;
        private System.Windows.Forms.TextBox tbOtherInformation;
        private System.Windows.Forms.TextBox tbTelephoneNumber;
        private System.Windows.Forms.Label lblTelephoneNumber;
        private System.Windows.Forms.TextBox tbEmailAddress;
        private System.Windows.Forms.Label lblEmailAddress;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox tbFullName;
        private System.Windows.Forms.Label lblFullName;
        private Mtf.Controls.MtfPictureBox pbPicture;
        private System.Windows.Forms.Label lblSizeMode;
        private System.Windows.Forms.ComboBox cbSizeMode;
        private System.Windows.Forms.Button btnSelectPicture;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbPicture;
        private System.Windows.Forms.GroupBox gbPersonalDetails;
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Profile));
            tb_CurrentPassword = new Mtf.Controls.PasswordBox();
            lbl_CurrentPassword = new System.Windows.Forms.Label();
            tb_ConfirmNewPassword = new Mtf.Controls.PasswordBox();
            lbl_ConfirmNewPassword = new System.Windows.Forms.Label();
            tb_NewPassword = new System.Windows.Forms.TextBox();
            lbl_NewPassword = new System.Windows.Forms.Label();
            lbl_Username = new System.Windows.Forms.Label();
            gb_Credentials = new System.Windows.Forms.GroupBox();
            tb_Username = new System.Windows.Forms.TextBox();
            tb_LicensePlate = new System.Windows.Forms.TextBox();
            lbl_LicensePlate = new System.Windows.Forms.Label();
            lbl_OtherInformations = new System.Windows.Forms.Label();
            tb_OtherInformations = new System.Windows.Forms.TextBox();
            tb_TelephoneNumber = new System.Windows.Forms.TextBox();
            lbl_TelephoneNumber = new System.Windows.Forms.Label();
            tb_EmailAddress = new System.Windows.Forms.TextBox();
            lbl_EmailAddress = new System.Windows.Forms.Label();
            tb_Address = new System.Windows.Forms.TextBox();
            lbl_Address = new System.Windows.Forms.Label();
            tb_FullName = new System.Windows.Forms.TextBox();
            lbl_FullName = new System.Windows.Forms.Label();
            pb_Picture = new Mtf.Controls.MtfPictureBox();
            lbl_SizeMode = new System.Windows.Forms.Label();
            cb_SizeMode = new System.Windows.Forms.ComboBox();
            btn_SelectPicture = new System.Windows.Forms.Button();
            btn_Close = new System.Windows.Forms.Button();
            btn_Save = new System.Windows.Forms.Button();
            gb_Picture = new System.Windows.Forms.GroupBox();
            gb_PersonalDetails = new System.Windows.Forms.GroupBox();
            p_Main = new System.Windows.Forms.Panel();
            gb_Credentials.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Picture).BeginInit();
            gb_Picture.SuspendLayout();
            gb_PersonalDetails.SuspendLayout();
            p_Main.SuspendLayout();
            SuspendLayout();
            // 
            // tb_CurrentPassword
            // 
            tb_CurrentPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_CurrentPassword.Location = new System.Drawing.Point(197, 42);
            tb_CurrentPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_CurrentPassword.MaxLength = 100;
            tb_CurrentPassword.Name = "tb_CurrentPassword";
            tb_CurrentPassword.Password = "";
            tb_CurrentPassword.PasswordChar = '*';
            tb_CurrentPassword.ShowRealPasswordLength = false;
            tb_CurrentPassword.Size = new System.Drawing.Size(176, 23);
            tb_CurrentPassword.TabIndex = 3;
            // 
            // lbl_CurrentPassword
            // 
            lbl_CurrentPassword.AutoSize = true;
            lbl_CurrentPassword.Location = new System.Drawing.Point(10, 45);
            lbl_CurrentPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_CurrentPassword.MaximumSize = new System.Drawing.Size(176, 15);
            lbl_CurrentPassword.Name = "lbl_CurrentPassword";
            lbl_CurrentPassword.Size = new System.Drawing.Size(100, 15);
            lbl_CurrentPassword.TabIndex = 2;
            lbl_CurrentPassword.Text = "Current password";
            // 
            // tb_ConfirmNewPassword
            // 
            tb_ConfirmNewPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_ConfirmNewPassword.Location = new System.Drawing.Point(197, 95);
            tb_ConfirmNewPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_ConfirmNewPassword.MaxLength = 100;
            tb_ConfirmNewPassword.Name = "tb_ConfirmNewPassword";
            tb_ConfirmNewPassword.Password = "";
            tb_ConfirmNewPassword.PasswordChar = '*';
            tb_ConfirmNewPassword.ShowRealPasswordLength = false;
            tb_ConfirmNewPassword.Size = new System.Drawing.Size(176, 23);
            tb_ConfirmNewPassword.TabIndex = 7;
            // 
            // lbl_ConfirmNewPassword
            // 
            lbl_ConfirmNewPassword.AutoSize = true;
            lbl_ConfirmNewPassword.Location = new System.Drawing.Point(10, 98);
            lbl_ConfirmNewPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_ConfirmNewPassword.MaximumSize = new System.Drawing.Size(176, 15);
            lbl_ConfirmNewPassword.Name = "lbl_ConfirmNewPassword";
            lbl_ConfirmNewPassword.Size = new System.Drawing.Size(129, 15);
            lbl_ConfirmNewPassword.TabIndex = 6;
            lbl_ConfirmNewPassword.Text = "Confirm new password";
            // 
            // tb_NewPassword
            // 
            tb_NewPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_NewPassword.Location = new System.Drawing.Point(197, 68);
            tb_NewPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_NewPassword.MaxLength = 100;
            tb_NewPassword.Name = "tb_NewPassword";
            tb_NewPassword.PasswordChar = '*';
            tb_NewPassword.Size = new System.Drawing.Size(176, 23);
            tb_NewPassword.TabIndex = 5;
            // 
            // lbl_NewPassword
            // 
            lbl_NewPassword.AutoSize = true;
            lbl_NewPassword.Location = new System.Drawing.Point(10, 72);
            lbl_NewPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_NewPassword.MaximumSize = new System.Drawing.Size(176, 15);
            lbl_NewPassword.Name = "lbl_NewPassword";
            lbl_NewPassword.Size = new System.Drawing.Size(84, 15);
            lbl_NewPassword.TabIndex = 4;
            lbl_NewPassword.Text = "New password";
            // 
            // lbl_Username
            // 
            lbl_Username.AutoSize = true;
            lbl_Username.Location = new System.Drawing.Point(10, 18);
            lbl_Username.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Username.MaximumSize = new System.Drawing.Size(176, 15);
            lbl_Username.Name = "lbl_Username";
            lbl_Username.Size = new System.Drawing.Size(60, 15);
            lbl_Username.TabIndex = 0;
            lbl_Username.Text = "Username";
            // 
            // gb_Credentials
            // 
            gb_Credentials.Controls.Add(tb_CurrentPassword);
            gb_Credentials.Controls.Add(lbl_CurrentPassword);
            gb_Credentials.Controls.Add(tb_ConfirmNewPassword);
            gb_Credentials.Controls.Add(lbl_ConfirmNewPassword);
            gb_Credentials.Controls.Add(tb_NewPassword);
            gb_Credentials.Controls.Add(lbl_NewPassword);
            gb_Credentials.Controls.Add(tb_Username);
            gb_Credentials.Controls.Add(lbl_Username);
            gb_Credentials.Location = new System.Drawing.Point(0, 3);
            gb_Credentials.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Credentials.Name = "gb_Credentials";
            gb_Credentials.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Credentials.Size = new System.Drawing.Size(380, 125);
            gb_Credentials.TabIndex = 0;
            gb_Credentials.TabStop = false;
            gb_Credentials.Text = "Credentials";
            // 
            // tb_Username
            // 
            tb_Username.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_Username.Location = new System.Drawing.Point(197, 15);
            tb_Username.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_Username.MaxLength = 100;
            tb_Username.Name = "tb_Username";
            tb_Username.ReadOnly = true;
            tb_Username.Size = new System.Drawing.Size(176, 23);
            tb_Username.TabIndex = 1;
            tb_Username.TabStop = false;
            // 
            // tb_LicensePlate
            // 
            tb_LicensePlate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_LicensePlate.Location = new System.Drawing.Point(197, 125);
            tb_LicensePlate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_LicensePlate.MaxLength = 50;
            tb_LicensePlate.Name = "tb_LicensePlate";
            tb_LicensePlate.Size = new System.Drawing.Size(176, 23);
            tb_LicensePlate.TabIndex = 11;
            // 
            // lbl_LicensePlate
            // 
            lbl_LicensePlate.AutoSize = true;
            lbl_LicensePlate.Location = new System.Drawing.Point(10, 128);
            lbl_LicensePlate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_LicensePlate.MaximumSize = new System.Drawing.Size(176, 15);
            lbl_LicensePlate.Name = "lbl_LicensePlate";
            lbl_LicensePlate.Size = new System.Drawing.Size(77, 15);
            lbl_LicensePlate.TabIndex = 10;
            lbl_LicensePlate.Text = "License-plate";
            // 
            // lbl_OtherInformations
            // 
            lbl_OtherInformations.AutoSize = true;
            lbl_OtherInformations.Location = new System.Drawing.Point(10, 155);
            lbl_OtherInformations.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_OtherInformations.Name = "lbl_OtherInformations";
            lbl_OtherInformations.Size = new System.Drawing.Size(108, 15);
            lbl_OtherInformations.TabIndex = 8;
            lbl_OtherInformations.Text = "Other informations";
            // 
            // tb_OtherInformations
            // 
            tb_OtherInformations.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_OtherInformations.Location = new System.Drawing.Point(7, 173);
            tb_OtherInformations.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_OtherInformations.Multiline = true;
            tb_OtherInformations.Name = "tb_OtherInformations";
            tb_OtherInformations.Size = new System.Drawing.Size(366, 104);
            tb_OtherInformations.TabIndex = 9;
            // 
            // tb_TelephoneNumber
            // 
            tb_TelephoneNumber.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_TelephoneNumber.Location = new System.Drawing.Point(197, 98);
            tb_TelephoneNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_TelephoneNumber.MaxLength = 50;
            tb_TelephoneNumber.Name = "tb_TelephoneNumber";
            tb_TelephoneNumber.Size = new System.Drawing.Size(176, 23);
            tb_TelephoneNumber.TabIndex = 7;
            // 
            // lbl_TelephoneNumber
            // 
            lbl_TelephoneNumber.AutoSize = true;
            lbl_TelephoneNumber.Location = new System.Drawing.Point(10, 102);
            lbl_TelephoneNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_TelephoneNumber.MaximumSize = new System.Drawing.Size(176, 15);
            lbl_TelephoneNumber.Name = "lbl_TelephoneNumber";
            lbl_TelephoneNumber.Size = new System.Drawing.Size(107, 15);
            lbl_TelephoneNumber.TabIndex = 6;
            lbl_TelephoneNumber.Text = "Telephone number";
            // 
            // tb_EmailAddress
            // 
            tb_EmailAddress.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_EmailAddress.Location = new System.Drawing.Point(197, 72);
            tb_EmailAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_EmailAddress.MaxLength = 200;
            tb_EmailAddress.Name = "tb_EmailAddress";
            tb_EmailAddress.Size = new System.Drawing.Size(176, 23);
            tb_EmailAddress.TabIndex = 5;
            // 
            // lbl_EmailAddress
            // 
            lbl_EmailAddress.AutoSize = true;
            lbl_EmailAddress.Location = new System.Drawing.Point(10, 75);
            lbl_EmailAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_EmailAddress.MaximumSize = new System.Drawing.Size(176, 15);
            lbl_EmailAddress.Name = "lbl_EmailAddress";
            lbl_EmailAddress.Size = new System.Drawing.Size(84, 15);
            lbl_EmailAddress.TabIndex = 4;
            lbl_EmailAddress.Text = "E-mail address";
            // 
            // tb_Address
            // 
            tb_Address.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_Address.Location = new System.Drawing.Point(197, 45);
            tb_Address.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_Address.MaxLength = 200;
            tb_Address.Name = "tb_Address";
            tb_Address.Size = new System.Drawing.Size(176, 23);
            tb_Address.TabIndex = 3;
            // 
            // lbl_Address
            // 
            lbl_Address.AutoSize = true;
            lbl_Address.Location = new System.Drawing.Point(10, 48);
            lbl_Address.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Address.MaximumSize = new System.Drawing.Size(176, 15);
            lbl_Address.Name = "lbl_Address";
            lbl_Address.Size = new System.Drawing.Size(49, 15);
            lbl_Address.TabIndex = 2;
            lbl_Address.Text = "Address";
            // 
            // tb_FullName
            // 
            tb_FullName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_FullName.Location = new System.Drawing.Point(197, 18);
            tb_FullName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_FullName.MaxLength = 100;
            tb_FullName.Name = "tb_FullName";
            tb_FullName.Size = new System.Drawing.Size(176, 23);
            tb_FullName.TabIndex = 1;
            // 
            // lbl_FullName
            // 
            lbl_FullName.AutoSize = true;
            lbl_FullName.Location = new System.Drawing.Point(10, 22);
            lbl_FullName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_FullName.MaximumSize = new System.Drawing.Size(176, 15);
            lbl_FullName.Name = "lbl_FullName";
            lbl_FullName.Size = new System.Drawing.Size(59, 15);
            lbl_FullName.TabIndex = 0;
            lbl_FullName.Text = "Full name";
            // 
            // pb_Picture
            // 
            pb_Picture.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pb_Picture.BackColor = System.Drawing.SystemColors.AppWorkspace;
            pb_Picture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pb_Picture.Location = new System.Drawing.Point(7, 68);
            pb_Picture.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pb_Picture.Name = "pb_Picture";
            pb_Picture.OriginalSize = new System.Drawing.Size(100, 50);
            pb_Picture.RepositioningAndResizingControlsOnResize = false;
            pb_Picture.Size = new System.Drawing.Size(244, 341);
            pb_Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pb_Picture.TabIndex = 5;
            pb_Picture.TabStop = false;
            // 
            // lbl_SizeMode
            // 
            lbl_SizeMode.AutoSize = true;
            lbl_SizeMode.Location = new System.Drawing.Point(7, 18);
            lbl_SizeMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_SizeMode.Name = "lbl_SizeMode";
            lbl_SizeMode.Size = new System.Drawing.Size(61, 15);
            lbl_SizeMode.TabIndex = 3;
            lbl_SizeMode.Text = "Size mode";
            // 
            // cb_SizeMode
            // 
            cb_SizeMode.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cb_SizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_SizeMode.FormattingEnabled = true;
            cb_SizeMode.Location = new System.Drawing.Point(7, 42);
            cb_SizeMode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_SizeMode.Name = "cb_SizeMode";
            cb_SizeMode.Size = new System.Drawing.Size(244, 23);
            cb_SizeMode.TabIndex = 4;
            // 
            // btn_SelectPicture
            // 
            btn_SelectPicture.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_SelectPicture.Location = new System.Drawing.Point(142, 13);
            btn_SelectPicture.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_SelectPicture.Name = "btn_SelectPicture";
            btn_SelectPicture.Size = new System.Drawing.Size(110, 27);
            btn_SelectPicture.TabIndex = 2;
            btn_SelectPicture.Text = "Select picture";
            btn_SelectPicture.UseVisualStyleBackColor = true;
            // 
            // btn_Close
            // 
            btn_Close.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btn_Close.Location = new System.Drawing.Point(559, 427);
            btn_Close.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Close.Name = "btn_Close";
            btn_Close.Size = new System.Drawing.Size(88, 27);
            btn_Close.TabIndex = 4;
            btn_Close.Text = "Close";
            btn_Close.UseVisualStyleBackColor = true;
            btn_Close.Click += Btn_Close_Click;
            // 
            // btn_Save
            // 
            btn_Save.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_Save.Location = new System.Drawing.Point(464, 427);
            btn_Save.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new System.Drawing.Size(88, 27);
            btn_Save.TabIndex = 3;
            btn_Save.Text = "Save";
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += Btn_Save_Click;
            // 
            // gb_Picture
            // 
            gb_Picture.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gb_Picture.Controls.Add(pb_Picture);
            gb_Picture.Controls.Add(lbl_SizeMode);
            gb_Picture.Controls.Add(cb_SizeMode);
            gb_Picture.Controls.Add(btn_SelectPicture);
            gb_Picture.Location = new System.Drawing.Point(387, 3);
            gb_Picture.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Picture.Name = "gb_Picture";
            gb_Picture.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Picture.Size = new System.Drawing.Size(259, 417);
            gb_Picture.TabIndex = 2;
            gb_Picture.TabStop = false;
            gb_Picture.Text = "Picture";
            // 
            // gb_PersonalDetails
            // 
            gb_PersonalDetails.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            gb_PersonalDetails.Controls.Add(tb_LicensePlate);
            gb_PersonalDetails.Controls.Add(lbl_LicensePlate);
            gb_PersonalDetails.Controls.Add(lbl_OtherInformations);
            gb_PersonalDetails.Controls.Add(tb_OtherInformations);
            gb_PersonalDetails.Controls.Add(tb_TelephoneNumber);
            gb_PersonalDetails.Controls.Add(lbl_TelephoneNumber);
            gb_PersonalDetails.Controls.Add(tb_EmailAddress);
            gb_PersonalDetails.Controls.Add(lbl_EmailAddress);
            gb_PersonalDetails.Controls.Add(tb_Address);
            gb_PersonalDetails.Controls.Add(lbl_Address);
            gb_PersonalDetails.Controls.Add(tb_FullName);
            gb_PersonalDetails.Controls.Add(lbl_FullName);
            gb_PersonalDetails.Location = new System.Drawing.Point(0, 135);
            gb_PersonalDetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_PersonalDetails.Name = "gb_PersonalDetails";
            gb_PersonalDetails.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_PersonalDetails.Size = new System.Drawing.Size(380, 285);
            gb_PersonalDetails.TabIndex = 1;
            gb_PersonalDetails.TabStop = false;
            gb_PersonalDetails.Text = "Personal details";
            // 
            // p_Main
            // 
            p_Main.Controls.Add(btn_Close);
            p_Main.Controls.Add(btn_Save);
            p_Main.Controls.Add(gb_Picture);
            p_Main.Controls.Add(gb_PersonalDetails);
            p_Main.Controls.Add(gb_Credentials);
            p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            p_Main.Location = new System.Drawing.Point(0, 0);
            p_Main.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_Main.Name = "p_Main";
            p_Main.Size = new System.Drawing.Size(654, 458);
            p_Main.TabIndex = 1;
            // 
            // Profile
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(654, 458);
            Controls.Add(p_Main);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(661, 432);
            Name = "Profile";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Profile";
            TopMost = true;
            gb_Credentials.ResumeLayout(false);
            gb_Credentials.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Picture).EndInit();
            gb_Picture.ResumeLayout(false);
            gb_Picture.PerformLayout();
            gb_PersonalDetails.ResumeLayout(false);
            gb_PersonalDetails.PerformLayout();
            p_Main.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Mtf.Controls.PasswordBox tb_CurrentPassword;
        private System.Windows.Forms.Label lbl_CurrentPassword;
        private Mtf.Controls.PasswordBox tb_ConfirmNewPassword;
        private System.Windows.Forms.Label lbl_ConfirmNewPassword;
        private System.Windows.Forms.TextBox tb_NewPassword;
        private System.Windows.Forms.Label lbl_NewPassword;
        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.GroupBox gb_Credentials;
        private System.Windows.Forms.TextBox tb_Username;
        private System.Windows.Forms.TextBox tb_LicensePlate;
        private System.Windows.Forms.Label lbl_LicensePlate;
        private System.Windows.Forms.Label lbl_OtherInformations;
        private System.Windows.Forms.TextBox tb_OtherInformations;
        private System.Windows.Forms.TextBox tb_TelephoneNumber;
        private System.Windows.Forms.Label lbl_TelephoneNumber;
        private System.Windows.Forms.TextBox tb_EmailAddress;
        private System.Windows.Forms.Label lbl_EmailAddress;
        private System.Windows.Forms.TextBox tb_Address;
        private System.Windows.Forms.Label lbl_Address;
        private System.Windows.Forms.TextBox tb_FullName;
        private System.Windows.Forms.Label lbl_FullName;
        private Mtf.Controls.MtfPictureBox pb_Picture;
        private System.Windows.Forms.Label lbl_SizeMode;
        private System.Windows.Forms.ComboBox cb_SizeMode;
        private System.Windows.Forms.Button btn_SelectPicture;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.GroupBox gb_Picture;
        private System.Windows.Forms.GroupBox gb_PersonalDetails;
        private System.Windows.Forms.Panel p_Main;
    }
}
namespace LiveView.Forms
{
    partial class CameraProperties
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
            gbProperties = new System.Windows.Forms.GroupBox();
            tbCameraName = new System.Windows.Forms.TextBox();
            tbCameraGuid = new System.Windows.Forms.TextBox();
            tbHttpStream = new System.Windows.Forms.TextBox();
            lblHttpStream = new System.Windows.Forms.Label();
            cbPatternName = new System.Windows.Forms.ComboBox();
            nudPatternNumber = new System.Windows.Forms.NumericUpDown();
            lblPatternNumberAndName = new System.Windows.Forms.Label();
            cbPresetName = new System.Windows.Forms.ComboBox();
            nudPresetNumber = new System.Windows.Forms.NumericUpDown();
            lblPresetNumberAndName = new System.Windows.Forms.Label();
            cbFullscreenMode = new System.Windows.Forms.ComboBox();
            lblFullscreenMode = new System.Windows.Forms.Label();
            nudStreamId = new System.Windows.Forms.NumericUpDown();
            lblStreamId = new System.Windows.Forms.Label();
            tbCameraPassword = new Mtf.Controls.PasswordBox();
            lblCameraPassword = new System.Windows.Forms.Label();
            tbCameraUsername = new System.Windows.Forms.TextBox();
            lblCameraUsername = new System.Windows.Forms.Label();
            btnClose = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            lblCameraName = new System.Windows.Forms.Label();
            tbCameraIpAddress = new System.Windows.Forms.TextBox();
            lblCameraIpAddress = new System.Windows.Forms.Label();
            lblCameraGUID = new System.Windows.Forms.Label();
            pMain.SuspendLayout();
            gbProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPatternNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPresetNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStreamId).BeginInit();
            SuspendLayout();
            // 
            // pMain
            // 
            pMain.Controls.Add(gbProperties);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(348, 321);
            pMain.TabIndex = 1;
            // 
            // gbProperties
            // 
            gbProperties.Controls.Add(tbCameraName);
            gbProperties.Controls.Add(tbCameraGuid);
            gbProperties.Controls.Add(tbHttpStream);
            gbProperties.Controls.Add(lblHttpStream);
            gbProperties.Controls.Add(cbPatternName);
            gbProperties.Controls.Add(nudPatternNumber);
            gbProperties.Controls.Add(lblPatternNumberAndName);
            gbProperties.Controls.Add(cbPresetName);
            gbProperties.Controls.Add(nudPresetNumber);
            gbProperties.Controls.Add(lblPresetNumberAndName);
            gbProperties.Controls.Add(cbFullscreenMode);
            gbProperties.Controls.Add(lblFullscreenMode);
            gbProperties.Controls.Add(nudStreamId);
            gbProperties.Controls.Add(lblStreamId);
            gbProperties.Controls.Add(tbCameraPassword);
            gbProperties.Controls.Add(lblCameraPassword);
            gbProperties.Controls.Add(tbCameraUsername);
            gbProperties.Controls.Add(lblCameraUsername);
            gbProperties.Controls.Add(btnClose);
            gbProperties.Controls.Add(btnSave);
            gbProperties.Controls.Add(lblCameraName);
            gbProperties.Controls.Add(tbCameraIpAddress);
            gbProperties.Controls.Add(lblCameraIpAddress);
            gbProperties.Controls.Add(lblCameraGUID);
            gbProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            gbProperties.Location = new System.Drawing.Point(0, 0);
            gbProperties.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbProperties.Name = "gbProperties";
            gbProperties.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbProperties.Size = new System.Drawing.Size(348, 321);
            gbProperties.TabIndex = 0;
            gbProperties.TabStop = false;
            // 
            // tbCameraName
            // 
            tbCameraName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbCameraName.Location = new System.Drawing.Point(152, 16);
            tbCameraName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbCameraName.MaxLength = 200;
            tbCameraName.Name = "tbCameraName";
            tbCameraName.ReadOnly = true;
            tbCameraName.Size = new System.Drawing.Size(181, 23);
            tbCameraName.TabIndex = 25;
            // 
            // tbCameraGuid
            // 
            tbCameraGuid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbCameraGuid.Location = new System.Drawing.Point(152, 41);
            tbCameraGuid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbCameraGuid.MaxLength = 200;
            tbCameraGuid.Name = "tbCameraGuid";
            tbCameraGuid.ReadOnly = true;
            tbCameraGuid.Size = new System.Drawing.Size(181, 23);
            tbCameraGuid.TabIndex = 24;
            // 
            // tbHttpStream
            // 
            tbHttpStream.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbHttpStream.Location = new System.Drawing.Point(152, 193);
            tbHttpStream.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbHttpStream.MaxLength = 200;
            tbHttpStream.Name = "tbHttpStream";
            tbHttpStream.Size = new System.Drawing.Size(181, 23);
            tbHttpStream.TabIndex = 15;
            // 
            // lblHttpStream
            // 
            lblHttpStream.AutoSize = true;
            lblHttpStream.Location = new System.Drawing.Point(7, 196);
            lblHttpStream.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblHttpStream.Name = "lblHttpStream";
            lblHttpStream.Size = new System.Drawing.Size(70, 15);
            lblHttpStream.TabIndex = 14;
            lblHttpStream.Text = "Http stream";
            // 
            // cbPatternName
            // 
            cbPatternName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbPatternName.FormattingEnabled = true;
            cbPatternName.Location = new System.Drawing.Point(203, 253);
            cbPatternName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbPatternName.MaxLength = 50;
            cbPatternName.Name = "cbPatternName";
            cbPatternName.Size = new System.Drawing.Size(130, 23);
            cbPatternName.TabIndex = 21;
            // 
            // nudPatternNumber
            // 
            nudPatternNumber.Location = new System.Drawing.Point(152, 254);
            nudPatternNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudPatternNumber.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            nudPatternNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudPatternNumber.Name = "nudPatternNumber";
            nudPatternNumber.Size = new System.Drawing.Size(44, 23);
            nudPatternNumber.TabIndex = 20;
            nudPatternNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblPatternNumberAndName
            // 
            lblPatternNumberAndName.AutoSize = true;
            lblPatternNumberAndName.Location = new System.Drawing.Point(7, 256);
            lblPatternNumberAndName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPatternNumberAndName.Name = "lblPatternNumberAndName";
            lblPatternNumberAndName.Size = new System.Drawing.Size(126, 15);
            lblPatternNumberAndName.TabIndex = 19;
            lblPatternNumberAndName.Text = "Pattern number, name";
            // 
            // cbPresetName
            // 
            cbPresetName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbPresetName.FormattingEnabled = true;
            cbPresetName.Location = new System.Drawing.Point(203, 227);
            cbPresetName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbPresetName.MaxLength = 50;
            cbPresetName.Name = "cbPresetName";
            cbPresetName.Size = new System.Drawing.Size(130, 23);
            cbPresetName.TabIndex = 18;
            // 
            // nudPresetNumber
            // 
            nudPresetNumber.Location = new System.Drawing.Point(152, 228);
            nudPresetNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudPresetNumber.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            nudPresetNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudPresetNumber.Name = "nudPresetNumber";
            nudPresetNumber.Size = new System.Drawing.Size(44, 23);
            nudPresetNumber.TabIndex = 17;
            nudPresetNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblPresetNumberAndName
            // 
            lblPresetNumberAndName.AutoSize = true;
            lblPresetNumberAndName.Location = new System.Drawing.Point(7, 231);
            lblPresetNumberAndName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPresetNumberAndName.Name = "lblPresetNumberAndName";
            lblPresetNumberAndName.Size = new System.Drawing.Size(120, 15);
            lblPresetNumberAndName.TabIndex = 16;
            lblPresetNumberAndName.Text = "Preset number, name";
            // 
            // cbFullscreenMode
            // 
            cbFullscreenMode.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbFullscreenMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFullscreenMode.FormattingEnabled = true;
            cbFullscreenMode.Location = new System.Drawing.Point(152, 167);
            cbFullscreenMode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbFullscreenMode.Name = "cbFullscreenMode";
            cbFullscreenMode.Size = new System.Drawing.Size(181, 23);
            cbFullscreenMode.TabIndex = 13;
            // 
            // lblFullscreenMode
            // 
            lblFullscreenMode.AutoSize = true;
            lblFullscreenMode.Location = new System.Drawing.Point(7, 171);
            lblFullscreenMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblFullscreenMode.Name = "lblFullscreenMode";
            lblFullscreenMode.Size = new System.Drawing.Size(94, 15);
            lblFullscreenMode.TabIndex = 12;
            lblFullscreenMode.Text = "Fullscreen mode";
            // 
            // nudStreamId
            // 
            nudStreamId.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudStreamId.Location = new System.Drawing.Point(152, 143);
            nudStreamId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudStreamId.Name = "nudStreamId";
            nudStreamId.Size = new System.Drawing.Size(182, 23);
            nudStreamId.TabIndex = 11;
            nudStreamId.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblStreamId
            // 
            lblStreamId.AutoSize = true;
            lblStreamId.Location = new System.Drawing.Point(7, 145);
            lblStreamId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblStreamId.Name = "lblStreamId";
            lblStreamId.Size = new System.Drawing.Size(58, 15);
            lblStreamId.TabIndex = 10;
            lblStreamId.Text = "Stream ID";
            // 
            // tbCameraPassword
            // 
            tbCameraPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbCameraPassword.Location = new System.Drawing.Point(152, 117);
            tbCameraPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbCameraPassword.MaxLength = 200;
            tbCameraPassword.Name = "tbCameraPassword";
            tbCameraPassword.Password = "";
            tbCameraPassword.PasswordChar = '*';
            tbCameraPassword.ShowRealPasswordLength = false;
            tbCameraPassword.Size = new System.Drawing.Size(181, 23);
            tbCameraPassword.TabIndex = 9;
            // 
            // lblCameraPassword
            // 
            lblCameraPassword.AutoSize = true;
            lblCameraPassword.Location = new System.Drawing.Point(7, 120);
            lblCameraPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCameraPassword.Name = "lblCameraPassword";
            lblCameraPassword.Size = new System.Drawing.Size(57, 15);
            lblCameraPassword.TabIndex = 8;
            lblCameraPassword.Text = "Password";
            // 
            // tbCameraUsername
            // 
            tbCameraUsername.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbCameraUsername.Location = new System.Drawing.Point(152, 91);
            tbCameraUsername.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbCameraUsername.MaxLength = 200;
            tbCameraUsername.Name = "tbCameraUsername";
            tbCameraUsername.Size = new System.Drawing.Size(181, 23);
            tbCameraUsername.TabIndex = 7;
            // 
            // lblCameraUsername
            // 
            lblCameraUsername.AutoSize = true;
            lblCameraUsername.Location = new System.Drawing.Point(7, 95);
            lblCameraUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCameraUsername.Name = "lblCameraUsername";
            lblCameraUsername.Size = new System.Drawing.Size(60, 15);
            lblCameraUsername.TabIndex = 6;
            lblCameraUsername.Text = "Username";
            // 
            // btnClose
            // 
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.Location = new System.Drawing.Point(246, 287);
            btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(88, 27);
            btnClose.TabIndex = 23;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSave.Location = new System.Drawing.Point(152, 287);
            btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(88, 27);
            btnSave.TabIndex = 22;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += BtnSave_Click;
            // 
            // lblCameraName
            // 
            lblCameraName.AutoSize = true;
            lblCameraName.Location = new System.Drawing.Point(7, 18);
            lblCameraName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCameraName.Name = "lblCameraName";
            lblCameraName.Size = new System.Drawing.Size(81, 15);
            lblCameraName.TabIndex = 0;
            lblCameraName.Text = "Camera name";
            // 
            // tbCameraIpAddress
            // 
            tbCameraIpAddress.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbCameraIpAddress.Location = new System.Drawing.Point(152, 66);
            tbCameraIpAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbCameraIpAddress.MaxLength = 200;
            tbCameraIpAddress.Name = "tbCameraIpAddress";
            tbCameraIpAddress.Size = new System.Drawing.Size(181, 23);
            tbCameraIpAddress.TabIndex = 5;
            // 
            // lblCameraIpAddress
            // 
            lblCameraIpAddress.AutoSize = true;
            lblCameraIpAddress.Location = new System.Drawing.Point(7, 69);
            lblCameraIpAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCameraIpAddress.Name = "lblCameraIpAddress";
            lblCameraIpAddress.Size = new System.Drawing.Size(60, 15);
            lblCameraIpAddress.TabIndex = 4;
            lblCameraIpAddress.Text = "IP address";
            // 
            // lblCameraGUID
            // 
            lblCameraGUID.AutoSize = true;
            lblCameraGUID.Location = new System.Drawing.Point(7, 44);
            lblCameraGUID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCameraGUID.Name = "lblCameraGUID";
            lblCameraGUID.Size = new System.Drawing.Size(34, 15);
            lblCameraGUID.TabIndex = 2;
            lblCameraGUID.Text = "GUID";
            // 
            // CameraProperties
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(348, 321);
            Controls.Add(pMain);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "CameraProperties";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Camera properties";
            Shown += CameraProperties_Shown;
            pMain.ResumeLayout(false);
            gbProperties.ResumeLayout(false);
            gbProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPatternNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPresetNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStreamId).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.GroupBox gbProperties;
        private System.Windows.Forms.TextBox tbHttpStream;
        private System.Windows.Forms.Label lblHttpStream;
        private System.Windows.Forms.ComboBox cbPatternName;
        private System.Windows.Forms.NumericUpDown nudPatternNumber;
        private System.Windows.Forms.Label lblPatternNumberAndName;
        private System.Windows.Forms.ComboBox cbPresetName;
        private System.Windows.Forms.NumericUpDown nudPresetNumber;
        private System.Windows.Forms.Label lblPresetNumberAndName;
        private System.Windows.Forms.ComboBox cbFullscreenMode;
        private System.Windows.Forms.Label lblFullscreenMode;
        private System.Windows.Forms.NumericUpDown nudStreamId;
        private System.Windows.Forms.Label lblStreamId;
        private Mtf.Controls.PasswordBox tbCameraPassword;
        private System.Windows.Forms.Label lblCameraPassword;
        private System.Windows.Forms.TextBox tbCameraUsername;
        private System.Windows.Forms.Label lblCameraUsername;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblCameraName;
        private System.Windows.Forms.TextBox tbCameraIpAddress;
        private System.Windows.Forms.Label lblCameraIpAddress;
        private System.Windows.Forms.Label lblCameraGUID;
        private System.Windows.Forms.TextBox tbCameraName;
        private System.Windows.Forms.TextBox tbCameraGuid;
    }
}
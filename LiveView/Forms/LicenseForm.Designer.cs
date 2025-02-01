namespace LiveView.Forms
{
    partial class LicenseForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(LicenseForm));
            gbMain = new System.Windows.Forms.GroupBox();
            btnUpgrade = new System.Windows.Forms.Button();
            lblEdition = new System.Windows.Forms.Label();
            lblIsVirtual = new System.Windows.Forms.Label();
            lblMaximumPerActual = new System.Windows.Forms.Label();
            btnClose = new System.Windows.Forms.Button();
            lblId = new System.Windows.Forms.Label();
            lblLicenseID = new System.Windows.Forms.Label();
            lblNumberOfCamerasRecordedByNotValidatedServers = new System.Windows.Forms.Label();
            lblNumberOfNotValidatedServers = new System.Windows.Forms.Label();
            lblNotValidatedCamerasMaxPerAct = new System.Windows.Forms.Label();
            lblNotValidatedServersMaxPerAct = new System.Windows.Forms.Label();
            lblNumberOfCamerasRecordedByValidatedServers = new System.Windows.Forms.Label();
            lblNumberOfValidatedServers = new System.Windows.Forms.Label();
            lblValidatedCamerasMaxPerAct = new System.Windows.Forms.Label();
            lblValidatedServersMaxPerAct = new System.Windows.Forms.Label();
            lblUsersMaxPerAct = new System.Windows.Forms.Label();
            lblNumberOfUsers = new System.Windows.Forms.Label();
            lblLicenseStatusResult = new System.Windows.Forms.Label();
            lblLicenseStatus = new System.Windows.Forms.Label();
            lblLicenseDetails = new System.Windows.Forms.Label();
            gbMain.SuspendLayout();
            SuspendLayout();
            // 
            // gbMain
            // 
            gbMain.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gbMain.Controls.Add(btnUpgrade);
            gbMain.Controls.Add(lblEdition);
            gbMain.Controls.Add(lblIsVirtual);
            gbMain.Controls.Add(lblMaximumPerActual);
            gbMain.Controls.Add(btnClose);
            gbMain.Controls.Add(lblId);
            gbMain.Controls.Add(lblLicenseID);
            gbMain.Controls.Add(lblNumberOfCamerasRecordedByNotValidatedServers);
            gbMain.Controls.Add(lblNumberOfNotValidatedServers);
            gbMain.Controls.Add(lblNotValidatedCamerasMaxPerAct);
            gbMain.Controls.Add(lblNotValidatedServersMaxPerAct);
            gbMain.Controls.Add(lblNumberOfCamerasRecordedByValidatedServers);
            gbMain.Controls.Add(lblNumberOfValidatedServers);
            gbMain.Controls.Add(lblValidatedCamerasMaxPerAct);
            gbMain.Controls.Add(lblValidatedServersMaxPerAct);
            gbMain.Controls.Add(lblUsersMaxPerAct);
            gbMain.Controls.Add(lblNumberOfUsers);
            gbMain.Controls.Add(lblLicenseStatusResult);
            gbMain.Controls.Add(lblLicenseStatus);
            gbMain.Controls.Add(lblLicenseDetails);
            gbMain.Location = new System.Drawing.Point(5, 2);
            gbMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbMain.Name = "gbMain";
            gbMain.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbMain.Size = new System.Drawing.Size(638, 252);
            gbMain.TabIndex = 1;
            gbMain.TabStop = false;
            // 
            // btnUpgrade
            // 
            btnUpgrade.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnUpgrade.Location = new System.Drawing.Point(9, 38);
            btnUpgrade.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnUpgrade.Name = "btnUpgrade";
            btnUpgrade.Size = new System.Drawing.Size(93, 27);
            btnUpgrade.TabIndex = 57;
            btnUpgrade.Text = "Upgrade";
            btnUpgrade.UseVisualStyleBackColor = true;
            btnUpgrade.Click += BtnUpgrade_Click;
            // 
            // lblEdition
            // 
            lblEdition.AutoSize = true;
            lblEdition.Font = (System.Drawing.Font)resources.GetObject("lblEdition.Font");
            lblEdition.Location = new System.Drawing.Point(9, 18);
            lblEdition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblEdition.Name = "lblEdition";
            lblEdition.Size = new System.Drawing.Size(136, 13);
            lblEdition.TabIndex = 56;
            lblEdition.Text = "LiveView Basic Edition";
            // 
            // lblIsVirtual
            // 
            lblIsVirtual.AutoSize = true;
            lblIsVirtual.Font = (System.Drawing.Font)resources.GetObject("lblIsVirtual.Font");
            lblIsVirtual.Location = new System.Drawing.Point(146, 125);
            lblIsVirtual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblIsVirtual.Name = "lblIsVirtual";
            lblIsVirtual.Size = new System.Drawing.Size(0, 13);
            lblIsVirtual.TabIndex = 54;
            // 
            // lblMaximumPerActual
            // 
            lblMaximumPerActual.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblMaximumPerActual.AutoSize = true;
            lblMaximumPerActual.Font = (System.Drawing.Font)resources.GetObject("lblMaximumPerActual.Font");
            lblMaximumPerActual.Location = new System.Drawing.Point(475, 125);
            lblMaximumPerActual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMaximumPerActual.Name = "lblMaximumPerActual";
            lblMaximumPerActual.Size = new System.Drawing.Size(108, 13);
            lblMaximumPerActual.TabIndex = 53;
            lblMaximumPerActual.Text = "Maximum / Actual";
            // 
            // btnClose
            // 
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.Location = new System.Drawing.Point(542, 216);
            btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(0, 0);
            btnClose.TabIndex = 52;
            btnClose.TabStop = false;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // lblId
            // 
            lblId.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblId.AutoSize = true;
            lblId.Location = new System.Drawing.Point(475, 89);
            lblId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblId.Name = "lblId";
            lblId.Size = new System.Drawing.Size(18, 15);
            lblId.TabIndex = 50;
            lblId.Text = "ID";
            // 
            // lblLicenseID
            // 
            lblLicenseID.AutoSize = true;
            lblLicenseID.Font = (System.Drawing.Font)resources.GetObject("lblLicenseID.Font");
            lblLicenseID.Location = new System.Drawing.Point(9, 89);
            lblLicenseID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblLicenseID.Name = "lblLicenseID";
            lblLicenseID.Size = new System.Drawing.Size(68, 13);
            lblLicenseID.TabIndex = 49;
            lblLicenseID.Text = "License ID";
            // 
            // lblNumberOfCamerasRecordedByNotValidatedServers
            // 
            lblNumberOfCamerasRecordedByNotValidatedServers.AutoSize = true;
            lblNumberOfCamerasRecordedByNotValidatedServers.Location = new System.Drawing.Point(9, 228);
            lblNumberOfCamerasRecordedByNotValidatedServers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblNumberOfCamerasRecordedByNotValidatedServers.Name = "lblNumberOfCamerasRecordedByNotValidatedServers";
            lblNumberOfCamerasRecordedByNotValidatedServers.Size = new System.Drawing.Size(289, 15);
            lblNumberOfCamerasRecordedByNotValidatedServers.TabIndex = 48;
            lblNumberOfCamerasRecordedByNotValidatedServers.Text = "Number of cameras recorded by not validated servers";
            // 
            // lblNumberOfNotValidatedServers
            // 
            lblNumberOfNotValidatedServers.AutoSize = true;
            lblNumberOfNotValidatedServers.Location = new System.Drawing.Point(9, 208);
            lblNumberOfNotValidatedServers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblNumberOfNotValidatedServers.Name = "lblNumberOfNotValidatedServers";
            lblNumberOfNotValidatedServers.Size = new System.Drawing.Size(176, 15);
            lblNumberOfNotValidatedServers.TabIndex = 47;
            lblNumberOfNotValidatedServers.Text = "Number of not validated servers";
            // 
            // lblNotValidatedCamerasMaxPerAct
            // 
            lblNotValidatedCamerasMaxPerAct.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblNotValidatedCamerasMaxPerAct.AutoSize = true;
            lblNotValidatedCamerasMaxPerAct.Location = new System.Drawing.Point(475, 228);
            lblNotValidatedCamerasMaxPerAct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblNotValidatedCamerasMaxPerAct.Name = "lblNotValidatedCamerasMaxPerAct";
            lblNotValidatedCamerasMaxPerAct.Size = new System.Drawing.Size(30, 15);
            lblNotValidatedCamerasMaxPerAct.TabIndex = 46;
            lblNotValidatedCamerasMaxPerAct.Text = "0 / 0";
            // 
            // lblNotValidatedServersMaxPerAct
            // 
            lblNotValidatedServersMaxPerAct.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblNotValidatedServersMaxPerAct.AutoSize = true;
            lblNotValidatedServersMaxPerAct.Location = new System.Drawing.Point(475, 208);
            lblNotValidatedServersMaxPerAct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblNotValidatedServersMaxPerAct.Name = "lblNotValidatedServersMaxPerAct";
            lblNotValidatedServersMaxPerAct.Size = new System.Drawing.Size(30, 15);
            lblNotValidatedServersMaxPerAct.TabIndex = 45;
            lblNotValidatedServersMaxPerAct.Text = "0 / 0";
            // 
            // lblNumberOfCamerasRecordedByValidatedServers
            // 
            lblNumberOfCamerasRecordedByValidatedServers.AutoSize = true;
            lblNumberOfCamerasRecordedByValidatedServers.Location = new System.Drawing.Point(9, 187);
            lblNumberOfCamerasRecordedByValidatedServers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblNumberOfCamerasRecordedByValidatedServers.Name = "lblNumberOfCamerasRecordedByValidatedServers";
            lblNumberOfCamerasRecordedByValidatedServers.Size = new System.Drawing.Size(268, 15);
            lblNumberOfCamerasRecordedByValidatedServers.TabIndex = 42;
            lblNumberOfCamerasRecordedByValidatedServers.Text = "Number of cameras recorded by validated servers";
            // 
            // lblNumberOfValidatedServers
            // 
            lblNumberOfValidatedServers.AutoSize = true;
            lblNumberOfValidatedServers.Location = new System.Drawing.Point(9, 166);
            lblNumberOfValidatedServers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblNumberOfValidatedServers.Name = "lblNumberOfValidatedServers";
            lblNumberOfValidatedServers.Size = new System.Drawing.Size(155, 15);
            lblNumberOfValidatedServers.TabIndex = 41;
            lblNumberOfValidatedServers.Text = "Number of validated servers";
            // 
            // lblValidatedCamerasMaxPerAct
            // 
            lblValidatedCamerasMaxPerAct.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblValidatedCamerasMaxPerAct.AutoSize = true;
            lblValidatedCamerasMaxPerAct.Location = new System.Drawing.Point(475, 187);
            lblValidatedCamerasMaxPerAct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblValidatedCamerasMaxPerAct.Name = "lblValidatedCamerasMaxPerAct";
            lblValidatedCamerasMaxPerAct.Size = new System.Drawing.Size(30, 15);
            lblValidatedCamerasMaxPerAct.TabIndex = 40;
            lblValidatedCamerasMaxPerAct.Text = "0 / 0";
            // 
            // lblValidatedServersMaxPerAct
            // 
            lblValidatedServersMaxPerAct.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblValidatedServersMaxPerAct.AutoSize = true;
            lblValidatedServersMaxPerAct.Location = new System.Drawing.Point(475, 166);
            lblValidatedServersMaxPerAct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblValidatedServersMaxPerAct.Name = "lblValidatedServersMaxPerAct";
            lblValidatedServersMaxPerAct.Size = new System.Drawing.Size(30, 15);
            lblValidatedServersMaxPerAct.TabIndex = 39;
            lblValidatedServersMaxPerAct.Text = "0 / 0";
            // 
            // lblUsersMaxPerAct
            // 
            lblUsersMaxPerAct.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblUsersMaxPerAct.AutoSize = true;
            lblUsersMaxPerAct.Location = new System.Drawing.Point(475, 145);
            lblUsersMaxPerAct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblUsersMaxPerAct.Name = "lblUsersMaxPerAct";
            lblUsersMaxPerAct.Size = new System.Drawing.Size(30, 15);
            lblUsersMaxPerAct.TabIndex = 38;
            lblUsersMaxPerAct.Text = "0 / 0";
            // 
            // lblNumberOfUsers
            // 
            lblNumberOfUsers.AutoSize = true;
            lblNumberOfUsers.Location = new System.Drawing.Point(9, 145);
            lblNumberOfUsers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblNumberOfUsers.Name = "lblNumberOfUsers";
            lblNumberOfUsers.Size = new System.Drawing.Size(95, 15);
            lblNumberOfUsers.TabIndex = 37;
            lblNumberOfUsers.Text = "Number of users";
            // 
            // lblLicenseStatusResult
            // 
            lblLicenseStatusResult.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblLicenseStatusResult.AutoSize = true;
            lblLicenseStatusResult.Location = new System.Drawing.Point(475, 68);
            lblLicenseStatusResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblLicenseStatusResult.Name = "lblLicenseStatusResult";
            lblLicenseStatusResult.Size = new System.Drawing.Size(73, 15);
            lblLicenseStatusResult.TabIndex = 36;
            lblLicenseStatusResult.Text = "Not licensed";
            // 
            // lblLicenseStatus
            // 
            lblLicenseStatus.AutoSize = true;
            lblLicenseStatus.Font = (System.Drawing.Font)resources.GetObject("lblLicenseStatus.Font");
            lblLicenseStatus.Location = new System.Drawing.Point(9, 68);
            lblLicenseStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblLicenseStatus.Name = "lblLicenseStatus";
            lblLicenseStatus.Size = new System.Drawing.Size(89, 13);
            lblLicenseStatus.TabIndex = 35;
            lblLicenseStatus.Text = "License status";
            // 
            // lblLicenseDetails
            // 
            lblLicenseDetails.AutoSize = true;
            lblLicenseDetails.Font = (System.Drawing.Font)resources.GetObject("lblLicenseDetails.Font");
            lblLicenseDetails.Location = new System.Drawing.Point(9, 125);
            lblLicenseDetails.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblLicenseDetails.Name = "lblLicenseDetails";
            lblLicenseDetails.Size = new System.Drawing.Size(92, 13);
            lblLicenseDetails.TabIndex = 34;
            lblLicenseDetails.Text = "License details";
            // 
            // LicenseForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(648, 257);
            Controls.Add(gbMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "LicenseForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "License";
            Shown += LicenseForm_Shown;
            gbMain.ResumeLayout(false);
            gbMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.Button btnUpgrade;
        private System.Windows.Forms.Label lblEdition;
        private System.Windows.Forms.Label lblIsVirtual;
        private System.Windows.Forms.Label lblMaximumPerActual;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblLicenseID;
        private System.Windows.Forms.Label lblNumberOfCamerasRecordedByNotValidatedServers;
        private System.Windows.Forms.Label lblNumberOfNotValidatedServers;
        private System.Windows.Forms.Label lblNotValidatedCamerasMaxPerAct;
        private System.Windows.Forms.Label lblNotValidatedServersMaxPerAct;
        private System.Windows.Forms.Label lblNumberOfCamerasRecordedByValidatedServers;
        private System.Windows.Forms.Label lblNumberOfValidatedServers;
        private System.Windows.Forms.Label lblValidatedCamerasMaxPerAct;
        private System.Windows.Forms.Label lblValidatedServersMaxPerAct;
        private System.Windows.Forms.Label lblUsersMaxPerAct;
        private System.Windows.Forms.Label lblNumberOfUsers;
        private System.Windows.Forms.Label lblLicenseStatusResult;
        private System.Windows.Forms.Label lblLicenseStatus;
        private System.Windows.Forms.Label lblLicenseDetails;
    }
}
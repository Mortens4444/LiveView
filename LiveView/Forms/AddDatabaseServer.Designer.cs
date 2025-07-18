namespace LiveView.Forms
{
    partial class AddDatabaseServer
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
            btnCancel = new System.Windows.Forms.Button();
            btnAddOrModify = new System.Windows.Forms.Button();
            gbNetwork = new System.Windows.Forms.GroupBox();
            lblManufacturer = new System.Windows.Forms.Label();
            tbManufacturer = new System.Windows.Forms.TextBox();
            tbMacAddress = new System.Windows.Forms.TextBox();
            lblMacAddress = new System.Windows.Forms.Label();
            gbDatabaseServer = new System.Windows.Forms.GroupBox();
            lblServerPort = new System.Windows.Forms.Label();
            nudDatabaseServerPort = new System.Windows.Forms.NumericUpDown();
            tbDatabaseName = new System.Windows.Forms.TextBox();
            lblDatabaseName = new System.Windows.Forms.Label();
            cbIpAddress = new System.Windows.Forms.ComboBox();
            tbHostname = new System.Windows.Forms.TextBox();
            lblHostname = new System.Windows.Forms.Label();
            tbPassword = new Mtf.Controls.PasswordBox();
            lblPassword = new System.Windows.Forms.Label();
            tbUsername = new System.Windows.Forms.TextBox();
            lblUsername = new System.Windows.Forms.Label();
            lblIpAddress = new System.Windows.Forms.Label();
            pMain.SuspendLayout();
            gbNetwork.SuspendLayout();
            gbDatabaseServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDatabaseServerPort).BeginInit();
            SuspendLayout();
            // 
            // pMain
            // 
            pMain.Controls.Add(btnCancel);
            pMain.Controls.Add(btnAddOrModify);
            pMain.Controls.Add(gbNetwork);
            pMain.Controls.Add(gbDatabaseServer);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(315, 392);
            pMain.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(221, 359);
            btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(88, 27);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Close";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnClose_Click;
            // 
            // btnAddOrModify
            // 
            btnAddOrModify.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnAddOrModify.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnAddOrModify.Location = new System.Drawing.Point(127, 359);
            btnAddOrModify.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAddOrModify.Name = "btnAddOrModify";
            btnAddOrModify.Size = new System.Drawing.Size(88, 27);
            btnAddOrModify.TabIndex = 12;
            btnAddOrModify.Text = "Add";
            btnAddOrModify.UseVisualStyleBackColor = true;
            btnAddOrModify.Click += BtnAddOrModify_Click;
            // 
            // gbNetwork
            // 
            gbNetwork.Controls.Add(lblManufacturer);
            gbNetwork.Controls.Add(tbManufacturer);
            gbNetwork.Controls.Add(tbMacAddress);
            gbNetwork.Controls.Add(lblMacAddress);
            gbNetwork.Dock = System.Windows.Forms.DockStyle.Top;
            gbNetwork.Location = new System.Drawing.Point(0, 286);
            gbNetwork.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbNetwork.Name = "gbNetwork";
            gbNetwork.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbNetwork.Size = new System.Drawing.Size(315, 70);
            gbNetwork.TabIndex = 11;
            gbNetwork.TabStop = false;
            gbNetwork.Text = "Network";
            // 
            // lblManufacturer
            // 
            lblManufacturer.AutoSize = true;
            lblManufacturer.Location = new System.Drawing.Point(156, 17);
            lblManufacturer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblManufacturer.Name = "lblManufacturer";
            lblManufacturer.Size = new System.Drawing.Size(79, 15);
            lblManufacturer.TabIndex = 5;
            lblManufacturer.Text = "Manufacturer";
            // 
            // tbManufacturer
            // 
            tbManufacturer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbManufacturer.Location = new System.Drawing.Point(156, 35);
            tbManufacturer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbManufacturer.MaxLength = 20;
            tbManufacturer.Name = "tbManufacturer";
            tbManufacturer.ReadOnly = true;
            tbManufacturer.Size = new System.Drawing.Size(153, 23);
            tbManufacturer.TabIndex = 4;
            // 
            // tbMacAddress
            // 
            tbMacAddress.Location = new System.Drawing.Point(10, 35);
            tbMacAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbMacAddress.MaxLength = 20;
            tbMacAddress.Name = "tbMacAddress";
            tbMacAddress.Size = new System.Drawing.Size(138, 23);
            tbMacAddress.TabIndex = 1;
            // 
            // lblMacAddress
            // 
            lblMacAddress.AutoSize = true;
            lblMacAddress.Location = new System.Drawing.Point(7, 18);
            lblMacAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMacAddress.Name = "lblMacAddress";
            lblMacAddress.Size = new System.Drawing.Size(134, 15);
            lblMacAddress.TabIndex = 0;
            lblMacAddress.Text = "MAC Address (optional)";
            // 
            // gbDatabaseServer
            // 
            gbDatabaseServer.Controls.Add(lblServerPort);
            gbDatabaseServer.Controls.Add(nudDatabaseServerPort);
            gbDatabaseServer.Controls.Add(tbDatabaseName);
            gbDatabaseServer.Controls.Add(lblDatabaseName);
            gbDatabaseServer.Controls.Add(cbIpAddress);
            gbDatabaseServer.Controls.Add(tbHostname);
            gbDatabaseServer.Controls.Add(lblHostname);
            gbDatabaseServer.Controls.Add(tbPassword);
            gbDatabaseServer.Controls.Add(lblPassword);
            gbDatabaseServer.Controls.Add(tbUsername);
            gbDatabaseServer.Controls.Add(lblUsername);
            gbDatabaseServer.Controls.Add(lblIpAddress);
            gbDatabaseServer.Dock = System.Windows.Forms.DockStyle.Top;
            gbDatabaseServer.Location = new System.Drawing.Point(0, 0);
            gbDatabaseServer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbDatabaseServer.Name = "gbDatabaseServer";
            gbDatabaseServer.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbDatabaseServer.Size = new System.Drawing.Size(315, 286);
            gbDatabaseServer.TabIndex = 10;
            gbDatabaseServer.TabStop = false;
            gbDatabaseServer.Text = "Database server";
            // 
            // lblServerPort
            // 
            lblServerPort.AutoSize = true;
            lblServerPort.Location = new System.Drawing.Point(9, 255);
            lblServerPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblServerPort.Name = "lblServerPort";
            lblServerPort.Size = new System.Drawing.Size(64, 15);
            lblServerPort.TabIndex = 11;
            lblServerPort.Text = "Server port";
            // 
            // nudDatabaseServerPort
            // 
            nudDatabaseServerPort.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nudDatabaseServerPort.Location = new System.Drawing.Point(191, 253);
            nudDatabaseServerPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudDatabaseServerPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nudDatabaseServerPort.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDatabaseServerPort.Name = "nudDatabaseServerPort";
            nudDatabaseServerPort.Size = new System.Drawing.Size(117, 23);
            nudDatabaseServerPort.TabIndex = 10;
            nudDatabaseServerPort.Value = new decimal(new int[] { 2242, 0, 0, 0 });
            // 
            // tbDatabaseName
            // 
            tbDatabaseName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbDatabaseName.Location = new System.Drawing.Point(10, 223);
            tbDatabaseName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbDatabaseName.MaxLength = 100;
            tbDatabaseName.Name = "tbDatabaseName";
            tbDatabaseName.Size = new System.Drawing.Size(294, 23);
            tbDatabaseName.TabIndex = 9;
            // 
            // lblDatabaseName
            // 
            lblDatabaseName.AutoSize = true;
            lblDatabaseName.Location = new System.Drawing.Point(7, 204);
            lblDatabaseName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblDatabaseName.Name = "lblDatabaseName";
            lblDatabaseName.Size = new System.Drawing.Size(88, 15);
            lblDatabaseName.TabIndex = 8;
            lblDatabaseName.Text = "Database name";
            // 
            // cbIpAddress
            // 
            cbIpAddress.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbIpAddress.FormattingEnabled = true;
            cbIpAddress.Location = new System.Drawing.Point(10, 37);
            cbIpAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbIpAddress.Name = "cbIpAddress";
            cbIpAddress.Size = new System.Drawing.Size(294, 23);
            cbIpAddress.TabIndex = 1;
            // 
            // tbHostname
            // 
            tbHostname.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbHostname.Location = new System.Drawing.Point(10, 83);
            tbHostname.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbHostname.MaxLength = 100;
            tbHostname.Name = "tbDisplayedName";
            tbHostname.Size = new System.Drawing.Size(294, 23);
            tbHostname.TabIndex = 3;
            // 
            // lblHostname
            // 
            lblHostname.AutoSize = true;
            lblHostname.Location = new System.Drawing.Point(7, 65);
            lblHostname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblHostname.Name = "lblDisplayedName";
            lblHostname.Size = new System.Drawing.Size(91, 15);
            lblHostname.TabIndex = 2;
            lblHostname.Text = "Displayed name";
            // 
            // tbPassword
            // 
            tbPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbPassword.Location = new System.Drawing.Point(10, 172);
            tbPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbPassword.MaxLength = 100;
            tbPassword.Name = "tbPassword";
            tbPassword.Password = "";
            tbPassword.PasswordChar = '*';
            tbPassword.ShowRealPasswordLength = true;
            tbPassword.Size = new System.Drawing.Size(294, 23);
            tbPassword.TabIndex = 7;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new System.Drawing.Point(7, 153);
            lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(57, 15);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Password";
            // 
            // tbUsername
            // 
            tbUsername.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbUsername.Location = new System.Drawing.Point(10, 127);
            tbUsername.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbUsername.MaxLength = 100;
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new System.Drawing.Size(294, 23);
            tbUsername.TabIndex = 5;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new System.Drawing.Point(7, 108);
            lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new System.Drawing.Size(60, 15);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Username";
            // 
            // lblIpAddress
            // 
            lblIpAddress.AutoSize = true;
            lblIpAddress.Location = new System.Drawing.Point(7, 18);
            lblIpAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblIpAddress.Name = "lblIpAddress";
            lblIpAddress.Size = new System.Drawing.Size(133, 15);
            lblIpAddress.TabIndex = 0;
            lblIpAddress.Text = "DNS name or IP address";
            // 
            // AddDatabaseServer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(315, 392);
            Controls.Add(pMain);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "AddDatabaseServer";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "New database server";
            TopMost = true;
            Shown += AddDatabaseServer_Shown;
            pMain.ResumeLayout(false);
            gbNetwork.ResumeLayout(false);
            gbNetwork.PerformLayout();
            gbDatabaseServer.ResumeLayout(false);
            gbDatabaseServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDatabaseServerPort).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddOrModify;
        private System.Windows.Forms.GroupBox gbNetwork;
        private System.Windows.Forms.TextBox tbMacAddress;
        private System.Windows.Forms.Label lblMacAddress;
        private System.Windows.Forms.GroupBox gbDatabaseServer;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.NumericUpDown nudDatabaseServerPort;
        private System.Windows.Forms.TextBox tbDatabaseName;
        private System.Windows.Forms.Label lblDatabaseName;
        private System.Windows.Forms.ComboBox cbIpAddress;
        private System.Windows.Forms.TextBox tbHostname;
        private System.Windows.Forms.Label lblHostname;
        private Mtf.Controls.PasswordBox tbPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblIpAddress;
        private System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.TextBox tbManufacturer;
    }
}
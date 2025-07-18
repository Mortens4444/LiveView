namespace LiveView.Forms
{
    partial class AddVideoServer
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(AddVideoServer));
            pMain = new System.Windows.Forms.Panel();
            gbValidate = new System.Windows.Forms.GroupBox();
            tbModel = new System.Windows.Forms.TextBox();
            lblModel = new System.Windows.Forms.Label();
            tbSziltechSerialNumber = new System.Windows.Forms.TextBox();
            lblSziltechSerialNumberOptional = new System.Windows.Forms.Label();
            btnValidate = new System.Windows.Forms.Button();
            btnClose = new System.Windows.Forms.Button();
            btnAddOrModify = new System.Windows.Forms.Button();
            gbNetwork = new System.Windows.Forms.GroupBox();
            lblManufacturer = new System.Windows.Forms.Label();
            tbManufacturer = new System.Windows.Forms.TextBox();
            tbMacAddress = new System.Windows.Forms.TextBox();
            lblMacAddressOptional = new System.Windows.Forms.Label();
            gbVideoServer = new System.Windows.Forms.GroupBox();
            cbIpAddress = new System.Windows.Forms.ComboBox();
            tbHostname = new System.Windows.Forms.TextBox();
            lblHostname = new System.Windows.Forms.Label();
            tbPassword = new Mtf.Controls.PasswordBox();
            lblPassword = new System.Windows.Forms.Label();
            tbUsername = new System.Windows.Forms.TextBox();
            lblUsername = new System.Windows.Forms.Label();
            lblIpAddress = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            lblWinPassword = new System.Windows.Forms.Label();
            tbWinPassword = new Mtf.Controls.PasswordBox();
            tbWinUsername = new System.Windows.Forms.TextBox();
            lblWinUsername = new System.Windows.Forms.Label();
            pMain.SuspendLayout();
            gbValidate.SuspendLayout();
            gbNetwork.SuspendLayout();
            gbVideoServer.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pMain
            // 
            pMain.Controls.Add(groupBox1);
            pMain.Controls.Add(gbValidate);
            pMain.Controls.Add(btnClose);
            pMain.Controls.Add(btnAddOrModify);
            pMain.Controls.Add(gbNetwork);
            pMain.Controls.Add(gbVideoServer);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(315, 485);
            pMain.TabIndex = 0;
            // 
            // gbValidate
            // 
            gbValidate.Controls.Add(tbModel);
            gbValidate.Controls.Add(lblModel);
            gbValidate.Controls.Add(tbSziltechSerialNumber);
            gbValidate.Controls.Add(lblSziltechSerialNumberOptional);
            gbValidate.Controls.Add(btnValidate);
            gbValidate.Dock = System.Windows.Forms.DockStyle.Top;
            gbValidate.Location = new System.Drawing.Point(0, 275);
            gbValidate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbValidate.Name = "gbValidate";
            gbValidate.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbValidate.Size = new System.Drawing.Size(315, 99);
            gbValidate.TabIndex = 7;
            gbValidate.TabStop = false;
            gbValidate.Text = "Validate";
            // 
            // tbModel
            // 
            tbModel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbModel.Location = new System.Drawing.Point(151, 37);
            tbModel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbModel.MaxLength = 20;
            tbModel.Name = "tbModel";
            tbModel.ReadOnly = true;
            tbModel.Size = new System.Drawing.Size(153, 23);
            tbModel.TabIndex = 4;
            // 
            // lblModel
            // 
            lblModel.AutoSize = true;
            lblModel.Location = new System.Drawing.Point(151, 18);
            lblModel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblModel.Name = "lblModel";
            lblModel.Size = new System.Drawing.Size(41, 15);
            lblModel.TabIndex = 4;
            lblModel.Text = "Model";
            // 
            // tbSziltechSerialNumber
            // 
            tbSziltechSerialNumber.Location = new System.Drawing.Point(10, 37);
            tbSziltechSerialNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbSziltechSerialNumber.MaxLength = 100;
            tbSziltechSerialNumber.Name = "tbSziltechSerialNumber";
            tbSziltechSerialNumber.Size = new System.Drawing.Size(133, 23);
            tbSziltechSerialNumber.TabIndex = 1;
            // 
            // lblSziltechSerialNumberOptional
            // 
            lblSziltechSerialNumberOptional.AutoSize = true;
            lblSziltechSerialNumberOptional.Location = new System.Drawing.Point(7, 18);
            lblSziltechSerialNumberOptional.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSziltechSerialNumberOptional.Name = "lblSziltechSerialNumberOptional";
            lblSziltechSerialNumberOptional.Size = new System.Drawing.Size(120, 15);
            lblSziltechSerialNumberOptional.TabIndex = 0;
            lblSziltechSerialNumberOptional.Text = "Sziltech SN (optional)";
            // 
            // btnValidate
            // 
            btnValidate.Location = new System.Drawing.Point(7, 65);
            btnValidate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnValidate.Name = "btnValidate";
            btnValidate.Size = new System.Drawing.Size(88, 27);
            btnValidate.TabIndex = 2;
            btnValidate.Text = "Validate";
            btnValidate.UseVisualStyleBackColor = true;
            btnValidate.Click += BtnValidate_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.Location = new System.Drawing.Point(218, 452);
            btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(88, 27);
            btnClose.TabIndex = 9;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            // 
            // btnAddOrModify
            // 
            btnAddOrModify.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnAddOrModify.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnAddOrModify.Enabled = false;
            btnAddOrModify.Location = new System.Drawing.Point(124, 452);
            btnAddOrModify.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAddOrModify.Name = "btnAddOrModify";
            btnAddOrModify.Size = new System.Drawing.Size(88, 27);
            btnAddOrModify.TabIndex = 8;
            btnAddOrModify.Text = "Add";
            btnAddOrModify.UseVisualStyleBackColor = true;
            btnAddOrModify.Click += BtnAddOrModify_Click;
            // 
            // gbNetwork
            // 
            gbNetwork.Controls.Add(lblManufacturer);
            gbNetwork.Controls.Add(tbManufacturer);
            gbNetwork.Controls.Add(tbMacAddress);
            gbNetwork.Controls.Add(lblMacAddressOptional);
            gbNetwork.Dock = System.Windows.Forms.DockStyle.Top;
            gbNetwork.Location = new System.Drawing.Point(0, 205);
            gbNetwork.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbNetwork.Name = "gbNetwork";
            gbNetwork.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbNetwork.Size = new System.Drawing.Size(315, 70);
            gbNetwork.TabIndex = 6;
            gbNetwork.TabStop = false;
            gbNetwork.Text = "Network";
            // 
            // lblManufacturer
            // 
            lblManufacturer.AutoSize = true;
            lblManufacturer.Location = new System.Drawing.Point(151, 17);
            lblManufacturer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblManufacturer.Name = "lblManufacturer";
            lblManufacturer.Size = new System.Drawing.Size(79, 15);
            lblManufacturer.TabIndex = 3;
            lblManufacturer.Text = "Manufacturer";
            // 
            // tbManufacturer
            // 
            tbManufacturer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbManufacturer.Location = new System.Drawing.Point(151, 35);
            tbManufacturer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbManufacturer.MaxLength = 20;
            tbManufacturer.Name = "tbManufacturer";
            tbManufacturer.ReadOnly = true;
            tbManufacturer.Size = new System.Drawing.Size(153, 23);
            tbManufacturer.TabIndex = 2;
            // 
            // tbMacAddress
            // 
            tbMacAddress.Location = new System.Drawing.Point(10, 35);
            tbMacAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbMacAddress.MaxLength = 20;
            tbMacAddress.Name = "tbMacAddress";
            tbMacAddress.Size = new System.Drawing.Size(133, 23);
            tbMacAddress.TabIndex = 1;
            // 
            // lblMacAddressOptional
            // 
            lblMacAddressOptional.AutoSize = true;
            lblMacAddressOptional.Location = new System.Drawing.Point(7, 18);
            lblMacAddressOptional.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMacAddressOptional.Name = "lblMacAddressOptional";
            lblMacAddressOptional.Size = new System.Drawing.Size(134, 15);
            lblMacAddressOptional.TabIndex = 0;
            lblMacAddressOptional.Text = "MAC Address (optional)";
            // 
            // gbVideoServer
            // 
            gbVideoServer.Controls.Add(cbIpAddress);
            gbVideoServer.Controls.Add(tbHostname);
            gbVideoServer.Controls.Add(lblHostname);
            gbVideoServer.Controls.Add(tbPassword);
            gbVideoServer.Controls.Add(lblPassword);
            gbVideoServer.Controls.Add(tbUsername);
            gbVideoServer.Controls.Add(lblUsername);
            gbVideoServer.Controls.Add(lblIpAddress);
            gbVideoServer.Dock = System.Windows.Forms.DockStyle.Top;
            gbVideoServer.Location = new System.Drawing.Point(0, 0);
            gbVideoServer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbVideoServer.Name = "gbVideoServer";
            gbVideoServer.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbVideoServer.Size = new System.Drawing.Size(315, 205);
            gbVideoServer.TabIndex = 5;
            gbVideoServer.TabStop = false;
            gbVideoServer.Text = "Video server";
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
            cbIpAddress.SelectedIndexChanged += CbIpAddress_SelectedIndexChanged;
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
            tbPassword.ShowRealPasswordLength = false;
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
            // groupBox1
            // 
            groupBox1.Controls.Add(lblWinPassword);
            groupBox1.Controls.Add(tbWinPassword);
            groupBox1.Controls.Add(tbWinUsername);
            groupBox1.Controls.Add(lblWinUsername);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox1.Location = new System.Drawing.Point(0, 374);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(315, 70);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Microsoft Windows";
            // 
            // lblWinPassword
            // 
            lblWinPassword.AutoSize = true;
            lblWinPassword.Location = new System.Drawing.Point(152, 17);
            lblWinPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblWinPassword.Name = "lblWinPassword";
            lblWinPassword.Size = new System.Drawing.Size(57, 15);
            lblWinPassword.TabIndex = 3;
            lblWinPassword.Text = "Password";
            // 
            // tbWinPassword
            // 
            tbWinPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbWinPassword.Location = new System.Drawing.Point(152, 35);
            tbWinPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbWinPassword.MaxLength = 20;
            tbWinPassword.Name = "tbWinPassword";
            tbWinPassword.PasswordChar = '*';
            tbWinPassword.Size = new System.Drawing.Size(152, 23);
            tbWinPassword.TabIndex = 2;
            // 
            // tbWinUsername
            // 
            tbWinUsername.Location = new System.Drawing.Point(10, 35);
            tbWinUsername.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbWinUsername.MaxLength = 20;
            tbWinUsername.Name = "tbWinUsername";
            tbWinUsername.Size = new System.Drawing.Size(133, 23);
            tbWinUsername.TabIndex = 1;
            // 
            // lblWinUsername
            // 
            lblWinUsername.AutoSize = true;
            lblWinUsername.Location = new System.Drawing.Point(8, 18);
            lblWinUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblWinUsername.Name = "lblWinUsername";
            lblWinUsername.Size = new System.Drawing.Size(60, 15);
            lblWinUsername.TabIndex = 0;
            lblWinUsername.Text = "Username";
            // 
            // AddVideoServer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(315, 485);
            Controls.Add(pMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(331, 524);
            Name = "AddVideoServer";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "New video server";
            TopMost = true;
            Shown += AddVideoServer_Shown;
            pMain.ResumeLayout(false);
            gbValidate.ResumeLayout(false);
            gbValidate.PerformLayout();
            gbNetwork.ResumeLayout(false);
            gbNetwork.PerformLayout();
            gbVideoServer.ResumeLayout(false);
            gbVideoServer.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.GroupBox gbValidate;
        private System.Windows.Forms.TextBox tbSziltechSerialNumber;
        private System.Windows.Forms.Label lblSziltechSerialNumberOptional;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddOrModify;
        private System.Windows.Forms.GroupBox gbNetwork;
        private System.Windows.Forms.TextBox tbMacAddress;
        private System.Windows.Forms.Label lblMacAddressOptional;
        private System.Windows.Forms.GroupBox gbVideoServer;
        private System.Windows.Forms.ComboBox cbIpAddress;
        private System.Windows.Forms.TextBox tbHostname;
        private System.Windows.Forms.Label lblHostname;
        private Mtf.Controls.PasswordBox tbPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblIpAddress;
        private System.Windows.Forms.TextBox tbManufacturer;
        private System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.TextBox tbModel;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblWinPassword;
        private Mtf.Controls.PasswordBox tbWinPassword;
        private System.Windows.Forms.TextBox tbWinUsername;
        private System.Windows.Forms.Label lblWinUsername;
    }
}
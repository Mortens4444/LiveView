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
            gb_Validate = new System.Windows.Forms.GroupBox();
            tb_SziltechSN = new System.Windows.Forms.TextBox();
            lbl_SziltechSNOptional = new System.Windows.Forms.Label();
            btn_Validate = new System.Windows.Forms.Button();
            btn_Cancel = new System.Windows.Forms.Button();
            btn_AddOrModify = new System.Windows.Forms.Button();
            gb_Network = new System.Windows.Forms.GroupBox();
            lblManufacturer = new System.Windows.Forms.Label();
            tbManufacturer = new System.Windows.Forms.TextBox();
            tb_MACAddress = new System.Windows.Forms.TextBox();
            lbl_MACAddressOptional = new System.Windows.Forms.Label();
            gb_VideoServer = new System.Windows.Forms.GroupBox();
            cb_DNSNameOrIPAddress = new System.Windows.Forms.ComboBox();
            tb_DisplayedName = new System.Windows.Forms.TextBox();
            lbl_DisplayedName = new System.Windows.Forms.Label();
            tb_Password = new Mtf.Controls.PasswordBox();
            lbl_Password = new System.Windows.Forms.Label();
            tb_Username = new System.Windows.Forms.TextBox();
            lbl_Username = new System.Windows.Forms.Label();
            lbl_DNSNameOrIPAddress = new System.Windows.Forms.Label();
            pMain.SuspendLayout();
            gb_Validate.SuspendLayout();
            gb_Network.SuspendLayout();
            gb_VideoServer.SuspendLayout();
            SuspendLayout();
            // 
            // pMain
            // 
            pMain.Controls.Add(gb_Validate);
            pMain.Controls.Add(btn_Cancel);
            pMain.Controls.Add(btn_AddOrModify);
            pMain.Controls.Add(gb_Network);
            pMain.Controls.Add(gb_VideoServer);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(315, 382);
            pMain.TabIndex = 0;
            // 
            // gb_Validate
            // 
            gb_Validate.Controls.Add(tb_SziltechSN);
            gb_Validate.Controls.Add(lbl_SziltechSNOptional);
            gb_Validate.Controls.Add(btn_Validate);
            gb_Validate.Dock = System.Windows.Forms.DockStyle.Top;
            gb_Validate.Location = new System.Drawing.Point(0, 275);
            gb_Validate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Validate.Name = "gb_Validate";
            gb_Validate.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Validate.Size = new System.Drawing.Size(315, 70);
            gb_Validate.TabIndex = 7;
            gb_Validate.TabStop = false;
            gb_Validate.Text = "Validate";
            // 
            // tb_SziltechSN
            // 
            tb_SziltechSN.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_SziltechSN.Location = new System.Drawing.Point(10, 37);
            tb_SziltechSN.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_SziltechSN.MaxLength = 100;
            tb_SziltechSN.Name = "tb_SziltechSN";
            tb_SziltechSN.Size = new System.Drawing.Size(200, 23);
            tb_SziltechSN.TabIndex = 1;
            // 
            // lbl_SziltechSNOptional
            // 
            lbl_SziltechSNOptional.AutoSize = true;
            lbl_SziltechSNOptional.Location = new System.Drawing.Point(7, 18);
            lbl_SziltechSNOptional.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_SziltechSNOptional.Name = "lbl_SziltechSNOptional";
            lbl_SziltechSNOptional.Size = new System.Drawing.Size(122, 15);
            lbl_SziltechSNOptional.TabIndex = 0;
            lbl_SziltechSNOptional.Text = "Sziltech SN (opcional)";
            // 
            // btn_Validate
            // 
            btn_Validate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_Validate.Location = new System.Drawing.Point(218, 35);
            btn_Validate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Validate.Name = "btn_Validate";
            btn_Validate.Size = new System.Drawing.Size(88, 27);
            btn_Validate.TabIndex = 2;
            btn_Validate.Text = "Validate";
            btn_Validate.UseVisualStyleBackColor = true;
            btn_Validate.Click += Btn_Validate_Click;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btn_Cancel.Location = new System.Drawing.Point(218, 349);
            btn_Cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new System.Drawing.Size(88, 27);
            btn_Cancel.TabIndex = 9;
            btn_Cancel.Text = "Cancel";
            btn_Cancel.UseVisualStyleBackColor = true;
            btn_Cancel.Click += Btn_Cancel_Click;
            // 
            // btn_AddOrModify
            // 
            btn_AddOrModify.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_AddOrModify.DialogResult = System.Windows.Forms.DialogResult.OK;
            btn_AddOrModify.Enabled = false;
            btn_AddOrModify.Location = new System.Drawing.Point(124, 349);
            btn_AddOrModify.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_AddOrModify.Name = "btn_AddOrModify";
            btn_AddOrModify.Size = new System.Drawing.Size(88, 27);
            btn_AddOrModify.TabIndex = 8;
            btn_AddOrModify.Text = "Add";
            btn_AddOrModify.UseVisualStyleBackColor = true;
            btn_AddOrModify.Click += Btn_AddOrModify_Click;
            // 
            // gb_Network
            // 
            gb_Network.Controls.Add(lblManufacturer);
            gb_Network.Controls.Add(tbManufacturer);
            gb_Network.Controls.Add(tb_MACAddress);
            gb_Network.Controls.Add(lbl_MACAddressOptional);
            gb_Network.Dock = System.Windows.Forms.DockStyle.Top;
            gb_Network.Location = new System.Drawing.Point(0, 205);
            gb_Network.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Network.Name = "gb_Network";
            gb_Network.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Network.Size = new System.Drawing.Size(315, 70);
            gb_Network.TabIndex = 6;
            gb_Network.TabStop = false;
            gb_Network.Text = "Network";
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
            // tb_MACAddress
            // 
            tb_MACAddress.Location = new System.Drawing.Point(10, 35);
            tb_MACAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_MACAddress.MaxLength = 20;
            tb_MACAddress.Name = "tb_MACAddress";
            tb_MACAddress.Size = new System.Drawing.Size(133, 23);
            tb_MACAddress.TabIndex = 1;
            // 
            // lbl_MACAddressOptional
            // 
            lbl_MACAddressOptional.AutoSize = true;
            lbl_MACAddressOptional.Location = new System.Drawing.Point(7, 18);
            lbl_MACAddressOptional.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_MACAddressOptional.Name = "lbl_MACAddressOptional";
            lbl_MACAddressOptional.Size = new System.Drawing.Size(136, 15);
            lbl_MACAddressOptional.TabIndex = 0;
            lbl_MACAddressOptional.Text = "MAC Address (opcional)";
            // 
            // gb_VideoServer
            // 
            gb_VideoServer.Controls.Add(cb_DNSNameOrIPAddress);
            gb_VideoServer.Controls.Add(tb_DisplayedName);
            gb_VideoServer.Controls.Add(lbl_DisplayedName);
            gb_VideoServer.Controls.Add(tb_Password);
            gb_VideoServer.Controls.Add(lbl_Password);
            gb_VideoServer.Controls.Add(tb_Username);
            gb_VideoServer.Controls.Add(lbl_Username);
            gb_VideoServer.Controls.Add(lbl_DNSNameOrIPAddress);
            gb_VideoServer.Dock = System.Windows.Forms.DockStyle.Top;
            gb_VideoServer.Location = new System.Drawing.Point(0, 0);
            gb_VideoServer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_VideoServer.Name = "gb_VideoServer";
            gb_VideoServer.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_VideoServer.Size = new System.Drawing.Size(315, 205);
            gb_VideoServer.TabIndex = 5;
            gb_VideoServer.TabStop = false;
            gb_VideoServer.Text = "Video server";
            // 
            // cb_DNSNameOrIPAddress
            // 
            cb_DNSNameOrIPAddress.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cb_DNSNameOrIPAddress.FormattingEnabled = true;
            cb_DNSNameOrIPAddress.Location = new System.Drawing.Point(10, 37);
            cb_DNSNameOrIPAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_DNSNameOrIPAddress.Name = "cb_DNSNameOrIPAddress";
            cb_DNSNameOrIPAddress.Size = new System.Drawing.Size(294, 23);
            cb_DNSNameOrIPAddress.TabIndex = 1;
            cb_DNSNameOrIPAddress.SelectedIndexChanged += Cb_DNSNameOrIPAddress_SelectedIndexChanged;
            // 
            // tb_DisplayedName
            // 
            tb_DisplayedName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_DisplayedName.Location = new System.Drawing.Point(10, 83);
            tb_DisplayedName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_DisplayedName.MaxLength = 100;
            tb_DisplayedName.Name = "tb_DisplayedName";
            tb_DisplayedName.Size = new System.Drawing.Size(294, 23);
            tb_DisplayedName.TabIndex = 3;
            // 
            // lbl_DisplayedName
            // 
            lbl_DisplayedName.AutoSize = true;
            lbl_DisplayedName.Location = new System.Drawing.Point(7, 65);
            lbl_DisplayedName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_DisplayedName.Name = "lbl_DisplayedName";
            lbl_DisplayedName.Size = new System.Drawing.Size(91, 15);
            lbl_DisplayedName.TabIndex = 2;
            lbl_DisplayedName.Text = "Displayed name";
            // 
            // tb_Password
            // 
            tb_Password.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_Password.Location = new System.Drawing.Point(10, 172);
            tb_Password.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_Password.MaxLength = 100;
            tb_Password.Name = "tb_Password";
            tb_Password.Password = "";
            tb_Password.PasswordChar = '*';
            tb_Password.ShowRealPasswordLength = false;
            tb_Password.Size = new System.Drawing.Size(294, 23);
            tb_Password.TabIndex = 7;
            // 
            // lbl_Password
            // 
            lbl_Password.AutoSize = true;
            lbl_Password.Location = new System.Drawing.Point(7, 153);
            lbl_Password.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Password.Name = "lbl_Password";
            lbl_Password.Size = new System.Drawing.Size(57, 15);
            lbl_Password.TabIndex = 6;
            lbl_Password.Text = "Password";
            // 
            // tb_Username
            // 
            tb_Username.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_Username.Location = new System.Drawing.Point(10, 127);
            tb_Username.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_Username.MaxLength = 100;
            tb_Username.Name = "tb_Username";
            tb_Username.Size = new System.Drawing.Size(294, 23);
            tb_Username.TabIndex = 5;
            // 
            // lbl_Username
            // 
            lbl_Username.AutoSize = true;
            lbl_Username.Location = new System.Drawing.Point(7, 108);
            lbl_Username.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Username.Name = "lbl_Username";
            lbl_Username.Size = new System.Drawing.Size(60, 15);
            lbl_Username.TabIndex = 4;
            lbl_Username.Text = "Username";
            // 
            // lbl_DNSNameOrIPAddress
            // 
            lbl_DNSNameOrIPAddress.AutoSize = true;
            lbl_DNSNameOrIPAddress.Location = new System.Drawing.Point(7, 18);
            lbl_DNSNameOrIPAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_DNSNameOrIPAddress.Name = "lbl_DNSNameOrIPAddress";
            lbl_DNSNameOrIPAddress.Size = new System.Drawing.Size(133, 15);
            lbl_DNSNameOrIPAddress.TabIndex = 0;
            lbl_DNSNameOrIPAddress.Text = "DNS name or IP address";
            // 
            // AddVideoServer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(315, 382);
            Controls.Add(pMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(322, 407);
            Name = "AddVideoServer";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "New Video Server";
            TopMost = true;
            Shown += AddVideoServer_Shown;
            pMain.ResumeLayout(false);
            gb_Validate.ResumeLayout(false);
            gb_Validate.PerformLayout();
            gb_Network.ResumeLayout(false);
            gb_Network.PerformLayout();
            gb_VideoServer.ResumeLayout(false);
            gb_VideoServer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.GroupBox gb_Validate;
        private System.Windows.Forms.TextBox tb_SziltechSN;
        private System.Windows.Forms.Label lbl_SziltechSNOptional;
        private System.Windows.Forms.Button btn_Validate;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_AddOrModify;
        private System.Windows.Forms.GroupBox gb_Network;
        private System.Windows.Forms.TextBox tb_MACAddress;
        private System.Windows.Forms.Label lbl_MACAddressOptional;
        private System.Windows.Forms.GroupBox gb_VideoServer;
        private System.Windows.Forms.ComboBox cb_DNSNameOrIPAddress;
        private System.Windows.Forms.TextBox tb_DisplayedName;
        private System.Windows.Forms.Label lbl_DisplayedName;
        private Mtf.Controls.PasswordBox tb_Password;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.TextBox tb_Username;
        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.Label lbl_DNSNameOrIPAddress;
        private System.Windows.Forms.TextBox tbManufacturer;
        private System.Windows.Forms.Label lblManufacturer;
    }
}
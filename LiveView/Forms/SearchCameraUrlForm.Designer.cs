namespace LiveView.Forms
{
    partial class SearchCameraUrlForm
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
            panel1 = new System.Windows.Forms.Panel();
            cbIpAddress = new System.Windows.Forms.ComboBox();
            btnCopy = new System.Windows.Forms.Button();
            lblManufacturer = new System.Windows.Forms.Label();
            cbManufacturer = new System.Windows.Forms.ComboBox();
            btnSearch = new System.Windows.Forms.Button();
            nudTimeout = new System.Windows.Forms.NumericUpDown();
            lblTimeout = new System.Windows.Forms.Label();
            nudHeight = new System.Windows.Forms.NumericUpDown();
            lblHeight = new System.Windows.Forms.Label();
            nudWidth = new System.Windows.Forms.NumericUpDown();
            lblWidth = new System.Windows.Forms.Label();
            nudChannel = new System.Windows.Forms.NumericUpDown();
            lblChannel = new System.Windows.Forms.Label();
            tbPassword = new System.Windows.Forms.TextBox();
            lblPassword = new System.Windows.Forms.Label();
            tbUsername = new System.Windows.Forms.TextBox();
            lblUsername = new System.Windows.Forms.Label();
            lblIpAddress = new System.Windows.Forms.Label();
            lblCameraUrls = new System.Windows.Forms.Label();
            cbCameraUrls = new System.Windows.Forms.ComboBox();
            pMain.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudTimeout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudChannel).BeginInit();
            SuspendLayout();
            // 
            // pMain
            // 
            pMain.Controls.Add(panel1);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(542, 201);
            pMain.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(cbIpAddress);
            panel1.Controls.Add(btnCopy);
            panel1.Controls.Add(lblManufacturer);
            panel1.Controls.Add(cbManufacturer);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(nudTimeout);
            panel1.Controls.Add(lblTimeout);
            panel1.Controls.Add(nudHeight);
            panel1.Controls.Add(lblHeight);
            panel1.Controls.Add(nudWidth);
            panel1.Controls.Add(lblWidth);
            panel1.Controls.Add(nudChannel);
            panel1.Controls.Add(lblChannel);
            panel1.Controls.Add(tbPassword);
            panel1.Controls.Add(lblPassword);
            panel1.Controls.Add(tbUsername);
            panel1.Controls.Add(lblUsername);
            panel1.Controls.Add(lblIpAddress);
            panel1.Controls.Add(lblCameraUrls);
            panel1.Controls.Add(cbCameraUrls);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(542, 201);
            panel1.TabIndex = 2;
            // 
            // cbIpAddress
            // 
            cbIpAddress.FormattingEnabled = true;
            cbIpAddress.Location = new System.Drawing.Point(12, 115);
            cbIpAddress.Name = "cbIpAddress";
            cbIpAddress.Size = new System.Drawing.Size(165, 23);
            cbIpAddress.TabIndex = 22;
            // 
            // btnCopy
            // 
            btnCopy.Image = Properties.Resources.copy;
            btnCopy.Location = new System.Drawing.Point(507, 71);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new System.Drawing.Size(25, 25);
            btnCopy.TabIndex = 21;
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += BtnCopy_Click;
            // 
            // lblManufacturer
            // 
            lblManufacturer.AutoSize = true;
            lblManufacturer.Location = new System.Drawing.Point(13, 9);
            lblManufacturer.Name = "lblManufacturer";
            lblManufacturer.Size = new System.Drawing.Size(79, 15);
            lblManufacturer.TabIndex = 20;
            lblManufacturer.Text = "Manufacturer";
            // 
            // cbManufacturer
            // 
            cbManufacturer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbManufacturer.FormattingEnabled = true;
            cbManufacturer.Location = new System.Drawing.Point(13, 27);
            cbManufacturer.Name = "cbManufacturer";
            cbManufacturer.Size = new System.Drawing.Size(519, 23);
            cbManufacturer.TabIndex = 19;
            cbManufacturer.SelectedIndexChanged += CbManufacturer_SelectedIndexChanged;
            // 
            // btnSearch
            // 
            btnSearch.Location = new System.Drawing.Point(457, 168);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(75, 23);
            btnSearch.TabIndex = 18;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += BtnSearch_Click;
            // 
            // nudTimeout
            // 
            nudTimeout.Location = new System.Drawing.Point(366, 168);
            nudTimeout.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudTimeout.Name = "nudTimeout";
            nudTimeout.Size = new System.Drawing.Size(57, 23);
            nudTimeout.TabIndex = 17;
            nudTimeout.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // lblTimeout
            // 
            lblTimeout.AutoSize = true;
            lblTimeout.Location = new System.Drawing.Point(365, 150);
            lblTimeout.Name = "lblTimeout";
            lblTimeout.Size = new System.Drawing.Size(52, 15);
            lblTimeout.TabIndex = 16;
            lblTimeout.Text = "Timeout";
            // 
            // nudHeight
            // 
            nudHeight.Location = new System.Drawing.Point(262, 166);
            nudHeight.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudHeight.Name = "nudHeight";
            nudHeight.Size = new System.Drawing.Size(63, 23);
            nudHeight.TabIndex = 15;
            nudHeight.Value = new decimal(new int[] { 640, 0, 0, 0 });
            // 
            // lblHeight
            // 
            lblHeight.AutoSize = true;
            lblHeight.Location = new System.Drawing.Point(262, 148);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new System.Drawing.Size(43, 15);
            lblHeight.TabIndex = 14;
            lblHeight.Text = "Height";
            // 
            // nudWidth
            // 
            nudWidth.Location = new System.Drawing.Point(190, 166);
            nudWidth.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudWidth.Name = "nudWidth";
            nudWidth.Size = new System.Drawing.Size(63, 23);
            nudWidth.TabIndex = 13;
            nudWidth.Value = new decimal(new int[] { 320, 0, 0, 0 });
            // 
            // lblWidth
            // 
            lblWidth.AutoSize = true;
            lblWidth.Location = new System.Drawing.Point(189, 148);
            lblWidth.Name = "lblWidth";
            lblWidth.Size = new System.Drawing.Size(39, 15);
            lblWidth.TabIndex = 12;
            lblWidth.Text = "Width";
            // 
            // nudChannel
            // 
            nudChannel.Location = new System.Drawing.Point(14, 166);
            nudChannel.Name = "nudChannel";
            nudChannel.Size = new System.Drawing.Size(58, 23);
            nudChannel.TabIndex = 11;
            // 
            // lblChannel
            // 
            lblChannel.AutoSize = true;
            lblChannel.Location = new System.Drawing.Point(13, 148);
            lblChannel.Name = "lblChannel";
            lblChannel.Size = new System.Drawing.Size(51, 15);
            lblChannel.TabIndex = 10;
            lblChannel.Text = "Channel";
            // 
            // tbPassword
            // 
            tbPassword.Location = new System.Drawing.Point(365, 115);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new System.Drawing.Size(167, 23);
            tbPassword.TabIndex = 9;
            tbPassword.Text = "admin";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new System.Drawing.Point(366, 97);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(57, 15);
            lblPassword.TabIndex = 8;
            lblPassword.Text = "Password";
            // 
            // tbUsername
            // 
            tbUsername.Location = new System.Drawing.Point(189, 115);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new System.Drawing.Size(165, 23);
            tbUsername.TabIndex = 7;
            tbUsername.Text = "admin";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new System.Drawing.Point(189, 97);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new System.Drawing.Size(60, 15);
            lblUsername.TabIndex = 6;
            lblUsername.Text = "Username";
            // 
            // lblIpAddress
            // 
            lblIpAddress.AutoSize = true;
            lblIpAddress.Location = new System.Drawing.Point(12, 97);
            lblIpAddress.Name = "lblIpAddress";
            lblIpAddress.Size = new System.Drawing.Size(60, 15);
            lblIpAddress.TabIndex = 4;
            lblIpAddress.Text = "IP address";
            // 
            // lblCameraUrls
            // 
            lblCameraUrls.AutoSize = true;
            lblCameraUrls.Location = new System.Drawing.Point(12, 53);
            lblCameraUrls.Name = "lblCameraUrls";
            lblCameraUrls.Size = new System.Drawing.Size(77, 15);
            lblCameraUrls.TabIndex = 3;
            lblCameraUrls.Text = "Camera URLs";
            // 
            // cbCameraUrls
            // 
            cbCameraUrls.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbCameraUrls.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCameraUrls.FormattingEnabled = true;
            cbCameraUrls.Location = new System.Drawing.Point(12, 71);
            cbCameraUrls.Name = "cbCameraUrls";
            cbCameraUrls.Size = new System.Drawing.Size(489, 23);
            cbCameraUrls.TabIndex = 2;
            // 
            // SearchCameraUrlForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(542, 201);
            Controls.Add(pMain);
            Name = "SearchCameraUrlForm";
            Text = "Search Camera URL";
            Shown += SearchCameraUrlForm_Shown;
            pMain.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudTimeout).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudChannel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.NumericUpDown nudTimeout;
        private System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.NumericUpDown nudChannel;
        private System.Windows.Forms.Label lblChannel;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblIpAddress;
        private System.Windows.Forms.Label lblCameraUrls;
        private System.Windows.Forms.ComboBox cbCameraUrls;
        private System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.ComboBox cbManufacturer;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.ComboBox cbIpAddress;
    }
}
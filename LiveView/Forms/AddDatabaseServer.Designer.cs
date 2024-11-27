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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDatabaseServer));
            pMain = new System.Windows.Forms.Panel();
            btnCancel = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            groupBox2 = new System.Windows.Forms.GroupBox();
            tbDatabaseServerMacAddress = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label7 = new System.Windows.Forms.Label();
            nudDatabaseServerPort = new System.Windows.Forms.NumericUpDown();
            tbDatabaseName = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            cb_HostnameOrIP = new System.Windows.Forms.ComboBox();
            tb_DisplayedName = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            tbPassword = new Mtf.Controls.PasswordBox();
            label4 = new System.Windows.Forms.Label();
            tbusername = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            pMain.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDatabaseServerPort).BeginInit();
            SuspendLayout();
            // 
            // pMain
            // 
            pMain.Controls.Add(btnCancel);
            pMain.Controls.Add(btnAdd);
            pMain.Controls.Add(groupBox2);
            pMain.Controls.Add(groupBox1);
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
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnCancel_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnAdd.Location = new System.Drawing.Point(127, 359);
            btnAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(88, 27);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += BtnAdd_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tbDatabaseServerMacAddress);
            groupBox2.Controls.Add(label6);
            groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox2.Location = new System.Drawing.Point(0, 286);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Size = new System.Drawing.Size(315, 70);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Network";
            // 
            // tbDatabaseServerMacAddress
            // 
            tbDatabaseServerMacAddress.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbDatabaseServerMacAddress.Location = new System.Drawing.Point(10, 35);
            tbDatabaseServerMacAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbDatabaseServerMacAddress.MaxLength = 20;
            tbDatabaseServerMacAddress.Name = "tbDatabaseServerMacAddress";
            tbDatabaseServerMacAddress.Size = new System.Drawing.Size(294, 23);
            tbDatabaseServerMacAddress.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(7, 18);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(144, 15);
            label6.TabIndex = 0;
            label6.Text = "MAC Address (opcionális)";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(nudDatabaseServerPort);
            groupBox1.Controls.Add(tbDatabaseName);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(cb_HostnameOrIP);
            groupBox1.Controls.Add(tb_DisplayedName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(tbPassword);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(tbusername);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox1.Location = new System.Drawing.Point(0, 0);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(315, 286);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Database server";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(9, 255);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(64, 15);
            label7.TabIndex = 11;
            label7.Text = "Server port";
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
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(7, 204);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(88, 15);
            label5.TabIndex = 8;
            label5.Text = "Database name";
            // 
            // cb_HostnameOrIP
            // 
            cb_HostnameOrIP.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cb_HostnameOrIP.FormattingEnabled = true;
            cb_HostnameOrIP.Location = new System.Drawing.Point(10, 37);
            cb_HostnameOrIP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_HostnameOrIP.Name = "cb_HostnameOrIP";
            cb_HostnameOrIP.Size = new System.Drawing.Size(294, 23);
            cb_HostnameOrIP.TabIndex = 1;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(7, 65);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(76, 15);
            label2.TabIndex = 2;
            label2.Text = "Shown name";
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(7, 153);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(57, 15);
            label4.TabIndex = 6;
            label4.Text = "Password";
            // 
            // tbusername
            // 
            tbusername.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbusername.Location = new System.Drawing.Point(10, 127);
            tbusername.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbusername.MaxLength = 100;
            tbusername.Name = "tbusername";
            tbusername.Size = new System.Drawing.Size(294, 23);
            tbusername.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(7, 108);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(60, 15);
            label3.TabIndex = 4;
            label3.Text = "Username";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(7, 18);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(133, 15);
            label1.TabIndex = 0;
            label1.Text = "DNS name or IP address";
            // 
            // AddDatabaseServer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(315, 392);
            Controls.Add(pMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "AddDatabaseServer";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "New database server";
            TopMost = true;
            pMain.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDatabaseServerPort).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbDatabaseServerMacAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudDatabaseServerPort;
        private System.Windows.Forms.TextBox tbDatabaseName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_HostnameOrIP;
        private System.Windows.Forms.TextBox tb_DisplayedName;
        private System.Windows.Forms.Label label2;
        private Mtf.Controls.PasswordBox tbPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbusername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}
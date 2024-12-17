namespace LiveView.Forms
{
    partial class About
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            pMain = new System.Windows.Forms.Panel();
            tbConditionsAndTerms = new System.Windows.Forms.TextBox();
            gbLogo = new System.Windows.Forms.GroupBox();
            pbLogo = new System.Windows.Forms.PictureBox();
            btnOk = new System.Windows.Forms.Button();
            lblVendor = new System.Windows.Forms.Label();
            lblCopyRight = new System.Windows.Forms.Label();
            lblAddress = new System.Windows.Forms.Label();
            lblVersion = new System.Windows.Forms.Label();
            lblPhone2 = new System.Windows.Forms.Label();
            lblProductName = new System.Windows.Forms.Label();
            lblSupportContact = new System.Windows.Forms.Label();
            llEmailAddress = new System.Windows.Forms.LinkLabel();
            lblPhone = new System.Windows.Forms.Label();
            llWebPage = new System.Windows.Forms.LinkLabel();
            lblFax = new System.Windows.Forms.Label();
            pMain.SuspendLayout();
            gbLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // pMain
            // 
            pMain.Controls.Add(tbConditionsAndTerms);
            pMain.Controls.Add(gbLogo);
            pMain.Controls.Add(btnOk);
            pMain.Controls.Add(lblVendor);
            pMain.Controls.Add(lblCopyRight);
            pMain.Controls.Add(lblAddress);
            pMain.Controls.Add(lblVersion);
            pMain.Controls.Add(lblPhone2);
            pMain.Controls.Add(lblProductName);
            pMain.Controls.Add(lblSupportContact);
            pMain.Controls.Add(llEmailAddress);
            pMain.Controls.Add(lblPhone);
            pMain.Controls.Add(llWebPage);
            pMain.Controls.Add(lblFax);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(569, 257);
            pMain.TabIndex = 15;
            // 
            // tbConditionsAndTerms
            // 
            tbConditionsAndTerms.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbConditionsAndTerms.Enabled = false;
            tbConditionsAndTerms.Location = new System.Drawing.Point(9, 186);
            tbConditionsAndTerms.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbConditionsAndTerms.MaxLength = 5000;
            tbConditionsAndTerms.Multiline = true;
            tbConditionsAndTerms.Name = "tbConditionsAndTerms";
            tbConditionsAndTerms.ReadOnly = true;
            tbConditionsAndTerms.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            tbConditionsAndTerms.Size = new System.Drawing.Size(552, 67);
            tbConditionsAndTerms.TabIndex = 55;
            tbConditionsAndTerms.TabStop = false;
            tbConditionsAndTerms.Text = resources.GetString("tbConditionsAndTerms.Text");
            // 
            // gbLogo
            // 
            gbLogo.Controls.Add(pbLogo);
            gbLogo.Location = new System.Drawing.Point(4, 3);
            gbLogo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbLogo.Name = "gbLogo";
            gbLogo.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbLogo.Size = new System.Drawing.Size(562, 83);
            gbLogo.TabIndex = 0;
            gbLogo.TabStop = false;
            // 
            // pbLogo
            // 
            pbLogo.Image = Properties.Resources.pb_Logo_Image;
            pbLogo.Location = new System.Drawing.Point(6, 13);
            pbLogo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new System.Drawing.Size(548, 63);
            pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 2;
            pbLogo.TabStop = false;
            pbLogo.Tag = "118; 55";
            // 
            // btnOk
            // 
            btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOk.Location = new System.Drawing.Point(9, 151);
            btnOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(88, 27);
            btnOk.TabIndex = 11;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += BtnOk_Click;
            // 
            // lblVendor
            // 
            lblVendor.AutoSize = true;
            lblVendor.Font = (System.Drawing.Font)resources.GetObject("lblVendor.Font");
            lblVendor.Location = new System.Drawing.Point(398, 91);
            lblVendor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblVendor.MaximumSize = new System.Drawing.Size(163, 15);
            lblVendor.Name = "lblVendor";
            lblVendor.Size = new System.Drawing.Size(137, 13);
            lblVendor.TabIndex = 8;
            lblVendor.Text = "Sziltech Electronic Kft.";
            // 
            // lblCopyRight
            // 
            lblCopyRight.AutoSize = true;
            lblCopyRight.Location = new System.Drawing.Point(7, 132);
            lblCopyRight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCopyRight.MaximumSize = new System.Drawing.Size(198, 15);
            lblCopyRight.Name = "lblCopyRight";
            lblCopyRight.Size = new System.Drawing.Size(101, 15);
            lblCopyRight.TabIndex = 3;
            lblCopyRight.Text = "Copyright © 2024";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new System.Drawing.Point(398, 114);
            lblAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblAddress.MaximumSize = new System.Drawing.Size(163, 15);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new System.Drawing.Size(125, 15);
            lblAddress.TabIndex = 9;
            lblAddress.Text = "H4030 Debrecen, Pf. 3.";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new System.Drawing.Point(7, 114);
            lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new System.Drawing.Size(45, 15);
            lblVersion.TabIndex = 2;
            lblVersion.Text = "Version";
            // 
            // lblPhone2
            // 
            lblPhone2.AutoSize = true;
            lblPhone2.Location = new System.Drawing.Point(398, 132);
            lblPhone2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPhone2.Name = "lblPhone2";
            lblPhone2.Size = new System.Drawing.Size(126, 15);
            lblPhone2.TabIndex = 10;
            lblPhone2.Text = "Phone: +36 80 204-768";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Font = (System.Drawing.Font)resources.GetObject("lblProductName.Font");
            lblProductName.Location = new System.Drawing.Point(7, 91);
            lblProductName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblProductName.MaximumSize = new System.Drawing.Size(198, 15);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new System.Drawing.Size(51, 13);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "Product";
            // 
            // lblSupportContact
            // 
            lblSupportContact.AutoSize = true;
            lblSupportContact.Font = (System.Drawing.Font)resources.GetObject("lblSupportContact.Font");
            lblSupportContact.Location = new System.Drawing.Point(210, 91);
            lblSupportContact.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSupportContact.Name = "lblSupportContact";
            lblSupportContact.Size = new System.Drawing.Size(98, 13);
            lblSupportContact.TabIndex = 4;
            lblSupportContact.Text = "Support contact";
            // 
            // llEmailAddress
            // 
            llEmailAddress.AutoSize = true;
            llEmailAddress.Location = new System.Drawing.Point(210, 163);
            llEmailAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            llEmailAddress.MaximumSize = new System.Drawing.Size(181, 15);
            llEmailAddress.Name = "llEmailAddress";
            llEmailAddress.Size = new System.Drawing.Size(94, 15);
            llEmailAddress.TabIndex = 12;
            llEmailAddress.TabStop = true;
            llEmailAddress.Text = "info@sziltech.eu";
            llEmailAddress.LinkClicked += EmailAddress_LinkClicked;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new System.Drawing.Point(210, 114);
            lblPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPhone.MaximumSize = new System.Drawing.Size(181, 15);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new System.Drawing.Size(126, 15);
            lblPhone.TabIndex = 5;
            lblPhone.Text = "Phone: +36 52 452-172";
            // 
            // llWebPage
            // 
            llWebPage.AutoSize = true;
            llWebPage.Location = new System.Drawing.Point(398, 163);
            llWebPage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            llWebPage.MaximumSize = new System.Drawing.Size(163, 15);
            llWebPage.Name = "llWebPage";
            llWebPage.Size = new System.Drawing.Size(127, 15);
            llWebPage.TabIndex = 13;
            llWebPage.TabStop = true;
            llWebPage.Text = "http://www.sziltech.eu";
            llWebPage.LinkClicked += WebPage_LinkClicked;
            // 
            // lblFax
            // 
            lblFax.AutoSize = true;
            lblFax.Location = new System.Drawing.Point(210, 132);
            lblFax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblFax.Name = "lblFax";
            lblFax.Size = new System.Drawing.Size(109, 15);
            lblFax.TabIndex = 6;
            lblFax.Text = "Fax: +36 52 533-759";
            // 
            // About
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(569, 257);
            Controls.Add(pMain);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "About";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "About";
            pMain.ResumeLayout(false);
            pMain.PerformLayout();
            gbLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.GroupBox gbLogo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.Label lblCopyRight;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblPhone2;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblSupportContact;
        private System.Windows.Forms.LinkLabel llEmailAddress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.LinkLabel llWebPage;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.TextBox tbConditionsAndTerms;
    }
}
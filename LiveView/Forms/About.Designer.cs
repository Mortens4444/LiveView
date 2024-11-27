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
            p_Main = new System.Windows.Forms.Panel();
            tb_ConditionsAndTerms = new System.Windows.Forms.TextBox();
            gb_Logo = new System.Windows.Forms.GroupBox();
            pb_Logo = new System.Windows.Forms.PictureBox();
            btn_Ok = new System.Windows.Forms.Button();
            lbl_Vendor = new System.Windows.Forms.Label();
            lbl_CopyRight = new System.Windows.Forms.Label();
            lbl_Address = new System.Windows.Forms.Label();
            lbl_Version = new System.Windows.Forms.Label();
            lbl_Phone_2 = new System.Windows.Forms.Label();
            lbl_ProductName = new System.Windows.Forms.Label();
            lbl_SupportContact = new System.Windows.Forms.Label();
            ll_EmailAddress = new System.Windows.Forms.LinkLabel();
            lbl_Phone = new System.Windows.Forms.Label();
            ll_WebPage = new System.Windows.Forms.LinkLabel();
            lbl_Fax = new System.Windows.Forms.Label();
            p_Main.SuspendLayout();
            gb_Logo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Logo).BeginInit();
            SuspendLayout();
            // 
            // p_Main
            // 
            p_Main.Controls.Add(tb_ConditionsAndTerms);
            p_Main.Controls.Add(gb_Logo);
            p_Main.Controls.Add(btn_Ok);
            p_Main.Controls.Add(lbl_Vendor);
            p_Main.Controls.Add(lbl_CopyRight);
            p_Main.Controls.Add(lbl_Address);
            p_Main.Controls.Add(lbl_Version);
            p_Main.Controls.Add(lbl_Phone_2);
            p_Main.Controls.Add(lbl_ProductName);
            p_Main.Controls.Add(lbl_SupportContact);
            p_Main.Controls.Add(ll_EmailAddress);
            p_Main.Controls.Add(lbl_Phone);
            p_Main.Controls.Add(ll_WebPage);
            p_Main.Controls.Add(lbl_Fax);
            p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            p_Main.Location = new System.Drawing.Point(0, 0);
            p_Main.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_Main.Name = "p_Main";
            p_Main.Size = new System.Drawing.Size(569, 257);
            p_Main.TabIndex = 15;
            // 
            // tb_ConditionsAndTerms
            // 
            tb_ConditionsAndTerms.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_ConditionsAndTerms.Enabled = false;
            tb_ConditionsAndTerms.Location = new System.Drawing.Point(9, 186);
            tb_ConditionsAndTerms.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_ConditionsAndTerms.MaxLength = 5000;
            tb_ConditionsAndTerms.Multiline = true;
            tb_ConditionsAndTerms.Name = "tb_ConditionsAndTerms";
            tb_ConditionsAndTerms.ReadOnly = true;
            tb_ConditionsAndTerms.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            tb_ConditionsAndTerms.Size = new System.Drawing.Size(552, 67);
            tb_ConditionsAndTerms.TabIndex = 55;
            tb_ConditionsAndTerms.TabStop = false;
            tb_ConditionsAndTerms.Text = resources.GetString("tb_ConditionsAndTerms.Text");
            // 
            // gb_Logo
            // 
            gb_Logo.Controls.Add(pb_Logo);
            gb_Logo.Location = new System.Drawing.Point(4, 3);
            gb_Logo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Logo.Name = "gb_Logo";
            gb_Logo.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Logo.Size = new System.Drawing.Size(562, 83);
            gb_Logo.TabIndex = 0;
            gb_Logo.TabStop = false;
            // 
            // pb_Logo
            // 
            pb_Logo.Image = Properties.Resources.pb_Logo_Image;
            pb_Logo.Location = new System.Drawing.Point(6, 13);
            pb_Logo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pb_Logo.Name = "pb_Logo";
            pb_Logo.Size = new System.Drawing.Size(548, 63);
            pb_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pb_Logo.TabIndex = 2;
            pb_Logo.TabStop = false;
            pb_Logo.Tag = "118; 55";
            // 
            // btn_Ok
            // 
            btn_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            btn_Ok.Location = new System.Drawing.Point(9, 151);
            btn_Ok.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Ok.Name = "btn_Ok";
            btn_Ok.Size = new System.Drawing.Size(88, 27);
            btn_Ok.TabIndex = 11;
            btn_Ok.Text = "OK";
            btn_Ok.UseVisualStyleBackColor = true;
            btn_Ok.Click += Btn_Ok_Click;
            // 
            // lbl_Vendor
            // 
            lbl_Vendor.AutoSize = true;
            lbl_Vendor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            lbl_Vendor.Location = new System.Drawing.Point(398, 91);
            lbl_Vendor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Vendor.MaximumSize = new System.Drawing.Size(163, 15);
            lbl_Vendor.Name = "lbl_Vendor";
            lbl_Vendor.Size = new System.Drawing.Size(137, 13);
            lbl_Vendor.TabIndex = 8;
            lbl_Vendor.Text = "Sziltech Electronic Kft.";
            // 
            // lbl_CopyRight
            // 
            lbl_CopyRight.AutoSize = true;
            lbl_CopyRight.Location = new System.Drawing.Point(7, 132);
            lbl_CopyRight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_CopyRight.MaximumSize = new System.Drawing.Size(198, 15);
            lbl_CopyRight.Name = "lbl_CopyRight";
            lbl_CopyRight.Size = new System.Drawing.Size(101, 15);
            lbl_CopyRight.TabIndex = 3;
            lbl_CopyRight.Text = "Copyright © 2024";
            // 
            // lbl_Address
            // 
            lbl_Address.AutoSize = true;
            lbl_Address.Location = new System.Drawing.Point(398, 114);
            lbl_Address.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Address.MaximumSize = new System.Drawing.Size(163, 15);
            lbl_Address.Name = "lbl_Address";
            lbl_Address.Size = new System.Drawing.Size(125, 15);
            lbl_Address.TabIndex = 9;
            lbl_Address.Text = "H4030 Debrecen, Pf. 3.";
            // 
            // lbl_Version
            // 
            lbl_Version.AutoSize = true;
            lbl_Version.Location = new System.Drawing.Point(7, 114);
            lbl_Version.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Version.Name = "lbl_Version";
            lbl_Version.Size = new System.Drawing.Size(45, 15);
            lbl_Version.TabIndex = 2;
            lbl_Version.Text = "Version";
            // 
            // lbl_Phone_2
            // 
            lbl_Phone_2.AutoSize = true;
            lbl_Phone_2.Location = new System.Drawing.Point(398, 132);
            lbl_Phone_2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Phone_2.Name = "lbl_Phone_2";
            lbl_Phone_2.Size = new System.Drawing.Size(126, 15);
            lbl_Phone_2.TabIndex = 10;
            lbl_Phone_2.Text = "Phone: +36 80 204-768";
            // 
            // lbl_ProductName
            // 
            lbl_ProductName.AutoSize = true;
            lbl_ProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            lbl_ProductName.Location = new System.Drawing.Point(7, 91);
            lbl_ProductName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_ProductName.MaximumSize = new System.Drawing.Size(198, 15);
            lbl_ProductName.Name = "lbl_ProductName";
            lbl_ProductName.Size = new System.Drawing.Size(51, 13);
            lbl_ProductName.TabIndex = 1;
            lbl_ProductName.Text = "Product";
            // 
            // lbl_SupportContact
            // 
            lbl_SupportContact.AutoSize = true;
            lbl_SupportContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            lbl_SupportContact.Location = new System.Drawing.Point(210, 91);
            lbl_SupportContact.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_SupportContact.Name = "lbl_SupportContact";
            lbl_SupportContact.Size = new System.Drawing.Size(98, 13);
            lbl_SupportContact.TabIndex = 4;
            lbl_SupportContact.Text = "Support contact";
            // 
            // ll_EmailAddress
            // 
            ll_EmailAddress.AutoSize = true;
            ll_EmailAddress.Location = new System.Drawing.Point(210, 163);
            ll_EmailAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            ll_EmailAddress.MaximumSize = new System.Drawing.Size(181, 15);
            ll_EmailAddress.Name = "ll_EmailAddress";
            ll_EmailAddress.Size = new System.Drawing.Size(94, 15);
            ll_EmailAddress.TabIndex = 12;
            ll_EmailAddress.TabStop = true;
            ll_EmailAddress.Text = "info@sziltech.eu";
            ll_EmailAddress.LinkClicked += EmailAddress_LinkClicked;
            // 
            // lbl_Phone
            // 
            lbl_Phone.AutoSize = true;
            lbl_Phone.Location = new System.Drawing.Point(210, 114);
            lbl_Phone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Phone.MaximumSize = new System.Drawing.Size(181, 15);
            lbl_Phone.Name = "lbl_Phone";
            lbl_Phone.Size = new System.Drawing.Size(126, 15);
            lbl_Phone.TabIndex = 5;
            lbl_Phone.Text = "Phone: +36 52 452-172";
            // 
            // ll_WebPage
            // 
            ll_WebPage.AutoSize = true;
            ll_WebPage.Location = new System.Drawing.Point(398, 163);
            ll_WebPage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            ll_WebPage.MaximumSize = new System.Drawing.Size(163, 15);
            ll_WebPage.Name = "ll_WebPage";
            ll_WebPage.Size = new System.Drawing.Size(127, 15);
            ll_WebPage.TabIndex = 13;
            ll_WebPage.TabStop = true;
            ll_WebPage.Text = "http://www.sziltech.eu";
            ll_WebPage.LinkClicked += WebPage_LinkClicked;
            // 
            // lbl_Fax
            // 
            lbl_Fax.AutoSize = true;
            lbl_Fax.Location = new System.Drawing.Point(210, 132);
            lbl_Fax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Fax.Name = "lbl_Fax";
            lbl_Fax.Size = new System.Drawing.Size(109, 15);
            lbl_Fax.TabIndex = 6;
            lbl_Fax.Text = "Fax: +36 52 533-759";
            // 
            // About
            // 
            AcceptButton = btn_Ok;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(569, 257);
            Controls.Add(p_Main);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "About";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "About";
            p_Main.ResumeLayout(false);
            p_Main.PerformLayout();
            gb_Logo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb_Logo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel p_Main;
        private System.Windows.Forms.GroupBox gb_Logo;
        private System.Windows.Forms.PictureBox pb_Logo;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Label lbl_Vendor;
        private System.Windows.Forms.Label lbl_CopyRight;
        private System.Windows.Forms.Label lbl_Address;
        private System.Windows.Forms.Label lbl_Version;
        private System.Windows.Forms.Label lbl_Phone_2;
        private System.Windows.Forms.Label lbl_ProductName;
        private System.Windows.Forms.Label lbl_SupportContact;
        private System.Windows.Forms.LinkLabel ll_EmailAddress;
        private System.Windows.Forms.Label lbl_Phone;
        private System.Windows.Forms.LinkLabel ll_WebPage;
        private System.Windows.Forms.Label lbl_Fax;
        private System.Windows.Forms.TextBox tb_ConditionsAndTerms;
    }
}
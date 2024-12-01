namespace LiveView.Forms
{
    partial class PersonalOptionsForm
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
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonalOptionsForm));
            fontDialog1 = new System.Windows.Forms.FontDialog();
            colorDialog1 = new System.Windows.Forms.ColorDialog();
            lbl_SelectedLanguage = new System.Windows.Forms.Label();
            lbl_FontSizeSmall = new System.Windows.Forms.Label();
            lbl_FontSizeBig = new System.Windows.Forms.Label();
            nud_FontSizeSmall = new System.Windows.Forms.NumericUpDown();
            nud_FontSizeBig = new System.Windows.Forms.NumericUpDown();
            btn_FontType = new System.Windows.Forms.Button();
            lbl_ShowVideoServerIdentifier = new System.Windows.Forms.Label();
            rb_None = new System.Windows.Forms.RadioButton();
            rb_DNSNameOrIPAddress = new System.Windows.Forms.RadioButton();
            cb_Languages = new System.Windows.Forms.ComboBox();
            btn_Close = new System.Windows.Forms.Button();
            btn_Save = new System.Windows.Forms.Button();
            rb_DisplayedName = new System.Windows.Forms.RadioButton();
            pb_ShadowColor = new Mtf.Controls.MtfPictureBox();
            pb_FontColor = new Mtf.Controls.MtfPictureBox();
            lbl_FontColor = new System.Windows.Forms.Label();
            tt_Hint = new System.Windows.Forms.ToolTip(components);
            gb_Texts = new System.Windows.Forms.GroupBox();
            lbl_ShadowColor = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            gb_Language = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)nud_FontSizeSmall).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_FontSizeBig).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_ShadowColor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_FontColor).BeginInit();
            gb_Texts.SuspendLayout();
            panel1.SuspendLayout();
            gb_Language.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_SelectedLanguage
            // 
            lbl_SelectedLanguage.AutoSize = true;
            lbl_SelectedLanguage.Location = new System.Drawing.Point(14, 18);
            lbl_SelectedLanguage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_SelectedLanguage.Name = "lbl_SelectedLanguage";
            lbl_SelectedLanguage.Size = new System.Drawing.Size(103, 15);
            lbl_SelectedLanguage.TabIndex = 0;
            lbl_SelectedLanguage.Text = "Selected language";
            // 
            // lbl_FontSizeSmall
            // 
            lbl_FontSizeSmall.AutoSize = true;
            lbl_FontSizeSmall.Location = new System.Drawing.Point(451, 93);
            lbl_FontSizeSmall.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_FontSizeSmall.Name = "lbl_FontSizeSmall";
            lbl_FontSizeSmall.Size = new System.Drawing.Size(83, 15);
            lbl_FontSizeSmall.TabIndex = 9;
            lbl_FontSizeSmall.Text = "Small font size";
            // 
            // lbl_FontSizeBig
            // 
            lbl_FontSizeBig.AutoSize = true;
            lbl_FontSizeBig.Location = new System.Drawing.Point(451, 63);
            lbl_FontSizeBig.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_FontSizeBig.Name = "lbl_FontSizeBig";
            lbl_FontSizeBig.Size = new System.Drawing.Size(83, 15);
            lbl_FontSizeBig.TabIndex = 7;
            lbl_FontSizeBig.Text = "Large font size";
            // 
            // nud_FontSizeSmall
            // 
            nud_FontSizeSmall.Location = new System.Drawing.Point(551, 91);
            nud_FontSizeSmall.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nud_FontSizeSmall.Name = "nud_FontSizeSmall";
            nud_FontSizeSmall.Size = new System.Drawing.Size(88, 23);
            nud_FontSizeSmall.TabIndex = 10;
            // 
            // nud_FontSizeBig
            // 
            nud_FontSizeBig.Location = new System.Drawing.Point(551, 61);
            nud_FontSizeBig.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nud_FontSizeBig.Name = "nud_FontSizeBig";
            nud_FontSizeBig.Size = new System.Drawing.Size(88, 23);
            nud_FontSizeBig.TabIndex = 8;
            // 
            // btn_FontType
            // 
            btn_FontType.Location = new System.Drawing.Point(455, 23);
            btn_FontType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_FontType.Name = "btn_FontType";
            btn_FontType.Size = new System.Drawing.Size(183, 27);
            btn_FontType.TabIndex = 6;
            btn_FontType.Text = "Font type";
            btn_FontType.UseVisualStyleBackColor = true;
            // 
            // lbl_ShowVideoServerIdentifier
            // 
            lbl_ShowVideoServerIdentifier.AutoSize = true;
            lbl_ShowVideoServerIdentifier.Location = new System.Drawing.Point(14, 23);
            lbl_ShowVideoServerIdentifier.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_ShowVideoServerIdentifier.Name = "lbl_ShowVideoServerIdentifier";
            lbl_ShowVideoServerIdentifier.Size = new System.Drawing.Size(152, 15);
            lbl_ShowVideoServerIdentifier.TabIndex = 0;
            lbl_ShowVideoServerIdentifier.Text = "Show video server identifier";
            // 
            // rb_None
            // 
            rb_None.AutoSize = true;
            rb_None.Location = new System.Drawing.Point(18, 95);
            rb_None.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rb_None.Name = "rb_None";
            rb_None.Size = new System.Drawing.Size(54, 19);
            rb_None.TabIndex = 3;
            rb_None.TabStop = true;
            rb_None.Text = "None";
            rb_None.UseVisualStyleBackColor = true;
            // 
            // rb_DNSNameOrIPAddress
            // 
            rb_DNSNameOrIPAddress.AutoSize = true;
            rb_DNSNameOrIPAddress.Location = new System.Drawing.Point(18, 68);
            rb_DNSNameOrIPAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rb_DNSNameOrIPAddress.Name = "rb_DNSNameOrIPAddress";
            rb_DNSNameOrIPAddress.Size = new System.Drawing.Size(151, 19);
            rb_DNSNameOrIPAddress.TabIndex = 2;
            rb_DNSNameOrIPAddress.TabStop = true;
            rb_DNSNameOrIPAddress.Text = "DNS name or IP address";
            rb_DNSNameOrIPAddress.UseVisualStyleBackColor = true;
            // 
            // cb_Languages
            // 
            cb_Languages.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cb_Languages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_Languages.FormattingEnabled = true;
            cb_Languages.Location = new System.Drawing.Point(455, 15);
            cb_Languages.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_Languages.Name = "cb_Languages";
            cb_Languages.Size = new System.Drawing.Size(182, 23);
            cb_Languages.TabIndex = 1;
            cb_Languages.SelectedIndexChanged += Cb_Languages_SelectedIndexChanged;
            // 
            // btn_Close
            // 
            btn_Close.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btn_Close.Location = new System.Drawing.Point(551, 175);
            btn_Close.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Close.Name = "btn_Close";
            btn_Close.Size = new System.Drawing.Size(88, 27);
            btn_Close.TabIndex = 3;
            btn_Close.Text = "Close";
            btn_Close.UseVisualStyleBackColor = true;
            btn_Close.Click += Btn_Close_Click;
            // 
            // btn_Save
            // 
            btn_Save.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_Save.DialogResult = System.Windows.Forms.DialogResult.OK;
            btn_Save.Location = new System.Drawing.Point(455, 175);
            btn_Save.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new System.Drawing.Size(88, 27);
            btn_Save.TabIndex = 2;
            btn_Save.Text = "Save";
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += Btn_Save_Click;
            // 
            // rb_DisplayedName
            // 
            rb_DisplayedName.AutoSize = true;
            rb_DisplayedName.Location = new System.Drawing.Point(18, 42);
            rb_DisplayedName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rb_DisplayedName.Name = "rb_DisplayedName";
            rb_DisplayedName.Size = new System.Drawing.Size(109, 19);
            rb_DisplayedName.TabIndex = 1;
            rb_DisplayedName.TabStop = true;
            rb_DisplayedName.Text = "Displayed name";
            rb_DisplayedName.UseVisualStyleBackColor = true;
            // 
            // pb_ShadowColor
            // 
            pb_ShadowColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pb_ShadowColor.Location = new System.Drawing.Point(220, 82);
            pb_ShadowColor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pb_ShadowColor.Name = "pb_ShadowColor";
            pb_ShadowColor.OriginalSize = new System.Drawing.Size(100, 50);
            pb_ShadowColor.RepositioningAndResizingControlsOnResize = false;
            pb_ShadowColor.Size = new System.Drawing.Size(33, 26);
            pb_ShadowColor.TabIndex = 14;
            pb_ShadowColor.TabStop = false;
            // 
            // pb_FontColor
            // 
            pb_FontColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pb_FontColor.Location = new System.Drawing.Point(220, 48);
            pb_FontColor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pb_FontColor.Name = "pb_FontColor";
            pb_FontColor.OriginalSize = new System.Drawing.Size(100, 50);
            pb_FontColor.RepositioningAndResizingControlsOnResize = false;
            pb_FontColor.Size = new System.Drawing.Size(33, 26);
            pb_FontColor.TabIndex = 13;
            pb_FontColor.TabStop = false;
            // 
            // lbl_FontColor
            // 
            lbl_FontColor.AutoSize = true;
            lbl_FontColor.Location = new System.Drawing.Point(261, 54);
            lbl_FontColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_FontColor.Name = "lbl_FontColor";
            lbl_FontColor.Size = new System.Drawing.Size(61, 15);
            lbl_FontColor.TabIndex = 4;
            lbl_FontColor.Text = "Font color";
            // 
            // gb_Texts
            // 
            gb_Texts.Controls.Add(lbl_FontSizeSmall);
            gb_Texts.Controls.Add(lbl_FontSizeBig);
            gb_Texts.Controls.Add(nud_FontSizeSmall);
            gb_Texts.Controls.Add(nud_FontSizeBig);
            gb_Texts.Controls.Add(btn_FontType);
            gb_Texts.Controls.Add(lbl_ShowVideoServerIdentifier);
            gb_Texts.Controls.Add(rb_None);
            gb_Texts.Controls.Add(rb_DNSNameOrIPAddress);
            gb_Texts.Controls.Add(rb_DisplayedName);
            gb_Texts.Controls.Add(pb_ShadowColor);
            gb_Texts.Controls.Add(pb_FontColor);
            gb_Texts.Controls.Add(lbl_ShadowColor);
            gb_Texts.Controls.Add(lbl_FontColor);
            gb_Texts.Dock = System.Windows.Forms.DockStyle.Top;
            gb_Texts.Location = new System.Drawing.Point(0, 47);
            gb_Texts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Texts.Name = "gb_Texts";
            gb_Texts.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Texts.Size = new System.Drawing.Size(645, 122);
            gb_Texts.TabIndex = 1;
            gb_Texts.TabStop = false;
            gb_Texts.Text = "Texts";
            // 
            // lbl_ShadowColor
            // 
            lbl_ShadowColor.AutoSize = true;
            lbl_ShadowColor.Location = new System.Drawing.Point(258, 88);
            lbl_ShadowColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_ShadowColor.Name = "lbl_ShadowColor";
            lbl_ShadowColor.Size = new System.Drawing.Size(79, 15);
            lbl_ShadowColor.TabIndex = 5;
            lbl_ShadowColor.Text = "Shadow color";
            // 
            // panel1
            // 
            panel1.Controls.Add(gb_Texts);
            panel1.Controls.Add(btn_Close);
            panel1.Controls.Add(btn_Save);
            panel1.Controls.Add(gb_Language);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(645, 205);
            panel1.TabIndex = 1;
            // 
            // gb_Language
            // 
            gb_Language.Controls.Add(cb_Languages);
            gb_Language.Controls.Add(lbl_SelectedLanguage);
            gb_Language.Dock = System.Windows.Forms.DockStyle.Top;
            gb_Language.Location = new System.Drawing.Point(0, 0);
            gb_Language.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Language.Name = "gb_Language";
            gb_Language.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Language.Size = new System.Drawing.Size(645, 47);
            gb_Language.TabIndex = 0;
            gb_Language.TabStop = false;
            gb_Language.Text = "Language";
            // 
            // PersonalOptionsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(645, 205);
            Controls.Add(panel1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(652, 231);
            Name = "PersonalOptionsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "PersonalOptions";
            Shown += PersonalOptionsForm_Shown;
            ((System.ComponentModel.ISupportInitialize)nud_FontSizeSmall).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_FontSizeBig).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_ShadowColor).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_FontColor).EndInit();
            gb_Texts.ResumeLayout(false);
            gb_Texts.PerformLayout();
            panel1.ResumeLayout(false);
            gb_Language.ResumeLayout(false);
            gb_Language.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lbl_SelectedLanguage;
        private System.Windows.Forms.Label lbl_FontSizeSmall;
        private System.Windows.Forms.Label lbl_FontSizeBig;
        private System.Windows.Forms.NumericUpDown nud_FontSizeSmall;
        private System.Windows.Forms.NumericUpDown nud_FontSizeBig;
        private System.Windows.Forms.Button btn_FontType;
        private System.Windows.Forms.Label lbl_ShowVideoServerIdentifier;
        private System.Windows.Forms.RadioButton rb_None;
        private System.Windows.Forms.RadioButton rb_DNSNameOrIPAddress;
        private System.Windows.Forms.ComboBox cb_Languages;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.RadioButton rb_DisplayedName;
        private Mtf.Controls.MtfPictureBox pb_ShadowColor;
        private Mtf.Controls.MtfPictureBox pb_FontColor;
        private System.Windows.Forms.Label lbl_FontColor;
        private System.Windows.Forms.ToolTip tt_Hint;
        private System.Windows.Forms.GroupBox gb_Texts;
        private System.Windows.Forms.Label lbl_ShadowColor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gb_Language;
    }
}
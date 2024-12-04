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
            fdFontPicker = new System.Windows.Forms.FontDialog();
            cdColorPicker = new System.Windows.Forms.ColorDialog();
            lblSelectedLanguage = new System.Windows.Forms.Label();
            lblFontSizeSmall = new System.Windows.Forms.Label();
            lblFontSizeBig = new System.Windows.Forms.Label();
            nudFontSizeSmall = new System.Windows.Forms.NumericUpDown();
            nudFontSizeBig = new System.Windows.Forms.NumericUpDown();
            btnFontType = new System.Windows.Forms.Button();
            lblShowVideoServerIdentifier = new System.Windows.Forms.Label();
            rbNone = new System.Windows.Forms.RadioButton();
            rbIpAddress = new System.Windows.Forms.RadioButton();
            cbLanguages = new System.Windows.Forms.ComboBox();
            btnClose = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            rbDisplayedName = new System.Windows.Forms.RadioButton();
            pbShadowColor = new Mtf.Controls.MtfPictureBox();
            pbFontColor = new Mtf.Controls.MtfPictureBox();
            lblFontColor = new System.Windows.Forms.Label();
            ttHint = new System.Windows.Forms.ToolTip(components);
            gbTexts = new System.Windows.Forms.GroupBox();
            lblShadowColor = new System.Windows.Forms.Label();
            pMain = new System.Windows.Forms.Panel();
            gbLanguage = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)nudFontSizeSmall).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFontSizeBig).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbShadowColor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFontColor).BeginInit();
            gbTexts.SuspendLayout();
            pMain.SuspendLayout();
            gbLanguage.SuspendLayout();
            SuspendLayout();
            // 
            // lblSelectedLanguage
            // 
            lblSelectedLanguage.AutoSize = true;
            lblSelectedLanguage.Location = new System.Drawing.Point(14, 18);
            lblSelectedLanguage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSelectedLanguage.Name = "lblSelectedLanguage";
            lblSelectedLanguage.Size = new System.Drawing.Size(103, 15);
            lblSelectedLanguage.TabIndex = 0;
            lblSelectedLanguage.Text = "Selected language";
            // 
            // lblFontSizeSmall
            // 
            lblFontSizeSmall.AutoSize = true;
            lblFontSizeSmall.Location = new System.Drawing.Point(451, 93);
            lblFontSizeSmall.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblFontSizeSmall.Name = "lblFontSizeSmall";
            lblFontSizeSmall.Size = new System.Drawing.Size(83, 15);
            lblFontSizeSmall.TabIndex = 9;
            lblFontSizeSmall.Text = "Small font size";
            // 
            // lblFontSizeBig
            // 
            lblFontSizeBig.AutoSize = true;
            lblFontSizeBig.Location = new System.Drawing.Point(451, 63);
            lblFontSizeBig.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblFontSizeBig.Name = "lblFontSizeBig";
            lblFontSizeBig.Size = new System.Drawing.Size(83, 15);
            lblFontSizeBig.TabIndex = 7;
            lblFontSizeBig.Text = "Large font size";
            // 
            // nudFontSizeSmall
            // 
            nudFontSizeSmall.Location = new System.Drawing.Point(551, 91);
            nudFontSizeSmall.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudFontSizeSmall.Name = "nudFontSizeSmall";
            nudFontSizeSmall.Size = new System.Drawing.Size(88, 23);
            nudFontSizeSmall.TabIndex = 10;
            // 
            // nudFontSizeBig
            // 
            nudFontSizeBig.Location = new System.Drawing.Point(551, 61);
            nudFontSizeBig.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudFontSizeBig.Name = "nudFontSizeBig";
            nudFontSizeBig.Size = new System.Drawing.Size(88, 23);
            nudFontSizeBig.TabIndex = 8;
            // 
            // btnFontType
            // 
            btnFontType.Location = new System.Drawing.Point(455, 23);
            btnFontType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnFontType.Name = "btnFontType";
            btnFontType.Size = new System.Drawing.Size(183, 27);
            btnFontType.TabIndex = 6;
            btnFontType.Text = "Font type";
            btnFontType.UseVisualStyleBackColor = true;
            // 
            // lblShowVideoServerIdentifier
            // 
            lblShowVideoServerIdentifier.AutoSize = true;
            lblShowVideoServerIdentifier.Location = new System.Drawing.Point(14, 23);
            lblShowVideoServerIdentifier.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblShowVideoServerIdentifier.Name = "lblShowVideoServerIdentifier";
            lblShowVideoServerIdentifier.Size = new System.Drawing.Size(152, 15);
            lblShowVideoServerIdentifier.TabIndex = 0;
            lblShowVideoServerIdentifier.Text = "Show video server identifier";
            // 
            // rbNone
            // 
            rbNone.AutoSize = true;
            rbNone.Location = new System.Drawing.Point(18, 95);
            rbNone.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rbNone.Name = "rbNone";
            rbNone.Size = new System.Drawing.Size(54, 19);
            rbNone.TabIndex = 3;
            rbNone.TabStop = true;
            rbNone.Text = "None";
            rbNone.UseVisualStyleBackColor = true;
            // 
            // rbIpAddress
            // 
            rbIpAddress.AutoSize = true;
            rbIpAddress.Location = new System.Drawing.Point(18, 68);
            rbIpAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rbIpAddress.Name = "rbIpAddress";
            rbIpAddress.Size = new System.Drawing.Size(151, 19);
            rbIpAddress.TabIndex = 2;
            rbIpAddress.TabStop = true;
            rbIpAddress.Text = "DNS name or IP address";
            rbIpAddress.UseVisualStyleBackColor = true;
            // 
            // cbLanguages
            // 
            cbLanguages.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cbLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbLanguages.FormattingEnabled = true;
            cbLanguages.Location = new System.Drawing.Point(455, 15);
            cbLanguages.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbLanguages.Name = "cbLanguages";
            cbLanguages.Size = new System.Drawing.Size(182, 23);
            cbLanguages.TabIndex = 1;
            cbLanguages.SelectedIndexChanged += CbLanguages_SelectedIndexChanged;
            // 
            // btnClose
            // 
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.Location = new System.Drawing.Point(551, 175);
            btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(88, 27);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnSave.Location = new System.Drawing.Point(455, 175);
            btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(88, 27);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += BtnSave_Click;
            // 
            // rbDisplayedName
            // 
            rbDisplayedName.AutoSize = true;
            rbDisplayedName.Location = new System.Drawing.Point(18, 42);
            rbDisplayedName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rbDisplayedName.Name = "rbDisplayedName";
            rbDisplayedName.Size = new System.Drawing.Size(109, 19);
            rbDisplayedName.TabIndex = 1;
            rbDisplayedName.TabStop = true;
            rbDisplayedName.Text = "Displayed name";
            rbDisplayedName.UseVisualStyleBackColor = true;
            // 
            // pbShadowColor
            // 
            pbShadowColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pbShadowColor.Location = new System.Drawing.Point(220, 82);
            pbShadowColor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pbShadowColor.Name = "pbShadowColor";
            pbShadowColor.OriginalSize = new System.Drawing.Size(100, 50);
            pbShadowColor.RepositioningAndResizingControlsOnResize = false;
            pbShadowColor.Size = new System.Drawing.Size(33, 26);
            pbShadowColor.TabIndex = 14;
            pbShadowColor.TabStop = false;
            // 
            // pbFontColor
            // 
            pbFontColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pbFontColor.Location = new System.Drawing.Point(220, 48);
            pbFontColor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pbFontColor.Name = "pbFontColor";
            pbFontColor.OriginalSize = new System.Drawing.Size(100, 50);
            pbFontColor.RepositioningAndResizingControlsOnResize = false;
            pbFontColor.Size = new System.Drawing.Size(33, 26);
            pbFontColor.TabIndex = 13;
            pbFontColor.TabStop = false;
            // 
            // lblFontColor
            // 
            lblFontColor.AutoSize = true;
            lblFontColor.Location = new System.Drawing.Point(261, 54);
            lblFontColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblFontColor.Name = "lblFontColor";
            lblFontColor.Size = new System.Drawing.Size(61, 15);
            lblFontColor.TabIndex = 4;
            lblFontColor.Text = "Font color";
            // 
            // gbTexts
            // 
            gbTexts.Controls.Add(lblFontSizeSmall);
            gbTexts.Controls.Add(lblFontSizeBig);
            gbTexts.Controls.Add(nudFontSizeSmall);
            gbTexts.Controls.Add(nudFontSizeBig);
            gbTexts.Controls.Add(btnFontType);
            gbTexts.Controls.Add(lblShowVideoServerIdentifier);
            gbTexts.Controls.Add(rbNone);
            gbTexts.Controls.Add(rbIpAddress);
            gbTexts.Controls.Add(rbDisplayedName);
            gbTexts.Controls.Add(pbShadowColor);
            gbTexts.Controls.Add(pbFontColor);
            gbTexts.Controls.Add(lblShadowColor);
            gbTexts.Controls.Add(lblFontColor);
            gbTexts.Dock = System.Windows.Forms.DockStyle.Top;
            gbTexts.Location = new System.Drawing.Point(0, 47);
            gbTexts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbTexts.Name = "gbTexts";
            gbTexts.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbTexts.Size = new System.Drawing.Size(645, 122);
            gbTexts.TabIndex = 1;
            gbTexts.TabStop = false;
            gbTexts.Text = "Texts";
            // 
            // lblShadowColor
            // 
            lblShadowColor.AutoSize = true;
            lblShadowColor.Location = new System.Drawing.Point(258, 88);
            lblShadowColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblShadowColor.Name = "lblShadowColor";
            lblShadowColor.Size = new System.Drawing.Size(79, 15);
            lblShadowColor.TabIndex = 5;
            lblShadowColor.Text = "Shadow color";
            // 
            // pMain
            // 
            pMain.Controls.Add(gbTexts);
            pMain.Controls.Add(btnClose);
            pMain.Controls.Add(btnSave);
            pMain.Controls.Add(gbLanguage);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(645, 205);
            pMain.TabIndex = 1;
            // 
            // gbLanguage
            // 
            gbLanguage.Controls.Add(cbLanguages);
            gbLanguage.Controls.Add(lblSelectedLanguage);
            gbLanguage.Dock = System.Windows.Forms.DockStyle.Top;
            gbLanguage.Location = new System.Drawing.Point(0, 0);
            gbLanguage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbLanguage.Name = "gbLanguage";
            gbLanguage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbLanguage.Size = new System.Drawing.Size(645, 47);
            gbLanguage.TabIndex = 0;
            gbLanguage.TabStop = false;
            gbLanguage.Text = "Language";
            // 
            // PersonalOptionsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(645, 205);
            Controls.Add(pMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(652, 231);
            Name = "PersonalOptionsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "PersonalOptions";
            Shown += PersonalOptionsForm_Shown;
            ((System.ComponentModel.ISupportInitialize)nudFontSizeSmall).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudFontSizeBig).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbShadowColor).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFontColor).EndInit();
            gbTexts.ResumeLayout(false);
            gbTexts.PerformLayout();
            pMain.ResumeLayout(false);
            gbLanguage.ResumeLayout(false);
            gbLanguage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FontDialog fdFontPicker;
        private System.Windows.Forms.ColorDialog cdColorPicker;
        private System.Windows.Forms.Label lblSelectedLanguage;
        private System.Windows.Forms.Label lblFontSizeSmall;
        private System.Windows.Forms.Label lblFontSizeBig;
        private System.Windows.Forms.NumericUpDown nudFontSizeSmall;
        private System.Windows.Forms.NumericUpDown nudFontSizeBig;
        private System.Windows.Forms.Button btnFontType;
        private System.Windows.Forms.Label lblShowVideoServerIdentifier;
        private System.Windows.Forms.RadioButton rbNone;
        private System.Windows.Forms.RadioButton rbIpAddress;
        private System.Windows.Forms.ComboBox cbLanguages;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton rbDisplayedName;
        private Mtf.Controls.MtfPictureBox pbShadowColor;
        private Mtf.Controls.MtfPictureBox pbFontColor;
        private System.Windows.Forms.Label lblFontColor;
        private System.Windows.Forms.ToolTip ttHint;
        private System.Windows.Forms.GroupBox gbTexts;
        private System.Windows.Forms.Label lblShadowColor;
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.GroupBox gbLanguage;
    }
}
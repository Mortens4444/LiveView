namespace LiveView.Forms
{
    partial class Templates
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Templates));
            lvTemplates = new Mtf.Controls.MtfListView();
            chTemplates = new System.Windows.Forms.ColumnHeader();
            pMain = new System.Windows.Forms.Panel();
            gbTemplates = new System.Windows.Forms.GroupBox();
            btnDelete = new System.Windows.Forms.Button();
            btnClose = new System.Windows.Forms.Button();
            gbCreateTemplate = new System.Windows.Forms.GroupBox();
            tbTemplateName = new System.Windows.Forms.TextBox();
            btnSave = new System.Windows.Forms.Button();
            lblTemplateName = new System.Windows.Forms.Label();
            pMain.SuspendLayout();
            gbTemplates.SuspendLayout();
            gbCreateTemplate.SuspendLayout();
            SuspendLayout();
            // 
            // lvTemplates
            // 
            lvTemplates.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lvTemplates.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lvTemplates.AlternatingColorsAreInUse = true;
            lvTemplates.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lvTemplates.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lvTemplates.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lvTemplates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { chTemplates });
            lvTemplates.CompactView = false;
            lvTemplates.EnsureLastItemIsVisible = false;
            lvTemplates.FirstItemIsGray = false;
            lvTemplates.FullRowSelect = true;
            lvTemplates.Location = new System.Drawing.Point(4, 18);
            lvTemplates.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lvTemplates.Name = "lvTemplates";
            lvTemplates.OwnerDraw = true;
            lvTemplates.ReadonlyCheckboxes = false;
            lvTemplates.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lvTemplates.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lvTemplates.Size = new System.Drawing.Size(454, 299);
            lvTemplates.TabIndex = 0;
            lvTemplates.UseCompatibleStateImageBehavior = false;
            lvTemplates.View = System.Windows.Forms.View.Details;
            // 
            // chTemplates
            // 
            chTemplates.Text = "Templates";
            chTemplates.Width = 385;
            // 
            // pMain
            // 
            pMain.Controls.Add(gbTemplates);
            pMain.Controls.Add(gbCreateTemplate);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(462, 437);
            pMain.TabIndex = 1;
            // 
            // gbTemplates
            // 
            gbTemplates.Controls.Add(btnDelete);
            gbTemplates.Controls.Add(btnClose);
            gbTemplates.Controls.Add(lvTemplates);
            gbTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            gbTemplates.Location = new System.Drawing.Point(0, 78);
            gbTemplates.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbTemplates.Name = "gbTemplates";
            gbTemplates.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbTemplates.Size = new System.Drawing.Size(462, 359);
            gbTemplates.TabIndex = 1;
            gbTemplates.TabStop = false;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnDelete.Location = new System.Drawing.Point(4, 325);
            btnDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(88, 27);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.Location = new System.Drawing.Point(368, 325);
            btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(88, 27);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            // 
            // gbCreateTemplate
            // 
            gbCreateTemplate.Controls.Add(tbTemplateName);
            gbCreateTemplate.Controls.Add(btnSave);
            gbCreateTemplate.Controls.Add(lblTemplateName);
            gbCreateTemplate.Dock = System.Windows.Forms.DockStyle.Top;
            gbCreateTemplate.Location = new System.Drawing.Point(0, 0);
            gbCreateTemplate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbCreateTemplate.Name = "gbCreateTemplate";
            gbCreateTemplate.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbCreateTemplate.Size = new System.Drawing.Size(462, 78);
            gbCreateTemplate.TabIndex = 0;
            gbCreateTemplate.TabStop = false;
            gbCreateTemplate.Text = "Create template from sequences";
            // 
            // tbTemplateName
            // 
            tbTemplateName.Location = new System.Drawing.Point(18, 47);
            tbTemplateName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbTemplateName.MaxLength = 50;
            tbTemplateName.Name = "tbTemplateName";
            tbTemplateName.Size = new System.Drawing.Size(342, 23);
            tbTemplateName.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Location = new System.Drawing.Point(368, 45);
            btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(88, 27);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += BtnSave_Click;
            // 
            // lblTemplateName
            // 
            lblTemplateName.AutoSize = true;
            lblTemplateName.Location = new System.Drawing.Point(14, 18);
            lblTemplateName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTemplateName.Name = "lblTemplateName";
            lblTemplateName.Size = new System.Drawing.Size(89, 15);
            lblTemplateName.TabIndex = 0;
            lblTemplateName.Text = "Template name";
            // 
            // Templates
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(462, 437);
            Controls.Add(pMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Templates";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Templates";
            Shown += Templates_Shown;
            pMain.ResumeLayout(false);
            gbTemplates.ResumeLayout(false);
            gbCreateTemplate.ResumeLayout(false);
            gbCreateTemplate.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Mtf.Controls.MtfListView lvTemplates;
        private System.Windows.Forms.ColumnHeader chTemplates;
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.GroupBox gbTemplates;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbCreateTemplate;
        private System.Windows.Forms.TextBox tbTemplateName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTemplateName;
    }
}
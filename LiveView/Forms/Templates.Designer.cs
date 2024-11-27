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
            lv_Templates = new Mtf.Controls.MtfListView();
            ch_0_Templates = new System.Windows.Forms.ColumnHeader();
            p_Main = new System.Windows.Forms.Panel();
            gb_Templates = new System.Windows.Forms.GroupBox();
            btn_Delete = new System.Windows.Forms.Button();
            btn_Close = new System.Windows.Forms.Button();
            gb_CreateTemplate = new System.Windows.Forms.GroupBox();
            tb_TemplateName = new System.Windows.Forms.TextBox();
            btn_Save = new System.Windows.Forms.Button();
            lbl_TemplateName = new System.Windows.Forms.Label();
            p_Main.SuspendLayout();
            gb_Templates.SuspendLayout();
            gb_CreateTemplate.SuspendLayout();
            SuspendLayout();
            // 
            // lv_Templates
            // 
            lv_Templates.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lv_Templates.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lv_Templates.AlternatingColorsAreInUse = true;
            lv_Templates.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lv_Templates.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lv_Templates.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lv_Templates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { ch_0_Templates });
            lv_Templates.CompactView = false;
            lv_Templates.EnsureLastItemIsVisible = false;
            lv_Templates.FirstItemIsGray = false;
            lv_Templates.FullRowSelect = true;
            lv_Templates.Location = new System.Drawing.Point(4, 18);
            lv_Templates.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lv_Templates.Name = "lv_Templates";
            lv_Templates.OwnerDraw = true;
            lv_Templates.ReadonlyCheckboxes = false;
            lv_Templates.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lv_Templates.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lv_Templates.Size = new System.Drawing.Size(454, 299);
            lv_Templates.TabIndex = 0;
            lv_Templates.UseCompatibleStateImageBehavior = false;
            lv_Templates.View = System.Windows.Forms.View.Details;
            // 
            // ch_0_Templates
            // 
            ch_0_Templates.Text = "Templates";
            ch_0_Templates.Width = 385;
            // 
            // p_Main
            // 
            p_Main.Controls.Add(gb_Templates);
            p_Main.Controls.Add(gb_CreateTemplate);
            p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            p_Main.Location = new System.Drawing.Point(0, 0);
            p_Main.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_Main.Name = "p_Main";
            p_Main.Size = new System.Drawing.Size(462, 437);
            p_Main.TabIndex = 1;
            // 
            // gb_Templates
            // 
            gb_Templates.Controls.Add(btn_Delete);
            gb_Templates.Controls.Add(btn_Close);
            gb_Templates.Controls.Add(lv_Templates);
            gb_Templates.Dock = System.Windows.Forms.DockStyle.Fill;
            gb_Templates.Location = new System.Drawing.Point(0, 78);
            gb_Templates.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Templates.Name = "gb_Templates";
            gb_Templates.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Templates.Size = new System.Drawing.Size(462, 359);
            gb_Templates.TabIndex = 1;
            gb_Templates.TabStop = false;
            // 
            // btn_Delete
            // 
            btn_Delete.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btn_Delete.Location = new System.Drawing.Point(4, 325);
            btn_Delete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Delete.Name = "btn_Delete";
            btn_Delete.Size = new System.Drawing.Size(88, 27);
            btn_Delete.TabIndex = 2;
            btn_Delete.Text = "Delete";
            btn_Delete.UseVisualStyleBackColor = true;
            btn_Delete.Click += Btn_Delete_Click;
            // 
            // btn_Close
            // 
            btn_Close.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btn_Close.Location = new System.Drawing.Point(368, 325);
            btn_Close.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Close.Name = "btn_Close";
            btn_Close.Size = new System.Drawing.Size(88, 27);
            btn_Close.TabIndex = 1;
            btn_Close.Text = "Close";
            btn_Close.UseVisualStyleBackColor = true;
            btn_Close.Click += Btn_Close_Click;
            // 
            // gb_CreateTemplate
            // 
            gb_CreateTemplate.Controls.Add(tb_TemplateName);
            gb_CreateTemplate.Controls.Add(btn_Save);
            gb_CreateTemplate.Controls.Add(lbl_TemplateName);
            gb_CreateTemplate.Dock = System.Windows.Forms.DockStyle.Top;
            gb_CreateTemplate.Location = new System.Drawing.Point(0, 0);
            gb_CreateTemplate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_CreateTemplate.Name = "gb_CreateTemplate";
            gb_CreateTemplate.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_CreateTemplate.Size = new System.Drawing.Size(462, 78);
            gb_CreateTemplate.TabIndex = 0;
            gb_CreateTemplate.TabStop = false;
            gb_CreateTemplate.Text = "Create template from sequences";
            // 
            // tb_TemplateName
            // 
            tb_TemplateName.Location = new System.Drawing.Point(18, 47);
            tb_TemplateName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_TemplateName.MaxLength = 50;
            tb_TemplateName.Name = "tb_TemplateName";
            tb_TemplateName.Size = new System.Drawing.Size(342, 23);
            tb_TemplateName.TabIndex = 2;
            // 
            // btn_Save
            // 
            btn_Save.Enabled = false;
            btn_Save.Location = new System.Drawing.Point(368, 45);
            btn_Save.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new System.Drawing.Size(88, 27);
            btn_Save.TabIndex = 1;
            btn_Save.Text = "Save";
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += Btn_Save_Click;
            // 
            // lbl_TemplateName
            // 
            lbl_TemplateName.AutoSize = true;
            lbl_TemplateName.Location = new System.Drawing.Point(14, 18);
            lbl_TemplateName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_TemplateName.Name = "lbl_TemplateName";
            lbl_TemplateName.Size = new System.Drawing.Size(89, 15);
            lbl_TemplateName.TabIndex = 0;
            lbl_TemplateName.Text = "Template name";
            // 
            // Templates
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(462, 437);
            Controls.Add(p_Main);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Templates";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Templates";
            p_Main.ResumeLayout(false);
            gb_Templates.ResumeLayout(false);
            gb_CreateTemplate.ResumeLayout(false);
            gb_CreateTemplate.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Mtf.Controls.MtfListView lv_Templates;
        private System.Windows.Forms.ColumnHeader ch_0_Templates;
        private System.Windows.Forms.Panel p_Main;
        private System.Windows.Forms.GroupBox gb_Templates;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.GroupBox gb_CreateTemplate;
        private System.Windows.Forms.TextBox tb_TemplateName;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label lbl_TemplateName;
    }
}
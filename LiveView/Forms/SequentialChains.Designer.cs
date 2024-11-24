namespace LiveView.Forms
{
    partial class SequentialChains
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(SequentialChains));
            pMain = new System.Windows.Forms.Panel();
            tb_SequenceName = new System.Windows.Forms.TextBox();
            cb_GridIdentifier = new System.Windows.Forms.ComboBox();
            nud_SecondsToShow = new System.Windows.Forms.NumericUpDown();
            lbl_SecondsToShow = new System.Windows.Forms.Label();
            btn_AddGrid = new System.Windows.Forms.Button();
            cb_GridName = new System.Windows.Forms.ComboBox();
            lbl_GridName = new System.Windows.Forms.Label();
            gb_AddGrid = new System.Windows.Forms.GroupBox();
            cb_SequenceIdentifier = new System.Windows.Forms.ComboBox();
            btn_DeleteSequence = new System.Windows.Forms.Button();
            cb_SequenceName = new System.Windows.Forms.ComboBox();
            gb_Sequences = new System.Windows.Forms.GroupBox();
            tsmi_DeleteGrid = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_MoveDown = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_MoveUp = new System.Windows.Forms.ToolStripMenuItem();
            cms_GridsContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            ch_2_GridName = new System.Windows.Forms.ColumnHeader();
            ch_1_SecondsToShow = new System.Windows.Forms.ColumnHeader();
            ch_0_Number = new System.Windows.Forms.ColumnHeader();
            btn_DeleteGrid = new System.Windows.Forms.Button();
            btn_MoveDown = new System.Windows.Forms.Button();
            btn_MoveUp = new System.Windows.Forms.Button();
            btn_AddOrUpdateSequence = new System.Windows.Forms.Button();
            lv_Grids = new Mtf.Controls.MtfListView();
            gb_SequenceName = new System.Windows.Forms.GroupBox();
            gb_SequenceStructure = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)nud_SecondsToShow).BeginInit();
            gb_AddGrid.SuspendLayout();
            gb_Sequences.SuspendLayout();
            cms_GridsContextMenu.SuspendLayout();
            gb_SequenceName.SuspendLayout();
            gb_SequenceStructure.SuspendLayout();
            SuspendLayout();
            // 
            // pMain
            // 
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(491, 391);
            pMain.TabIndex = 0;
            // 
            // tb_SequenceName
            // 
            tb_SequenceName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_SequenceName.Location = new System.Drawing.Point(7, 22);
            tb_SequenceName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_SequenceName.MaxLength = 50;
            tb_SequenceName.Name = "tb_SequenceName";
            tb_SequenceName.Size = new System.Drawing.Size(476, 23);
            tb_SequenceName.TabIndex = 0;
            // 
            // cb_GridIdentifier
            // 
            cb_GridIdentifier.FormattingEnabled = true;
            cb_GridIdentifier.Location = new System.Drawing.Point(164, 9);
            cb_GridIdentifier.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_GridIdentifier.Name = "cb_GridIdentifier";
            cb_GridIdentifier.Size = new System.Drawing.Size(88, 23);
            cb_GridIdentifier.TabIndex = 5;
            cb_GridIdentifier.Visible = false;
            // 
            // nud_SecondsToShow
            // 
            nud_SecondsToShow.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nud_SecondsToShow.Location = new System.Drawing.Point(276, 38);
            nud_SecondsToShow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nud_SecondsToShow.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nud_SecondsToShow.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            nud_SecondsToShow.Name = "nud_SecondsToShow";
            nud_SecondsToShow.Size = new System.Drawing.Size(105, 23);
            nud_SecondsToShow.TabIndex = 3;
            nud_SecondsToShow.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lbl_SecondsToShow
            // 
            lbl_SecondsToShow.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lbl_SecondsToShow.AutoSize = true;
            lbl_SecondsToShow.Location = new System.Drawing.Point(273, 18);
            lbl_SecondsToShow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_SecondsToShow.Name = "lbl_SecondsToShow";
            lbl_SecondsToShow.Size = new System.Drawing.Size(96, 15);
            lbl_SecondsToShow.TabIndex = 2;
            lbl_SecondsToShow.Text = "Seconds to show";
            // 
            // btn_AddGrid
            // 
            btn_AddGrid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_AddGrid.Location = new System.Drawing.Point(397, 35);
            btn_AddGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_AddGrid.Name = "btn_AddGrid";
            btn_AddGrid.Size = new System.Drawing.Size(88, 27);
            btn_AddGrid.TabIndex = 4;
            btn_AddGrid.Text = "Add";
            btn_AddGrid.UseVisualStyleBackColor = true;
            // 
            // cb_GridName
            // 
            cb_GridName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cb_GridName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_GridName.FormattingEnabled = true;
            cb_GridName.Location = new System.Drawing.Point(7, 37);
            cb_GridName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_GridName.Name = "cb_GridName";
            cb_GridName.Size = new System.Drawing.Size(245, 23);
            cb_GridName.TabIndex = 1;
            // 
            // lbl_GridName
            // 
            lbl_GridName.AutoSize = true;
            lbl_GridName.Location = new System.Drawing.Point(4, 18);
            lbl_GridName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_GridName.Name = "lbl_GridName";
            lbl_GridName.Size = new System.Drawing.Size(62, 15);
            lbl_GridName.TabIndex = 0;
            lbl_GridName.Text = "Grid name";
            // 
            // gb_AddGrid
            // 
            gb_AddGrid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gb_AddGrid.Controls.Add(cb_GridIdentifier);
            gb_AddGrid.Controls.Add(nud_SecondsToShow);
            gb_AddGrid.Controls.Add(lbl_SecondsToShow);
            gb_AddGrid.Controls.Add(btn_AddGrid);
            gb_AddGrid.Controls.Add(cb_GridName);
            gb_AddGrid.Controls.Add(lbl_GridName);
            gb_AddGrid.Location = new System.Drawing.Point(0, 105);
            gb_AddGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_AddGrid.Name = "gb_AddGrid";
            gb_AddGrid.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_AddGrid.Size = new System.Drawing.Size(491, 69);
            gb_AddGrid.TabIndex = 6;
            gb_AddGrid.TabStop = false;
            gb_AddGrid.Text = "Add grid to sequential chain";
            // 
            // cb_SequenceIdentifier
            // 
            cb_SequenceIdentifier.FormattingEnabled = true;
            cb_SequenceIdentifier.Location = new System.Drawing.Point(293, 14);
            cb_SequenceIdentifier.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_SequenceIdentifier.Name = "cb_SequenceIdentifier";
            cb_SequenceIdentifier.Size = new System.Drawing.Size(88, 23);
            cb_SequenceIdentifier.TabIndex = 2;
            cb_SequenceIdentifier.Visible = false;
            // 
            // btn_DeleteSequence
            // 
            btn_DeleteSequence.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_DeleteSequence.Location = new System.Drawing.Point(397, 20);
            btn_DeleteSequence.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_DeleteSequence.Name = "btn_DeleteSequence";
            btn_DeleteSequence.Size = new System.Drawing.Size(88, 27);
            btn_DeleteSequence.TabIndex = 1;
            btn_DeleteSequence.Text = "Delete";
            btn_DeleteSequence.UseVisualStyleBackColor = true;
            // 
            // cb_SequenceName
            // 
            cb_SequenceName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cb_SequenceName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_SequenceName.FormattingEnabled = true;
            cb_SequenceName.Location = new System.Drawing.Point(7, 22);
            cb_SequenceName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_SequenceName.Name = "cb_SequenceName";
            cb_SequenceName.Size = new System.Drawing.Size(374, 23);
            cb_SequenceName.TabIndex = 0;
            // 
            // gb_Sequences
            // 
            gb_Sequences.Controls.Add(cb_SequenceIdentifier);
            gb_Sequences.Controls.Add(btn_DeleteSequence);
            gb_Sequences.Controls.Add(cb_SequenceName);
            gb_Sequences.Dock = System.Windows.Forms.DockStyle.Top;
            gb_Sequences.Location = new System.Drawing.Point(0, 0);
            gb_Sequences.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Sequences.Name = "gb_Sequences";
            gb_Sequences.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Sequences.Size = new System.Drawing.Size(491, 53);
            gb_Sequences.TabIndex = 4;
            gb_Sequences.TabStop = false;
            gb_Sequences.Text = "Sequential chains";
            // 
            // tsmi_DeleteGrid
            // 
            tsmi_DeleteGrid.Name = "tsmi_DeleteGrid";
            tsmi_DeleteGrid.Size = new System.Drawing.Size(137, 22);
            tsmi_DeleteGrid.Text = "Delete";
            // 
            // tsmi_MoveDown
            // 
            tsmi_MoveDown.Name = "tsmi_MoveDown";
            tsmi_MoveDown.Size = new System.Drawing.Size(137, 22);
            tsmi_MoveDown.Text = "Move down";
            // 
            // tsmi_MoveUp
            // 
            tsmi_MoveUp.Name = "tsmi_MoveUp";
            tsmi_MoveUp.Size = new System.Drawing.Size(137, 22);
            tsmi_MoveUp.Text = "Move up";
            // 
            // cms_GridsContextMenu
            // 
            cms_GridsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmi_MoveUp, tsmi_MoveDown, tsmi_DeleteGrid });
            cms_GridsContextMenu.Name = "cms_GridsContextMenu";
            cms_GridsContextMenu.Size = new System.Drawing.Size(138, 70);
            // 
            // ch_2_GridName
            // 
            ch_2_GridName.Text = "Grid name";
            ch_2_GridName.Width = 266;
            // 
            // ch_1_SecondsToShow
            // 
            ch_1_SecondsToShow.Text = "Seconds to show";
            ch_1_SecondsToShow.Width = 95;
            // 
            // ch_0_Number
            // 
            ch_0_Number.Text = "Number";
            ch_0_Number.Width = 50;
            // 
            // btn_DeleteGrid
            // 
            btn_DeleteGrid.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btn_DeleteGrid.Location = new System.Drawing.Point(192, 181);
            btn_DeleteGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_DeleteGrid.Name = "btn_DeleteGrid";
            btn_DeleteGrid.Size = new System.Drawing.Size(88, 27);
            btn_DeleteGrid.TabIndex = 3;
            btn_DeleteGrid.Text = "Delete";
            btn_DeleteGrid.UseVisualStyleBackColor = true;
            // 
            // btn_MoveDown
            // 
            btn_MoveDown.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btn_MoveDown.Location = new System.Drawing.Point(98, 181);
            btn_MoveDown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_MoveDown.Name = "btn_MoveDown";
            btn_MoveDown.Size = new System.Drawing.Size(88, 27);
            btn_MoveDown.TabIndex = 2;
            btn_MoveDown.Text = "Move down";
            btn_MoveDown.UseVisualStyleBackColor = true;
            // 
            // btn_MoveUp
            // 
            btn_MoveUp.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btn_MoveUp.Location = new System.Drawing.Point(4, 181);
            btn_MoveUp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_MoveUp.Name = "btn_MoveUp";
            btn_MoveUp.Size = new System.Drawing.Size(88, 27);
            btn_MoveUp.TabIndex = 1;
            btn_MoveUp.Text = "Move up";
            btn_MoveUp.UseVisualStyleBackColor = true;
            // 
            // btn_AddOrUpdateSequence
            // 
            btn_AddOrUpdateSequence.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_AddOrUpdateSequence.Location = new System.Drawing.Point(397, 181);
            btn_AddOrUpdateSequence.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_AddOrUpdateSequence.Name = "btn_AddOrUpdateSequence";
            btn_AddOrUpdateSequence.Size = new System.Drawing.Size(88, 27);
            btn_AddOrUpdateSequence.TabIndex = 4;
            btn_AddOrUpdateSequence.Text = "Add/Update";
            btn_AddOrUpdateSequence.UseVisualStyleBackColor = true;
            // 
            // lv_Grids
            // 
            lv_Grids.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lv_Grids.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lv_Grids.AlternatingColorsAreInUse = true;
            lv_Grids.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lv_Grids.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lv_Grids.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lv_Grids.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { ch_0_Number, ch_1_SecondsToShow, ch_2_GridName });
            lv_Grids.CompactView = false;
            lv_Grids.ContextMenuStrip = cms_GridsContextMenu;
            lv_Grids.EnsureLastItemIsVisible = false;
            lv_Grids.FirstItemIsGray = false;
            lv_Grids.FullRowSelect = true;
            lv_Grids.Location = new System.Drawing.Point(4, 20);
            lv_Grids.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lv_Grids.MultiSelect = false;
            lv_Grids.Name = "lv_Grids";
            lv_Grids.OwnerDraw = true;
            lv_Grids.ReadonlyCheckboxes = false;
            lv_Grids.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lv_Grids.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lv_Grids.Size = new System.Drawing.Size(483, 154);
            lv_Grids.TabIndex = 0;
            lv_Grids.UseCompatibleStateImageBehavior = false;
            lv_Grids.View = System.Windows.Forms.View.Details;
            // 
            // gb_SequenceName
            // 
            gb_SequenceName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gb_SequenceName.Controls.Add(tb_SequenceName);
            gb_SequenceName.Location = new System.Drawing.Point(0, 53);
            gb_SequenceName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_SequenceName.Name = "gb_SequenceName";
            gb_SequenceName.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_SequenceName.Size = new System.Drawing.Size(491, 52);
            gb_SequenceName.TabIndex = 5;
            gb_SequenceName.TabStop = false;
            gb_SequenceName.Text = "Name of the sequential chain";
            // 
            // gb_SequenceStructure
            // 
            gb_SequenceStructure.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gb_SequenceStructure.Controls.Add(btn_DeleteGrid);
            gb_SequenceStructure.Controls.Add(btn_MoveDown);
            gb_SequenceStructure.Controls.Add(btn_MoveUp);
            gb_SequenceStructure.Controls.Add(btn_AddOrUpdateSequence);
            gb_SequenceStructure.Controls.Add(lv_Grids);
            gb_SequenceStructure.Location = new System.Drawing.Point(0, 177);
            gb_SequenceStructure.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_SequenceStructure.Name = "gb_SequenceStructure";
            gb_SequenceStructure.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_SequenceStructure.Size = new System.Drawing.Size(491, 215);
            gb_SequenceStructure.TabIndex = 7;
            gb_SequenceStructure.TabStop = false;
            gb_SequenceStructure.Text = "Sequential chain structure";
            // 
            // SequentialChains
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(491, 391);
            Controls.Add(gb_AddGrid);
            Controls.Add(gb_Sequences);
            Controls.Add(gb_SequenceName);
            Controls.Add(gb_SequenceStructure);
            Controls.Add(pMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(498, 416);
            Name = "SequentialChains";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Sequential chains";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)nud_SecondsToShow).EndInit();
            gb_AddGrid.ResumeLayout(false);
            gb_AddGrid.PerformLayout();
            gb_Sequences.ResumeLayout(false);
            cms_GridsContextMenu.ResumeLayout(false);
            gb_SequenceName.ResumeLayout(false);
            gb_SequenceName.PerformLayout();
            gb_SequenceStructure.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.TextBox tb_SequenceName;
        private System.Windows.Forms.ComboBox cb_GridIdentifier;
        private System.Windows.Forms.NumericUpDown nud_SecondsToShow;
        private System.Windows.Forms.Label lbl_SecondsToShow;
        private System.Windows.Forms.Button btn_AddGrid;
        private System.Windows.Forms.ComboBox cb_GridName;
        private System.Windows.Forms.Label lbl_GridName;
        private System.Windows.Forms.GroupBox gb_AddGrid;
        private System.Windows.Forms.ComboBox cb_SequenceIdentifier;
        private System.Windows.Forms.Button btn_DeleteSequence;
        private System.Windows.Forms.ComboBox cb_SequenceName;
        private System.Windows.Forms.GroupBox gb_Sequences;
        private System.Windows.Forms.ToolStripMenuItem tsmi_DeleteGrid;
        private System.Windows.Forms.ToolStripMenuItem tsmi_MoveDown;
        private System.Windows.Forms.ToolStripMenuItem tsmi_MoveUp;
        private System.Windows.Forms.ContextMenuStrip cms_GridsContextMenu;
        private System.Windows.Forms.ColumnHeader ch_2_GridName;
        private System.Windows.Forms.ColumnHeader ch_1_SecondsToShow;
        private System.Windows.Forms.ColumnHeader ch_0_Number;
        private System.Windows.Forms.Button btn_DeleteGrid;
        private System.Windows.Forms.Button btn_MoveDown;
        private System.Windows.Forms.Button btn_MoveUp;
        private System.Windows.Forms.Button btn_AddOrUpdateSequence;
        private Mtf.Controls.MtfListView lv_Grids;
        private System.Windows.Forms.GroupBox gb_SequenceName;
        private System.Windows.Forms.GroupBox gb_SequenceStructure;
    }
}
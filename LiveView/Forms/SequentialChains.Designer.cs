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
            pMain = new System.Windows.Forms.Panel();
            tbSequenceName = new System.Windows.Forms.TextBox();
            nudSecondsToShow = new System.Windows.Forms.NumericUpDown();
            lblSecondsToShow = new System.Windows.Forms.Label();
            btnAddGridToSequence = new System.Windows.Forms.Button();
            cbGrids = new System.Windows.Forms.ComboBox();
            lblGridName = new System.Windows.Forms.Label();
            gbAddGrid = new System.Windows.Forms.GroupBox();
            btnDeleteSequence = new System.Windows.Forms.Button();
            cbSequences = new System.Windows.Forms.ComboBox();
            gbSequences = new System.Windows.Forms.GroupBox();
            tsmiDeleteGrid = new System.Windows.Forms.ToolStripMenuItem();
            tsmiMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            tsmiMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            cmsGridsContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            chGridName = new System.Windows.Forms.ColumnHeader();
            chSecondsToShow = new System.Windows.Forms.ColumnHeader();
            chNumber = new System.Windows.Forms.ColumnHeader();
            btnRemoveGridFromSequence = new System.Windows.Forms.Button();
            btnMoveDown = new System.Windows.Forms.Button();
            btnMoveUp = new System.Windows.Forms.Button();
            btnSaveSequence = new System.Windows.Forms.Button();
            lvGrids = new Mtf.Controls.MtfListView();
            gbSequenceName = new System.Windows.Forms.GroupBox();
            gbSequenceStructure = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)nudSecondsToShow).BeginInit();
            gbAddGrid.SuspendLayout();
            gbSequences.SuspendLayout();
            cmsGridsContextMenu.SuspendLayout();
            gbSequenceName.SuspendLayout();
            gbSequenceStructure.SuspendLayout();
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
            // tbSequenceName
            // 
            tbSequenceName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbSequenceName.Location = new System.Drawing.Point(7, 22);
            tbSequenceName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbSequenceName.MaxLength = 50;
            tbSequenceName.Name = "tbSequenceName";
            tbSequenceName.Size = new System.Drawing.Size(476, 23);
            tbSequenceName.TabIndex = 0;
            // 
            // nudSecondsToShow
            // 
            nudSecondsToShow.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nudSecondsToShow.Location = new System.Drawing.Point(276, 38);
            nudSecondsToShow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudSecondsToShow.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudSecondsToShow.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            nudSecondsToShow.Name = "nudSecondsToShow";
            nudSecondsToShow.Size = new System.Drawing.Size(105, 23);
            nudSecondsToShow.TabIndex = 3;
            nudSecondsToShow.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblSecondsToShow
            // 
            lblSecondsToShow.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblSecondsToShow.AutoSize = true;
            lblSecondsToShow.Location = new System.Drawing.Point(273, 18);
            lblSecondsToShow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSecondsToShow.Name = "lblSecondsToShow";
            lblSecondsToShow.Size = new System.Drawing.Size(96, 15);
            lblSecondsToShow.TabIndex = 2;
            lblSecondsToShow.Text = "Seconds to show";
            // 
            // btnAddGridToSequence
            // 
            btnAddGridToSequence.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAddGridToSequence.Location = new System.Drawing.Point(397, 35);
            btnAddGridToSequence.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAddGridToSequence.Name = "btnAddGridToSequence";
            btnAddGridToSequence.Size = new System.Drawing.Size(88, 27);
            btnAddGridToSequence.TabIndex = 4;
            btnAddGridToSequence.Text = "Add";
            btnAddGridToSequence.UseVisualStyleBackColor = true;
            btnAddGridToSequence.Click += BtnAddGridToSequence_Click;
            // 
            // cbGrids
            // 
            cbGrids.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbGrids.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbGrids.FormattingEnabled = true;
            cbGrids.Location = new System.Drawing.Point(7, 37);
            cbGrids.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbGrids.Name = "cbGrids";
            cbGrids.Size = new System.Drawing.Size(245, 23);
            cbGrids.TabIndex = 1;
            // 
            // lblGridName
            // 
            lblGridName.AutoSize = true;
            lblGridName.Location = new System.Drawing.Point(4, 18);
            lblGridName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblGridName.Name = "lblGridName";
            lblGridName.Size = new System.Drawing.Size(62, 15);
            lblGridName.TabIndex = 0;
            lblGridName.Text = "Grid name";
            // 
            // gbAddGrid
            // 
            gbAddGrid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gbAddGrid.Controls.Add(nudSecondsToShow);
            gbAddGrid.Controls.Add(lblSecondsToShow);
            gbAddGrid.Controls.Add(btnAddGridToSequence);
            gbAddGrid.Controls.Add(cbGrids);
            gbAddGrid.Controls.Add(lblGridName);
            gbAddGrid.Location = new System.Drawing.Point(0, 105);
            gbAddGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbAddGrid.Name = "gbAddGrid";
            gbAddGrid.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbAddGrid.Size = new System.Drawing.Size(491, 69);
            gbAddGrid.TabIndex = 6;
            gbAddGrid.TabStop = false;
            gbAddGrid.Text = "Add grid to sequential chain";
            // 
            // btnDeleteSequence
            // 
            btnDeleteSequence.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnDeleteSequence.Location = new System.Drawing.Point(397, 20);
            btnDeleteSequence.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnDeleteSequence.Name = "btnDeleteSequence";
            btnDeleteSequence.Size = new System.Drawing.Size(88, 27);
            btnDeleteSequence.TabIndex = 1;
            btnDeleteSequence.Text = "Delete";
            btnDeleteSequence.UseVisualStyleBackColor = true;
            btnDeleteSequence.Click += BtnDeleteSequence_Click;
            // 
            // cbSequences
            // 
            cbSequences.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbSequences.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbSequences.FormattingEnabled = true;
            cbSequences.Location = new System.Drawing.Point(7, 22);
            cbSequences.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbSequences.Name = "cbSequences";
            cbSequences.Size = new System.Drawing.Size(374, 23);
            cbSequences.TabIndex = 0;
            cbSequences.SelectedIndexChanged += CbSequences_SelectedIndexChanged;
            // 
            // gbSequences
            // 
            gbSequences.Controls.Add(btnDeleteSequence);
            gbSequences.Controls.Add(cbSequences);
            gbSequences.Dock = System.Windows.Forms.DockStyle.Top;
            gbSequences.Location = new System.Drawing.Point(0, 0);
            gbSequences.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbSequences.Name = "gbSequences";
            gbSequences.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbSequences.Size = new System.Drawing.Size(491, 53);
            gbSequences.TabIndex = 4;
            gbSequences.TabStop = false;
            gbSequences.Text = "Sequential chains";
            // 
            // tsmiDeleteGrid
            // 
            tsmiDeleteGrid.Name = "tsmiDeleteGrid";
            tsmiDeleteGrid.Size = new System.Drawing.Size(137, 22);
            tsmiDeleteGrid.Text = "Delete";
            // 
            // tsmiMoveDown
            // 
            tsmiMoveDown.Name = "tsmiMoveDown";
            tsmiMoveDown.Size = new System.Drawing.Size(137, 22);
            tsmiMoveDown.Text = "Move down";
            // 
            // tsmiMoveUp
            // 
            tsmiMoveUp.Name = "tsmiMoveUp";
            tsmiMoveUp.Size = new System.Drawing.Size(137, 22);
            tsmiMoveUp.Text = "Move up";
            // 
            // cmsGridsContextMenu
            // 
            cmsGridsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiMoveUp, tsmiMoveDown, tsmiDeleteGrid });
            cmsGridsContextMenu.Name = "cms_GridsContextMenu";
            cmsGridsContextMenu.Size = new System.Drawing.Size(138, 70);
            // 
            // chGridName
            // 
            chGridName.Text = "Grid name";
            chGridName.Width = 266;
            // 
            // chSecondsToShow
            // 
            chSecondsToShow.Text = "Seconds to show";
            chSecondsToShow.Width = 95;
            // 
            // chNumber
            // 
            chNumber.Text = "Number";
            chNumber.Width = 50;
            // 
            // btnRemoveGridFromSequence
            // 
            btnRemoveGridFromSequence.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnRemoveGridFromSequence.Location = new System.Drawing.Point(192, 181);
            btnRemoveGridFromSequence.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnRemoveGridFromSequence.Name = "btnRemoveGridFromSequence";
            btnRemoveGridFromSequence.Size = new System.Drawing.Size(88, 27);
            btnRemoveGridFromSequence.TabIndex = 3;
            btnRemoveGridFromSequence.Text = "Delete";
            btnRemoveGridFromSequence.UseVisualStyleBackColor = true;
            btnRemoveGridFromSequence.Click += BtnRemoveGridFromSequence_Click;
            // 
            // btnMoveDown
            // 
            btnMoveDown.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnMoveDown.Location = new System.Drawing.Point(98, 181);
            btnMoveDown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnMoveDown.Name = "btnMoveDown";
            btnMoveDown.Size = new System.Drawing.Size(88, 27);
            btnMoveDown.TabIndex = 2;
            btnMoveDown.Text = "Move down";
            btnMoveDown.UseVisualStyleBackColor = true;
            btnMoveDown.Click += BtnMoveDown_Click;
            // 
            // btnMoveUp
            // 
            btnMoveUp.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnMoveUp.Location = new System.Drawing.Point(4, 181);
            btnMoveUp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnMoveUp.Name = "btnMoveUp";
            btnMoveUp.Size = new System.Drawing.Size(88, 27);
            btnMoveUp.TabIndex = 1;
            btnMoveUp.Text = "Move up";
            btnMoveUp.UseVisualStyleBackColor = true;
            btnMoveUp.Click += BtnMoveUp_Click;
            // 
            // btnSaveSequence
            // 
            btnSaveSequence.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSaveSequence.Location = new System.Drawing.Point(397, 181);
            btnSaveSequence.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSaveSequence.Name = "btnSaveSequence";
            btnSaveSequence.Size = new System.Drawing.Size(88, 27);
            btnSaveSequence.TabIndex = 4;
            btnSaveSequence.Text = "Save";
            btnSaveSequence.UseVisualStyleBackColor = true;
            btnSaveSequence.Click += BtnSaveSequence_Click;
            // 
            // lvGrids
            // 
            lvGrids.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lvGrids.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lvGrids.AlternatingColorsAreInUse = true;
            lvGrids.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lvGrids.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lvGrids.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lvGrids.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { chNumber, chSecondsToShow, chGridName });
            lvGrids.CompactView = false;
            lvGrids.ContextMenuStrip = cmsGridsContextMenu;
            lvGrids.EnsureLastItemIsVisible = false;
            lvGrids.FirstItemIsGray = false;
            lvGrids.FullRowSelect = true;
            lvGrids.Location = new System.Drawing.Point(4, 20);
            lvGrids.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lvGrids.MultiSelect = false;
            lvGrids.Name = "lvGrids";
            lvGrids.OwnerDraw = true;
            lvGrids.ReadonlyCheckboxes = false;
            lvGrids.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lvGrids.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lvGrids.Size = new System.Drawing.Size(483, 154);
            lvGrids.TabIndex = 0;
            lvGrids.UseCompatibleStateImageBehavior = false;
            lvGrids.View = System.Windows.Forms.View.Details;
            // 
            // gbSequenceName
            // 
            gbSequenceName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gbSequenceName.Controls.Add(tbSequenceName);
            gbSequenceName.Location = new System.Drawing.Point(0, 53);
            gbSequenceName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbSequenceName.Name = "gbSequenceName";
            gbSequenceName.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbSequenceName.Size = new System.Drawing.Size(491, 52);
            gbSequenceName.TabIndex = 5;
            gbSequenceName.TabStop = false;
            gbSequenceName.Text = "Name of the sequential chain";
            // 
            // gbSequenceStructure
            // 
            gbSequenceStructure.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gbSequenceStructure.Controls.Add(btnRemoveGridFromSequence);
            gbSequenceStructure.Controls.Add(btnMoveDown);
            gbSequenceStructure.Controls.Add(btnMoveUp);
            gbSequenceStructure.Controls.Add(btnSaveSequence);
            gbSequenceStructure.Controls.Add(lvGrids);
            gbSequenceStructure.Location = new System.Drawing.Point(0, 177);
            gbSequenceStructure.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbSequenceStructure.Name = "gbSequenceStructure";
            gbSequenceStructure.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbSequenceStructure.Size = new System.Drawing.Size(491, 215);
            gbSequenceStructure.TabIndex = 7;
            gbSequenceStructure.TabStop = false;
            gbSequenceStructure.Text = "Sequential chain structure";
            // 
            // SequentialChains
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(491, 391);
            Controls.Add(gbAddGrid);
            Controls.Add(gbSequences);
            Controls.Add(gbSequenceName);
            Controls.Add(gbSequenceStructure);
            Controls.Add(pMain);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(498, 416);
            Name = "SequentialChains";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Sequential chains";
            TopMost = true;
            Shown += SequentialChains_Shown;
            ((System.ComponentModel.ISupportInitialize)nudSecondsToShow).EndInit();
            gbAddGrid.ResumeLayout(false);
            gbAddGrid.PerformLayout();
            gbSequences.ResumeLayout(false);
            cmsGridsContextMenu.ResumeLayout(false);
            gbSequenceName.ResumeLayout(false);
            gbSequenceName.PerformLayout();
            gbSequenceStructure.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.TextBox tbSequenceName;
        private System.Windows.Forms.ComboBox cbGridIdentifier;
        private System.Windows.Forms.NumericUpDown nudSecondsToShow;
        private System.Windows.Forms.Label lblSecondsToShow;
        private System.Windows.Forms.Button btnAddGridToSequence;
        private System.Windows.Forms.ComboBox cbGrids;
        private System.Windows.Forms.Label lblGridName;
        private System.Windows.Forms.GroupBox gbAddGrid;
        private System.Windows.Forms.Button btnDeleteSequence;
        private System.Windows.Forms.ComboBox cbSequences;
        private System.Windows.Forms.GroupBox gbSequences;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteGrid;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoveDown;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoveUp;
        private System.Windows.Forms.ContextMenuStrip cmsGridsContextMenu;
        private System.Windows.Forms.ColumnHeader chGridName;
        private System.Windows.Forms.ColumnHeader chSecondsToShow;
        private System.Windows.Forms.ColumnHeader chNumber;
        private System.Windows.Forms.Button btnRemoveGridFromSequence;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnSaveSequence;
        private Mtf.Controls.MtfListView lvGrids;
        private System.Windows.Forms.GroupBox gbSequenceName;
        private System.Windows.Forms.GroupBox gbSequenceStructure;
    }
}
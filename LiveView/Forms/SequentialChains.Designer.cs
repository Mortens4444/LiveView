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
            cbGridIdentifier = new System.Windows.Forms.ComboBox();
            nudSecondsToShow = new System.Windows.Forms.NumericUpDown();
            lblSecondsToShow = new System.Windows.Forms.Label();
            btnAddGrid = new System.Windows.Forms.Button();
            cbGridName = new System.Windows.Forms.ComboBox();
            lblGridName = new System.Windows.Forms.Label();
            gbAddGrid = new System.Windows.Forms.GroupBox();
            btnDeleteSequence = new System.Windows.Forms.Button();
            cbSequenceName = new System.Windows.Forms.ComboBox();
            gbSequences = new System.Windows.Forms.GroupBox();
            tsmiDeleteGrid = new System.Windows.Forms.ToolStripMenuItem();
            tsmiMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            tsmiMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            cmsGridsContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            chGridName = new System.Windows.Forms.ColumnHeader();
            chSecondsToShow = new System.Windows.Forms.ColumnHeader();
            chNumber = new System.Windows.Forms.ColumnHeader();
            btnDeleteGrid = new System.Windows.Forms.Button();
            btnMoveDown = new System.Windows.Forms.Button();
            btnMoveUp = new System.Windows.Forms.Button();
            btnAddOrUpdateSequence = new System.Windows.Forms.Button();
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
            // cbGridIdentifier
            // 
            cbGridIdentifier.FormattingEnabled = true;
            cbGridIdentifier.Location = new System.Drawing.Point(164, 9);
            cbGridIdentifier.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbGridIdentifier.Name = "cbGridIdentifier";
            cbGridIdentifier.Size = new System.Drawing.Size(88, 23);
            cbGridIdentifier.TabIndex = 5;
            cbGridIdentifier.Visible = false;
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
            // btnAddGrid
            // 
            btnAddGrid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAddGrid.Location = new System.Drawing.Point(397, 35);
            btnAddGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAddGrid.Name = "btnAddGrid";
            btnAddGrid.Size = new System.Drawing.Size(88, 27);
            btnAddGrid.TabIndex = 4;
            btnAddGrid.Text = "Add";
            btnAddGrid.UseVisualStyleBackColor = true;
            btnAddGrid.Click += BtnAddGrid_Click;
            // 
            // cbGridName
            // 
            cbGridName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbGridName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbGridName.FormattingEnabled = true;
            cbGridName.Location = new System.Drawing.Point(7, 37);
            cbGridName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbGridName.Name = "cbGridName";
            cbGridName.Size = new System.Drawing.Size(245, 23);
            cbGridName.TabIndex = 1;
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
            gbAddGrid.Controls.Add(cbGridIdentifier);
            gbAddGrid.Controls.Add(nudSecondsToShow);
            gbAddGrid.Controls.Add(lblSecondsToShow);
            gbAddGrid.Controls.Add(btnAddGrid);
            gbAddGrid.Controls.Add(cbGridName);
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
            // cbSequenceName
            // 
            cbSequenceName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbSequenceName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbSequenceName.FormattingEnabled = true;
            cbSequenceName.Location = new System.Drawing.Point(7, 22);
            cbSequenceName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbSequenceName.Name = "cbSequenceName";
            cbSequenceName.Size = new System.Drawing.Size(374, 23);
            cbSequenceName.TabIndex = 0;
            // 
            // gbSequences
            // 
            gbSequences.Controls.Add(btnDeleteSequence);
            gbSequences.Controls.Add(cbSequenceName);
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
            // btnDeleteGrid
            // 
            btnDeleteGrid.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnDeleteGrid.Location = new System.Drawing.Point(192, 181);
            btnDeleteGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnDeleteGrid.Name = "btnDeleteGrid";
            btnDeleteGrid.Size = new System.Drawing.Size(88, 27);
            btnDeleteGrid.TabIndex = 3;
            btnDeleteGrid.Text = "Delete";
            btnDeleteGrid.UseVisualStyleBackColor = true;
            btnDeleteGrid.Click += BtnDeleteGrid_Click;
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
            // btnAddOrUpdateSequence
            // 
            btnAddOrUpdateSequence.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnAddOrUpdateSequence.Location = new System.Drawing.Point(397, 181);
            btnAddOrUpdateSequence.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAddOrUpdateSequence.Name = "btnAddOrUpdateSequence";
            btnAddOrUpdateSequence.Size = new System.Drawing.Size(88, 27);
            btnAddOrUpdateSequence.TabIndex = 4;
            btnAddOrUpdateSequence.Text = "Save";
            btnAddOrUpdateSequence.UseVisualStyleBackColor = true;
            btnAddOrUpdateSequence.Click += BtnAddOrUpdateSequence_Click;
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
            gbSequenceStructure.Controls.Add(btnDeleteGrid);
            gbSequenceStructure.Controls.Add(btnMoveDown);
            gbSequenceStructure.Controls.Add(btnMoveUp);
            gbSequenceStructure.Controls.Add(btnAddOrUpdateSequence);
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
        private System.Windows.Forms.Button btnAddGrid;
        private System.Windows.Forms.ComboBox cbGridName;
        private System.Windows.Forms.Label lblGridName;
        private System.Windows.Forms.GroupBox gbAddGrid;
        private System.Windows.Forms.Button btnDeleteSequence;
        private System.Windows.Forms.ComboBox cbSequenceName;
        private System.Windows.Forms.GroupBox gbSequences;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteGrid;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoveDown;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoveUp;
        private System.Windows.Forms.ContextMenuStrip cmsGridsContextMenu;
        private System.Windows.Forms.ColumnHeader chGridName;
        private System.Windows.Forms.ColumnHeader chSecondsToShow;
        private System.Windows.Forms.ColumnHeader chNumber;
        private System.Windows.Forms.Button btnDeleteGrid;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnAddOrUpdateSequence;
        private Mtf.Controls.MtfListView lvGrids;
        private System.Windows.Forms.GroupBox gbSequenceName;
        private System.Windows.Forms.GroupBox gbSequenceStructure;
    }
}
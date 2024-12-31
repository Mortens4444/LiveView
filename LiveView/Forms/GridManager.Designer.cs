namespace LiveView.Forms
{
    partial class GridManager
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(GridManager));
            pMain = new System.Windows.Forms.Panel();
            tbGridName = new System.Windows.Forms.TextBox();
            btnNewGrid = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            cbGrids = new System.Windows.Forms.ComboBox();
            tsmiChangeCameraTo = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            tsmiDeleteGridFromChain = new System.Windows.Forms.ToolStripMenuItem();
            tsmiMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            tsmiMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            chGuid = new System.Windows.Forms.ColumnHeader();
            chVideoServerName = new System.Windows.Forms.ColumnHeader();
            chCameraName = new System.Windows.Forms.ColumnHeader();
            chNumber = new System.Windows.Forms.ColumnHeader();
            btnMoveDown = new System.Windows.Forms.Button();
            btnMoveUp = new System.Windows.Forms.Button();
            btnModify = new System.Windows.Forms.Button();
            lvGridCameras = new Mtf.Controls.MtfListView();
            gbGridStructure = new System.Windows.Forms.GroupBox();
            gbGridName = new System.Windows.Forms.GroupBox();
            gbGridSelector = new System.Windows.Forms.GroupBox();
            contextMenuStrip.SuspendLayout();
            gbGridStructure.SuspendLayout();
            gbGridName.SuspendLayout();
            gbGridSelector.SuspendLayout();
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
            // tbGridName
            // 
            tbGridName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbGridName.Location = new System.Drawing.Point(7, 22);
            tbGridName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbGridName.MaxLength = 50;
            tbGridName.Name = "tbGridName";
            tbGridName.Size = new System.Drawing.Size(476, 23);
            tbGridName.TabIndex = 0;
            // 
            // btnNewGrid
            // 
            btnNewGrid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnNewGrid.Location = new System.Drawing.Point(397, 20);
            btnNewGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnNewGrid.Name = "btnNewGrid";
            btnNewGrid.Size = new System.Drawing.Size(88, 27);
            btnNewGrid.TabIndex = 4;
            btnNewGrid.Text = "New grid";
            btnNewGrid.UseVisualStyleBackColor = true;
            btnNewGrid.Click += BtnNewGrid_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnDelete.Location = new System.Drawing.Point(302, 20);
            btnDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(88, 27);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += BtnDelete_Click;
            // 
            // cbGrids
            // 
            cbGrids.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbGrids.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbGrids.FormattingEnabled = true;
            cbGrids.Location = new System.Drawing.Point(7, 22);
            cbGrids.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbGrids.Name = "cbGrids";
            cbGrids.Size = new System.Drawing.Size(288, 23);
            cbGrids.TabIndex = 0;
            cbGrids.SelectedIndexChanged += CbGrids_SelectedIndexChanged;
            // 
            // tsmiChangeCameraTo
            // 
            tsmiChangeCameraTo.Name = "tsmiChangeCameraTo";
            tsmiChangeCameraTo.Size = new System.Drawing.Size(192, 22);
            tsmiChangeCameraTo.Text = "Change camera to ...";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(189, 6);
            toolStripSeparator1.Visible = false;
            // 
            // tsmiDeleteGridFromChain
            // 
            tsmiDeleteGridFromChain.Name = "tsmiDeleteGridFromChain";
            tsmiDeleteGridFromChain.Size = new System.Drawing.Size(192, 22);
            tsmiDeleteGridFromChain.Text = "Delete grid from chain";
            tsmiDeleteGridFromChain.Visible = false;
            // 
            // tsmiMoveDown
            // 
            tsmiMoveDown.Name = "tsmiMoveDown";
            tsmiMoveDown.Size = new System.Drawing.Size(192, 22);
            tsmiMoveDown.Text = "Move down";
            tsmiMoveDown.Visible = false;
            // 
            // tsmiMoveUp
            // 
            tsmiMoveUp.Name = "tsmiMoveUp";
            tsmiMoveUp.Size = new System.Drawing.Size(192, 22);
            tsmiMoveUp.Text = "Move up";
            tsmiMoveUp.Visible = false;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiMoveUp, tsmiMoveDown, tsmiDeleteGridFromChain, toolStripSeparator1, tsmiChangeCameraTo });
            contextMenuStrip.Name = "contextMenuStrip1";
            contextMenuStrip.Size = new System.Drawing.Size(193, 98);
            // 
            // chGuid
            // 
            chGuid.Text = "GUID";
            chGuid.Width = 229;
            // 
            // chVideoServerName
            // 
            chVideoServerName.Text = "Video server name";
            chVideoServerName.Width = 131;
            // 
            // chCameraName
            // 
            chCameraName.Text = "Camera name";
            chCameraName.Width = 103;
            // 
            // chNumber
            // 
            chNumber.Text = "Number";
            // 
            // btnMoveDown
            // 
            btnMoveDown.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnMoveDown.Enabled = false;
            btnMoveDown.Location = new System.Drawing.Point(98, 253);
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
            btnMoveUp.Enabled = false;
            btnMoveUp.Location = new System.Drawing.Point(4, 253);
            btnMoveUp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnMoveUp.Name = "btnMoveUp";
            btnMoveUp.Size = new System.Drawing.Size(88, 27);
            btnMoveUp.TabIndex = 1;
            btnMoveUp.Text = "Move up";
            btnMoveUp.UseVisualStyleBackColor = true;
            btnMoveUp.Click += BtnMoveUp_Click;
            // 
            // btnModify
            // 
            btnModify.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnModify.Location = new System.Drawing.Point(397, 253);
            btnModify.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnModify.Name = "btnModify";
            btnModify.Size = new System.Drawing.Size(88, 27);
            btnModify.TabIndex = 4;
            btnModify.Text = "Modify";
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += BtnModify_Click;
            // 
            // lvGridCameras
            // 
            lvGridCameras.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lvGridCameras.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lvGridCameras.AlternatingColorsAreInUse = true;
            lvGridCameras.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lvGridCameras.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lvGridCameras.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lvGridCameras.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { chNumber, chCameraName, chVideoServerName, chGuid });
            lvGridCameras.CompactView = false;
            lvGridCameras.ContextMenuStrip = contextMenuStrip;
            lvGridCameras.EnsureLastItemIsVisible = false;
            lvGridCameras.FirstItemIsGray = false;
            lvGridCameras.FullRowSelect = true;
            lvGridCameras.Location = new System.Drawing.Point(2, 23);
            lvGridCameras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lvGridCameras.Name = "lvGridCameras";
            lvGridCameras.OwnerDraw = true;
            lvGridCameras.ReadonlyCheckboxes = false;
            lvGridCameras.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lvGridCameras.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lvGridCameras.Size = new System.Drawing.Size(483, 226);
            lvGridCameras.TabIndex = 0;
            lvGridCameras.UseCompatibleStateImageBehavior = false;
            lvGridCameras.View = System.Windows.Forms.View.Details;
            // 
            // gbGridStructure
            // 
            gbGridStructure.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gbGridStructure.Controls.Add(btnMoveDown);
            gbGridStructure.Controls.Add(btnMoveUp);
            gbGridStructure.Controls.Add(btnModify);
            gbGridStructure.Controls.Add(lvGridCameras);
            gbGridStructure.Location = new System.Drawing.Point(0, 105);
            gbGridStructure.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbGridStructure.Name = "gbGridStructure";
            gbGridStructure.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbGridStructure.Size = new System.Drawing.Size(491, 286);
            gbGridStructure.TabIndex = 10;
            gbGridStructure.TabStop = false;
            gbGridStructure.Text = "Grid structure";
            // 
            // gbGridName
            // 
            gbGridName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gbGridName.Controls.Add(tbGridName);
            gbGridName.Location = new System.Drawing.Point(0, 53);
            gbGridName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbGridName.Name = "gbGridName";
            gbGridName.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbGridName.Size = new System.Drawing.Size(491, 52);
            gbGridName.TabIndex = 9;
            gbGridName.TabStop = false;
            gbGridName.Text = "Name of the grid";
            // 
            // gbGridSelector
            // 
            gbGridSelector.Controls.Add(btnNewGrid);
            gbGridSelector.Controls.Add(btnDelete);
            gbGridSelector.Controls.Add(cbGrids);
            gbGridSelector.Dock = System.Windows.Forms.DockStyle.Top;
            gbGridSelector.Location = new System.Drawing.Point(0, 0);
            gbGridSelector.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbGridSelector.Name = "gbGridSelector";
            gbGridSelector.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbGridSelector.Size = new System.Drawing.Size(491, 53);
            gbGridSelector.TabIndex = 8;
            gbGridSelector.TabStop = false;
            gbGridSelector.Text = "Grid name";
            // 
            // GridManager
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(491, 391);
            Controls.Add(gbGridStructure);
            Controls.Add(gbGridName);
            Controls.Add(gbGridSelector);
            Controls.Add(pMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "GridManager";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Grid manager";
            Shown += GridManager_Shown;
            contextMenuStrip.ResumeLayout(false);
            gbGridStructure.ResumeLayout(false);
            gbGridName.ResumeLayout(false);
            gbGridName.PerformLayout();
            gbGridSelector.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.TextBox tbGridName;
        private System.Windows.Forms.Button btnNewGrid;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cbGrids;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeCameraTo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteGridFromChain;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoveDown;
        private System.Windows.Forms.ToolStripMenuItem tsmiMoveUp;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ColumnHeader chGuid;
        private System.Windows.Forms.ColumnHeader chVideoServerName;
        private System.Windows.Forms.ColumnHeader chCameraName;
        private System.Windows.Forms.ColumnHeader chNumber;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnModify;
        private Mtf.Controls.MtfListView lvGridCameras;
        private System.Windows.Forms.GroupBox gbGridStructure;
        private System.Windows.Forms.GroupBox gbGridName;
        private System.Windows.Forms.GroupBox gbGridSelector;
    }
}
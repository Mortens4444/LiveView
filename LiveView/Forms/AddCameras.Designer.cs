namespace LiveView.Forms
{
    partial class AddCameras
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCameras));
            ttHint = new System.Windows.Forms.ToolTip(components);
            lblCamerasOfServer = new System.Windows.Forms.Label();
            cbServers = new System.Windows.Forms.ComboBox();
            lvCamerasToView = new Mtf.Controls.MtfListView();
            ilImages = new System.Windows.Forms.ImageList(components);
            lblCamerasToView = new System.Windows.Forms.Label();
            lvCamerasOfServer = new Mtf.Controls.MtfListView();
            btnAddAll = new System.Windows.Forms.Button();
            btnRemoveAll = new System.Windows.Forms.Button();
            btnAddSelected = new System.Windows.Forms.Button();
            pHeader = new System.Windows.Forms.Panel();
            axVideoServer = new AxVIDEOCONTROL4Lib.AxVideoServer();
            lblHost = new System.Windows.Forms.Label();
            btnAddCameras = new System.Windows.Forms.Button();
            btnRemoveSelected = new System.Windows.Forms.Button();
            pFooter = new System.Windows.Forms.Panel();
            btnClose = new System.Windows.Forms.Button();
            pCameras = new System.Windows.Forms.Panel();
            pMain = new System.Windows.Forms.Panel();
            gbMain = new System.Windows.Forms.GroupBox();
            pHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)axVideoServer).BeginInit();
            pFooter.SuspendLayout();
            pCameras.SuspendLayout();
            pMain.SuspendLayout();
            gbMain.SuspendLayout();
            SuspendLayout();
            // 
            // lblCamerasOfServer
            // 
            lblCamerasOfServer.AutoSize = true;
            lblCamerasOfServer.Location = new System.Drawing.Point(2, 52);
            lblCamerasOfServer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCamerasOfServer.Name = "lblCamerasOfServer";
            lblCamerasOfServer.Size = new System.Drawing.Size(86, 15);
            lblCamerasOfServer.TabIndex = 2;
            lblCamerasOfServer.Text = "Server cameras";
            // 
            // cbServers
            // 
            cbServers.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbServers.FormattingEnabled = true;
            cbServers.Location = new System.Drawing.Point(1, 24);
            cbServers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbServers.Name = "cbServers";
            cbServers.Size = new System.Drawing.Size(423, 23);
            cbServers.TabIndex = 1;
            cbServers.SelectedIndexChanged += CbServers_SelectedIndexChanged;
            // 
            // lvCamerasToView
            // 
            lvCamerasToView.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lvCamerasToView.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lvCamerasToView.AlternatingColorsAreInUse = true;
            lvCamerasToView.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lvCamerasToView.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lvCamerasToView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            lvCamerasToView.CompactView = false;
            lvCamerasToView.EnsureLastItemIsVisible = false;
            lvCamerasToView.FirstItemIsGray = false;
            lvCamerasToView.FullRowSelect = true;
            lvCamerasToView.Location = new System.Drawing.Point(235, 0);
            lvCamerasToView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lvCamerasToView.MinimumSize = new System.Drawing.Size(191, 316);
            lvCamerasToView.Name = "lvCamerasToView";
            lvCamerasToView.OwnerDraw = true;
            lvCamerasToView.ReadonlyCheckboxes = false;
            lvCamerasToView.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lvCamerasToView.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lvCamerasToView.ShowItemToolTips = true;
            lvCamerasToView.Size = new System.Drawing.Size(191, 389);
            lvCamerasToView.SmallImageList = ilImages;
            lvCamerasToView.TabIndex = 1;
            lvCamerasToView.UseCompatibleStateImageBehavior = false;
            lvCamerasToView.View = System.Windows.Forms.View.List;
            // 
            // ilImages
            // 
            ilImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            ilImages.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ilImages.ImageStream");
            ilImages.TransparentColor = System.Drawing.Color.Transparent;
            ilImages.Images.SetKeyName(0, "cam 0.ico");
            // 
            // lblCamerasToView
            // 
            lblCamerasToView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblCamerasToView.AutoSize = true;
            lblCamerasToView.Location = new System.Drawing.Point(240, 52);
            lblCamerasToView.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCamerasToView.Name = "lblCamerasToView";
            lblCamerasToView.Size = new System.Drawing.Size(94, 15);
            lblCamerasToView.TabIndex = 3;
            lblCamerasToView.Text = "Cameras to view";
            // 
            // lvCamerasOfServer
            // 
            lvCamerasOfServer.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lvCamerasOfServer.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lvCamerasOfServer.AlternatingColorsAreInUse = true;
            lvCamerasOfServer.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lvCamerasOfServer.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lvCamerasOfServer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lvCamerasOfServer.CompactView = false;
            lvCamerasOfServer.EnsureLastItemIsVisible = false;
            lvCamerasOfServer.FirstItemIsGray = false;
            lvCamerasOfServer.FullRowSelect = true;
            lvCamerasOfServer.Location = new System.Drawing.Point(1, 0);
            lvCamerasOfServer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lvCamerasOfServer.MinimumSize = new System.Drawing.Size(191, 316);
            lvCamerasOfServer.Name = "lvCamerasOfServer";
            lvCamerasOfServer.OwnerDraw = true;
            lvCamerasOfServer.ReadonlyCheckboxes = false;
            lvCamerasOfServer.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lvCamerasOfServer.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lvCamerasOfServer.ShowItemToolTips = true;
            lvCamerasOfServer.Size = new System.Drawing.Size(191, 389);
            lvCamerasOfServer.SmallImageList = ilImages;
            lvCamerasOfServer.TabIndex = 0;
            lvCamerasOfServer.UseCompatibleStateImageBehavior = false;
            lvCamerasOfServer.View = System.Windows.Forms.View.List;
            // 
            // btnAddAll
            // 
            btnAddAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btnAddAll.Image = Properties.Resources.summa_add;
            btnAddAll.Location = new System.Drawing.Point(198, 106);
            btnAddAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAddAll.Name = "btnAddAll";
            btnAddAll.Size = new System.Drawing.Size(33, 27);
            btnAddAll.TabIndex = 3;
            btnAddAll.UseVisualStyleBackColor = true;
            btnAddAll.Click += BtnAddAll_Click;
            // 
            // btnRemoveAll
            // 
            btnRemoveAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btnRemoveAll.Image = Properties.Resources.summa_del;
            btnRemoveAll.Location = new System.Drawing.Point(198, 173);
            btnRemoveAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnRemoveAll.Name = "btnRemoveAll";
            btnRemoveAll.Size = new System.Drawing.Size(33, 27);
            btnRemoveAll.TabIndex = 5;
            btnRemoveAll.UseVisualStyleBackColor = true;
            btnRemoveAll.Click += BtnRemoveAll_Click;
            // 
            // btnAddSelected
            // 
            btnAddSelected.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btnAddSelected.Image = Properties.Resources.add;
            btnAddSelected.Location = new System.Drawing.Point(198, 73);
            btnAddSelected.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAddSelected.Name = "btnAddSelected";
            btnAddSelected.Size = new System.Drawing.Size(33, 27);
            btnAddSelected.TabIndex = 2;
            btnAddSelected.UseVisualStyleBackColor = true;
            btnAddSelected.Click += BtnAddSelected_Click;
            // 
            // pHeader
            // 
            pHeader.Controls.Add(axVideoServer);
            pHeader.Controls.Add(lblCamerasToView);
            pHeader.Controls.Add(lblCamerasOfServer);
            pHeader.Controls.Add(cbServers);
            pHeader.Controls.Add(lblHost);
            pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pHeader.Location = new System.Drawing.Point(4, 19);
            pHeader.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pHeader.Name = "pHeader";
            pHeader.Size = new System.Drawing.Size(428, 70);
            pHeader.TabIndex = 0;
            // 
            // axVideoServer
            // 
            axVideoServer.Enabled = true;
            axVideoServer.Location = new System.Drawing.Point(335, 3);
            axVideoServer.Name = "axVideoServer";
            axVideoServer.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("axVideoServer.OcxState");
            axVideoServer.Size = new System.Drawing.Size(62, 44);
            axVideoServer.TabIndex = 4;
            axVideoServer.Visible = false;
            // 
            // lblHost
            // 
            lblHost.AutoSize = true;
            lblHost.Location = new System.Drawing.Point(2, 5);
            lblHost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblHost.Name = "lblHost";
            lblHost.Size = new System.Drawing.Size(142, 15);
            lblHost.TabIndex = 0;
            lblHost.Text = "Server name or IP address";
            // 
            // btnAddCameras
            // 
            btnAddCameras.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAddCameras.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnAddCameras.Enabled = false;
            btnAddCameras.Location = new System.Drawing.Point(240, 5);
            btnAddCameras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAddCameras.Name = "btnAddCameras";
            btnAddCameras.Size = new System.Drawing.Size(88, 27);
            btnAddCameras.TabIndex = 0;
            btnAddCameras.Text = "Add";
            btnAddCameras.UseVisualStyleBackColor = true;
            btnAddCameras.Click += BtnAddCameras_Click;
            // 
            // btnRemoveSelected
            // 
            btnRemoveSelected.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btnRemoveSelected.Image = Properties.Resources.del;
            btnRemoveSelected.Location = new System.Drawing.Point(198, 140);
            btnRemoveSelected.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnRemoveSelected.Name = "btnRemoveSelected";
            btnRemoveSelected.Size = new System.Drawing.Size(33, 27);
            btnRemoveSelected.TabIndex = 4;
            btnRemoveSelected.UseVisualStyleBackColor = true;
            btnRemoveSelected.Click += BtnRemoveSelected_Click;
            // 
            // pFooter
            // 
            pFooter.Controls.Add(btnClose);
            pFooter.Controls.Add(btnAddCameras);
            pFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            pFooter.Location = new System.Drawing.Point(0, 391);
            pFooter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pFooter.Name = "pFooter";
            pFooter.Size = new System.Drawing.Size(428, 36);
            pFooter.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.Location = new System.Drawing.Point(335, 5);
            btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(88, 27);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            // 
            // pCameras
            // 
            pCameras.Controls.Add(lvCamerasToView);
            pCameras.Controls.Add(lvCamerasOfServer);
            pCameras.Controls.Add(btnAddAll);
            pCameras.Controls.Add(btnRemoveAll);
            pCameras.Controls.Add(btnAddSelected);
            pCameras.Controls.Add(btnRemoveSelected);
            pCameras.Dock = System.Windows.Forms.DockStyle.Fill;
            pCameras.Location = new System.Drawing.Point(0, 0);
            pCameras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pCameras.Name = "pCameras";
            pCameras.Size = new System.Drawing.Size(428, 391);
            pCameras.TabIndex = 0;
            // 
            // pMain
            // 
            pMain.Controls.Add(pCameras);
            pMain.Controls.Add(pFooter);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(4, 89);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(428, 427);
            pMain.TabIndex = 0;
            // 
            // gbMain
            // 
            gbMain.Controls.Add(pMain);
            gbMain.Controls.Add(pHeader);
            gbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            gbMain.Location = new System.Drawing.Point(0, 0);
            gbMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbMain.Name = "gbMain";
            gbMain.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbMain.Size = new System.Drawing.Size(436, 519);
            gbMain.TabIndex = 1;
            gbMain.TabStop = false;
            // 
            // AddCameras
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(436, 519);
            Controls.Add(gbMain);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "AddCameras";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "New camera";
            Shown += AddCameras_Shown;
            pHeader.ResumeLayout(false);
            pHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)axVideoServer).EndInit();
            pFooter.ResumeLayout(false);
            pCameras.ResumeLayout(false);
            pMain.ResumeLayout(false);
            gbMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ToolTip ttHint;
        private System.Windows.Forms.Label lblCamerasOfServer;
        private System.Windows.Forms.ComboBox cbServers;
        private Mtf.Controls.MtfListView lvCamerasToView;
        private System.Windows.Forms.ImageList ilImages;
        private System.Windows.Forms.Label lblCamerasToView;
        private Mtf.Controls.MtfListView lvCamerasOfServer;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnAddSelected;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Button btnAddCameras;
        private System.Windows.Forms.Button btnRemoveSelected;
        private System.Windows.Forms.Panel pFooter;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pCameras;
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.GroupBox gbMain;
        private AxVIDEOCONTROL4Lib.AxVideoServer axVideoServer;
    }
}
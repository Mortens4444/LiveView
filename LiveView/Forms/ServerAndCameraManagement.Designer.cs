namespace LiveView.Forms
{
    partial class ServerAndCameraManagement
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerAndCameraManagement));
            var treeNode1 = new System.Windows.Forms.TreeNode("Servers", 0, 0);
            var treeNode2 = new System.Windows.Forms.TreeNode("DB servers", 7, 7);
            ttHint = new System.Windows.Forms.ToolTip(components);
            ilImages = new System.Windows.Forms.ImageList(components);
            btnMotionDetection = new System.Windows.Forms.Button();
            btnNewDbServer = new System.Windows.Forms.Button();
            lblHorizontalLine = new System.Windows.Forms.Label();
            rbCameraName = new System.Windows.Forms.RadioButton();
            lblSyncronizeBy = new System.Windows.Forms.Label();
            rbRecorderIndex = new System.Windows.Forms.RadioButton();
            btnClose = new System.Windows.Forms.Button();
            btnProperties = new System.Windows.Forms.Button();
            rbGuid = new System.Windows.Forms.RadioButton();
            btnSyncronize = new System.Windows.Forms.Button();
            tvServersAndCameras = new Mtf.Controls.MtfTreeView();
            btnNewVideoServer = new System.Windows.Forms.Button();
            btnModify = new System.Windows.Forms.Button();
            btnRemove = new System.Windows.Forms.Button();
            btnNewCamera = new System.Windows.Forms.Button();
            gbRegisteredServersAndCameras = new System.Windows.Forms.GroupBox();
            pMain = new System.Windows.Forms.Panel();
            gbRegisteredServersAndCameras.SuspendLayout();
            pMain.SuspendLayout();
            SuspendLayout();
            // 
            // ilImages
            // 
            ilImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            ilImages.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ilImages.ImageStream");
            ilImages.TransparentColor = System.Drawing.Color.Transparent;
            ilImages.Images.SetKeyName(0, "videoservers.ico");
            ilImages.Images.SetKeyName(1, "videoserver.ico");
            ilImages.Images.SetKeyName(2, "cam 0.ico");
            ilImages.Images.SetKeyName(3, "videoserver_mod.ico");
            ilImages.Images.SetKeyName(4, "cammod.ico");
            ilImages.Images.SetKeyName(5, "videoserver_del.ico");
            ilImages.Images.SetKeyName(6, "camdel.ico");
            ilImages.Images.SetKeyName(7, "db_server.ico");
            // 
            // btnMotionDetection
            // 
            btnMotionDetection.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnMotionDetection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnMotionDetection.Location = new System.Drawing.Point(495, 220);
            btnMotionDetection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnMotionDetection.Name = "btnMotionDetection";
            btnMotionDetection.Size = new System.Drawing.Size(179, 27);
            btnMotionDetection.TabIndex = 10;
            btnMotionDetection.Text = "Motion detection";
            btnMotionDetection.UseVisualStyleBackColor = true;
            btnMotionDetection.Click += BtnMotionDetection_Click;
            // 
            // btnNewDbServer
            // 
            btnNewDbServer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnNewDbServer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnNewDbServer.Location = new System.Drawing.Point(495, 53);
            btnNewDbServer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnNewDbServer.Name = "btnNewDbServer";
            btnNewDbServer.Size = new System.Drawing.Size(179, 27);
            btnNewDbServer.TabIndex = 9;
            btnNewDbServer.Text = "New DB server";
            btnNewDbServer.UseVisualStyleBackColor = true;
            btnNewDbServer.Click += BtnNewDBServer_Click;
            // 
            // lblHorizontalLine
            // 
            lblHorizontalLine.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            lblHorizontalLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lblHorizontalLine.Location = new System.Drawing.Point(500, 353);
            lblHorizontalLine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblHorizontalLine.Name = "lblHorizontalLine";
            lblHorizontalLine.Size = new System.Drawing.Size(168, 1);
            lblHorizontalLine.TabIndex = 8;
            // 
            // rbCameraName
            // 
            rbCameraName.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            rbCameraName.Location = new System.Drawing.Point(500, 408);
            rbCameraName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rbCameraName.Name = "rbCameraName";
            rbCameraName.Size = new System.Drawing.Size(170, 19);
            rbCameraName.TabIndex = 3;
            rbCameraName.Text = "Camera name";
            rbCameraName.UseVisualStyleBackColor = true;
            // 
            // lblSyncronizeBy
            // 
            lblSyncronizeBy.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            lblSyncronizeBy.AutoSize = true;
            lblSyncronizeBy.Location = new System.Drawing.Point(495, 328);
            lblSyncronizeBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSyncronizeBy.Name = "lblSyncronizeBy";
            lblSyncronizeBy.Size = new System.Drawing.Size(80, 15);
            lblSyncronizeBy.TabIndex = 7;
            lblSyncronizeBy.Text = "Syncronize by";
            // 
            // rbRecorderIndex
            // 
            rbRecorderIndex.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            rbRecorderIndex.Location = new System.Drawing.Point(500, 383);
            rbRecorderIndex.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rbRecorderIndex.Name = "rbRecorderIndex";
            rbRecorderIndex.Size = new System.Drawing.Size(170, 19);
            rbRecorderIndex.TabIndex = 2;
            rbRecorderIndex.Text = "Recorder index";
            rbRecorderIndex.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.Location = new System.Drawing.Point(500, 485);
            btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(174, 27);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            // 
            // btnProperties
            // 
            btnProperties.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnProperties.Enabled = false;
            btnProperties.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnProperties.Location = new System.Drawing.Point(495, 187);
            btnProperties.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnProperties.Name = "btnProperties";
            btnProperties.Size = new System.Drawing.Size(179, 27);
            btnProperties.TabIndex = 6;
            btnProperties.Text = "Properties";
            btnProperties.UseVisualStyleBackColor = true;
            btnProperties.Click += BtnProperties_Click;
            // 
            // rbGuid
            // 
            rbGuid.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            rbGuid.Checked = true;
            rbGuid.Location = new System.Drawing.Point(500, 358);
            rbGuid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rbGuid.Name = "rbGuid";
            rbGuid.Size = new System.Drawing.Size(170, 19);
            rbGuid.TabIndex = 1;
            rbGuid.TabStop = true;
            rbGuid.Text = "GUID";
            rbGuid.UseVisualStyleBackColor = true;
            // 
            // btnSyncronize
            // 
            btnSyncronize.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSyncronize.Location = new System.Drawing.Point(500, 444);
            btnSyncronize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSyncronize.Name = "btnSyncronize";
            btnSyncronize.Size = new System.Drawing.Size(160, 27);
            btnSyncronize.TabIndex = 0;
            btnSyncronize.Text = "Syncronize";
            btnSyncronize.UseVisualStyleBackColor = true;
            btnSyncronize.Click += BtnSyncronize_Click;
            // 
            // tvServersAndCameras
            // 
            tvServersAndCameras.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tvServersAndCameras.CheckBoxBackground = System.Drawing.SystemColors.Window;
            tvServersAndCameras.DrawDefaultImageToNodes = true;
            tvServersAndCameras.FullRowSelect = true;
            tvServersAndCameras.HideSelection = false;
            tvServersAndCameras.ImageIndex = 0;
            tvServersAndCameras.ImageList = ilImages;
            tvServersAndCameras.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            tvServersAndCameras.Location = new System.Drawing.Point(7, 20);
            tvServersAndCameras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tvServersAndCameras.MultiSelect = false;
            tvServersAndCameras.Name = "tvServersAndCameras";
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "Servers";
            treeNode1.SelectedImageIndex = 0;
            treeNode1.Text = "Servers";
            treeNode2.ImageIndex = 7;
            treeNode2.Name = "DBServers";
            treeNode2.SelectedImageIndex = 7;
            treeNode2.Text = "DB servers";
            tvServersAndCameras.Nodes.AddRange(new System.Windows.Forms.TreeNode[] { treeNode1, treeNode2 });
            tvServersAndCameras.SelectedImageIndex = 0;
            tvServersAndCameras.ShowNodeToolTips = true;
            tvServersAndCameras.ShowPlusMinusOnRootNodes = true;
            tvServersAndCameras.ShowRootLines = false;
            tvServersAndCameras.Size = new System.Drawing.Size(480, 451);
            tvServersAndCameras.StateImageOrCheckBoxOnLeft = false;
            tvServersAndCameras.TabIndex = 0;
            tvServersAndCameras.TickColor = System.Drawing.Color.Green;
            tvServersAndCameras.AfterSelect += TvServersAndCameras_AfterSelect;
            // 
            // btnNewVideoServer
            // 
            btnNewVideoServer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnNewVideoServer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnNewVideoServer.Location = new System.Drawing.Point(495, 20);
            btnNewVideoServer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnNewVideoServer.Name = "btnNewVideoServer";
            btnNewVideoServer.Size = new System.Drawing.Size(179, 27);
            btnNewVideoServer.TabIndex = 1;
            btnNewVideoServer.Text = "New video server";
            btnNewVideoServer.UseVisualStyleBackColor = true;
            btnNewVideoServer.Click += BtnNewVideoServer_Click;
            // 
            // btnModify
            // 
            btnModify.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnModify.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnModify.Location = new System.Drawing.Point(495, 120);
            btnModify.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnModify.Name = "btnModify";
            btnModify.Size = new System.Drawing.Size(179, 27);
            btnModify.TabIndex = 3;
            btnModify.Text = "Modify";
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += BtnModify_Click;
            // 
            // btnRemove
            // 
            btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnRemove.Location = new System.Drawing.Point(495, 153);
            btnRemove.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new System.Drawing.Size(179, 27);
            btnRemove.TabIndex = 4;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += BtnRemove_Click;
            // 
            // btnNewCamera
            // 
            btnNewCamera.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnNewCamera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnNewCamera.Location = new System.Drawing.Point(495, 87);
            btnNewCamera.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnNewCamera.Name = "btnNewCamera";
            btnNewCamera.Size = new System.Drawing.Size(179, 27);
            btnNewCamera.TabIndex = 2;
            btnNewCamera.Text = "New camera";
            btnNewCamera.UseVisualStyleBackColor = true;
            btnNewCamera.Click += BtnNewCamera_Click;
            // 
            // gbRegisteredServersAndCameras
            // 
            gbRegisteredServersAndCameras.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gbRegisteredServersAndCameras.Controls.Add(btnMotionDetection);
            gbRegisteredServersAndCameras.Controls.Add(btnNewDbServer);
            gbRegisteredServersAndCameras.Controls.Add(lblHorizontalLine);
            gbRegisteredServersAndCameras.Controls.Add(rbCameraName);
            gbRegisteredServersAndCameras.Controls.Add(lblSyncronizeBy);
            gbRegisteredServersAndCameras.Controls.Add(rbRecorderIndex);
            gbRegisteredServersAndCameras.Controls.Add(btnProperties);
            gbRegisteredServersAndCameras.Controls.Add(rbGuid);
            gbRegisteredServersAndCameras.Controls.Add(btnSyncronize);
            gbRegisteredServersAndCameras.Controls.Add(tvServersAndCameras);
            gbRegisteredServersAndCameras.Controls.Add(btnNewVideoServer);
            gbRegisteredServersAndCameras.Controls.Add(btnModify);
            gbRegisteredServersAndCameras.Controls.Add(btnRemove);
            gbRegisteredServersAndCameras.Controls.Add(btnNewCamera);
            gbRegisteredServersAndCameras.Location = new System.Drawing.Point(0, 0);
            gbRegisteredServersAndCameras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbRegisteredServersAndCameras.Name = "gbRegisteredServersAndCameras";
            gbRegisteredServersAndCameras.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbRegisteredServersAndCameras.Size = new System.Drawing.Size(681, 479);
            gbRegisteredServersAndCameras.TabIndex = 0;
            gbRegisteredServersAndCameras.TabStop = false;
            gbRegisteredServersAndCameras.Text = "Registered servers and cameras";
            // 
            // pMain
            // 
            pMain.Controls.Add(btnClose);
            pMain.Controls.Add(gbRegisteredServersAndCameras);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(681, 515);
            pMain.TabIndex = 2;
            // 
            // ServerAndCameraManagement
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(681, 515);
            Controls.Add(pMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(541, 396);
            Name = "ServerAndCameraManagement";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Servers and cameras";
            Shown += ServerAndCameraManagement_Shown;
            gbRegisteredServersAndCameras.ResumeLayout(false);
            gbRegisteredServersAndCameras.PerformLayout();
            pMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ToolTip ttHint;
        private System.Windows.Forms.ImageList ilImages;
        private System.Windows.Forms.Button btnMotionDetection;
        private System.Windows.Forms.Button btnNewDbServer;
        private System.Windows.Forms.Label lblHorizontalLine;
        private System.Windows.Forms.RadioButton rbCameraName;
        private System.Windows.Forms.Label lblSyncronizeBy;
        private System.Windows.Forms.RadioButton rbRecorderIndex;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnProperties;
        private System.Windows.Forms.RadioButton rbGuid;
        private System.Windows.Forms.Button btnSyncronize;
        private Mtf.Controls.MtfTreeView tvServersAndCameras;
        private System.Windows.Forms.Button btnNewVideoServer;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnNewCamera;
        private System.Windows.Forms.GroupBox gbRegisteredServersAndCameras;
        private System.Windows.Forms.Panel pMain;
    }
}
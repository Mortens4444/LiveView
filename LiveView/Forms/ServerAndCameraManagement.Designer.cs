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
            tt_Hint = new System.Windows.Forms.ToolTip(components);
            il_Images = new System.Windows.Forms.ImageList(components);
            btn_MotionDetection = new System.Windows.Forms.Button();
            btn_NewDBServer = new System.Windows.Forms.Button();
            lbl_HorizontalLine = new System.Windows.Forms.Label();
            rb_CameraName = new System.Windows.Forms.RadioButton();
            lbl_SyncronizeBy = new System.Windows.Forms.Label();
            rb_RecorderIndex = new System.Windows.Forms.RadioButton();
            btn_Close = new System.Windows.Forms.Button();
            btn_Properties = new System.Windows.Forms.Button();
            rb_GUID = new System.Windows.Forms.RadioButton();
            btn_Syncronize = new System.Windows.Forms.Button();
            tv_ServersAndCameras = new Mtf.Controls.MtfTreeView();
            btn_NewVideoServer = new System.Windows.Forms.Button();
            btn_Modify = new System.Windows.Forms.Button();
            btn_Remove = new System.Windows.Forms.Button();
            btn_NewCamera = new System.Windows.Forms.Button();
            gb_RegisteredServersAndCameras = new System.Windows.Forms.GroupBox();
            p_Main = new System.Windows.Forms.Panel();
            gb_RegisteredServersAndCameras.SuspendLayout();
            p_Main.SuspendLayout();
            SuspendLayout();
            // 
            // il_Images
            // 
            il_Images.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            il_Images.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("il_Images.ImageStream");
            il_Images.TransparentColor = System.Drawing.Color.Transparent;
            il_Images.Images.SetKeyName(0, "videoservers.ico");
            il_Images.Images.SetKeyName(1, "videoserver.ico");
            il_Images.Images.SetKeyName(2, "cam 0.ico");
            il_Images.Images.SetKeyName(3, "videoserver_mod.ico");
            il_Images.Images.SetKeyName(4, "cammod.ico");
            il_Images.Images.SetKeyName(5, "videoserver_del.ico");
            il_Images.Images.SetKeyName(6, "camdel.ico");
            il_Images.Images.SetKeyName(7, "db_server.ico");
            // 
            // btn_MotionDetection
            // 
            btn_MotionDetection.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_MotionDetection.Image = (System.Drawing.Image)resources.GetObject("btn_MotionDetection.Image");
            btn_MotionDetection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn_MotionDetection.Location = new System.Drawing.Point(528, 220);
            btn_MotionDetection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_MotionDetection.Name = "btn_MotionDetection";
            btn_MotionDetection.Size = new System.Drawing.Size(146, 27);
            btn_MotionDetection.TabIndex = 10;
            btn_MotionDetection.Text = "Motion detection";
            btn_MotionDetection.UseVisualStyleBackColor = true;
            // 
            // btn_NewDBServer
            // 
            btn_NewDBServer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_NewDBServer.Image = (System.Drawing.Image)resources.GetObject("btn_NewDBServer.Image");
            btn_NewDBServer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn_NewDBServer.Location = new System.Drawing.Point(528, 53);
            btn_NewDBServer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_NewDBServer.Name = "btn_NewDBServer";
            btn_NewDBServer.Size = new System.Drawing.Size(146, 27);
            btn_NewDBServer.TabIndex = 9;
            btn_NewDBServer.Text = "New DB server";
            btn_NewDBServer.UseVisualStyleBackColor = true;
            // 
            // lbl_HorizontalLine
            // 
            lbl_HorizontalLine.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            lbl_HorizontalLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lbl_HorizontalLine.Location = new System.Drawing.Point(528, 353);
            lbl_HorizontalLine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_HorizontalLine.Name = "lbl_HorizontalLine";
            lbl_HorizontalLine.Size = new System.Drawing.Size(140, 2);
            lbl_HorizontalLine.TabIndex = 8;
            // 
            // rb_CameraName
            // 
            rb_CameraName.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            rb_CameraName.AutoSize = true;
            rb_CameraName.Location = new System.Drawing.Point(534, 418);
            rb_CameraName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rb_CameraName.Name = "rb_CameraName";
            rb_CameraName.Size = new System.Drawing.Size(99, 19);
            rb_CameraName.TabIndex = 3;
            rb_CameraName.Text = "Camera name";
            rb_CameraName.UseVisualStyleBackColor = true;
            // 
            // lbl_SyncronizeBy
            // 
            lbl_SyncronizeBy.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            lbl_SyncronizeBy.AutoSize = true;
            lbl_SyncronizeBy.Location = new System.Drawing.Point(525, 333);
            lbl_SyncronizeBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_SyncronizeBy.Name = "lbl_SyncronizeBy";
            lbl_SyncronizeBy.Size = new System.Drawing.Size(80, 15);
            lbl_SyncronizeBy.TabIndex = 7;
            lbl_SyncronizeBy.Text = "Syncronize by";
            // 
            // rb_RecorderIndex
            // 
            rb_RecorderIndex.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            rb_RecorderIndex.AutoSize = true;
            rb_RecorderIndex.Location = new System.Drawing.Point(539, 392);
            rb_RecorderIndex.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rb_RecorderIndex.Name = "rb_RecorderIndex";
            rb_RecorderIndex.Size = new System.Drawing.Size(103, 19);
            rb_RecorderIndex.TabIndex = 2;
            rb_RecorderIndex.Text = "Recorder index";
            rb_RecorderIndex.UseVisualStyleBackColor = true;
            // 
            // btn_Close
            // 
            btn_Close.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btn_Close.Location = new System.Drawing.Point(528, 485);
            btn_Close.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Close.Name = "btn_Close";
            btn_Close.Size = new System.Drawing.Size(146, 27);
            btn_Close.TabIndex = 1;
            btn_Close.Text = "Close";
            btn_Close.UseVisualStyleBackColor = true;
            // 
            // btn_Properties
            // 
            btn_Properties.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_Properties.Enabled = false;
            btn_Properties.Image = (System.Drawing.Image)resources.GetObject("btn_Properties.Image");
            btn_Properties.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn_Properties.Location = new System.Drawing.Point(528, 187);
            btn_Properties.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Properties.Name = "btn_Properties";
            btn_Properties.Size = new System.Drawing.Size(146, 27);
            btn_Properties.TabIndex = 6;
            btn_Properties.Text = "Properties";
            btn_Properties.UseVisualStyleBackColor = true;
            // 
            // rb_GUID
            // 
            rb_GUID.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            rb_GUID.AutoSize = true;
            rb_GUID.Checked = true;
            rb_GUID.Location = new System.Drawing.Point(537, 364);
            rb_GUID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rb_GUID.Name = "rb_GUID";
            rb_GUID.Size = new System.Drawing.Size(52, 19);
            rb_GUID.TabIndex = 1;
            rb_GUID.TabStop = true;
            rb_GUID.Text = "GUID";
            rb_GUID.UseVisualStyleBackColor = true;
            // 
            // btn_Syncronize
            // 
            btn_Syncronize.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_Syncronize.Location = new System.Drawing.Point(528, 444);
            btn_Syncronize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Syncronize.Name = "btn_Syncronize";
            btn_Syncronize.Size = new System.Drawing.Size(132, 27);
            btn_Syncronize.TabIndex = 0;
            btn_Syncronize.Text = "Syncronize";
            btn_Syncronize.UseVisualStyleBackColor = true;
            // 
            // tv_ServersAndCameras
            // 
            tv_ServersAndCameras.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tv_ServersAndCameras.CheckBoxBackground = System.Drawing.SystemColors.Window;
            tv_ServersAndCameras.DrawDefaultImageToNodes = true;
            tv_ServersAndCameras.FullRowSelect = true;
            tv_ServersAndCameras.HideSelection = false;
            tv_ServersAndCameras.ImageIndex = 0;
            tv_ServersAndCameras.ImageList = il_Images;
            tv_ServersAndCameras.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            tv_ServersAndCameras.Location = new System.Drawing.Point(7, 20);
            tv_ServersAndCameras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tv_ServersAndCameras.MultiSelect = false;
            tv_ServersAndCameras.Name = "tv_ServersAndCameras";
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "Servers";
            treeNode1.SelectedImageIndex = 0;
            treeNode1.Text = "Servers";
            treeNode2.ImageIndex = 7;
            treeNode2.Name = "DBServers";
            treeNode2.SelectedImageIndex = 7;
            treeNode2.Text = "DB servers";
            tv_ServersAndCameras.Nodes.AddRange(new System.Windows.Forms.TreeNode[] { treeNode1, treeNode2 });
            tv_ServersAndCameras.SelectedImageIndex = 0;
            tv_ServersAndCameras.ShowPlusMinusOnRootNodes = true;
            tv_ServersAndCameras.ShowRootLines = false;
            tv_ServersAndCameras.Size = new System.Drawing.Size(514, 451);
            tv_ServersAndCameras.StateImageOrCheckBoxOnLeft = false;
            tv_ServersAndCameras.TabIndex = 0;
            tv_ServersAndCameras.TickColor = System.Drawing.Color.Green;
            // 
            // btn_NewVideoServer
            // 
            btn_NewVideoServer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_NewVideoServer.Image = (System.Drawing.Image)resources.GetObject("btn_NewVideoServer.Image");
            btn_NewVideoServer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn_NewVideoServer.Location = new System.Drawing.Point(528, 20);
            btn_NewVideoServer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_NewVideoServer.Name = "btn_NewVideoServer";
            btn_NewVideoServer.Size = new System.Drawing.Size(146, 27);
            btn_NewVideoServer.TabIndex = 1;
            btn_NewVideoServer.Text = "New video server";
            btn_NewVideoServer.UseVisualStyleBackColor = true;
            // 
            // btn_Modify
            // 
            btn_Modify.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_Modify.Image = (System.Drawing.Image)resources.GetObject("btn_Modify.Image");
            btn_Modify.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn_Modify.Location = new System.Drawing.Point(528, 120);
            btn_Modify.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Modify.Name = "btn_Modify";
            btn_Modify.Size = new System.Drawing.Size(146, 27);
            btn_Modify.TabIndex = 3;
            btn_Modify.Text = "Modify";
            btn_Modify.UseVisualStyleBackColor = true;
            // 
            // btn_Remove
            // 
            btn_Remove.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_Remove.Image = (System.Drawing.Image)resources.GetObject("btn_Remove.Image");
            btn_Remove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn_Remove.Location = new System.Drawing.Point(528, 153);
            btn_Remove.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Remove.Name = "btn_Remove";
            btn_Remove.Size = new System.Drawing.Size(146, 27);
            btn_Remove.TabIndex = 4;
            btn_Remove.Text = "Remove";
            btn_Remove.UseVisualStyleBackColor = true;
            // 
            // btn_NewCamera
            // 
            btn_NewCamera.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_NewCamera.Image = (System.Drawing.Image)resources.GetObject("btn_NewCamera.Image");
            btn_NewCamera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn_NewCamera.Location = new System.Drawing.Point(528, 87);
            btn_NewCamera.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_NewCamera.Name = "btn_NewCamera";
            btn_NewCamera.Size = new System.Drawing.Size(146, 27);
            btn_NewCamera.TabIndex = 2;
            btn_NewCamera.Text = "New camera";
            btn_NewCamera.UseVisualStyleBackColor = true;
            btn_NewCamera.Click += Btn_NewCamera_Click;
            // 
            // gb_RegisteredServersAndCameras
            // 
            gb_RegisteredServersAndCameras.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gb_RegisteredServersAndCameras.Controls.Add(btn_MotionDetection);
            gb_RegisteredServersAndCameras.Controls.Add(btn_NewDBServer);
            gb_RegisteredServersAndCameras.Controls.Add(lbl_HorizontalLine);
            gb_RegisteredServersAndCameras.Controls.Add(rb_CameraName);
            gb_RegisteredServersAndCameras.Controls.Add(lbl_SyncronizeBy);
            gb_RegisteredServersAndCameras.Controls.Add(rb_RecorderIndex);
            gb_RegisteredServersAndCameras.Controls.Add(btn_Properties);
            gb_RegisteredServersAndCameras.Controls.Add(rb_GUID);
            gb_RegisteredServersAndCameras.Controls.Add(btn_Syncronize);
            gb_RegisteredServersAndCameras.Controls.Add(tv_ServersAndCameras);
            gb_RegisteredServersAndCameras.Controls.Add(btn_NewVideoServer);
            gb_RegisteredServersAndCameras.Controls.Add(btn_Modify);
            gb_RegisteredServersAndCameras.Controls.Add(btn_Remove);
            gb_RegisteredServersAndCameras.Controls.Add(btn_NewCamera);
            gb_RegisteredServersAndCameras.Location = new System.Drawing.Point(0, 0);
            gb_RegisteredServersAndCameras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_RegisteredServersAndCameras.Name = "gb_RegisteredServersAndCameras";
            gb_RegisteredServersAndCameras.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_RegisteredServersAndCameras.Size = new System.Drawing.Size(681, 479);
            gb_RegisteredServersAndCameras.TabIndex = 0;
            gb_RegisteredServersAndCameras.TabStop = false;
            gb_RegisteredServersAndCameras.Text = "Registered servers and cameras";
            // 
            // p_Main
            // 
            p_Main.Controls.Add(btn_Close);
            p_Main.Controls.Add(gb_RegisteredServersAndCameras);
            p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            p_Main.Location = new System.Drawing.Point(0, 0);
            p_Main.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_Main.Name = "p_Main";
            p_Main.Size = new System.Drawing.Size(681, 515);
            p_Main.TabIndex = 2;
            // 
            // ServerAndCameraManagement
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(681, 515);
            Controls.Add(p_Main);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(541, 396);
            Name = "ServerAndCameraManagement";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Servers and cameras";
            gb_RegisteredServersAndCameras.ResumeLayout(false);
            gb_RegisteredServersAndCameras.PerformLayout();
            p_Main.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ToolTip tt_Hint;
        private System.Windows.Forms.ImageList il_Images;
        private System.Windows.Forms.Button btn_MotionDetection;
        private System.Windows.Forms.Button btn_NewDBServer;
        private System.Windows.Forms.Label lbl_HorizontalLine;
        private System.Windows.Forms.RadioButton rb_CameraName;
        private System.Windows.Forms.Label lbl_SyncronizeBy;
        private System.Windows.Forms.RadioButton rb_RecorderIndex;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Properties;
        private System.Windows.Forms.RadioButton rb_GUID;
        private System.Windows.Forms.Button btn_Syncronize;
        private Mtf.Controls.MtfTreeView tv_ServersAndCameras;
        private System.Windows.Forms.Button btn_NewVideoServer;
        private System.Windows.Forms.Button btn_Modify;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_NewCamera;
        private System.Windows.Forms.GroupBox gb_RegisteredServersAndCameras;
        private System.Windows.Forms.Panel p_Main;
    }
}
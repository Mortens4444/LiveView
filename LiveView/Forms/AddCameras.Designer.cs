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
            tt_Hint = new System.Windows.Forms.ToolTip(components);
            lbl_CamerasOfServer = new System.Windows.Forms.Label();
            cb_Servers = new System.Windows.Forms.ComboBox();
            lv_CamerasToView = new Mtf.Controls.MtfListView();
            il_Images = new System.Windows.Forms.ImageList(components);
            lbl_CamerasToView = new System.Windows.Forms.Label();
            lv_CamerasOfServer = new Mtf.Controls.MtfListView();
            btn_AddAll = new System.Windows.Forms.Button();
            btn_RemoveAll = new System.Windows.Forms.Button();
            btn_AddSelected = new System.Windows.Forms.Button();
            p_Header = new System.Windows.Forms.Panel();
            lbl_Host = new System.Windows.Forms.Label();
            btn_AddCameras = new System.Windows.Forms.Button();
            btn_RemoveSelected = new System.Windows.Forms.Button();
            p_Footer = new System.Windows.Forms.Panel();
            btn_Cancel = new System.Windows.Forms.Button();
            p_Cameras = new System.Windows.Forms.Panel();
            p_Main = new System.Windows.Forms.Panel();
            gb_Main = new System.Windows.Forms.GroupBox();
            axVideoServer = new AxVIDEOCONTROL4Lib.AxVideoServer();
            p_Header.SuspendLayout();
            p_Footer.SuspendLayout();
            p_Cameras.SuspendLayout();
            p_Main.SuspendLayout();
            gb_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)axVideoServer).BeginInit();
            SuspendLayout();
            // 
            // lbl_CamerasOfServer
            // 
            lbl_CamerasOfServer.AutoSize = true;
            lbl_CamerasOfServer.Location = new System.Drawing.Point(2, 52);
            lbl_CamerasOfServer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_CamerasOfServer.Name = "lbl_CamerasOfServer";
            lbl_CamerasOfServer.Size = new System.Drawing.Size(94, 15);
            lbl_CamerasOfServer.TabIndex = 2;
            lbl_CamerasOfServer.Text = "Server's cameras";
            // 
            // cb_Servers
            // 
            cb_Servers.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cb_Servers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_Servers.FormattingEnabled = true;
            cb_Servers.Location = new System.Drawing.Point(1, 24);
            cb_Servers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_Servers.Name = "cb_Servers";
            cb_Servers.Size = new System.Drawing.Size(423, 23);
            cb_Servers.TabIndex = 1;
            cb_Servers.SelectedIndexChanged += Cb_Servers_SelectedIndexChanged;
            // 
            // lv_CamerasToView
            // 
            lv_CamerasToView.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lv_CamerasToView.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lv_CamerasToView.AlternatingColorsAreInUse = true;
            lv_CamerasToView.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lv_CamerasToView.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lv_CamerasToView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            lv_CamerasToView.CompactView = false;
            lv_CamerasToView.EnsureLastItemIsVisible = false;
            lv_CamerasToView.FirstItemIsGray = false;
            lv_CamerasToView.FullRowSelect = true;
            lv_CamerasToView.Location = new System.Drawing.Point(235, 0);
            lv_CamerasToView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lv_CamerasToView.MinimumSize = new System.Drawing.Size(191, 316);
            lv_CamerasToView.Name = "lv_CamerasToView";
            lv_CamerasToView.OwnerDraw = true;
            lv_CamerasToView.ReadonlyCheckboxes = false;
            lv_CamerasToView.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lv_CamerasToView.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lv_CamerasToView.Size = new System.Drawing.Size(191, 389);
            lv_CamerasToView.SmallImageList = il_Images;
            lv_CamerasToView.TabIndex = 1;
            lv_CamerasToView.UseCompatibleStateImageBehavior = false;
            lv_CamerasToView.View = System.Windows.Forms.View.List;
            // 
            // il_Images
            // 
            il_Images.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            il_Images.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("il_Images.ImageStream");
            il_Images.TransparentColor = System.Drawing.Color.Transparent;
            il_Images.Images.SetKeyName(0, "cam 0.ico");
            // 
            // lbl_CamerasToView
            // 
            lbl_CamerasToView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lbl_CamerasToView.AutoSize = true;
            lbl_CamerasToView.Location = new System.Drawing.Point(240, 52);
            lbl_CamerasToView.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_CamerasToView.Name = "lbl_CamerasToView";
            lbl_CamerasToView.Size = new System.Drawing.Size(111, 15);
            lbl_CamerasToView.TabIndex = 3;
            lbl_CamerasToView.Text = "Cameras to preview";
            // 
            // lv_CamerasOfServer
            // 
            lv_CamerasOfServer.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lv_CamerasOfServer.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lv_CamerasOfServer.AlternatingColorsAreInUse = true;
            lv_CamerasOfServer.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lv_CamerasOfServer.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lv_CamerasOfServer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lv_CamerasOfServer.CompactView = false;
            lv_CamerasOfServer.EnsureLastItemIsVisible = false;
            lv_CamerasOfServer.FirstItemIsGray = false;
            lv_CamerasOfServer.FullRowSelect = true;
            lv_CamerasOfServer.Location = new System.Drawing.Point(1, 0);
            lv_CamerasOfServer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lv_CamerasOfServer.MinimumSize = new System.Drawing.Size(191, 316);
            lv_CamerasOfServer.Name = "lv_CamerasOfServer";
            lv_CamerasOfServer.OwnerDraw = true;
            lv_CamerasOfServer.ReadonlyCheckboxes = false;
            lv_CamerasOfServer.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lv_CamerasOfServer.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lv_CamerasOfServer.Size = new System.Drawing.Size(191, 389);
            lv_CamerasOfServer.SmallImageList = il_Images;
            lv_CamerasOfServer.TabIndex = 0;
            lv_CamerasOfServer.UseCompatibleStateImageBehavior = false;
            lv_CamerasOfServer.View = System.Windows.Forms.View.List;
            lv_CamerasOfServer.ItemMouseHover += Lv_CamerasOfServer_ItemMouseHover;
            // 
            // btn_AddAll
            // 
            btn_AddAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btn_AddAll.Image = (System.Drawing.Image)resources.GetObject("btn_AddAll.Image");
            btn_AddAll.Location = new System.Drawing.Point(198, 106);
            btn_AddAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_AddAll.Name = "btn_AddAll";
            btn_AddAll.Size = new System.Drawing.Size(33, 27);
            btn_AddAll.TabIndex = 3;
            btn_AddAll.UseVisualStyleBackColor = true;
            btn_AddAll.Click += Btn_AddAll_Click;
            // 
            // btn_RemoveAll
            // 
            btn_RemoveAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btn_RemoveAll.Image = (System.Drawing.Image)resources.GetObject("btn_RemoveAll.Image");
            btn_RemoveAll.Location = new System.Drawing.Point(198, 173);
            btn_RemoveAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_RemoveAll.Name = "btn_RemoveAll";
            btn_RemoveAll.Size = new System.Drawing.Size(33, 27);
            btn_RemoveAll.TabIndex = 5;
            btn_RemoveAll.UseVisualStyleBackColor = true;
            btn_RemoveAll.Click += Btn_RemoveAll_Click;
            // 
            // btn_AddSelected
            // 
            btn_AddSelected.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btn_AddSelected.Image = (System.Drawing.Image)resources.GetObject("btn_AddSelected.Image");
            btn_AddSelected.Location = new System.Drawing.Point(198, 73);
            btn_AddSelected.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_AddSelected.Name = "btn_AddSelected";
            btn_AddSelected.Size = new System.Drawing.Size(33, 27);
            btn_AddSelected.TabIndex = 2;
            btn_AddSelected.UseVisualStyleBackColor = true;
            btn_AddSelected.Click += Btn_AddSelected_Click;
            // 
            // p_Header
            // 
            p_Header.Controls.Add(axVideoServer);
            p_Header.Controls.Add(lbl_CamerasToView);
            p_Header.Controls.Add(lbl_CamerasOfServer);
            p_Header.Controls.Add(cb_Servers);
            p_Header.Controls.Add(lbl_Host);
            p_Header.Dock = System.Windows.Forms.DockStyle.Top;
            p_Header.Location = new System.Drawing.Point(4, 19);
            p_Header.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_Header.Name = "p_Header";
            p_Header.Size = new System.Drawing.Size(428, 70);
            p_Header.TabIndex = 0;
            // 
            // lbl_Host
            // 
            lbl_Host.AutoSize = true;
            lbl_Host.Location = new System.Drawing.Point(2, 5);
            lbl_Host.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Host.Name = "lbl_Host";
            lbl_Host.Size = new System.Drawing.Size(142, 15);
            lbl_Host.TabIndex = 0;
            lbl_Host.Text = "Server name or IP address";
            // 
            // btn_AddCameras
            // 
            btn_AddCameras.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_AddCameras.DialogResult = System.Windows.Forms.DialogResult.OK;
            btn_AddCameras.Enabled = false;
            btn_AddCameras.Location = new System.Drawing.Point(240, 5);
            btn_AddCameras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_AddCameras.Name = "btn_AddCameras";
            btn_AddCameras.Size = new System.Drawing.Size(88, 27);
            btn_AddCameras.TabIndex = 0;
            btn_AddCameras.Text = "Add";
            btn_AddCameras.UseVisualStyleBackColor = true;
            btn_AddCameras.Click += Btn_AddCameras_Click;
            // 
            // btn_RemoveSelected
            // 
            btn_RemoveSelected.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btn_RemoveSelected.Image = (System.Drawing.Image)resources.GetObject("btn_RemoveSelected.Image");
            btn_RemoveSelected.Location = new System.Drawing.Point(198, 140);
            btn_RemoveSelected.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_RemoveSelected.Name = "btn_RemoveSelected";
            btn_RemoveSelected.Size = new System.Drawing.Size(33, 27);
            btn_RemoveSelected.TabIndex = 4;
            btn_RemoveSelected.UseVisualStyleBackColor = true;
            btn_RemoveSelected.Click += Btn_RemoveSelected_Click;
            // 
            // p_Footer
            // 
            p_Footer.Controls.Add(btn_Cancel);
            p_Footer.Controls.Add(btn_AddCameras);
            p_Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            p_Footer.Location = new System.Drawing.Point(0, 391);
            p_Footer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_Footer.Name = "p_Footer";
            p_Footer.Size = new System.Drawing.Size(428, 36);
            p_Footer.TabIndex = 0;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btn_Cancel.Location = new System.Drawing.Point(335, 5);
            btn_Cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new System.Drawing.Size(88, 27);
            btn_Cancel.TabIndex = 1;
            btn_Cancel.Text = "Cancel";
            btn_Cancel.UseVisualStyleBackColor = true;
            btn_Cancel.Click += Btn_Cancel_Click;
            // 
            // p_Cameras
            // 
            p_Cameras.Controls.Add(lv_CamerasToView);
            p_Cameras.Controls.Add(lv_CamerasOfServer);
            p_Cameras.Controls.Add(btn_AddAll);
            p_Cameras.Controls.Add(btn_RemoveAll);
            p_Cameras.Controls.Add(btn_AddSelected);
            p_Cameras.Controls.Add(btn_RemoveSelected);
            p_Cameras.Dock = System.Windows.Forms.DockStyle.Fill;
            p_Cameras.Location = new System.Drawing.Point(0, 0);
            p_Cameras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_Cameras.Name = "p_Cameras";
            p_Cameras.Size = new System.Drawing.Size(428, 391);
            p_Cameras.TabIndex = 0;
            // 
            // p_Main
            // 
            p_Main.Controls.Add(p_Cameras);
            p_Main.Controls.Add(p_Footer);
            p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            p_Main.Location = new System.Drawing.Point(4, 89);
            p_Main.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_Main.Name = "p_Main";
            p_Main.Size = new System.Drawing.Size(428, 427);
            p_Main.TabIndex = 0;
            // 
            // gb_Main
            // 
            gb_Main.Controls.Add(p_Main);
            gb_Main.Controls.Add(p_Header);
            gb_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            gb_Main.Location = new System.Drawing.Point(0, 0);
            gb_Main.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Main.Name = "gb_Main";
            gb_Main.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Main.Size = new System.Drawing.Size(436, 519);
            gb_Main.TabIndex = 1;
            gb_Main.TabStop = false;
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
            // AddCameras
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(436, 519);
            Controls.Add(gb_Main);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "AddCameras";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "New cameras";
            Shown += AddCameras_Shown;
            p_Header.ResumeLayout(false);
            p_Header.PerformLayout();
            p_Footer.ResumeLayout(false);
            p_Cameras.ResumeLayout(false);
            p_Main.ResumeLayout(false);
            gb_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)axVideoServer).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ToolTip tt_Hint;
        private System.Windows.Forms.Label lbl_CamerasOfServer;
        private System.Windows.Forms.ComboBox cb_Servers;
        private Mtf.Controls.MtfListView lv_CamerasToView;
        private System.Windows.Forms.ImageList il_Images;
        private System.Windows.Forms.Label lbl_CamerasToView;
        private Mtf.Controls.MtfListView lv_CamerasOfServer;
        private System.Windows.Forms.Button btn_AddAll;
        private System.Windows.Forms.Button btn_RemoveAll;
        private System.Windows.Forms.Button btn_AddSelected;
        private System.Windows.Forms.Panel p_Header;
        private System.Windows.Forms.Label lbl_Host;
        private System.Windows.Forms.Button btn_AddCameras;
        private System.Windows.Forms.Button btn_RemoveSelected;
        private System.Windows.Forms.Panel p_Footer;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Panel p_Cameras;
        private System.Windows.Forms.Panel p_Main;
        private System.Windows.Forms.GroupBox gb_Main;
        private AxVIDEOCONTROL4Lib.AxVideoServer axVideoServer;
    }
}
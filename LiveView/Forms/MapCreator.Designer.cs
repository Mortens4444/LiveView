namespace LiveView.Forms
{
    partial class MapCreator
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MapCreator));
            il_Images = new System.Windows.Forms.ImageList(components);
            btn_DeleteMap = new System.Windows.Forms.Button();
            cb_MapName = new System.Windows.Forms.ComboBox();
            btn_AddObject = new System.Windows.Forms.Button();
            rtb_Comment = new System.Windows.Forms.RichTextBox();
            lbl_Comment = new System.Windows.Forms.Label();
            lbl_MapName = new System.Windows.Forms.Label();
            btn_SaveMap = new System.Windows.Forms.Button();
            tsmi_SetNewObjectsDefaultSize = new System.Windows.Forms.ToolStripMenuItem();
            tss_Separator = new System.Windows.Forms.ToolStripSeparator();
            tsmi_Delete = new System.Windows.Forms.ToolStripMenuItem();
            tst_Comment = new System.Windows.Forms.ToolStripTextBox();
            tsmi_AddComment = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_OpenMap = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_OpenCamera = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_AddFunctionality = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_Browse = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_MapIcon = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_CameraIcon = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_AddImage = new System.Windows.Forms.ToolStripMenuItem();
            cms_ObjectMenu = new System.Windows.Forms.ContextMenuStrip(components);
            p_Default = new Mtf.Controls.MovableSizablePanel();
            gb_Tools = new System.Windows.Forms.GroupBox();
            btn_LoadImage = new System.Windows.Forms.Button();
            p_Canvas = new System.Windows.Forms.Panel();
            pb_Canvas = new Mtf.Controls.MtfPictureBox();
            p_Tools = new System.Windows.Forms.Panel();
            p_Main = new System.Windows.Forms.Panel();
            cms_ObjectMenu.SuspendLayout();
            gb_Tools.SuspendLayout();
            p_Canvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Canvas).BeginInit();
            p_Tools.SuspendLayout();
            p_Main.SuspendLayout();
            SuspendLayout();
            // 
            // il_Images
            // 
            il_Images.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            il_Images.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("il_Images.ImageStream");
            il_Images.TransparentColor = System.Drawing.Color.Transparent;
            il_Images.Images.SetKeyName(0, "camera_unknown.ico");
            il_Images.Images.SetKeyName(1, "maps.png");
            // 
            // btn_DeleteMap
            // 
            btn_DeleteMap.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btn_DeleteMap.Enabled = false;
            btn_DeleteMap.Location = new System.Drawing.Point(554, 38);
            btn_DeleteMap.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_DeleteMap.Name = "btn_DeleteMap";
            btn_DeleteMap.Size = new System.Drawing.Size(130, 27);
            btn_DeleteMap.TabIndex = 6;
            btn_DeleteMap.Text = "Delete map";
            btn_DeleteMap.UseVisualStyleBackColor = true;
            btn_DeleteMap.Click += Btn_DeleteMap_Click;
            // 
            // cb_MapName
            // 
            cb_MapName.FormattingEnabled = true;
            cb_MapName.Location = new System.Drawing.Point(418, 40);
            cb_MapName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_MapName.Name = "cb_MapName";
            cb_MapName.Size = new System.Drawing.Size(129, 23);
            cb_MapName.TabIndex = 1;
            // 
            // btn_AddObject
            // 
            btn_AddObject.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btn_AddObject.Location = new System.Drawing.Point(7, 143);
            btn_AddObject.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_AddObject.Name = "btn_AddObject";
            btn_AddObject.Size = new System.Drawing.Size(130, 27);
            btn_AddObject.TabIndex = 5;
            btn_AddObject.Text = "Add object";
            btn_AddObject.UseVisualStyleBackColor = true;
            btn_AddObject.Visible = false;
            btn_AddObject.Click += Btn_AddObject_Click;
            // 
            // rtb_Comment
            // 
            rtb_Comment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            rtb_Comment.Location = new System.Drawing.Point(418, 90);
            rtb_Comment.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rtb_Comment.MaxLength = 200;
            rtb_Comment.Name = "rtb_Comment";
            rtb_Comment.Size = new System.Drawing.Size(265, 46);
            rtb_Comment.TabIndex = 3;
            rtb_Comment.Text = "";
            // 
            // lbl_Comment
            // 
            lbl_Comment.AutoSize = true;
            lbl_Comment.Location = new System.Drawing.Point(414, 72);
            lbl_Comment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Comment.Name = "lbl_Comment";
            lbl_Comment.Size = new System.Drawing.Size(61, 15);
            lbl_Comment.TabIndex = 2;
            lbl_Comment.Text = "Comment";
            // 
            // lbl_MapName
            // 
            lbl_MapName.AutoSize = true;
            lbl_MapName.Location = new System.Drawing.Point(414, 22);
            lbl_MapName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_MapName.Name = "lbl_MapName";
            lbl_MapName.Size = new System.Drawing.Size(64, 15);
            lbl_MapName.TabIndex = 0;
            lbl_MapName.Text = "Map name";
            // 
            // btn_SaveMap
            // 
            btn_SaveMap.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btn_SaveMap.DialogResult = System.Windows.Forms.DialogResult.OK;
            btn_SaveMap.Enabled = false;
            btn_SaveMap.Location = new System.Drawing.Point(554, 143);
            btn_SaveMap.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_SaveMap.Name = "btn_SaveMap";
            btn_SaveMap.Size = new System.Drawing.Size(130, 27);
            btn_SaveMap.TabIndex = 7;
            btn_SaveMap.Text = "Save map";
            btn_SaveMap.UseVisualStyleBackColor = true;
            btn_SaveMap.Click += Btn_SaveMap_Click;
            // 
            // tsmi_SetNewObjectsDefaultSize
            // 
            tsmi_SetNewObjectsDefaultSize.Name = "tsmi_SetNewObjectsDefaultSize";
            tsmi_SetNewObjectsDefaultSize.Size = new System.Drawing.Size(218, 22);
            tsmi_SetNewObjectsDefaultSize.Text = "Set new objects default size";
            // 
            // tss_Separator
            // 
            tss_Separator.Name = "tss_Separator";
            tss_Separator.Size = new System.Drawing.Size(215, 6);
            // 
            // tsmi_Delete
            // 
            tsmi_Delete.Name = "tsmi_Delete";
            tsmi_Delete.Size = new System.Drawing.Size(218, 22);
            tsmi_Delete.Text = "Delete";
            // 
            // tst_Comment
            // 
            tst_Comment.MaxLength = 200;
            tst_Comment.Name = "tst_Comment";
            tst_Comment.Size = new System.Drawing.Size(100, 23);
            // 
            // tsmi_AddComment
            // 
            tsmi_AddComment.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tst_Comment });
            tsmi_AddComment.Name = "tsmi_AddComment";
            tsmi_AddComment.Size = new System.Drawing.Size(218, 22);
            tsmi_AddComment.Text = "Add comment";
            // 
            // tsmi_OpenMap
            // 
            tsmi_OpenMap.Name = "tsmi_OpenMap";
            tsmi_OpenMap.Size = new System.Drawing.Size(145, 22);
            tsmi_OpenMap.Text = "Open map";
            // 
            // tsmi_OpenCamera
            // 
            tsmi_OpenCamera.Name = "tsmi_OpenCamera";
            tsmi_OpenCamera.Size = new System.Drawing.Size(145, 22);
            tsmi_OpenCamera.Text = "Open camera";
            // 
            // tsmi_AddFunctionality
            // 
            tsmi_AddFunctionality.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmi_OpenCamera, tsmi_OpenMap });
            tsmi_AddFunctionality.Name = "tsmi_AddFunctionality";
            tsmi_AddFunctionality.Size = new System.Drawing.Size(218, 22);
            tsmi_AddFunctionality.Text = "Add functionality";
            // 
            // tsmi_Browse
            // 
            tsmi_Browse.Name = "tsmi_Browse";
            tsmi_Browse.Size = new System.Drawing.Size(121, 22);
            tsmi_Browse.Text = "Browse...";
            // 
            // tsmi_MapIcon
            // 
            tsmi_MapIcon.Image = (System.Drawing.Image)resources.GetObject("tsmi_MapIcon.Image");
            tsmi_MapIcon.Name = "tsmi_MapIcon";
            tsmi_MapIcon.Size = new System.Drawing.Size(121, 22);
            tsmi_MapIcon.Text = "Map";
            tsmi_MapIcon.Visible = false;
            // 
            // tsmi_CameraIcon
            // 
            tsmi_CameraIcon.Image = (System.Drawing.Image)resources.GetObject("tsmi_CameraIcon.Image");
            tsmi_CameraIcon.Name = "tsmi_CameraIcon";
            tsmi_CameraIcon.Size = new System.Drawing.Size(121, 22);
            tsmi_CameraIcon.Text = "Camera";
            tsmi_CameraIcon.Visible = false;
            // 
            // tsmi_AddImage
            // 
            tsmi_AddImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmi_CameraIcon, tsmi_MapIcon, tsmi_Browse });
            tsmi_AddImage.Name = "tsmi_AddImage";
            tsmi_AddImage.Size = new System.Drawing.Size(218, 22);
            tsmi_AddImage.Text = "Add image";
            // 
            // cms_ObjectMenu
            // 
            cms_ObjectMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmi_AddImage, tsmi_AddFunctionality, tsmi_AddComment, tsmi_Delete, tss_Separator, tsmi_SetNewObjectsDefaultSize });
            cms_ObjectMenu.Name = "cms_ObjectMenu";
            cms_ObjectMenu.Size = new System.Drawing.Size(219, 120);
            // 
            // p_Default
            // 
            p_Default.BackColor = System.Drawing.Color.Black;
            p_Default.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            p_Default.CanMove = true;
            p_Default.CanSize = true;
            p_Default.ContextMenuStrip = cms_ObjectMenu;
            p_Default.Location = new System.Drawing.Point(7, 22);
            p_Default.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_Default.Name = "p_Default";
            p_Default.Size = new System.Drawing.Size(63, 48);
            p_Default.TabIndex = 8;
            p_Default.TransparentColor = System.Drawing.Color.Black;
            p_Default.UseTransparentColor = false;
            // 
            // gb_Tools
            // 
            gb_Tools.Controls.Add(p_Default);
            gb_Tools.Controls.Add(btn_DeleteMap);
            gb_Tools.Controls.Add(cb_MapName);
            gb_Tools.Controls.Add(btn_AddObject);
            gb_Tools.Controls.Add(rtb_Comment);
            gb_Tools.Controls.Add(lbl_Comment);
            gb_Tools.Controls.Add(lbl_MapName);
            gb_Tools.Controls.Add(btn_SaveMap);
            gb_Tools.Controls.Add(btn_LoadImage);
            gb_Tools.Dock = System.Windows.Forms.DockStyle.Fill;
            gb_Tools.Location = new System.Drawing.Point(0, 0);
            gb_Tools.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Tools.Name = "gb_Tools";
            gb_Tools.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Tools.Size = new System.Drawing.Size(691, 177);
            gb_Tools.TabIndex = 0;
            gb_Tools.TabStop = false;
            gb_Tools.Text = "Tools";
            // 
            // btn_LoadImage
            // 
            btn_LoadImage.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btn_LoadImage.Location = new System.Drawing.Point(418, 143);
            btn_LoadImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_LoadImage.Name = "btn_LoadImage";
            btn_LoadImage.Size = new System.Drawing.Size(130, 27);
            btn_LoadImage.TabIndex = 4;
            btn_LoadImage.Text = "Load image";
            btn_LoadImage.UseVisualStyleBackColor = true;
            btn_LoadImage.Click += Btn_LoadImage_Click;
            // 
            // p_Canvas
            // 
            p_Canvas.Controls.Add(pb_Canvas);
            p_Canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            p_Canvas.Location = new System.Drawing.Point(0, 177);
            p_Canvas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_Canvas.Name = "p_Canvas";
            p_Canvas.Size = new System.Drawing.Size(691, 369);
            p_Canvas.TabIndex = 0;
            // 
            // pb_Canvas
            // 
            pb_Canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            pb_Canvas.Location = new System.Drawing.Point(0, 0);
            pb_Canvas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pb_Canvas.Name = "pb_Canvas";
            pb_Canvas.OriginalSize = new System.Drawing.Size(100, 50);
            pb_Canvas.RepositioningAndResizingControlsOnResize = false;
            pb_Canvas.Size = new System.Drawing.Size(691, 369);
            pb_Canvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pb_Canvas.TabIndex = 0;
            pb_Canvas.TabStop = false;
            // 
            // p_Tools
            // 
            p_Tools.Controls.Add(gb_Tools);
            p_Tools.Dock = System.Windows.Forms.DockStyle.Top;
            p_Tools.Location = new System.Drawing.Point(0, 0);
            p_Tools.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_Tools.Name = "p_Tools";
            p_Tools.Size = new System.Drawing.Size(691, 177);
            p_Tools.TabIndex = 0;
            // 
            // p_Main
            // 
            p_Main.Controls.Add(p_Canvas);
            p_Main.Controls.Add(p_Tools);
            p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            p_Main.Location = new System.Drawing.Point(0, 0);
            p_Main.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_Main.Name = "p_Main";
            p_Main.Size = new System.Drawing.Size(691, 546);
            p_Main.TabIndex = 1;
            // 
            // MapCreator
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(691, 546);
            Controls.Add(p_Main);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(697, 571);
            Name = "MapCreator";
            Text = "MapCreator";
            cms_ObjectMenu.ResumeLayout(false);
            gb_Tools.ResumeLayout(false);
            gb_Tools.PerformLayout();
            p_Canvas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb_Canvas).EndInit();
            p_Tools.ResumeLayout(false);
            p_Main.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ImageList il_Images;
        private System.Windows.Forms.Button btn_DeleteMap;
        private System.Windows.Forms.ComboBox cb_MapName;
        private System.Windows.Forms.Button btn_AddObject;
        private System.Windows.Forms.RichTextBox rtb_Comment;
        private System.Windows.Forms.Label lbl_Comment;
        private System.Windows.Forms.Label lbl_MapName;
        private System.Windows.Forms.Button btn_SaveMap;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SetNewObjectsDefaultSize;
        private System.Windows.Forms.ToolStripSeparator tss_Separator;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Delete;
        private System.Windows.Forms.ToolStripTextBox tst_Comment;
        private System.Windows.Forms.ToolStripMenuItem tsmi_AddComment;
        private System.Windows.Forms.ToolStripMenuItem tsmi_OpenMap;
        private System.Windows.Forms.ToolStripMenuItem tsmi_OpenCamera;
        private System.Windows.Forms.ToolStripMenuItem tsmi_AddFunctionality;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Browse;
        private System.Windows.Forms.ToolStripMenuItem tsmi_MapIcon;
        private System.Windows.Forms.ToolStripMenuItem tsmi_CameraIcon;
        private System.Windows.Forms.ToolStripMenuItem tsmi_AddImage;
        private System.Windows.Forms.ContextMenuStrip cms_ObjectMenu;
        private Mtf.Controls.MovableSizablePanel p_Default;
        private System.Windows.Forms.GroupBox gb_Tools;
        private System.Windows.Forms.Button btn_LoadImage;
        private System.Windows.Forms.Panel p_Canvas;
        private Mtf.Controls.MtfPictureBox pb_Canvas;
        private System.Windows.Forms.Panel p_Tools;
        private System.Windows.Forms.Panel p_Main;
    }
}
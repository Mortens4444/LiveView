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
            ilImages = new System.Windows.Forms.ImageList(components);
            btnDeleteMap = new System.Windows.Forms.Button();
            cbMapName = new System.Windows.Forms.ComboBox();
            btnAddObject = new System.Windows.Forms.Button();
            rtbComment = new System.Windows.Forms.RichTextBox();
            lblComment = new System.Windows.Forms.Label();
            lblMapName = new System.Windows.Forms.Label();
            btnSaveMap = new System.Windows.Forms.Button();
            tsmiSetNewObjectsDefaultSize = new System.Windows.Forms.ToolStripMenuItem();
            tssSeparator = new System.Windows.Forms.ToolStripSeparator();
            tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            tstComment = new System.Windows.Forms.ToolStripTextBox();
            tsmiAddComment = new System.Windows.Forms.ToolStripMenuItem();
            tsmiOpenMap = new System.Windows.Forms.ToolStripMenuItem();
            tsmiOpenCamera = new System.Windows.Forms.ToolStripMenuItem();
            tsmiAddFunctionality = new System.Windows.Forms.ToolStripMenuItem();
            tsmiBrowse = new System.Windows.Forms.ToolStripMenuItem();
            tsmiMapIcon = new System.Windows.Forms.ToolStripMenuItem();
            tsmiCameraIcon = new System.Windows.Forms.ToolStripMenuItem();
            tsmiAddImage = new System.Windows.Forms.ToolStripMenuItem();
            cmsObjectMenu = new System.Windows.Forms.ContextMenuStrip(components);
            pDefault = new Mtf.Controls.MovableSizablePanel();
            gbTools = new System.Windows.Forms.GroupBox();
            btnLoadImage = new System.Windows.Forms.Button();
            pCanvas = new System.Windows.Forms.Panel();
            pbCanvas = new Mtf.Controls.MtfPictureBox();
            pTools = new System.Windows.Forms.Panel();
            pMain = new System.Windows.Forms.Panel();
            cmsObjectMenu.SuspendLayout();
            gbTools.SuspendLayout();
            pCanvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbCanvas).BeginInit();
            pTools.SuspendLayout();
            pMain.SuspendLayout();
            SuspendLayout();
            // 
            // ilImages
            // 
            ilImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            ilImages.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ilImages.ImageStream");
            ilImages.TransparentColor = System.Drawing.Color.Transparent;
            ilImages.Images.SetKeyName(0, "camera_unknown.ico");
            ilImages.Images.SetKeyName(1, "maps.png");
            // 
            // btnDeleteMap
            // 
            btnDeleteMap.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnDeleteMap.Enabled = false;
            btnDeleteMap.Location = new System.Drawing.Point(554, 38);
            btnDeleteMap.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnDeleteMap.Name = "btnDeleteMap";
            btnDeleteMap.Size = new System.Drawing.Size(130, 27);
            btnDeleteMap.TabIndex = 6;
            btnDeleteMap.Text = "Delete map";
            btnDeleteMap.UseVisualStyleBackColor = true;
            btnDeleteMap.Click += BtnDeleteMap_Click;
            // 
            // cbMapName
            // 
            cbMapName.FormattingEnabled = true;
            cbMapName.Location = new System.Drawing.Point(418, 40);
            cbMapName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbMapName.Name = "cbMapName";
            cbMapName.Size = new System.Drawing.Size(129, 23);
            cbMapName.TabIndex = 1;
            // 
            // btnAddObject
            // 
            btnAddObject.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnAddObject.Location = new System.Drawing.Point(7, 143);
            btnAddObject.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAddObject.Name = "btnAddObject";
            btnAddObject.Size = new System.Drawing.Size(130, 27);
            btnAddObject.TabIndex = 5;
            btnAddObject.Text = "Add object";
            btnAddObject.UseVisualStyleBackColor = true;
            btnAddObject.Visible = false;
            btnAddObject.Click += BtnAddObject_Click;
            // 
            // rtbComment
            // 
            rtbComment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            rtbComment.Location = new System.Drawing.Point(418, 90);
            rtbComment.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rtbComment.MaxLength = 200;
            rtbComment.Name = "rtbComment";
            rtbComment.Size = new System.Drawing.Size(265, 46);
            rtbComment.TabIndex = 3;
            rtbComment.Text = "";
            // 
            // lblComment
            // 
            lblComment.AutoSize = true;
            lblComment.Location = new System.Drawing.Point(414, 72);
            lblComment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblComment.Name = "lblComment";
            lblComment.Size = new System.Drawing.Size(61, 15);
            lblComment.TabIndex = 2;
            lblComment.Text = "Comment";
            // 
            // lblMapName
            // 
            lblMapName.AutoSize = true;
            lblMapName.Location = new System.Drawing.Point(414, 22);
            lblMapName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMapName.Name = "lblMapName";
            lblMapName.Size = new System.Drawing.Size(64, 15);
            lblMapName.TabIndex = 0;
            lblMapName.Text = "Map name";
            // 
            // btnSaveMap
            // 
            btnSaveMap.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnSaveMap.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnSaveMap.Enabled = false;
            btnSaveMap.Location = new System.Drawing.Point(554, 143);
            btnSaveMap.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSaveMap.Name = "btnSaveMap";
            btnSaveMap.Size = new System.Drawing.Size(130, 27);
            btnSaveMap.TabIndex = 7;
            btnSaveMap.Text = "Save map";
            btnSaveMap.UseVisualStyleBackColor = true;
            btnSaveMap.Click += BtnSaveMap_Click;
            // 
            // tsmiSetNewObjectsDefaultSize
            // 
            tsmiSetNewObjectsDefaultSize.Name = "tsmiSetNewObjectsDefaultSize";
            tsmiSetNewObjectsDefaultSize.Size = new System.Drawing.Size(218, 22);
            tsmiSetNewObjectsDefaultSize.Text = "Set new objects default size";
            // 
            // tssSeparator
            // 
            tssSeparator.Name = "tssSeparator";
            tssSeparator.Size = new System.Drawing.Size(215, 6);
            // 
            // tsmiDelete
            // 
            tsmiDelete.Name = "tsmiDelete";
            tsmiDelete.Size = new System.Drawing.Size(218, 22);
            tsmiDelete.Text = "Delete";
            // 
            // tstComment
            // 
            tstComment.MaxLength = 200;
            tstComment.Name = "tstComment";
            tstComment.Size = new System.Drawing.Size(100, 23);
            // 
            // tsmiAddComment
            // 
            tsmiAddComment.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tstComment });
            tsmiAddComment.Name = "tsmiAddComment";
            tsmiAddComment.Size = new System.Drawing.Size(218, 22);
            tsmiAddComment.Text = "Add comment";
            // 
            // tsmiOpenMap
            // 
            tsmiOpenMap.Name = "tsmiOpenMap";
            tsmiOpenMap.Size = new System.Drawing.Size(180, 22);
            tsmiOpenMap.Text = "Open map";
            // 
            // tsmiOpenCamera
            // 
            tsmiOpenCamera.Name = "tsmiOpenCamera";
            tsmiOpenCamera.Size = new System.Drawing.Size(180, 22);
            tsmiOpenCamera.Text = "Open camera";
            // 
            // tsmiAddFunctionality
            // 
            tsmiAddFunctionality.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiOpenCamera, tsmiOpenMap });
            tsmiAddFunctionality.Name = "tsmiAddFunctionality";
            tsmiAddFunctionality.Size = new System.Drawing.Size(218, 22);
            tsmiAddFunctionality.Text = "Add functionality";
            // 
            // tsmiBrowse
            // 
            tsmiBrowse.Name = "tsmiBrowse";
            tsmiBrowse.Size = new System.Drawing.Size(180, 22);
            tsmiBrowse.Text = "Browse...";
            // 
            // tsmiMapIcon
            // 
            tsmiMapIcon.Image = (System.Drawing.Image)resources.GetObject("tsmiMapIcon.Image");
            tsmiMapIcon.Name = "tsmiMapIcon";
            tsmiMapIcon.Size = new System.Drawing.Size(180, 22);
            tsmiMapIcon.Text = "Map";
            tsmiMapIcon.Visible = false;
            // 
            // tsmiCameraIcon
            // 
            tsmiCameraIcon.Image = (System.Drawing.Image)resources.GetObject("tsmiCameraIcon.Image");
            tsmiCameraIcon.Name = "tsmiCameraIcon";
            tsmiCameraIcon.Size = new System.Drawing.Size(180, 22);
            tsmiCameraIcon.Text = "Camera";
            tsmiCameraIcon.Visible = false;
            // 
            // tsmiAddImage
            // 
            tsmiAddImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiCameraIcon, tsmiMapIcon, tsmiBrowse });
            tsmiAddImage.Name = "tsmiAddImage";
            tsmiAddImage.Size = new System.Drawing.Size(218, 22);
            tsmiAddImage.Text = "Add image";
            // 
            // cmsObjectMenu
            // 
            cmsObjectMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiAddImage, tsmiAddFunctionality, tsmiAddComment, tsmiDelete, tssSeparator, tsmiSetNewObjectsDefaultSize });
            cmsObjectMenu.Name = "cms_ObjectMenu";
            cmsObjectMenu.Size = new System.Drawing.Size(219, 142);
            // 
            // pDefault
            // 
            pDefault.BackColor = System.Drawing.Color.Black;
            pDefault.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pDefault.CanMove = true;
            pDefault.CanSize = true;
            pDefault.ContextMenuStrip = cmsObjectMenu;
            pDefault.Location = new System.Drawing.Point(7, 22);
            pDefault.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pDefault.Name = "pDefault";
            pDefault.Size = new System.Drawing.Size(63, 48);
            pDefault.TabIndex = 8;
            pDefault.TransparentColor = System.Drawing.Color.Black;
            pDefault.UseTransparentColor = false;
            // 
            // gbTools
            // 
            gbTools.Controls.Add(pDefault);
            gbTools.Controls.Add(btnDeleteMap);
            gbTools.Controls.Add(cbMapName);
            gbTools.Controls.Add(btnAddObject);
            gbTools.Controls.Add(rtbComment);
            gbTools.Controls.Add(lblComment);
            gbTools.Controls.Add(lblMapName);
            gbTools.Controls.Add(btnSaveMap);
            gbTools.Controls.Add(btnLoadImage);
            gbTools.Dock = System.Windows.Forms.DockStyle.Fill;
            gbTools.Location = new System.Drawing.Point(0, 0);
            gbTools.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbTools.Name = "gbTools";
            gbTools.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbTools.Size = new System.Drawing.Size(691, 177);
            gbTools.TabIndex = 0;
            gbTools.TabStop = false;
            gbTools.Text = "Tools";
            // 
            // btnLoadImage
            // 
            btnLoadImage.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnLoadImage.Location = new System.Drawing.Point(418, 143);
            btnLoadImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnLoadImage.Name = "btnLoadImage";
            btnLoadImage.Size = new System.Drawing.Size(130, 27);
            btnLoadImage.TabIndex = 4;
            btnLoadImage.Text = "Load image";
            btnLoadImage.UseVisualStyleBackColor = true;
            btnLoadImage.Click += BtnLoadImage_Click;
            // 
            // pCanvas
            // 
            pCanvas.Controls.Add(pbCanvas);
            pCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            pCanvas.Location = new System.Drawing.Point(0, 177);
            pCanvas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pCanvas.Name = "pCanvas";
            pCanvas.Size = new System.Drawing.Size(691, 369);
            pCanvas.TabIndex = 0;
            // 
            // pbCanvas
            // 
            pbCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            pbCanvas.Location = new System.Drawing.Point(0, 0);
            pbCanvas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pbCanvas.Name = "pbCanvas";
            pbCanvas.OriginalSize = new System.Drawing.Size(100, 50);
            pbCanvas.RepositioningAndResizingControlsOnResize = false;
            pbCanvas.Size = new System.Drawing.Size(691, 369);
            pbCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbCanvas.TabIndex = 0;
            pbCanvas.TabStop = false;
            // 
            // pTools
            // 
            pTools.Controls.Add(gbTools);
            pTools.Dock = System.Windows.Forms.DockStyle.Top;
            pTools.Location = new System.Drawing.Point(0, 0);
            pTools.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pTools.Name = "pTools";
            pTools.Size = new System.Drawing.Size(691, 177);
            pTools.TabIndex = 0;
            // 
            // pMain
            // 
            pMain.Controls.Add(pCanvas);
            pMain.Controls.Add(pTools);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(691, 546);
            pMain.TabIndex = 1;
            // 
            // MapCreator
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(691, 546);
            Controls.Add(pMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(697, 571);
            Name = "MapCreator";
            Text = "MapCreator";
            cmsObjectMenu.ResumeLayout(false);
            gbTools.ResumeLayout(false);
            gbTools.PerformLayout();
            pCanvas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbCanvas).EndInit();
            pTools.ResumeLayout(false);
            pMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ImageList ilImages;
        private System.Windows.Forms.Button btnDeleteMap;
        private System.Windows.Forms.ComboBox cbMapName;
        private System.Windows.Forms.Button btnAddObject;
        private System.Windows.Forms.RichTextBox rtbComment;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblMapName;
        private System.Windows.Forms.Button btnSaveMap;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetNewObjectsDefaultSize;
        private System.Windows.Forms.ToolStripSeparator tssSeparator;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripTextBox tstComment;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddComment;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenMap;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenCamera;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddFunctionality;
        private System.Windows.Forms.ToolStripMenuItem tsmiBrowse;
        private System.Windows.Forms.ToolStripMenuItem tsmiMapIcon;
        private System.Windows.Forms.ToolStripMenuItem tsmiCameraIcon;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddImage;
        private System.Windows.Forms.ContextMenuStrip cmsObjectMenu;
        private Mtf.Controls.MovableSizablePanel pDefault;
        private System.Windows.Forms.GroupBox gbTools;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Panel pCanvas;
        private Mtf.Controls.MtfPictureBox pbCanvas;
        private System.Windows.Forms.Panel pTools;
        private System.Windows.Forms.Panel pMain;
    }
}
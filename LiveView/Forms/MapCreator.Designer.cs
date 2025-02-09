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
            cbMap = new System.Windows.Forms.ComboBox();
            btnAddObject = new System.Windows.Forms.Button();
            rtbComment = new System.Windows.Forms.RichTextBox();
            lblComment = new System.Windows.Forms.Label();
            lblMapName = new System.Windows.Forms.Label();
            btnSaveMap = new System.Windows.Forms.Button();
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
            pTemplate = new Mtf.Controls.MovableSizablePanel();
            gbTools = new System.Windows.Forms.GroupBox();
            btnNewMap = new System.Windows.Forms.Button();
            btnLoadImage = new System.Windows.Forms.Button();
            pCanvas = new System.Windows.Forms.Panel();
            pTools = new System.Windows.Forms.Panel();
            pMain = new System.Windows.Forms.Panel();
            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            cmsObjectMenu.SuspendLayout();
            gbTools.SuspendLayout();
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
            btnDeleteMap.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnDeleteMap.Enabled = false;
            btnDeleteMap.Location = new System.Drawing.Point(803, 40);
            btnDeleteMap.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnDeleteMap.Name = "btnDeleteMap";
            btnDeleteMap.Size = new System.Drawing.Size(119, 27);
            btnDeleteMap.TabIndex = 6;
            btnDeleteMap.Text = "Delete map";
            btnDeleteMap.UseVisualStyleBackColor = true;
            btnDeleteMap.Click += BtnDeleteMap_Click;
            // 
            // cbMap
            // 
            cbMap.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbMap.FormattingEnabled = true;
            cbMap.Location = new System.Drawing.Point(418, 40);
            cbMap.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbMap.Name = "cbMap";
            cbMap.Size = new System.Drawing.Size(377, 23);
            cbMap.TabIndex = 1;
            cbMap.SelectedIndexChanged += CbMap_SelectedIndexChanged;
            // 
            // btnAddObject
            // 
            btnAddObject.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnAddObject.Image = Properties.Resources.plus_16;
            btnAddObject.Location = new System.Drawing.Point(4, 22);
            btnAddObject.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAddObject.Name = "btnAddObject";
            btnAddObject.Size = new System.Drawing.Size(27, 27);
            btnAddObject.TabIndex = 5;
            btnAddObject.UseVisualStyleBackColor = true;
            btnAddObject.Click += BtnAddObject_Click;
            // 
            // rtbComment
            // 
            rtbComment.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            rtbComment.Location = new System.Drawing.Point(418, 90);
            rtbComment.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rtbComment.MaxLength = 200;
            rtbComment.Name = "rtbComment";
            rtbComment.Size = new System.Drawing.Size(503, 46);
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
            btnSaveMap.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSaveMap.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnSaveMap.Enabled = false;
            btnSaveMap.Location = new System.Drawing.Point(803, 143);
            btnSaveMap.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSaveMap.Name = "btnSaveMap";
            btnSaveMap.Size = new System.Drawing.Size(119, 27);
            btnSaveMap.TabIndex = 7;
            btnSaveMap.Text = "Save map";
            btnSaveMap.UseVisualStyleBackColor = true;
            btnSaveMap.Click += BtnSaveMap_Click;
            // 
            // tsmiDelete
            // 
            tsmiDelete.Image = Properties.Resources.cancel;
            tsmiDelete.Name = "tsmiDelete";
            tsmiDelete.Size = new System.Drawing.Size(166, 22);
            tsmiDelete.Text = "Delete";
            tsmiDelete.Click += TsmiDelete_Click;
            // 
            // tstComment
            // 
            tstComment.MaxLength = 200;
            tstComment.Name = "tstComment";
            tstComment.Size = new System.Drawing.Size(100, 23);
            tstComment.LostFocus += TstComment_Leave;
            // 
            // tsmiAddComment
            // 
            tsmiAddComment.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tstComment });
            tsmiAddComment.Image = Properties.Resources.comment;
            tsmiAddComment.Name = "tsmiAddComment";
            tsmiAddComment.Size = new System.Drawing.Size(166, 22);
            tsmiAddComment.Text = "Add comment";
            tsmiAddComment.DropDownOpening += TsmiAddComment_DropDownOpening;
            // 
            // tsmiOpenMap
            // 
            tsmiOpenMap.Image = Properties.Resources.map_creator;
            tsmiOpenMap.Name = "tsmiOpenMap";
            tsmiOpenMap.Size = new System.Drawing.Size(145, 22);
            tsmiOpenMap.Text = "Open map";
            // 
            // tsmiOpenCamera
            // 
            tsmiOpenCamera.Image = Properties.Resources.camera;
            tsmiOpenCamera.Name = "tsmiOpenCamera";
            tsmiOpenCamera.Size = new System.Drawing.Size(145, 22);
            tsmiOpenCamera.Text = "Open camera";
            // 
            // tsmiAddFunctionality
            // 
            tsmiAddFunctionality.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiOpenCamera, tsmiOpenMap });
            tsmiAddFunctionality.Image = Properties.Resources.link;
            tsmiAddFunctionality.Name = "tsmiAddFunctionality";
            tsmiAddFunctionality.Size = new System.Drawing.Size(166, 22);
            tsmiAddFunctionality.Text = "Add functionality";
            // 
            // tsmiBrowse
            // 
            tsmiBrowse.Image = Properties.Resources.folder;
            tsmiBrowse.Name = "tsmiBrowse";
            tsmiBrowse.Size = new System.Drawing.Size(121, 22);
            tsmiBrowse.Text = "Browse…";
            tsmiBrowse.Click += TsmiBrowse_Click;
            // 
            // tsmiMapIcon
            // 
            tsmiMapIcon.Image = Properties.Resources.map_creator;
            tsmiMapIcon.Name = "tsmiMapIcon";
            tsmiMapIcon.Size = new System.Drawing.Size(121, 22);
            tsmiMapIcon.Text = "Map";
            tsmiMapIcon.Click += TsmiMapIcon_Click;
            // 
            // tsmiCameraIcon
            // 
            tsmiCameraIcon.Image = Properties.Resources.camera;
            tsmiCameraIcon.Name = "tsmiCameraIcon";
            tsmiCameraIcon.Size = new System.Drawing.Size(121, 22);
            tsmiCameraIcon.Text = "Camera";
            tsmiCameraIcon.Click += TsmiCameraIcon_Click;
            // 
            // tsmiAddImage
            // 
            tsmiAddImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiCameraIcon, tsmiMapIcon, tsmiBrowse });
            tsmiAddImage.Image = Properties.Resources.templates;
            tsmiAddImage.Name = "tsmiAddImage";
            tsmiAddImage.Size = new System.Drawing.Size(166, 22);
            tsmiAddImage.Text = "Add image";
            // 
            // cmsObjectMenu
            // 
            cmsObjectMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiAddImage, tsmiAddFunctionality, tsmiAddComment, tsmiDelete });
            cmsObjectMenu.Name = "cms_ObjectMenu";
            cmsObjectMenu.Size = new System.Drawing.Size(167, 92);
            // 
            // pTemplate
            // 
            pTemplate.BackColor = System.Drawing.Color.Gold;
            pTemplate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pTemplate.CanMove = false;
            pTemplate.CanSize = true;
            pTemplate.Location = new System.Drawing.Point(39, 22);
            pTemplate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pTemplate.Name = "pTemplate";
            pTemplate.Size = new System.Drawing.Size(63, 48);
            pTemplate.TabIndex = 8;
            pTemplate.TransparentColor = System.Drawing.Color.Black;
            pTemplate.UseTransparentColor = false;
            pTemplate.MouseDown += PTemplate_MouseDown;
            pTemplate.MouseUp += PTemplate_MouseUp;
            // 
            // gbTools
            // 
            gbTools.Controls.Add(btnNewMap);
            gbTools.Controls.Add(pTemplate);
            gbTools.Controls.Add(btnDeleteMap);
            gbTools.Controls.Add(cbMap);
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
            gbTools.Size = new System.Drawing.Size(929, 177);
            gbTools.TabIndex = 0;
            gbTools.TabStop = false;
            gbTools.Text = "Tools";
            // 
            // btnNewMap
            // 
            btnNewMap.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnNewMap.Enabled = false;
            btnNewMap.Location = new System.Drawing.Point(418, 142);
            btnNewMap.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnNewMap.Name = "btnNewMap";
            btnNewMap.Size = new System.Drawing.Size(119, 27);
            btnNewMap.TabIndex = 9;
            btnNewMap.Text = "Clear canvas";
            btnNewMap.UseVisualStyleBackColor = true;
            btnNewMap.Click += BtnNewMap_Click;
            // 
            // btnLoadImage
            // 
            btnLoadImage.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnLoadImage.Location = new System.Drawing.Point(545, 142);
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
            pCanvas.AllowDrop = true;
            pCanvas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            pCanvas.Location = new System.Drawing.Point(0, 177);
            pCanvas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pCanvas.Name = "pCanvas";
            pCanvas.Size = new System.Drawing.Size(929, 484);
            pCanvas.TabIndex = 0;
            pCanvas.BackgroundImageChanged += PCanvas_BackgroundImageChanged;
            pCanvas.DragDrop += PCanvas_DragDrop;
            pCanvas.DragEnter += PCanvas_DragEnter;
            pCanvas.Resize += PCanvas_Resize;
            // 
            // pTools
            // 
            pTools.Controls.Add(gbTools);
            pTools.Dock = System.Windows.Forms.DockStyle.Top;
            pTools.Location = new System.Drawing.Point(0, 0);
            pTools.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pTools.Name = "pTools";
            pTools.Size = new System.Drawing.Size(929, 177);
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
            pMain.Size = new System.Drawing.Size(929, 661);
            pMain.TabIndex = 1;
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.ico;*.tiff;*.emf;*.wmf|BMP files|*.bmp|JPEG files|*.jpg;*.jpeg|PNG files|*.png";
            // 
            // MapCreator
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(929, 661);
            Controls.Add(pMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(824, 700);
            Name = "MapCreator";
            Text = "Map creator";
            Shown += MapCreator_Shown;
            cmsObjectMenu.ResumeLayout(false);
            gbTools.ResumeLayout(false);
            gbTools.PerformLayout();
            pTools.ResumeLayout(false);
            pMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ImageList ilImages;
        private System.Windows.Forms.Button btnDeleteMap;
        private System.Windows.Forms.ComboBox cbMap;
        private System.Windows.Forms.Button btnAddObject;
        private System.Windows.Forms.RichTextBox rtbComment;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblMapName;
        private System.Windows.Forms.Button btnSaveMap;
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
        private Mtf.Controls.MovableSizablePanel pTemplate;
        private System.Windows.Forms.GroupBox gbTools;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Panel pCanvas;
        private System.Windows.Forms.Panel pTools;
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnNewMap;
    }
}
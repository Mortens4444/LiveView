namespace LiveView.Forms
{
    partial class AddGroup
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
            var listViewGroup1 = new System.Windows.Forms.ListViewGroup("Operations", System.Windows.Forms.HorizontalAlignment.Left);
            var listViewGroup2 = new System.Windows.Forms.ListViewGroup("Cameras", System.Windows.Forms.HorizontalAlignment.Left);
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(AddGroup));
            var listViewGroup3 = new System.Windows.Forms.ListViewGroup("Operations", System.Windows.Forms.HorizontalAlignment.Left);
            var listViewGroup4 = new System.Windows.Forms.ListViewGroup("Cameras", System.Windows.Forms.HorizontalAlignment.Left);
            pMain = new System.Windows.Forms.Panel();
            gbPermissions = new System.Windows.Forms.GroupBox();
            lblUserEvents = new System.Windows.Forms.Label();
            btnDeleteEvent = new System.Windows.Forms.Button();
            btnSelectAllCameras = new System.Windows.Forms.Button();
            btnModifyEvent = new System.Windows.Forms.Button();
            btnSelectAllOperation = new System.Windows.Forms.Button();
            btnCreateEvent = new System.Windows.Forms.Button();
            lvSelectableOperationsAndCameras = new Mtf.Controls.MtfListView();
            chSelectableOperationsAndCameras = new System.Windows.Forms.ColumnHeader();
            ilImages = new System.Windows.Forms.ImageList(components);
            tbUserEventNote = new System.Windows.Forms.TextBox();
            lvExecuteableOperationsAndVisibleCameras = new Mtf.Controls.MtfListView();
            chExecuteableOperationsAndVisibleCameras = new System.Windows.Forms.ColumnHeader();
            lblNote2 = new System.Windows.Forms.Label();
            lblEventName = new System.Windows.Forms.Label();
            cbEvents = new System.Windows.Forms.ComboBox();
            btnRemoveAll = new System.Windows.Forms.Button();
            btnRemoveSelected = new System.Windows.Forms.Button();
            btnAddAll = new System.Windows.Forms.Button();
            btnAddSelected = new System.Windows.Forms.Button();
            btnClose = new System.Windows.Forms.Button();
            btnSavePermissions = new System.Windows.Forms.Button();
            gbGeneralDetails = new System.Windows.Forms.GroupBox();
            btnCreateOrModifyGroup = new System.Windows.Forms.Button();
            tbGroupNote = new System.Windows.Forms.TextBox();
            lblNote = new System.Windows.Forms.Label();
            tbGroupName = new System.Windows.Forms.TextBox();
            lblGroupname = new System.Windows.Forms.Label();
            niModifyIcon = new System.Windows.Forms.NotifyIcon(components);
            pMain.SuspendLayout();
            gbPermissions.SuspendLayout();
            gbGeneralDetails.SuspendLayout();
            SuspendLayout();
            // 
            // pMain
            // 
            pMain.Controls.Add(gbPermissions);
            pMain.Controls.Add(btnClose);
            pMain.Controls.Add(btnSavePermissions);
            pMain.Controls.Add(gbGeneralDetails);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(664, 500);
            pMain.TabIndex = 0;
            // 
            // gbPermissions
            // 
            gbPermissions.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gbPermissions.Controls.Add(lblUserEvents);
            gbPermissions.Controls.Add(btnDeleteEvent);
            gbPermissions.Controls.Add(btnSelectAllCameras);
            gbPermissions.Controls.Add(btnModifyEvent);
            gbPermissions.Controls.Add(btnSelectAllOperation);
            gbPermissions.Controls.Add(btnCreateEvent);
            gbPermissions.Controls.Add(lvSelectableOperationsAndCameras);
            gbPermissions.Controls.Add(tbUserEventNote);
            gbPermissions.Controls.Add(lvExecuteableOperationsAndVisibleCameras);
            gbPermissions.Controls.Add(lblNote2);
            gbPermissions.Controls.Add(lblEventName);
            gbPermissions.Controls.Add(cbEvents);
            gbPermissions.Controls.Add(btnRemoveAll);
            gbPermissions.Controls.Add(btnRemoveSelected);
            gbPermissions.Controls.Add(btnAddAll);
            gbPermissions.Controls.Add(btnAddSelected);
            gbPermissions.Location = new System.Drawing.Point(0, 104);
            gbPermissions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbPermissions.Name = "gbPermissions";
            gbPermissions.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbPermissions.Size = new System.Drawing.Size(664, 360);
            gbPermissions.TabIndex = 5;
            gbPermissions.TabStop = false;
            gbPermissions.Text = "Permissions";
            // 
            // lblUserEvents
            // 
            lblUserEvents.AutoSize = true;
            lblUserEvents.Location = new System.Drawing.Point(14, 18);
            lblUserEvents.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblUserEvents.Name = "lblUserEvents";
            lblUserEvents.Size = new System.Drawing.Size(67, 15);
            lblUserEvents.TabIndex = 9;
            lblUserEvents.Text = "User events";
            // 
            // btnDeleteEvent
            // 
            btnDeleteEvent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnDeleteEvent.Location = new System.Drawing.Point(559, 99);
            btnDeleteEvent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnDeleteEvent.Name = "btnDeleteEvent";
            btnDeleteEvent.Size = new System.Drawing.Size(88, 27);
            btnDeleteEvent.TabIndex = 6;
            btnDeleteEvent.Text = "Delete";
            btnDeleteEvent.UseVisualStyleBackColor = true;
            btnDeleteEvent.Click += BtnDeleteEvent_Click;
            // 
            // btnSelectAllCameras
            // 
            btnSelectAllCameras.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btnSelectAllCameras.Image = Properties.Resources.summa_cam;
            btnSelectAllCameras.Location = new System.Drawing.Point(316, 172);
            btnSelectAllCameras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSelectAllCameras.Name = "btnSelectAllCameras";
            btnSelectAllCameras.Size = new System.Drawing.Size(33, 27);
            btnSelectAllCameras.TabIndex = 3;
            btnSelectAllCameras.UseVisualStyleBackColor = true;
            btnSelectAllCameras.Click += BtnSelectAllCameras_Click;
            // 
            // btnModifyEvent
            // 
            btnModifyEvent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnModifyEvent.Location = new System.Drawing.Point(559, 68);
            btnModifyEvent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnModifyEvent.Name = "btnModifyEvent";
            btnModifyEvent.Size = new System.Drawing.Size(88, 27);
            btnModifyEvent.TabIndex = 5;
            btnModifyEvent.Text = "Modify";
            btnModifyEvent.UseVisualStyleBackColor = true;
            btnModifyEvent.Click += BtnModifyEvent_Click;
            // 
            // btnSelectAllOperation
            // 
            btnSelectAllOperation.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btnSelectAllOperation.Image = Properties.Resources.summa_right;
            btnSelectAllOperation.Location = new System.Drawing.Point(316, 138);
            btnSelectAllOperation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSelectAllOperation.Name = "btnSelectAllOperation";
            btnSelectAllOperation.Size = new System.Drawing.Size(33, 27);
            btnSelectAllOperation.TabIndex = 2;
            btnSelectAllOperation.UseVisualStyleBackColor = true;
            btnSelectAllOperation.Click += BtnSelectAllOperation_Click;
            // 
            // btnCreateEvent
            // 
            btnCreateEvent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCreateEvent.Enabled = false;
            btnCreateEvent.Location = new System.Drawing.Point(559, 37);
            btnCreateEvent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCreateEvent.Name = "btnCreateEvent";
            btnCreateEvent.Size = new System.Drawing.Size(88, 27);
            btnCreateEvent.TabIndex = 4;
            btnCreateEvent.Text = "Create";
            btnCreateEvent.UseVisualStyleBackColor = true;
            btnCreateEvent.Click += BtnCreateEvent_Click;
            // 
            // lvSelectableOperationsAndCameras
            // 
            lvSelectableOperationsAndCameras.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lvSelectableOperationsAndCameras.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lvSelectableOperationsAndCameras.AlternatingColorsAreInUse = true;
            lvSelectableOperationsAndCameras.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lvSelectableOperationsAndCameras.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lvSelectableOperationsAndCameras.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lvSelectableOperationsAndCameras.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { chSelectableOperationsAndCameras });
            lvSelectableOperationsAndCameras.CompactView = false;
            lvSelectableOperationsAndCameras.EnsureLastItemIsVisible = false;
            lvSelectableOperationsAndCameras.FirstItemIsGray = false;
            lvSelectableOperationsAndCameras.FullRowSelect = true;
            listViewGroup1.Header = "Operations";
            listViewGroup1.Name = "Operations";
            listViewGroup2.Header = "Cameras";
            listViewGroup2.Name = "Cameras";
            lvSelectableOperationsAndCameras.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { listViewGroup1, listViewGroup2 });
            lvSelectableOperationsAndCameras.Location = new System.Drawing.Point(4, 138);
            lvSelectableOperationsAndCameras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lvSelectableOperationsAndCameras.Name = "lvSelectableOperationsAndCameras";
            lvSelectableOperationsAndCameras.OwnerDraw = true;
            lvSelectableOperationsAndCameras.ReadonlyCheckboxes = false;
            lvSelectableOperationsAndCameras.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lvSelectableOperationsAndCameras.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lvSelectableOperationsAndCameras.Size = new System.Drawing.Size(302, 214);
            lvSelectableOperationsAndCameras.SmallImageList = ilImages;
            lvSelectableOperationsAndCameras.TabIndex = 1;
            lvSelectableOperationsAndCameras.Tag = "307; 120";
            lvSelectableOperationsAndCameras.UseCompatibleStateImageBehavior = false;
            lvSelectableOperationsAndCameras.View = System.Windows.Forms.View.Details;
            // 
            // chSelectableOperationsAndCameras
            // 
            chSelectableOperationsAndCameras.Text = "Selectable operations and cameras";
            chSelectableOperationsAndCameras.Width = 270;
            // 
            // ilImages
            // 
            ilImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            ilImages.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ilImages.ImageStream");
            ilImages.TransparentColor = System.Drawing.Color.Transparent;
            ilImages.Images.SetKeyName(0, "key.ico");
            ilImages.Images.SetKeyName(1, "cam 0.ico");
            // 
            // tbUserEventNote
            // 
            tbUserEventNote.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbUserEventNote.Location = new System.Drawing.Point(158, 70);
            tbUserEventNote.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbUserEventNote.MaxLength = 5000;
            tbUserEventNote.Multiline = true;
            tbUserEventNote.Name = "tbUserEventNote";
            tbUserEventNote.Size = new System.Drawing.Size(394, 55);
            tbUserEventNote.TabIndex = 3;
            // 
            // lvExecuteableOperationsAndVisibleCameras
            // 
            lvExecuteableOperationsAndVisibleCameras.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lvExecuteableOperationsAndVisibleCameras.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lvExecuteableOperationsAndVisibleCameras.AlternatingColorsAreInUse = true;
            lvExecuteableOperationsAndVisibleCameras.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lvExecuteableOperationsAndVisibleCameras.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lvExecuteableOperationsAndVisibleCameras.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lvExecuteableOperationsAndVisibleCameras.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { chExecuteableOperationsAndVisibleCameras });
            lvExecuteableOperationsAndVisibleCameras.CompactView = false;
            lvExecuteableOperationsAndVisibleCameras.EnsureLastItemIsVisible = false;
            lvExecuteableOperationsAndVisibleCameras.FirstItemIsGray = false;
            lvExecuteableOperationsAndVisibleCameras.FullRowSelect = true;
            listViewGroup3.Header = "Operations";
            listViewGroup3.Name = "Operations2";
            listViewGroup4.Header = "Cameras";
            listViewGroup4.Name = "Cameras2";
            lvExecuteableOperationsAndVisibleCameras.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { listViewGroup3, listViewGroup4 });
            lvExecuteableOperationsAndVisibleCameras.Location = new System.Drawing.Point(358, 138);
            lvExecuteableOperationsAndVisibleCameras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lvExecuteableOperationsAndVisibleCameras.Name = "lvExecuteableOperationsAndVisibleCameras";
            lvExecuteableOperationsAndVisibleCameras.OwnerDraw = true;
            lvExecuteableOperationsAndVisibleCameras.ReadonlyCheckboxes = false;
            lvExecuteableOperationsAndVisibleCameras.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lvExecuteableOperationsAndVisibleCameras.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lvExecuteableOperationsAndVisibleCameras.Size = new System.Drawing.Size(302, 214);
            lvExecuteableOperationsAndVisibleCameras.SmallImageList = ilImages;
            lvExecuteableOperationsAndVisibleCameras.TabIndex = 8;
            lvExecuteableOperationsAndVisibleCameras.Tag = "3; 120";
            lvExecuteableOperationsAndVisibleCameras.UseCompatibleStateImageBehavior = false;
            lvExecuteableOperationsAndVisibleCameras.View = System.Windows.Forms.View.Details;
            // 
            // chExecuteableOperationsAndVisibleCameras
            // 
            chExecuteableOperationsAndVisibleCameras.Text = "Executable operations and visible cameras";
            chExecuteableOperationsAndVisibleCameras.Width = 270;
            // 
            // lblNote2
            // 
            lblNote2.AutoSize = true;
            lblNote2.Location = new System.Drawing.Point(14, 74);
            lblNote2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblNote2.MaximumSize = new System.Drawing.Size(136, 15);
            lblNote2.Name = "lblNote2";
            lblNote2.Size = new System.Drawing.Size(33, 15);
            lblNote2.TabIndex = 2;
            lblNote2.Text = "Note";
            // 
            // lblEventName
            // 
            lblEventName.AutoSize = true;
            lblEventName.Location = new System.Drawing.Point(14, 43);
            lblEventName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblEventName.MaximumSize = new System.Drawing.Size(136, 15);
            lblEventName.Name = "lblEventName";
            lblEventName.Size = new System.Drawing.Size(69, 15);
            lblEventName.TabIndex = 0;
            lblEventName.Text = "Event name";
            // 
            // cbEvents
            // 
            cbEvents.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbEvents.FormattingEnabled = true;
            cbEvents.Location = new System.Drawing.Point(158, 39);
            cbEvents.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbEvents.Name = "cbEvents";
            cbEvents.Size = new System.Drawing.Size(394, 23);
            cbEvents.TabIndex = 1;
            cbEvents.SelectedIndexChanged += CbEvents_SelectedIndexChanged;
            // 
            // btnRemoveAll
            // 
            btnRemoveAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btnRemoveAll.Image = Properties.Resources.summa_del;
            btnRemoveAll.Location = new System.Drawing.Point(316, 323);
            btnRemoveAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnRemoveAll.Name = "btnRemoveAll";
            btnRemoveAll.Size = new System.Drawing.Size(33, 27);
            btnRemoveAll.TabIndex = 7;
            btnRemoveAll.UseVisualStyleBackColor = true;
            btnRemoveAll.Click += BtnRemoveAll_Click;
            // 
            // btnRemoveSelected
            // 
            btnRemoveSelected.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btnRemoveSelected.Image = Properties.Resources.del;
            btnRemoveSelected.Location = new System.Drawing.Point(316, 290);
            btnRemoveSelected.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnRemoveSelected.Name = "btnRemoveSelected";
            btnRemoveSelected.Size = new System.Drawing.Size(33, 27);
            btnRemoveSelected.TabIndex = 6;
            btnRemoveSelected.UseVisualStyleBackColor = true;
            btnRemoveSelected.Click += BtnRemoveSelected_Click;
            // 
            // btnAddAll
            // 
            btnAddAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btnAddAll.Image = Properties.Resources.summa_add;
            btnAddAll.Location = new System.Drawing.Point(316, 256);
            btnAddAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAddAll.Name = "btnAddAll";
            btnAddAll.Size = new System.Drawing.Size(33, 27);
            btnAddAll.TabIndex = 5;
            btnAddAll.UseVisualStyleBackColor = true;
            btnAddAll.Click += BtnAddAll_Click;
            // 
            // btnAddSelected
            // 
            btnAddSelected.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btnAddSelected.Image = Properties.Resources.add;
            btnAddSelected.Location = new System.Drawing.Point(316, 223);
            btnAddSelected.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAddSelected.Name = "btnAddSelected";
            btnAddSelected.Size = new System.Drawing.Size(33, 27);
            btnAddSelected.TabIndex = 4;
            btnAddSelected.UseVisualStyleBackColor = true;
            btnAddSelected.Click += BtnAddSelected_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.Location = new System.Drawing.Point(569, 467);
            btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(88, 27);
            btnClose.TabIndex = 7;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            // 
            // btnSavePermissions
            // 
            btnSavePermissions.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSavePermissions.Location = new System.Drawing.Point(354, 467);
            btnSavePermissions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSavePermissions.Name = "btnSavePermissions";
            btnSavePermissions.Size = new System.Drawing.Size(208, 27);
            btnSavePermissions.TabIndex = 6;
            btnSavePermissions.Text = "Save permissions";
            btnSavePermissions.UseVisualStyleBackColor = true;
            btnSavePermissions.Click += BtnSavePermissions_Click;
            // 
            // gbGeneralDetails
            // 
            gbGeneralDetails.Controls.Add(btnCreateOrModifyGroup);
            gbGeneralDetails.Controls.Add(tbGroupNote);
            gbGeneralDetails.Controls.Add(lblNote);
            gbGeneralDetails.Controls.Add(tbGroupName);
            gbGeneralDetails.Controls.Add(lblGroupname);
            gbGeneralDetails.Dock = System.Windows.Forms.DockStyle.Top;
            gbGeneralDetails.Location = new System.Drawing.Point(0, 0);
            gbGeneralDetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbGeneralDetails.Name = "gbGeneralDetails";
            gbGeneralDetails.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbGeneralDetails.Size = new System.Drawing.Size(664, 103);
            gbGeneralDetails.TabIndex = 4;
            gbGeneralDetails.TabStop = false;
            gbGeneralDetails.Text = "General details";
            // 
            // btnCreateOrModifyGroup
            // 
            btnCreateOrModifyGroup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCreateOrModifyGroup.Location = new System.Drawing.Point(559, 13);
            btnCreateOrModifyGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCreateOrModifyGroup.Name = "btnCreateOrModifyGroup";
            btnCreateOrModifyGroup.Size = new System.Drawing.Size(88, 27);
            btnCreateOrModifyGroup.TabIndex = 4;
            btnCreateOrModifyGroup.Text = "Create";
            btnCreateOrModifyGroup.UseVisualStyleBackColor = true;
            btnCreateOrModifyGroup.Click += BtnCreateOrModifyGroup_Click;
            // 
            // tbGroupNote
            // 
            tbGroupNote.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbGroupNote.Location = new System.Drawing.Point(158, 42);
            tbGroupNote.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbGroupNote.MaxLength = 5000;
            tbGroupNote.Multiline = true;
            tbGroupNote.Name = "tbGroupNote";
            tbGroupNote.Size = new System.Drawing.Size(394, 54);
            tbGroupNote.TabIndex = 3;
            // 
            // lblNote
            // 
            lblNote.AutoSize = true;
            lblNote.Location = new System.Drawing.Point(14, 45);
            lblNote.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblNote.MaximumSize = new System.Drawing.Size(136, 15);
            lblNote.Name = "lblNote";
            lblNote.Size = new System.Drawing.Size(33, 15);
            lblNote.TabIndex = 2;
            lblNote.Text = "Note";
            // 
            // tbGroupName
            // 
            tbGroupName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbGroupName.Location = new System.Drawing.Point(158, 15);
            tbGroupName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbGroupName.MaxLength = 100;
            tbGroupName.Name = "tbGroupName";
            tbGroupName.Size = new System.Drawing.Size(394, 23);
            tbGroupName.TabIndex = 1;
            // 
            // lblGroupname
            // 
            lblGroupname.AutoSize = true;
            lblGroupname.Location = new System.Drawing.Point(14, 18);
            lblGroupname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblGroupname.MaximumSize = new System.Drawing.Size(136, 15);
            lblGroupname.Name = "lblGroupname";
            lblGroupname.Size = new System.Drawing.Size(73, 15);
            lblGroupname.TabIndex = 0;
            lblGroupname.Text = "Group name";
            // 
            // niModifyIcon
            // 
            niModifyIcon.Text = "ModifyIcon";
            // 
            // AddGroup
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(664, 500);
            Controls.Add(pMain);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(670, 525);
            Name = "AddGroup";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Add group";
            TopMost = true;
            Shown += AddGroup_Shown;
            pMain.ResumeLayout(false);
            gbPermissions.ResumeLayout(false);
            gbPermissions.PerformLayout();
            gbGeneralDetails.ResumeLayout(false);
            gbGeneralDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.GroupBox gbPermissions;
        private System.Windows.Forms.Label lblUserEvents;
        private System.Windows.Forms.Button btnDeleteEvent;
        private System.Windows.Forms.Button btnSelectAllCameras;
        private System.Windows.Forms.Button btnModifyEvent;
        private System.Windows.Forms.Button btnSelectAllOperation;
        private System.Windows.Forms.Button btnCreateEvent;
        private Mtf.Controls.MtfListView lvSelectableOperationsAndCameras;
        private System.Windows.Forms.ColumnHeader chSelectableOperationsAndCameras;
        private System.Windows.Forms.ImageList ilImages;
        private System.Windows.Forms.TextBox tbUserEventNote;
        private Mtf.Controls.MtfListView lvExecuteableOperationsAndVisibleCameras;
        private System.Windows.Forms.ColumnHeader chExecuteableOperationsAndVisibleCameras;
        private System.Windows.Forms.Label lblNote2;
        private System.Windows.Forms.Label lblEventName;
        private System.Windows.Forms.ComboBox cbEvents;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnRemoveSelected;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.Button btnAddSelected;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSavePermissions;
        private System.Windows.Forms.GroupBox gbGeneralDetails;
        private System.Windows.Forms.Button btnCreateOrModifyGroup;
        private System.Windows.Forms.TextBox tbGroupNote;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox tbGroupName;
        private System.Windows.Forms.Label lblGroupname;
        private System.Windows.Forms.NotifyIcon niModifyIcon;
    }
}
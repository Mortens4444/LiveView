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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(AddGroup));
            pMain = new System.Windows.Forms.Panel();
            gb_Permissions = new System.Windows.Forms.GroupBox();
            lbl_UserEvents = new System.Windows.Forms.Label();
            btn_DeleteEvent = new System.Windows.Forms.Button();
            btn_SelectAllCameras = new System.Windows.Forms.Button();
            btn_ModifyEvent = new System.Windows.Forms.Button();
            btn_SelectAllOperation = new System.Windows.Forms.Button();
            btn_CreateEvent = new System.Windows.Forms.Button();
            lv_SelectableOperationsAndCameras = new Mtf.Controls.MtfListView();
            ch_SelectableOperationsAndCameras = new System.Windows.Forms.ColumnHeader();
            il_Images = new System.Windows.Forms.ImageList(components);
            tb_Note2 = new System.Windows.Forms.TextBox();
            lv_ExecuteableOperationsAndVisibleCameras = new Mtf.Controls.MtfListView();
            ch_ExecuteableOperationsAndVisibleCameras = new System.Windows.Forms.ColumnHeader();
            lbl_Note2 = new System.Windows.Forms.Label();
            lbl_EventName = new System.Windows.Forms.Label();
            cb_EventName = new System.Windows.Forms.ComboBox();
            btn_RemoveAll = new System.Windows.Forms.Button();
            btn_RemoveSelected = new System.Windows.Forms.Button();
            btn_AddAll = new System.Windows.Forms.Button();
            btn_AddSelected = new System.Windows.Forms.Button();
            btn_Close = new System.Windows.Forms.Button();
            btn_SavePermissions = new System.Windows.Forms.Button();
            gb_GeneralDetails = new System.Windows.Forms.GroupBox();
            btn_CreateOrModifyGroup = new System.Windows.Forms.Button();
            tb_Note = new System.Windows.Forms.TextBox();
            lbl_Note = new System.Windows.Forms.Label();
            tb_Groupname = new System.Windows.Forms.TextBox();
            lbl_Groupname = new System.Windows.Forms.Label();
            ni_ModifyIcon = new System.Windows.Forms.NotifyIcon(components);
            pMain.SuspendLayout();
            gb_Permissions.SuspendLayout();
            gb_GeneralDetails.SuspendLayout();
            SuspendLayout();
            // 
            // pMain
            // 
            pMain.Controls.Add(gb_Permissions);
            pMain.Controls.Add(btn_Close);
            pMain.Controls.Add(btn_SavePermissions);
            pMain.Controls.Add(gb_GeneralDetails);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(664, 500);
            pMain.TabIndex = 0;
            // 
            // gb_Permissions
            // 
            gb_Permissions.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gb_Permissions.Controls.Add(lbl_UserEvents);
            gb_Permissions.Controls.Add(btn_DeleteEvent);
            gb_Permissions.Controls.Add(btn_SelectAllCameras);
            gb_Permissions.Controls.Add(btn_ModifyEvent);
            gb_Permissions.Controls.Add(btn_SelectAllOperation);
            gb_Permissions.Controls.Add(btn_CreateEvent);
            gb_Permissions.Controls.Add(lv_SelectableOperationsAndCameras);
            gb_Permissions.Controls.Add(tb_Note2);
            gb_Permissions.Controls.Add(lv_ExecuteableOperationsAndVisibleCameras);
            gb_Permissions.Controls.Add(lbl_Note2);
            gb_Permissions.Controls.Add(lbl_EventName);
            gb_Permissions.Controls.Add(cb_EventName);
            gb_Permissions.Controls.Add(btn_RemoveAll);
            gb_Permissions.Controls.Add(btn_RemoveSelected);
            gb_Permissions.Controls.Add(btn_AddAll);
            gb_Permissions.Controls.Add(btn_AddSelected);
            gb_Permissions.Location = new System.Drawing.Point(0, 104);
            gb_Permissions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Permissions.Name = "gb_Permissions";
            gb_Permissions.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Permissions.Size = new System.Drawing.Size(664, 360);
            gb_Permissions.TabIndex = 5;
            gb_Permissions.TabStop = false;
            gb_Permissions.Text = "Permissions";
            // 
            // lbl_UserEvents
            // 
            lbl_UserEvents.AutoSize = true;
            lbl_UserEvents.Location = new System.Drawing.Point(14, 18);
            lbl_UserEvents.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_UserEvents.Name = "lbl_UserEvents";
            lbl_UserEvents.Size = new System.Drawing.Size(67, 15);
            lbl_UserEvents.TabIndex = 9;
            lbl_UserEvents.Text = "User events";
            // 
            // btn_DeleteEvent
            // 
            btn_DeleteEvent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_DeleteEvent.Location = new System.Drawing.Point(559, 99);
            btn_DeleteEvent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_DeleteEvent.Name = "btn_DeleteEvent";
            btn_DeleteEvent.Size = new System.Drawing.Size(88, 27);
            btn_DeleteEvent.TabIndex = 6;
            btn_DeleteEvent.Text = "Delete";
            btn_DeleteEvent.UseVisualStyleBackColor = true;
            // 
            // btn_SelectAllCameras
            // 
            btn_SelectAllCameras.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btn_SelectAllCameras.Image = (System.Drawing.Image)resources.GetObject("btn_SelectAllCameras.Image");
            btn_SelectAllCameras.Location = new System.Drawing.Point(316, 172);
            btn_SelectAllCameras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_SelectAllCameras.Name = "btn_SelectAllCameras";
            btn_SelectAllCameras.Size = new System.Drawing.Size(33, 27);
            btn_SelectAllCameras.TabIndex = 3;
            btn_SelectAllCameras.UseVisualStyleBackColor = true;
            // 
            // btn_ModifyEvent
            // 
            btn_ModifyEvent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_ModifyEvent.Location = new System.Drawing.Point(559, 68);
            btn_ModifyEvent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_ModifyEvent.Name = "btn_ModifyEvent";
            btn_ModifyEvent.Size = new System.Drawing.Size(88, 27);
            btn_ModifyEvent.TabIndex = 5;
            btn_ModifyEvent.Text = "Modify";
            btn_ModifyEvent.UseVisualStyleBackColor = true;
            // 
            // btn_SelectAllOperation
            // 
            btn_SelectAllOperation.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btn_SelectAllOperation.Image = (System.Drawing.Image)resources.GetObject("btn_SelectAllOperation.Image");
            btn_SelectAllOperation.Location = new System.Drawing.Point(316, 138);
            btn_SelectAllOperation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_SelectAllOperation.Name = "btn_SelectAllOperation";
            btn_SelectAllOperation.Size = new System.Drawing.Size(33, 27);
            btn_SelectAllOperation.TabIndex = 2;
            btn_SelectAllOperation.UseVisualStyleBackColor = true;
            // 
            // btn_CreateEvent
            // 
            btn_CreateEvent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_CreateEvent.Enabled = false;
            btn_CreateEvent.Location = new System.Drawing.Point(559, 37);
            btn_CreateEvent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_CreateEvent.Name = "btn_CreateEvent";
            btn_CreateEvent.Size = new System.Drawing.Size(88, 27);
            btn_CreateEvent.TabIndex = 4;
            btn_CreateEvent.Text = "Create";
            btn_CreateEvent.UseVisualStyleBackColor = true;
            // 
            // lv_SelectableOperationsAndCameras
            // 
            lv_SelectableOperationsAndCameras.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lv_SelectableOperationsAndCameras.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lv_SelectableOperationsAndCameras.AlternatingColorsAreInUse = true;
            lv_SelectableOperationsAndCameras.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lv_SelectableOperationsAndCameras.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lv_SelectableOperationsAndCameras.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lv_SelectableOperationsAndCameras.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { ch_SelectableOperationsAndCameras });
            lv_SelectableOperationsAndCameras.CompactView = false;
            lv_SelectableOperationsAndCameras.EnsureLastItemIsVisible = false;
            lv_SelectableOperationsAndCameras.FirstItemIsGray = false;
            lv_SelectableOperationsAndCameras.FullRowSelect = true;
            lv_SelectableOperationsAndCameras.Location = new System.Drawing.Point(4, 138);
            lv_SelectableOperationsAndCameras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lv_SelectableOperationsAndCameras.Name = "lv_SelectableOperationsAndCameras";
            lv_SelectableOperationsAndCameras.OwnerDraw = true;
            lv_SelectableOperationsAndCameras.ReadonlyCheckboxes = false;
            lv_SelectableOperationsAndCameras.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lv_SelectableOperationsAndCameras.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lv_SelectableOperationsAndCameras.Size = new System.Drawing.Size(302, 214);
            lv_SelectableOperationsAndCameras.SmallImageList = il_Images;
            lv_SelectableOperationsAndCameras.TabIndex = 1;
            lv_SelectableOperationsAndCameras.Tag = "307; 120";
            lv_SelectableOperationsAndCameras.UseCompatibleStateImageBehavior = false;
            lv_SelectableOperationsAndCameras.View = System.Windows.Forms.View.Details;
            // 
            // ch_SelectableOperationsAndCameras
            // 
            ch_SelectableOperationsAndCameras.Text = "Selectable operations and cameras";
            ch_SelectableOperationsAndCameras.Width = 270;
            // 
            // il_Images
            // 
            il_Images.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            il_Images.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("il_Images.ImageStream");
            il_Images.TransparentColor = System.Drawing.Color.Transparent;
            il_Images.Images.SetKeyName(0, "key.ico");
            il_Images.Images.SetKeyName(1, "cam 0.ico");
            // 
            // tb_Note2
            // 
            tb_Note2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_Note2.Location = new System.Drawing.Point(158, 70);
            tb_Note2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_Note2.MaxLength = 5000;
            tb_Note2.Multiline = true;
            tb_Note2.Name = "tb_Note2";
            tb_Note2.Size = new System.Drawing.Size(394, 55);
            tb_Note2.TabIndex = 3;
            // 
            // lv_ExecuteableOperationsAndVisibleCameras
            // 
            lv_ExecuteableOperationsAndVisibleCameras.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lv_ExecuteableOperationsAndVisibleCameras.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lv_ExecuteableOperationsAndVisibleCameras.AlternatingColorsAreInUse = true;
            lv_ExecuteableOperationsAndVisibleCameras.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lv_ExecuteableOperationsAndVisibleCameras.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lv_ExecuteableOperationsAndVisibleCameras.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lv_ExecuteableOperationsAndVisibleCameras.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { ch_ExecuteableOperationsAndVisibleCameras });
            lv_ExecuteableOperationsAndVisibleCameras.CompactView = false;
            lv_ExecuteableOperationsAndVisibleCameras.EnsureLastItemIsVisible = false;
            lv_ExecuteableOperationsAndVisibleCameras.FirstItemIsGray = false;
            lv_ExecuteableOperationsAndVisibleCameras.FullRowSelect = true;
            lv_ExecuteableOperationsAndVisibleCameras.Location = new System.Drawing.Point(358, 138);
            lv_ExecuteableOperationsAndVisibleCameras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lv_ExecuteableOperationsAndVisibleCameras.Name = "lv_ExecuteableOperationsAndVisibleCameras";
            lv_ExecuteableOperationsAndVisibleCameras.OwnerDraw = true;
            lv_ExecuteableOperationsAndVisibleCameras.ReadonlyCheckboxes = false;
            lv_ExecuteableOperationsAndVisibleCameras.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lv_ExecuteableOperationsAndVisibleCameras.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lv_ExecuteableOperationsAndVisibleCameras.Size = new System.Drawing.Size(302, 214);
            lv_ExecuteableOperationsAndVisibleCameras.SmallImageList = il_Images;
            lv_ExecuteableOperationsAndVisibleCameras.TabIndex = 8;
            lv_ExecuteableOperationsAndVisibleCameras.Tag = "3; 120";
            lv_ExecuteableOperationsAndVisibleCameras.UseCompatibleStateImageBehavior = false;
            lv_ExecuteableOperationsAndVisibleCameras.View = System.Windows.Forms.View.Details;
            // 
            // ch_ExecuteableOperationsAndVisibleCameras
            // 
            ch_ExecuteableOperationsAndVisibleCameras.Text = "Executeable operations and visible cameras";
            ch_ExecuteableOperationsAndVisibleCameras.Width = 270;
            // 
            // lbl_Note2
            // 
            lbl_Note2.AutoSize = true;
            lbl_Note2.Location = new System.Drawing.Point(14, 74);
            lbl_Note2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Note2.MaximumSize = new System.Drawing.Size(136, 15);
            lbl_Note2.Name = "lbl_Note2";
            lbl_Note2.Size = new System.Drawing.Size(33, 15);
            lbl_Note2.TabIndex = 2;
            lbl_Note2.Text = "Note";
            // 
            // lbl_EventName
            // 
            lbl_EventName.AutoSize = true;
            lbl_EventName.Location = new System.Drawing.Point(14, 43);
            lbl_EventName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_EventName.MaximumSize = new System.Drawing.Size(136, 15);
            lbl_EventName.Name = "lbl_EventName";
            lbl_EventName.Size = new System.Drawing.Size(69, 15);
            lbl_EventName.TabIndex = 0;
            lbl_EventName.Text = "Event name";
            // 
            // cb_EventName
            // 
            cb_EventName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cb_EventName.FormattingEnabled = true;
            cb_EventName.Location = new System.Drawing.Point(158, 39);
            cb_EventName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_EventName.Name = "cb_EventName";
            cb_EventName.Size = new System.Drawing.Size(394, 23);
            cb_EventName.TabIndex = 1;
            // 
            // btn_RemoveAll
            // 
            btn_RemoveAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btn_RemoveAll.Image = (System.Drawing.Image)resources.GetObject("btn_RemoveAll.Image");
            btn_RemoveAll.Location = new System.Drawing.Point(316, 323);
            btn_RemoveAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_RemoveAll.Name = "btn_RemoveAll";
            btn_RemoveAll.Size = new System.Drawing.Size(33, 27);
            btn_RemoveAll.TabIndex = 7;
            btn_RemoveAll.UseVisualStyleBackColor = true;
            // 
            // btn_RemoveSelected
            // 
            btn_RemoveSelected.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btn_RemoveSelected.Image = (System.Drawing.Image)resources.GetObject("btn_RemoveSelected.Image");
            btn_RemoveSelected.Location = new System.Drawing.Point(316, 290);
            btn_RemoveSelected.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_RemoveSelected.Name = "btn_RemoveSelected";
            btn_RemoveSelected.Size = new System.Drawing.Size(33, 27);
            btn_RemoveSelected.TabIndex = 6;
            btn_RemoveSelected.UseVisualStyleBackColor = true;
            // 
            // btn_AddAll
            // 
            btn_AddAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btn_AddAll.Image = (System.Drawing.Image)resources.GetObject("btn_AddAll.Image");
            btn_AddAll.Location = new System.Drawing.Point(316, 256);
            btn_AddAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_AddAll.Name = "btn_AddAll";
            btn_AddAll.Size = new System.Drawing.Size(33, 27);
            btn_AddAll.TabIndex = 5;
            btn_AddAll.UseVisualStyleBackColor = true;
            // 
            // btn_AddSelected
            // 
            btn_AddSelected.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btn_AddSelected.Image = (System.Drawing.Image)resources.GetObject("btn_AddSelected.Image");
            btn_AddSelected.Location = new System.Drawing.Point(316, 223);
            btn_AddSelected.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_AddSelected.Name = "btn_AddSelected";
            btn_AddSelected.Size = new System.Drawing.Size(33, 27);
            btn_AddSelected.TabIndex = 4;
            btn_AddSelected.UseVisualStyleBackColor = true;
            // 
            // btn_Close
            // 
            btn_Close.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btn_Close.Location = new System.Drawing.Point(569, 467);
            btn_Close.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Close.Name = "btn_Close";
            btn_Close.Size = new System.Drawing.Size(88, 27);
            btn_Close.TabIndex = 7;
            btn_Close.Text = "Close";
            btn_Close.UseVisualStyleBackColor = true;
            // 
            // btn_SavePermissions
            // 
            btn_SavePermissions.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_SavePermissions.Location = new System.Drawing.Point(354, 467);
            btn_SavePermissions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_SavePermissions.Name = "btn_SavePermissions";
            btn_SavePermissions.Size = new System.Drawing.Size(208, 27);
            btn_SavePermissions.TabIndex = 6;
            btn_SavePermissions.Text = "Save permissions";
            btn_SavePermissions.UseVisualStyleBackColor = true;
            // 
            // gb_GeneralDetails
            // 
            gb_GeneralDetails.Controls.Add(btn_CreateOrModifyGroup);
            gb_GeneralDetails.Controls.Add(tb_Note);
            gb_GeneralDetails.Controls.Add(lbl_Note);
            gb_GeneralDetails.Controls.Add(tb_Groupname);
            gb_GeneralDetails.Controls.Add(lbl_Groupname);
            gb_GeneralDetails.Dock = System.Windows.Forms.DockStyle.Top;
            gb_GeneralDetails.Location = new System.Drawing.Point(0, 0);
            gb_GeneralDetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_GeneralDetails.Name = "gb_GeneralDetails";
            gb_GeneralDetails.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_GeneralDetails.Size = new System.Drawing.Size(664, 103);
            gb_GeneralDetails.TabIndex = 4;
            gb_GeneralDetails.TabStop = false;
            gb_GeneralDetails.Text = "General details";
            // 
            // btn_CreateOrModifyGroup
            // 
            btn_CreateOrModifyGroup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_CreateOrModifyGroup.Location = new System.Drawing.Point(559, 13);
            btn_CreateOrModifyGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_CreateOrModifyGroup.Name = "btn_CreateOrModifyGroup";
            btn_CreateOrModifyGroup.Size = new System.Drawing.Size(88, 27);
            btn_CreateOrModifyGroup.TabIndex = 4;
            btn_CreateOrModifyGroup.Text = "Create";
            btn_CreateOrModifyGroup.UseVisualStyleBackColor = true;
            btn_CreateOrModifyGroup.Click += Btn_CreateOrModifyGroup_Click;
            // 
            // tb_Note
            // 
            tb_Note.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_Note.Location = new System.Drawing.Point(158, 42);
            tb_Note.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_Note.MaxLength = 5000;
            tb_Note.Multiline = true;
            tb_Note.Name = "tb_Note";
            tb_Note.Size = new System.Drawing.Size(394, 54);
            tb_Note.TabIndex = 3;
            // 
            // lbl_Note
            // 
            lbl_Note.AutoSize = true;
            lbl_Note.Location = new System.Drawing.Point(14, 45);
            lbl_Note.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Note.MaximumSize = new System.Drawing.Size(136, 15);
            lbl_Note.Name = "lbl_Note";
            lbl_Note.Size = new System.Drawing.Size(33, 15);
            lbl_Note.TabIndex = 2;
            lbl_Note.Text = "Note";
            // 
            // tb_Groupname
            // 
            tb_Groupname.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_Groupname.Location = new System.Drawing.Point(158, 15);
            tb_Groupname.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_Groupname.MaxLength = 100;
            tb_Groupname.Name = "tb_Groupname";
            tb_Groupname.Size = new System.Drawing.Size(394, 23);
            tb_Groupname.TabIndex = 1;
            // 
            // lbl_Groupname
            // 
            lbl_Groupname.AutoSize = true;
            lbl_Groupname.Location = new System.Drawing.Point(14, 18);
            lbl_Groupname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Groupname.MaximumSize = new System.Drawing.Size(136, 15);
            lbl_Groupname.Name = "lbl_Groupname";
            lbl_Groupname.Size = new System.Drawing.Size(70, 15);
            lbl_Groupname.TabIndex = 0;
            lbl_Groupname.Text = "Groupname";
            // 
            // ni_ModifyIcon
            // 
            ni_ModifyIcon.Icon = (System.Drawing.Icon)resources.GetObject("ni_ModifyIcon.Icon");
            ni_ModifyIcon.Text = "ModifyIcon";
            // 
            // AddGroup
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(664, 500);
            Controls.Add(pMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(670, 525);
            Name = "AddGroup";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Create group";
            TopMost = true;
            pMain.ResumeLayout(false);
            gb_Permissions.ResumeLayout(false);
            gb_Permissions.PerformLayout();
            gb_GeneralDetails.ResumeLayout(false);
            gb_GeneralDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.GroupBox gb_Permissions;
        private System.Windows.Forms.Label lbl_UserEvents;
        private System.Windows.Forms.Button btn_DeleteEvent;
        private System.Windows.Forms.Button btn_SelectAllCameras;
        private System.Windows.Forms.Button btn_ModifyEvent;
        private System.Windows.Forms.Button btn_SelectAllOperation;
        private System.Windows.Forms.Button btn_CreateEvent;
        private Mtf.Controls.MtfListView lv_SelectableOperationsAndCameras;
        private System.Windows.Forms.ColumnHeader ch_SelectableOperationsAndCameras;
        private System.Windows.Forms.ImageList il_Images;
        private System.Windows.Forms.TextBox tb_Note2;
        private Mtf.Controls.MtfListView lv_ExecuteableOperationsAndVisibleCameras;
        private System.Windows.Forms.ColumnHeader ch_ExecuteableOperationsAndVisibleCameras;
        private System.Windows.Forms.Label lbl_Note2;
        private System.Windows.Forms.Label lbl_EventName;
        private System.Windows.Forms.ComboBox cb_EventName;
        private System.Windows.Forms.Button btn_RemoveAll;
        private System.Windows.Forms.Button btn_RemoveSelected;
        private System.Windows.Forms.Button btn_AddAll;
        private System.Windows.Forms.Button btn_AddSelected;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_SavePermissions;
        private System.Windows.Forms.GroupBox gb_GeneralDetails;
        private System.Windows.Forms.Button btn_CreateOrModifyGroup;
        private System.Windows.Forms.TextBox tb_Note;
        private System.Windows.Forms.Label lbl_Note;
        private System.Windows.Forms.TextBox tb_Groupname;
        private System.Windows.Forms.Label lbl_Groupname;
        private System.Windows.Forms.NotifyIcon ni_ModifyIcon;
    }
}
namespace LiveView.Forms
{
    partial class UserAndGroupManagement
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
            var treeNode1 = new System.Windows.Forms.TreeNode("Groups", 0, 0);
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAndGroupManagement));
            gbUsersAndGroups = new System.Windows.Forms.GroupBox();
            tvUsersAndGroups = new Mtf.Controls.MtfTreeView();
            ilImages = new System.Windows.Forms.ImageList(components);
            btnNewGroup = new System.Windows.Forms.Button();
            btnModify = new System.Windows.Forms.Button();
            btnRemove = new System.Windows.Forms.Button();
            btnNewUser = new System.Windows.Forms.Button();
            pMain = new System.Windows.Forms.Panel();
            btnClose = new System.Windows.Forms.Button();
            gbUsersAndGroups.SuspendLayout();
            pMain.SuspendLayout();
            SuspendLayout();
            // 
            // gbUsersAndGroups
            // 
            gbUsersAndGroups.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gbUsersAndGroups.Controls.Add(tvUsersAndGroups);
            gbUsersAndGroups.Controls.Add(btnNewGroup);
            gbUsersAndGroups.Controls.Add(btnModify);
            gbUsersAndGroups.Controls.Add(btnRemove);
            gbUsersAndGroups.Controls.Add(btnNewUser);
            gbUsersAndGroups.Location = new System.Drawing.Point(0, 0);
            gbUsersAndGroups.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbUsersAndGroups.Name = "gbUsersAndGroups";
            gbUsersAndGroups.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbUsersAndGroups.Size = new System.Drawing.Size(750, 423);
            gbUsersAndGroups.TabIndex = 0;
            gbUsersAndGroups.TabStop = false;
            gbUsersAndGroups.Text = "Groups and users";
            // 
            // tvUsersAndGroups
            // 
            tvUsersAndGroups.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tvUsersAndGroups.CheckBoxBackground = System.Drawing.SystemColors.Window;
            tvUsersAndGroups.DrawDefaultImageToNodes = true;
            tvUsersAndGroups.FullRowSelect = true;
            tvUsersAndGroups.HideSelection = false;
            tvUsersAndGroups.ImageIndex = 0;
            tvUsersAndGroups.ImageList = ilImages;
            tvUsersAndGroups.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            tvUsersAndGroups.Location = new System.Drawing.Point(7, 20);
            tvUsersAndGroups.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tvUsersAndGroups.MultiSelect = false;
            tvUsersAndGroups.Name = "tvUsersAndGroups";
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "Groups";
            treeNode1.SelectedImageIndex = 0;
            treeNode1.Text = "Groups";
            tvUsersAndGroups.Nodes.AddRange(new System.Windows.Forms.TreeNode[] { treeNode1 });
            tvUsersAndGroups.SelectedImageIndex = 0;
            tvUsersAndGroups.ShowPlusMinusOnRootNodes = true;
            tvUsersAndGroups.ShowRootLines = false;
            tvUsersAndGroups.Size = new System.Drawing.Size(583, 395);
            tvUsersAndGroups.StateImageOrCheckBoxOnLeft = false;
            tvUsersAndGroups.TabIndex = 0;
            tvUsersAndGroups.TickColor = System.Drawing.Color.Green;
            // 
            // ilImages
            // 
            ilImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            ilImages.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ilImages.ImageStream");
            ilImages.TransparentColor = System.Drawing.Color.Transparent;
            ilImages.Images.SetKeyName(0, "group.ico");
            ilImages.Images.SetKeyName(1, "user.ico");
            ilImages.Images.SetKeyName(2, "group_edit.ico");
            ilImages.Images.SetKeyName(3, "user_edit.ico");
            ilImages.Images.SetKeyName(4, "group_del.ico");
            ilImages.Images.SetKeyName(5, "user_del.ico");
            // 
            // btnNewGroup
            // 
            btnNewGroup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnNewGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnNewGroup.Location = new System.Drawing.Point(597, 20);
            btnNewGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnNewGroup.Name = "btnNewGroup";
            btnNewGroup.Size = new System.Drawing.Size(146, 27);
            btnNewGroup.TabIndex = 1;
            btnNewGroup.Text = "New group";
            btnNewGroup.UseVisualStyleBackColor = true;
            btnNewGroup.Click += BtnNewGroup_Click;
            // 
            // btnModify
            // 
            btnModify.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnModify.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnModify.Location = new System.Drawing.Point(597, 87);
            btnModify.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnModify.Name = "btnModify";
            btnModify.Size = new System.Drawing.Size(146, 27);
            btnModify.TabIndex = 3;
            btnModify.Text = "Modify";
            btnModify.UseVisualStyleBackColor = true;
            btnModify.Click += BtnModify_Click;
            // 
            // btnRemove
            // 
            btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnRemove.Location = new System.Drawing.Point(597, 120);
            btnRemove.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new System.Drawing.Size(146, 27);
            btnRemove.TabIndex = 4;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += BtnRemove_Click;
            // 
            // btnNewUser
            // 
            btnNewUser.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnNewUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnNewUser.Location = new System.Drawing.Point(597, 53);
            btnNewUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnNewUser.Name = "btnNewUser";
            btnNewUser.Size = new System.Drawing.Size(146, 27);
            btnNewUser.TabIndex = 2;
            btnNewUser.Text = "New user";
            btnNewUser.UseVisualStyleBackColor = true;
            btnNewUser.Click += BtnNewUser_Click;
            // 
            // pMain
            // 
            pMain.Controls.Add(btnClose);
            pMain.Controls.Add(gbUsersAndGroups);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(750, 459);
            pMain.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.Location = new System.Drawing.Point(597, 429);
            btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(146, 27);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            // 
            // UserAndGroupManagement
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(750, 459);
            Controls.Add(pMain);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(473, 216);
            Name = "UserAndGroupManagement";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "User and group management";
            TopMost = true;
            Shown += UserAndGroupManagement_Shown;
            gbUsersAndGroups.ResumeLayout(false);
            pMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox gbUsersAndGroups;
        private Mtf.Controls.MtfTreeView tvUsersAndGroups;
        private System.Windows.Forms.ImageList ilImages;
        private System.Windows.Forms.Button btnNewGroup;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnNewUser;
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Button btnClose;
    }
}
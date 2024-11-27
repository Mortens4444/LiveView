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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAndGroupManagement));
            gb_UsersAndGroups = new System.Windows.Forms.GroupBox();
            tv_UsersAndGroups = new Mtf.Controls.MtfTreeView();
            il_Images = new System.Windows.Forms.ImageList(components);
            btn_NewGroup = new System.Windows.Forms.Button();
            btn_Modify = new System.Windows.Forms.Button();
            btn_Remove = new System.Windows.Forms.Button();
            btn_NewUser = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            btn_Close = new System.Windows.Forms.Button();
            gb_UsersAndGroups.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // gb_UsersAndGroups
            // 
            gb_UsersAndGroups.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gb_UsersAndGroups.Controls.Add(tv_UsersAndGroups);
            gb_UsersAndGroups.Controls.Add(btn_NewGroup);
            gb_UsersAndGroups.Controls.Add(btn_Modify);
            gb_UsersAndGroups.Controls.Add(btn_Remove);
            gb_UsersAndGroups.Controls.Add(btn_NewUser);
            gb_UsersAndGroups.Location = new System.Drawing.Point(0, 0);
            gb_UsersAndGroups.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_UsersAndGroups.Name = "gb_UsersAndGroups";
            gb_UsersAndGroups.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_UsersAndGroups.Size = new System.Drawing.Size(750, 423);
            gb_UsersAndGroups.TabIndex = 0;
            gb_UsersAndGroups.TabStop = false;
            gb_UsersAndGroups.Text = "Groups and users";
            // 
            // tv_UsersAndGroups
            // 
            tv_UsersAndGroups.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tv_UsersAndGroups.CheckBoxBackground = System.Drawing.SystemColors.Window;
            tv_UsersAndGroups.DrawDefaultImageToNodes = true;
            tv_UsersAndGroups.FullRowSelect = true;
            tv_UsersAndGroups.HideSelection = false;
            tv_UsersAndGroups.ImageIndex = 0;
            tv_UsersAndGroups.ImageList = il_Images;
            tv_UsersAndGroups.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            tv_UsersAndGroups.Location = new System.Drawing.Point(7, 20);
            tv_UsersAndGroups.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tv_UsersAndGroups.MultiSelect = false;
            tv_UsersAndGroups.Name = "tv_UsersAndGroups";
            tv_UsersAndGroups.SelectedImageIndex = 0;
            tv_UsersAndGroups.ShowPlusMinusOnRootNodes = true;
            tv_UsersAndGroups.ShowRootLines = false;
            tv_UsersAndGroups.Size = new System.Drawing.Size(583, 395);
            tv_UsersAndGroups.StateImageOrCheckBoxOnLeft = false;
            tv_UsersAndGroups.TabIndex = 0;
            tv_UsersAndGroups.TickColor = System.Drawing.Color.Green;
            // 
            // il_Images
            // 
            il_Images.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            il_Images.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("il_Images.ImageStream");
            il_Images.TransparentColor = System.Drawing.Color.Transparent;
            il_Images.Images.SetKeyName(0, "group.ico");
            il_Images.Images.SetKeyName(1, "user.ico");
            il_Images.Images.SetKeyName(2, "group_edit.ico");
            il_Images.Images.SetKeyName(3, "user_edit.ico");
            il_Images.Images.SetKeyName(4, "group_del.ico");
            il_Images.Images.SetKeyName(5, "user_del.ico");
            // 
            // btn_NewGroup
            // 
            btn_NewGroup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_NewGroup.Image = (System.Drawing.Image)resources.GetObject("btn_NewGroup.Image");
            btn_NewGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn_NewGroup.Location = new System.Drawing.Point(597, 20);
            btn_NewGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_NewGroup.Name = "btn_NewGroup";
            btn_NewGroup.Size = new System.Drawing.Size(146, 27);
            btn_NewGroup.TabIndex = 1;
            btn_NewGroup.Text = "New group";
            btn_NewGroup.UseVisualStyleBackColor = true;
            btn_NewGroup.Click += Btn_NewGroup_Click;
            // 
            // btn_Modify
            // 
            btn_Modify.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_Modify.Image = (System.Drawing.Image)resources.GetObject("btn_Modify.Image");
            btn_Modify.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn_Modify.Location = new System.Drawing.Point(597, 87);
            btn_Modify.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Modify.Name = "btn_Modify";
            btn_Modify.Size = new System.Drawing.Size(146, 27);
            btn_Modify.TabIndex = 3;
            btn_Modify.Text = "Modify";
            btn_Modify.UseVisualStyleBackColor = true;
            btn_Modify.Click += Btn_Modify_Click;
            // 
            // btn_Remove
            // 
            btn_Remove.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_Remove.Image = (System.Drawing.Image)resources.GetObject("btn_Remove.Image");
            btn_Remove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn_Remove.Location = new System.Drawing.Point(597, 120);
            btn_Remove.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Remove.Name = "btn_Remove";
            btn_Remove.Size = new System.Drawing.Size(146, 27);
            btn_Remove.TabIndex = 4;
            btn_Remove.Text = "Remove";
            btn_Remove.UseVisualStyleBackColor = true;
            btn_Remove.Click += Btn_Remove_Click;
            // 
            // btn_NewUser
            // 
            btn_NewUser.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_NewUser.Image = (System.Drawing.Image)resources.GetObject("btn_NewUser.Image");
            btn_NewUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn_NewUser.Location = new System.Drawing.Point(597, 53);
            btn_NewUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_NewUser.Name = "btn_NewUser";
            btn_NewUser.Size = new System.Drawing.Size(146, 27);
            btn_NewUser.TabIndex = 2;
            btn_NewUser.Text = "New user";
            btn_NewUser.UseVisualStyleBackColor = true;
            btn_NewUser.Click += Btn_NewUser_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_Close);
            panel1.Controls.Add(gb_UsersAndGroups);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(750, 459);
            panel1.TabIndex = 1;
            // 
            // btn_Close
            // 
            btn_Close.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btn_Close.Location = new System.Drawing.Point(597, 429);
            btn_Close.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Close.Name = "btn_Close";
            btn_Close.Size = new System.Drawing.Size(146, 27);
            btn_Close.TabIndex = 1;
            btn_Close.Text = "Close";
            btn_Close.UseVisualStyleBackColor = true;
            btn_Close.Click += Btn_Close_Click;
            // 
            // UserAndGroupManagement
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(750, 459);
            Controls.Add(panel1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(473, 216);
            Name = "UserAndGroupManagement";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "User and group management";
            TopMost = true;
            gb_UsersAndGroups.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox gb_UsersAndGroups;
        private Mtf.Controls.MtfTreeView tv_UsersAndGroups;
        private System.Windows.Forms.ImageList il_Images;
        private System.Windows.Forms.Button btn_NewGroup;
        private System.Windows.Forms.Button btn_Modify;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_NewUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Close;
    }
}
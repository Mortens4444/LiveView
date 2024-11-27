namespace LiveView.Forms
{
    partial class AddUser
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUser));
            ni_Icon = new System.Windows.Forms.NotifyIcon(components);
            tb_PasswordAgain = new System.Windows.Forms.TextBox();
            lbl_ConfirmPassword = new System.Windows.Forms.Label();
            tb_Password = new Mtf.Controls.PasswordBox();
            lbl_Password = new System.Windows.Forms.Label();
            tb_Username = new System.Windows.Forms.TextBox();
            btn_Create = new System.Windows.Forms.Button();
            nud_LoginSupervisorsRequiredPriority = new System.Windows.Forms.NumericUpDown();
            lbl_Priority = new System.Windows.Forms.Label();
            btn_Cancel = new System.Windows.Forms.Button();
            chk_LoginSupervisorsRequiredPriority = new System.Windows.Forms.CheckBox();
            gb_LoginSupervisorsRequiredPriority = new System.Windows.Forms.GroupBox();
            nud_LoginSupervisingPriority = new System.Windows.Forms.NumericUpDown();
            lbl_Priority_2 = new System.Windows.Forms.Label();
            chk_LoginSupervisingPriority = new System.Windows.Forms.CheckBox();
            gb_LoginSupervisingPriority = new System.Windows.Forms.GroupBox();
            p_Main = new System.Windows.Forms.Panel();
            gb_LoginDetails = new System.Windows.Forms.GroupBox();
            lbl_Username = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)nud_LoginSupervisorsRequiredPriority).BeginInit();
            gb_LoginSupervisorsRequiredPriority.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_LoginSupervisingPriority).BeginInit();
            gb_LoginSupervisingPriority.SuspendLayout();
            p_Main.SuspendLayout();
            gb_LoginDetails.SuspendLayout();
            SuspendLayout();
            // 
            // ni_Icon
            // 
            ni_Icon.Text = "ni_Icon";
            // 
            // tb_PasswordAgain
            // 
            tb_PasswordAgain.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_PasswordAgain.Location = new System.Drawing.Point(158, 68);
            tb_PasswordAgain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_PasswordAgain.MaxLength = 100;
            tb_PasswordAgain.Name = "tb_PasswordAgain";
            tb_PasswordAgain.PasswordChar = '*';
            tb_PasswordAgain.Size = new System.Drawing.Size(182, 23);
            tb_PasswordAgain.TabIndex = 5;
            // 
            // lbl_ConfirmPassword
            // 
            lbl_ConfirmPassword.AutoSize = true;
            lbl_ConfirmPassword.Location = new System.Drawing.Point(14, 72);
            lbl_ConfirmPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_ConfirmPassword.Name = "lbl_ConfirmPassword";
            lbl_ConfirmPassword.Size = new System.Drawing.Size(104, 15);
            lbl_ConfirmPassword.TabIndex = 4;
            lbl_ConfirmPassword.Text = "Confirm password";
            // 
            // tb_Password
            // 
            tb_Password.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_Password.Location = new System.Drawing.Point(158, 42);
            tb_Password.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_Password.MaxLength = 100;
            tb_Password.Name = "tb_Password";
            tb_Password.Password = "";
            tb_Password.PasswordChar = '*';
            tb_Password.ShowRealPasswordLength = false;
            tb_Password.Size = new System.Drawing.Size(182, 23);
            tb_Password.TabIndex = 3;
            // 
            // lbl_Password
            // 
            lbl_Password.AutoSize = true;
            lbl_Password.Location = new System.Drawing.Point(14, 45);
            lbl_Password.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Password.Name = "lbl_Password";
            lbl_Password.Size = new System.Drawing.Size(57, 15);
            lbl_Password.TabIndex = 2;
            lbl_Password.Text = "Password";
            // 
            // tb_Username
            // 
            tb_Username.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_Username.Location = new System.Drawing.Point(158, 15);
            tb_Username.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_Username.MaxLength = 100;
            tb_Username.Name = "tb_Username";
            tb_Username.Size = new System.Drawing.Size(182, 23);
            tb_Username.TabIndex = 1;
            // 
            // btn_Create
            // 
            btn_Create.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_Create.DialogResult = System.Windows.Forms.DialogResult.OK;
            btn_Create.Location = new System.Drawing.Point(158, 209);
            btn_Create.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Create.Name = "btn_Create";
            btn_Create.Size = new System.Drawing.Size(88, 27);
            btn_Create.TabIndex = 1;
            btn_Create.Text = "Add";
            btn_Create.UseVisualStyleBackColor = true;
            btn_Create.Click += Btn_Create_Click;
            // 
            // nud_LoginSupervisorsRequiredPriority
            // 
            nud_LoginSupervisorsRequiredPriority.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nud_LoginSupervisorsRequiredPriority.Enabled = false;
            nud_LoginSupervisorsRequiredPriority.Location = new System.Drawing.Point(158, 22);
            nud_LoginSupervisorsRequiredPriority.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nud_LoginSupervisorsRequiredPriority.Name = "nud_LoginSupervisorsRequiredPriority";
            nud_LoginSupervisorsRequiredPriority.Size = new System.Drawing.Size(183, 23);
            nud_LoginSupervisorsRequiredPriority.TabIndex = 2;
            // 
            // lbl_Priority
            // 
            lbl_Priority.AutoSize = true;
            lbl_Priority.Enabled = false;
            lbl_Priority.Location = new System.Drawing.Point(14, 24);
            lbl_Priority.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Priority.Name = "lbl_Priority";
            lbl_Priority.Size = new System.Drawing.Size(45, 15);
            lbl_Priority.TabIndex = 1;
            lbl_Priority.Text = "Priority";
            // 
            // btn_Cancel
            // 
            btn_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btn_Cancel.Location = new System.Drawing.Point(253, 209);
            btn_Cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new System.Drawing.Size(88, 27);
            btn_Cancel.TabIndex = 2;
            btn_Cancel.Text = "Cancel";
            btn_Cancel.UseVisualStyleBackColor = true;
            btn_Cancel.Click += Btn_Cancel_Click;
            // 
            // chk_LoginSupervisorsRequiredPriority
            // 
            chk_LoginSupervisorsRequiredPriority.AutoSize = true;
            chk_LoginSupervisorsRequiredPriority.Location = new System.Drawing.Point(13, 1);
            chk_LoginSupervisorsRequiredPriority.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chk_LoginSupervisorsRequiredPriority.Name = "chk_LoginSupervisorsRequiredPriority";
            chk_LoginSupervisorsRequiredPriority.Size = new System.Drawing.Size(209, 19);
            chk_LoginSupervisorsRequiredPriority.TabIndex = 0;
            chk_LoginSupervisorsRequiredPriority.Text = "Login supervisor's required priority";
            chk_LoginSupervisorsRequiredPriority.UseVisualStyleBackColor = true;
            // 
            // gb_LoginSupervisorsRequiredPriority
            // 
            gb_LoginSupervisorsRequiredPriority.Controls.Add(nud_LoginSupervisorsRequiredPriority);
            gb_LoginSupervisorsRequiredPriority.Controls.Add(lbl_Priority);
            gb_LoginSupervisorsRequiredPriority.Controls.Add(chk_LoginSupervisorsRequiredPriority);
            gb_LoginSupervisorsRequiredPriority.Dock = System.Windows.Forms.DockStyle.Top;
            gb_LoginSupervisorsRequiredPriority.Location = new System.Drawing.Point(0, 98);
            gb_LoginSupervisorsRequiredPriority.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_LoginSupervisorsRequiredPriority.Name = "gb_LoginSupervisorsRequiredPriority";
            gb_LoginSupervisorsRequiredPriority.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_LoginSupervisorsRequiredPriority.Size = new System.Drawing.Size(348, 52);
            gb_LoginSupervisorsRequiredPriority.TabIndex = 3;
            gb_LoginSupervisorsRequiredPriority.TabStop = false;
            gb_LoginSupervisorsRequiredPriority.Text = " ";
            // 
            // nud_LoginSupervisingPriority
            // 
            nud_LoginSupervisingPriority.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nud_LoginSupervisingPriority.Enabled = false;
            nud_LoginSupervisingPriority.Location = new System.Drawing.Point(158, 22);
            nud_LoginSupervisingPriority.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nud_LoginSupervisingPriority.Name = "nud_LoginSupervisingPriority";
            nud_LoginSupervisingPriority.Size = new System.Drawing.Size(183, 23);
            nud_LoginSupervisingPriority.TabIndex = 3;
            // 
            // lbl_Priority_2
            // 
            lbl_Priority_2.AutoSize = true;
            lbl_Priority_2.Enabled = false;
            lbl_Priority_2.Location = new System.Drawing.Point(14, 24);
            lbl_Priority_2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Priority_2.Name = "lbl_Priority_2";
            lbl_Priority_2.Size = new System.Drawing.Size(45, 15);
            lbl_Priority_2.TabIndex = 2;
            lbl_Priority_2.Text = "Priority";
            // 
            // chk_LoginSupervisingPriority
            // 
            chk_LoginSupervisingPriority.AutoSize = true;
            chk_LoginSupervisingPriority.Location = new System.Drawing.Point(13, 1);
            chk_LoginSupervisingPriority.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chk_LoginSupervisingPriority.Name = "chk_LoginSupervisingPriority";
            chk_LoginSupervisingPriority.Size = new System.Drawing.Size(160, 19);
            chk_LoginSupervisingPriority.TabIndex = 1;
            chk_LoginSupervisingPriority.Text = "Login supervising priority";
            chk_LoginSupervisingPriority.UseVisualStyleBackColor = true;
            // 
            // gb_LoginSupervisingPriority
            // 
            gb_LoginSupervisingPriority.Controls.Add(nud_LoginSupervisingPriority);
            gb_LoginSupervisingPriority.Controls.Add(lbl_Priority_2);
            gb_LoginSupervisingPriority.Controls.Add(chk_LoginSupervisingPriority);
            gb_LoginSupervisingPriority.Dock = System.Windows.Forms.DockStyle.Top;
            gb_LoginSupervisingPriority.Location = new System.Drawing.Point(0, 150);
            gb_LoginSupervisingPriority.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_LoginSupervisingPriority.Name = "gb_LoginSupervisingPriority";
            gb_LoginSupervisingPriority.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_LoginSupervisingPriority.Size = new System.Drawing.Size(348, 52);
            gb_LoginSupervisingPriority.TabIndex = 4;
            gb_LoginSupervisingPriority.TabStop = false;
            gb_LoginSupervisingPriority.Text = " ";
            // 
            // p_Main
            // 
            p_Main.Controls.Add(gb_LoginSupervisingPriority);
            p_Main.Controls.Add(gb_LoginSupervisorsRequiredPriority);
            p_Main.Controls.Add(btn_Cancel);
            p_Main.Controls.Add(btn_Create);
            p_Main.Controls.Add(gb_LoginDetails);
            p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            p_Main.Location = new System.Drawing.Point(0, 0);
            p_Main.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_Main.Name = "p_Main";
            p_Main.Size = new System.Drawing.Size(348, 240);
            p_Main.TabIndex = 1;
            // 
            // gb_LoginDetails
            // 
            gb_LoginDetails.Controls.Add(tb_PasswordAgain);
            gb_LoginDetails.Controls.Add(lbl_ConfirmPassword);
            gb_LoginDetails.Controls.Add(tb_Password);
            gb_LoginDetails.Controls.Add(lbl_Password);
            gb_LoginDetails.Controls.Add(tb_Username);
            gb_LoginDetails.Controls.Add(lbl_Username);
            gb_LoginDetails.Dock = System.Windows.Forms.DockStyle.Top;
            gb_LoginDetails.Location = new System.Drawing.Point(0, 0);
            gb_LoginDetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_LoginDetails.Name = "gb_LoginDetails";
            gb_LoginDetails.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_LoginDetails.Size = new System.Drawing.Size(348, 98);
            gb_LoginDetails.TabIndex = 0;
            gb_LoginDetails.TabStop = false;
            gb_LoginDetails.Text = "Login details";
            // 
            // lbl_Username
            // 
            lbl_Username.AutoSize = true;
            lbl_Username.Location = new System.Drawing.Point(14, 18);
            lbl_Username.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Username.Name = "lbl_Username";
            lbl_Username.Size = new System.Drawing.Size(60, 15);
            lbl_Username.TabIndex = 0;
            lbl_Username.Text = "Username";
            // 
            // AddUser
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(348, 240);
            Controls.Add(p_Main);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(354, 265);
            Name = "AddUser";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Add user";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)nud_LoginSupervisorsRequiredPriority).EndInit();
            gb_LoginSupervisorsRequiredPriority.ResumeLayout(false);
            gb_LoginSupervisorsRequiredPriority.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_LoginSupervisingPriority).EndInit();
            gb_LoginSupervisingPriority.ResumeLayout(false);
            gb_LoginSupervisingPriority.PerformLayout();
            p_Main.ResumeLayout(false);
            gb_LoginDetails.ResumeLayout(false);
            gb_LoginDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.NotifyIcon ni_Icon;
        private System.Windows.Forms.TextBox tb_PasswordAgain;
        private System.Windows.Forms.Label lbl_ConfirmPassword;
        private Mtf.Controls.PasswordBox tb_Password;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.TextBox tb_Username;
        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.NumericUpDown nud_LoginSupervisorsRequiredPriority;
        private System.Windows.Forms.Label lbl_Priority;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.CheckBox chk_LoginSupervisorsRequiredPriority;
        private System.Windows.Forms.GroupBox gb_LoginSupervisorsRequiredPriority;
        private System.Windows.Forms.NumericUpDown nud_LoginSupervisingPriority;
        private System.Windows.Forms.Label lbl_Priority_2;
        private System.Windows.Forms.CheckBox chk_LoginSupervisingPriority;
        private System.Windows.Forms.GroupBox gb_LoginSupervisingPriority;
        private System.Windows.Forms.Panel p_Main;
        private System.Windows.Forms.GroupBox gb_LoginDetails;
        private System.Windows.Forms.Label lbl_Username;
    }
}
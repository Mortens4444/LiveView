namespace LiveView.Forms
{
    partial class GridManager
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(GridManager));
            pMain = new System.Windows.Forms.Panel();
            textBox1 = new System.Windows.Forms.TextBox();
            comboBox3 = new System.Windows.Forms.ComboBox();
            btn_NewGrid = new System.Windows.Forms.Button();
            button5 = new System.Windows.Forms.Button();
            comboBox2 = new System.Windows.Forms.ComboBox();
            tsmi_ChangeCameraTo = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            deleteGridFromChainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            columnHeader4 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            btn_MoveDown = new System.Windows.Forms.Button();
            btn_MoveUp = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            listView1 = new Mtf.Controls.MtfListView();
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox4 = new System.Windows.Forms.GroupBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            contextMenuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // pMain
            // 
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(491, 391);
            pMain.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox1.Location = new System.Drawing.Point(7, 22);
            textBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox1.MaxLength = 50;
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(476, 23);
            textBox1.TabIndex = 0;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new System.Drawing.Point(98, 22);
            comboBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new System.Drawing.Size(88, 23);
            comboBox3.TabIndex = 2;
            comboBox3.Visible = false;
            // 
            // btn_NewGrid
            // 
            btn_NewGrid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_NewGrid.Location = new System.Drawing.Point(397, 20);
            btn_NewGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_NewGrid.Name = "btn_NewGrid";
            btn_NewGrid.Size = new System.Drawing.Size(88, 27);
            btn_NewGrid.TabIndex = 4;
            btn_NewGrid.Text = "New grid";
            btn_NewGrid.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button5.Location = new System.Drawing.Point(302, 20);
            button5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(88, 27);
            button5.TabIndex = 1;
            button5.Text = "Delete";
            button5.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            comboBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new System.Drawing.Point(7, 22);
            comboBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new System.Drawing.Size(288, 23);
            comboBox2.TabIndex = 0;
            // 
            // tsmi_ChangeCameraTo
            // 
            tsmi_ChangeCameraTo.Name = "tsmi_ChangeCameraTo";
            tsmi_ChangeCameraTo.Size = new System.Drawing.Size(192, 22);
            tsmi_ChangeCameraTo.Text = "Change camera to ...";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(189, 6);
            toolStripSeparator1.Visible = false;
            // 
            // deleteGridFromChainToolStripMenuItem
            // 
            deleteGridFromChainToolStripMenuItem.Name = "deleteGridFromChainToolStripMenuItem";
            deleteGridFromChainToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            deleteGridFromChainToolStripMenuItem.Text = "Delete grid from chain";
            deleteGridFromChainToolStripMenuItem.Visible = false;
            // 
            // moveDownToolStripMenuItem
            // 
            moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            moveDownToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            moveDownToolStripMenuItem.Text = "Move down";
            moveDownToolStripMenuItem.Visible = false;
            // 
            // moveUpToolStripMenuItem
            // 
            moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            moveUpToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            moveUpToolStripMenuItem.Text = "Move up";
            moveUpToolStripMenuItem.Visible = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { moveUpToolStripMenuItem, moveDownToolStripMenuItem, deleteGridFromChainToolStripMenuItem, toolStripSeparator1, tsmi_ChangeCameraTo });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(193, 98);
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "GUID";
            columnHeader3.Width = 229;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Video server name";
            columnHeader4.Width = 131;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Camera name";
            columnHeader2.Width = 103;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Number";
            columnHeader1.Width = 53;
            // 
            // btn_MoveDown
            // 
            btn_MoveDown.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btn_MoveDown.Enabled = false;
            btn_MoveDown.Location = new System.Drawing.Point(98, 253);
            btn_MoveDown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_MoveDown.Name = "btn_MoveDown";
            btn_MoveDown.Size = new System.Drawing.Size(88, 27);
            btn_MoveDown.TabIndex = 2;
            btn_MoveDown.Text = "Move down";
            btn_MoveDown.UseVisualStyleBackColor = true;
            // 
            // btn_MoveUp
            // 
            btn_MoveUp.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btn_MoveUp.Enabled = false;
            btn_MoveUp.Location = new System.Drawing.Point(4, 253);
            btn_MoveUp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_MoveUp.Name = "btn_MoveUp";
            btn_MoveUp.Size = new System.Drawing.Size(88, 27);
            btn_MoveUp.TabIndex = 1;
            btn_MoveUp.Text = "Move up";
            btn_MoveUp.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button2.Location = new System.Drawing.Point(397, 253);
            button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(88, 27);
            button2.TabIndex = 4;
            button2.Text = "Modify";
            button2.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.AlternatingColorEven = System.Drawing.Color.LightBlue;
            listView1.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            listView1.AlternatingColorsAreInUse = true;
            listView1.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            listView1.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            listView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2, columnHeader4, columnHeader3 });
            listView1.CompactView = false;
            listView1.ContextMenuStrip = contextMenuStrip1;
            listView1.EnsureLastItemIsVisible = false;
            listView1.FirstItemIsGray = false;
            listView1.FullRowSelect = true;
            listView1.Location = new System.Drawing.Point(2, 23);
            listView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            listView1.Name = "listView1";
            listView1.OwnerDraw = true;
            listView1.ReadonlyCheckboxes = false;
            listView1.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            listView1.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            listView1.Size = new System.Drawing.Size(483, 226);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = System.Windows.Forms.View.Details;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(btn_MoveDown);
            groupBox1.Controls.Add(btn_MoveUp);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(listView1);
            groupBox1.Location = new System.Drawing.Point(0, 105);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(491, 286);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Grid structure";
            // 
            // groupBox4
            // 
            groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox4.Controls.Add(textBox1);
            groupBox4.Location = new System.Drawing.Point(0, 53);
            groupBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox4.Size = new System.Drawing.Size(491, 52);
            groupBox4.TabIndex = 9;
            groupBox4.TabStop = false;
            groupBox4.Text = "Name of the grid";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox3);
            groupBox2.Controls.Add(btn_NewGrid);
            groupBox2.Controls.Add(button5);
            groupBox2.Controls.Add(comboBox2);
            groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox2.Location = new System.Drawing.Point(0, 0);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Size = new System.Drawing.Size(491, 53);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Grid name";
            // 
            // GridManager
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(491, 391);
            Controls.Add(groupBox1);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            Controls.Add(pMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "GridManager";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Grid manager";
            contextMenuStrip1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button btn_NewGrid;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ChangeCameraTo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteGridFromChainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btn_MoveDown;
        private System.Windows.Forms.Button btn_MoveUp;
        private System.Windows.Forms.Button button2;
        private Mtf.Controls.MtfListView listView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
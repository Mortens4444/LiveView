using Mtf.Network.Enums;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    partial class VncClientForm
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
            SuspendLayout();
            // 
            // VncClientForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Name = "VncClientForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VNC client";
            FormClosing += VncClientForm_FormClosing;
            KeyPress += VncClientForm_KeyPress;
            MouseClick += VncClient_MouseClick;
            MouseDoubleClick += VncClient_MouseDoubleClick;
            MouseDown += VncClient_MouseDown;
            MouseMove += VncClient_MouseMove;
            MouseUp += VncClient_MouseUp;
            MouseWheel += VncClient_Wheel;
            ResumeLayout(false);
        }

        #endregion
    }
}
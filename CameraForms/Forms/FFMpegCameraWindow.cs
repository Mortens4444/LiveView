using Database.Models;
using Mtf.Permissions.Services;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CameraForms.Forms
{
    public partial class FFMpegCameraWindow : Form
    {
        private readonly ManualResetEvent initializationCompleted = new ManualResetEvent(false);
        private readonly PermissionManager<User> permissionManager;
        private readonly Rectangle rectangle;
        private readonly string url;

        public FFMpegCameraWindow(PermissionManager<User> permissionManager, string url, Rectangle rectangle)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            this.url = url;
            this.rectangle = rectangle;
            this.permissionManager = permissionManager;
        }

        private void VideoSourceCamera_Load(object sender, EventArgs e)
        {
            Location = new Point(rectangle.X, rectangle.Y);
            Size = new Size(rectangle.Width, rectangle.Height);
        }

        private void VideoSourceCamera_Shown(object sender, EventArgs e)
        {
            fFmpegWindow.Start(url);
        }

        private void VideoSourceCamera_FormClosing(object sender, FormClosingEventArgs e)
        {
            fFmpegWindow.Stop();
        }
    }
}

using Database.Enums;
using Database.Interfaces;
using Database.Models;
using Database.Repositories;
using LiveView.Core.Extensions;
using Mtf.Controls.x86;
using Mtf.Network;
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
        private readonly IPersonalOptionsRepository personalOptionsRepository;
        private readonly Rectangle rectangle;
        private readonly string url;

        public FFMpegCameraWindow(PermissionManager<User> permissionManager, IPersonalOptionsRepository personalOptionsRepository, string url, Rectangle rectangle)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            this.url = url;
            this.rectangle = rectangle;
            this.permissionManager = permissionManager;
            this.personalOptionsRepository = personalOptionsRepository;
        }

        private void VideoSourceCamera_Load(object sender, EventArgs e)
        {
            Location = new Point(rectangle.X, rectangle.Y);
            Size = new Size(rectangle.Width, rectangle.Height);
        }

        private void VideoSourceCamera_Shown(object sender, EventArgs e)
        {
            fFmpegWindow.Start(url);

            var largeFontSize = personalOptionsRepository.Get(Setting.CameraLargeFontSize, permissionManager.CurrentUser.Tag.Id, 30);
            //var smallFontSize = personalOptionsRepository.Get(Setting.CameraSmallFontSize, permissionManager.CurrentUser.Tag.Id, 15);
            var fontName = personalOptionsRepository.Get(Setting.CameraFont, permissionManager.CurrentUser.Tag.Id, "Arial");
            var fontColor = Color.FromArgb(personalOptionsRepository.Get(Setting.CameraFontColor, permissionManager.CurrentUser.Tag.Id, Color.White.ToArgb()));
            //var shadowColor = Color.FromArgb(personalOptionsRepository.Get(Setting.CameraFontShadowColor, permissionManager.CurrentUser.Tag.Id, Color.Black.ToArgb()));

            var cameraName = personalOptionsRepository.GetCameraName(permissionManager.CurrentUser.Id, url);
            fFmpegWindow.SetOsdText(fontName, largeFontSize, FontStyle.Bold, fontColor, cameraName);
        }

        private void VideoSourceCamera_FormClosing(object sender, FormClosingEventArgs e)
        {
            fFmpegWindow.Stop();
        }
    }
}

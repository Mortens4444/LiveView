using CameraForms.Services;
using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Core.Extensions;
using LiveView.Core.Services;
using LiveView.Core.Services.Pipe;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly KBD300ASimulatorServer kBD300ASimulatorServer;
        private readonly ManualResetEvent initializationCompleted = new ManualResetEvent(false);
        private readonly PermissionManager<User> permissionManager;
        private readonly ICameraRepository cameraRepository;
        private readonly IPersonalOptionsRepository personalOptionsRepository;
        
        private string url;
        private Rectangle rectangle;

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

        public FFMpegCameraWindow(ServiceProvider serviceProvider, long userId, long cameraId, long? displayId)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            kBD300ASimulatorServer = new KBD300ASimulatorServer();
            permissionManager = PermissionManagerBuilder.Build(serviceProvider, this, userId);
            cameraRepository = serviceProvider.GetRequiredService<ICameraRepository>();
            personalOptionsRepository = serviceProvider.GetRequiredService<IPersonalOptionsRepository>();
            var display = DisplayProvider.Get(displayId);
            rectangle = display.Bounds;
            Initialize(cameraId, rectangle, true);
        }

        public FFMpegCameraWindow(ServiceProvider serviceProvider, long userId, long cameraId, Rectangle rectangle)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            kBD300ASimulatorServer = new KBD300ASimulatorServer();
            permissionManager = PermissionManagerBuilder.Build(serviceProvider, this, userId);
            cameraRepository = serviceProvider.GetRequiredService<ICameraRepository>();
            personalOptionsRepository = serviceProvider.GetRequiredService<IPersonalOptionsRepository>();
            Initialize(cameraId, rectangle, true);
        }

        private void Initialize(long cameraId, Rectangle rectangle, bool fullScreen)
        {
            var camera = cameraRepository.Select(cameraId);
            this.rectangle = rectangle;
            url = camera.HttpStreamUrl;

            if (fullScreen)
            {
                kBD300ASimulatorServer.StartPipeServerAsync("KBD300A_Pipe");
                //client = CameraRegister.RegisterCameraWithUrl(userId, cameraId, display, ClientDataArrivedEventHandler, CameraMode.FFMpeg);
            }
        }

        private void FFMpegCameraWindow_Load(object sender, EventArgs e)
        {
            Location = new Point(rectangle.X, rectangle.Y);
            Size = new Size(rectangle.Width, rectangle.Height);
        }

        private void FFMpegCameraWindow_Shown(object sender, EventArgs e)
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

        private void FFMpegCameraWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            fFmpegWindow.Stop();
        }
    }
}

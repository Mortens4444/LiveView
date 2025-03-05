using CameraForms.Services;
using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Core.Services;
using LiveView.Core.Services.Pipe;
using Microsoft.Extensions.DependencyInjection;
using Mtf.Controls.Enums;
using Mtf.Controls.Video;
using Mtf.Network;
using Mtf.Permissions.Services;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CameraForms.Forms
{
    public partial class VlcCameraWindow : Form
    {
        private readonly KBD300ASimulatorServer kBD300ASimulatorServer;
        private readonly ManualResetEvent initializationCompleted = new ManualResetEvent(false);
        private readonly PermissionManager<User> permissionManager;
        private readonly ICameraRepository cameraRepository;
        private readonly IPersonalOptionsRepository personalOptionsRepository;

        private string url;
        private Rectangle rectangle;

        public VlcCameraWindow(PermissionManager<User> permissionManager, string url, Rectangle rectangle)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            this.url = url;
            this.rectangle = rectangle;
            this.permissionManager = permissionManager;
        }

        public VlcCameraWindow(ServiceProvider serviceProvider, long userId, long cameraId, long? displayId)
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

        public VlcCameraWindow(ServiceProvider serviceProvider, long userId, long cameraId, Rectangle rectangle)
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
                //client = CameraRegister.RegisterCameraWithUrl(userId, cameraId, display, ClientDataArrivedEventHandler, CameraMode.Vlc);
            }
        }

        private void VlcCameraWindow_Load(object sender, EventArgs e)
        {
            Location = new Point(rectangle.X, rectangle.Y);
            Size = new Size(rectangle.Width, rectangle.Height);
        }

        private void VlcCameraWindow_Shown(object sender, EventArgs e)
        {
            vlcWindow.Start(url, true, true, false, 0, 0, Demux.live555);
        }

        private void VlcCameraWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            vlcWindow.Stop();
        }
    }
}

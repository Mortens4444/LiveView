using CameraForms.Dto;
using CameraForms.Services;
using Database.Enums;
using Database.Models;
using Database.Repositories;
using LiveView.Core.Services;
using LiveView.Core.Services.Pipe;
using Microsoft.Extensions.DependencyInjection;
using Mtf.Network;
using Mtf.Permissions.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CameraForms.Forms
{
    public partial class SunellLegacyCameraWindow : Form
    {
        private readonly KBD300ASimulatorServer kBD300ASimulatorServer;
        private PermissionManager<User> permissionManager;
        private Rectangle rectangle;
        private SunellLegacyCameraInfo sunellLegacyCameraInfo;

        public SunellLegacyCameraWindow(PermissionManager<User> permissionManager, SunellLegacyCameraInfo sunellLegacyCameraInfo, Rectangle rectangle)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            this.sunellLegacyCameraInfo = sunellLegacyCameraInfo;
            this.rectangle = rectangle;
            this.permissionManager = permissionManager;
        }

        public SunellLegacyCameraWindow(ServiceProvider serviceProvider, long userId, long cameraId, long? displayId)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            kBD300ASimulatorServer = new KBD300ASimulatorServer();
            permissionManager = PermissionManagerBuilder.Build(serviceProvider, this, userId);
            var display = DisplayProvider.Get(displayId);
            Initialize( cameraId, display.Bounds, true);
        }

        public SunellLegacyCameraWindow(ServiceProvider serviceProvider, long userId, long cameraId, Rectangle rectangle)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            kBD300ASimulatorServer = new KBD300ASimulatorServer();
            permissionManager = PermissionManagerBuilder.Build(serviceProvider, this, userId);
            Initialize(cameraId, rectangle, true);
        }

        private void Initialize(long cameraId, Rectangle rectangle, bool fullScreen)
        {
            var camerasRepository = new CameraRepository();
            var camera = camerasRepository.Select(cameraId);
            sunellLegacyCameraInfo = new SunellLegacyCameraInfo
            {
                CameraIp = camera.IpAddress,
                CameraPort = SunellLegacyCameraInfo.PagoPort,
                Username = camera.Username,
                Password = camera.Password,
                StreamId = camera.StreamId ?? 1
            };

            if (fullScreen)
            {
                kBD300ASimulatorServer.StartPipeServerAsync("KBD300A_Pipe");
                //client = CameraRegister.RegisterCameraWithUrl(userId, cameraId, display, ClientDataArrivedEventHandler, CameraMode.SunellLegacyCamera);
            }

            this.rectangle = rectangle;
        }

        private void SunellLegacyCameraWindow_Load(object sender, EventArgs e)
        {
            Location = new Point(rectangle.X, rectangle.Y);
            Size = new Size(rectangle.Width, rectangle.Height);
        }

        private void SunellLegacyCameraWindow_Shown(object sender, EventArgs e)
        {
            sunellVideoWindowLegacy1.Connect(this, sunellLegacyCameraInfo.CameraIp, sunellLegacyCameraInfo.CameraPort, sunellLegacyCameraInfo.Username, sunellLegacyCameraInfo.Password, sunellLegacyCameraInfo.StreamId);
        }

        private void SunellLegacyCameraWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            sunellVideoWindowLegacy1.Disconnect();
        }
    }
}

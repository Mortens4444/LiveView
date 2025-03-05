using CameraForms.Dto;
using CameraForms.Services;
using Database.Enums;
using Database.Models;
using Database.Repositories;
using LiveView.Core.Services;
using LiveView.Core.Services.Pipe;
using Microsoft.Extensions.DependencyInjection;
using Mtf.Controls.Sunell.IPR67.SunellSdk;
using Mtf.Network;
using Mtf.Permissions.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CameraForms.Forms
{
    public partial class SunellCameraWindow : Form
    {
        private readonly KBD300ASimulatorServer kBD300ASimulatorServer;
        private PermissionManager<User> permissionManager;
        private Rectangle rectangle;
        private SunellCameraInfo sunellCameraInfo;

        public SunellCameraWindow(PermissionManager<User> permissionManager, SunellCameraInfo sunellCameraInfo, Rectangle rectangle)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            this.sunellCameraInfo = sunellCameraInfo;
            this.rectangle = rectangle;
            this.permissionManager = permissionManager;
        }

        public SunellCameraWindow(ServiceProvider serviceProvider, long userId, long cameraId, long? displayId)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            kBD300ASimulatorServer = new KBD300ASimulatorServer();
            permissionManager = PermissionManagerBuilder.Build(serviceProvider, this, userId);
            var display = DisplayProvider.Get(displayId);
            rectangle = display.Bounds;
            Initialize(cameraId, rectangle, true);
        }

        public SunellCameraWindow(ServiceProvider serviceProvider, long userId, long cameraId, Rectangle rectangle)
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
            sunellCameraInfo = new SunellCameraInfo
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
                //client = CameraRegister.RegisterCameraWithUrl(userId, cameraId, display, ClientDataArrivedEventHandler, CameraMode.SunellCamera);
            }

            this.rectangle = rectangle;
        }

        private void SunellCameraWindow_Load(object sender, EventArgs e)
        {
            Location = new Point(rectangle.X, rectangle.Y);
            Size = new Size(rectangle.Width, rectangle.Height);
        }

        private void SunellCameraWindow_Shown(object sender, EventArgs e)
        {
            sunellVideoWindow1.Connect(sunellCameraInfo.CameraIp, sunellCameraInfo.CameraPort, sunellCameraInfo.Username, sunellCameraInfo.Password, sunellCameraInfo.StreamId, 1, StreamType.HighDensity, false);
        }

        private void SunellCameraWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            sunellVideoWindow1.Disconnect();
        }
    }
}
using CameraForms.Dto;
using CameraForms.Services;
using Database.Enums;
using Database.Models;
using Database.Repositories;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Network;
using LiveView.Core.Services;
using LiveView.Core.Services.Pipe;
using Microsoft.Extensions.DependencyInjection;
using Mtf.Controls.Sunell.IPR67.SunellSdk;
using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Network.EventArg;
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
        private Client client;

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
            Initialize(userId, cameraId, rectangle, display, true);
        }

        public SunellCameraWindow(ServiceProvider serviceProvider, long userId, long cameraId, Rectangle rectangle)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            kBD300ASimulatorServer = new KBD300ASimulatorServer();
            permissionManager = PermissionManagerBuilder.Build(serviceProvider, this, userId);
            Initialize(userId, cameraId, rectangle, null, true);
        }

        private void Initialize(long userId, long cameraId, Rectangle rectangle, DisplayDto display, bool fullScreen)
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
                client = CameraRegister.RegisterCamera(userId, cameraId, display, ClientDataArrivedEventHandler, CameraMode.SunellCamera);

                Console.CancelKeyPress += (sender, e) => OnExit();
                Application.ApplicationExit += (sender, e) => OnExit();
                AppDomain.CurrentDomain.ProcessExit += (sender, e) => OnExit();
                FormClosing += (sender, e) => OnExit();
            }

            this.rectangle = rectangle;
        }

        private void ClientDataArrivedEventHandler(object sender, DataArrivedEventArgs e)
        {
            try
            {
                var messages = $"{client?.Encoding.GetString(e.Data)}";
                var allMessages = messages.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var message in allMessages)
                {
                    var messageParts = message.Split('|');
                    if (message.StartsWith(NetworkCommand.Close.ToString(), StringComparison.InvariantCulture))
                    {
                        Close();
                    }
                    else if (message.StartsWith(NetworkCommand.Kill.ToString(), StringComparison.InvariantCulture))
                    {
                        Close();
                    }
                    else if (message.StartsWith(NetworkCommand.PanToEast.ToString(), StringComparison.InvariantCulture))
                    {
                    }
                    else if (message.StartsWith(NetworkCommand.TiltToNorth.ToString(), StringComparison.InvariantCulture))
                    {
                    }
                    else if (message.StartsWith(NetworkCommand.PanToEastAndTiltToNorth.ToString(), StringComparison.InvariantCulture))
                    {
                    }
                    else if (message.StartsWith(NetworkCommand.PanToWestAndTiltToNorth.ToString(), StringComparison.InvariantCulture))
                    {
                    }
                    else if (message.StartsWith(NetworkCommand.MoveToPresetZero.ToString(), StringComparison.InvariantCulture))
                    {
                    }
                    else if (message.StartsWith(NetworkCommand.TiltToSouth.ToString(), StringComparison.InvariantCulture))
                    {
                    }
                    else if (message.StartsWith(NetworkCommand.PanToEastAndTiltToSouth.ToString(), StringComparison.InvariantCulture))
                    {
                    }
                    else if (message.StartsWith(NetworkCommand.PanToWestAndTiltToSouth.ToString(), StringComparison.InvariantCulture))
                    {
                    }
                    else if (message.StartsWith(NetworkCommand.PanToWest.ToString(), StringComparison.InvariantCulture))
                    {
                    }
                    else if (message.StartsWith(NetworkCommand.StopPanAndTilt.ToString(), StringComparison.InvariantCulture))
                    {
                    }
                    else if (message.StartsWith(NetworkCommand.StopZoom.ToString(), StringComparison.InvariantCulture))
                    {
                    }
                    else if (message.StartsWith(NetworkCommand.ZoomIn.ToString(), StringComparison.InvariantCulture))
                    {
                    }
                    else if (message.StartsWith(NetworkCommand.ZoomOut.ToString(), StringComparison.InvariantCulture))
                    {
                    }
                    else
                    {
                        ErrorBox.Show("General error", $"Unexpected message arrived: {message}");
                    }
                }
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
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

        private void OnExit()
        {
            client?.Send($"{NetworkCommand.UnregisterCamera}", true);
        }

        private void SunellCameraWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            sunellVideoWindow1.Disconnect();
        }
    }
}
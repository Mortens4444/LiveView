using CameraForms.Dto;
using CameraForms.Services;
using Database.Enums;
using Database.Interfaces;
using Database.Models;
using Database.Repositories;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Network;
using LiveView.Core.Services;
using LiveView.Core.Services.Pipe;
using Microsoft.Extensions.DependencyInjection;
using Mtf.Controls.Extensions;
using Mtf.Controls.Sunell.IPR66.CustomEventArgs;
using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Network.EventArg;
using Mtf.Permissions.Services;
using System;
using System.Configuration;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CameraForms.Forms
{
    public partial class SunellLegacyCameraWindow : Form
    {
        private readonly KBD300ASimulatorServer kBD300ASimulatorServer;
        private readonly IPersonalOptionsRepository personalOptionsRepository;
        private readonly PermissionManager<User> permissionManager;

        private Rectangle rectangle;
        private SunellLegacyCameraInfo sunellLegacyCameraInfo;
        private Client client;
        private Label label;
        private GridCamera gridCamera;
        private int rotateSpeed = 50;

        public SunellLegacyCameraWindow(PermissionManager<User> permissionManager, IPersonalOptionsRepository personalOptionsRepository, SunellLegacyCameraInfo sunellLegacyCameraInfo, Rectangle rectangle, GridCamera gridCamera)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            if (Int32.TryParse(ConfigurationManager.AppSettings["SunellLegacyCameraWindowRotate"], out var currentRotateSpeed))
            {
                rotateSpeed = currentRotateSpeed;
            }

            this.sunellLegacyCameraInfo = sunellLegacyCameraInfo;
            this.rectangle = rectangle;
            this.permissionManager = permissionManager;
            this.personalOptionsRepository = personalOptionsRepository;
            this.gridCamera = gridCamera;

            if (gridCamera?.Frame ?? false)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
            }
        }

        public SunellLegacyCameraWindow(ServiceProvider serviceProvider, long userId, long cameraId, long? displayId)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            personalOptionsRepository = serviceProvider.GetRequiredService<IPersonalOptionsRepository>();
            kBD300ASimulatorServer = new KBD300ASimulatorServer();
            permissionManager = PermissionManagerBuilder.Build(serviceProvider, this, userId);
            var display = DisplayProvider.Get(displayId);
            Initialize(userId, cameraId, display.Bounds, display, true);
        }

        public SunellLegacyCameraWindow(ServiceProvider serviceProvider, long userId, long cameraId, Rectangle rectangle)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            personalOptionsRepository = serviceProvider.GetRequiredService<IPersonalOptionsRepository>();
            kBD300ASimulatorServer = new KBD300ASimulatorServer();
            permissionManager = PermissionManagerBuilder.Build(serviceProvider, this, userId);
            Initialize(userId, cameraId, rectangle, null, true);
        }

        private void Initialize(long userId, long cameraId, Rectangle rectangle, DisplayDto display, bool fullScreen)
        {
            var camerasRepository = new CameraRepository();
            var camera = camerasRepository.Select(cameraId);
            sunellLegacyCameraInfo = new SunellLegacyCameraInfo
            {
                CameraIp = camera.IpAddress,
                CameraPort = SunellLegacyCameraInfo.PagoPort,
                Username = camera.Username,
                Password = camera.Password,
                CameraId = camera.CameraId ?? 1,
                StreamId = camera.StreamId ?? 1
            };

            if (fullScreen)
            {
                kBD300ASimulatorServer.StartPipeServerAsync("KBD300A_Pipe");
                client = CameraRegister.RegisterCamera(userId, cameraId, display, ClientDataArrivedEventHandler, CameraMode.SunellLegacyCamera);

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
                        sunellVideoWindowLegacy1.PTZ_RotateRight(rotateSpeed);
                    }
                    else if (message.StartsWith(NetworkCommand.TiltToNorth.ToString(), StringComparison.InvariantCulture))
                    {
                        sunellVideoWindowLegacy1.PTZ_RotateUp(rotateSpeed);
                    }
                    else if (message.StartsWith(NetworkCommand.PanToEastAndTiltToNorth.ToString(), StringComparison.InvariantCulture))
                    {
                        sunellVideoWindowLegacy1.PTZ_RotateRight(rotateSpeed);
                        sunellVideoWindowLegacy1.PTZ_RotateUp(rotateSpeed);
                    }
                    else if (message.StartsWith(NetworkCommand.PanToWestAndTiltToNorth.ToString(), StringComparison.InvariantCulture))
                    {
                        sunellVideoWindowLegacy1.PTZ_RotateLeft(rotateSpeed);
                        sunellVideoWindowLegacy1.PTZ_RotateUp(rotateSpeed);
                    }
                    else if (message.StartsWith(NetworkCommand.MoveToPresetZero.ToString(), StringComparison.InvariantCulture))
                    {

                    }
                    else if (message.StartsWith(NetworkCommand.TiltToSouth.ToString(), StringComparison.InvariantCulture))
                    {
                        sunellVideoWindowLegacy1.PTZ_RotateDown(rotateSpeed);
                    }
                    else if (message.StartsWith(NetworkCommand.PanToEastAndTiltToSouth.ToString(), StringComparison.InvariantCulture))
                    {
                        sunellVideoWindowLegacy1.PTZ_RotateRight(rotateSpeed);
                        sunellVideoWindowLegacy1.PTZ_RotateDown(rotateSpeed);
                    }
                    else if (message.StartsWith(NetworkCommand.PanToWestAndTiltToSouth.ToString(), StringComparison.InvariantCulture))
                    {
                        sunellVideoWindowLegacy1.PTZ_RotateLeft(rotateSpeed);
                        sunellVideoWindowLegacy1.PTZ_RotateDown(rotateSpeed);
                    }
                    else if (message.StartsWith(NetworkCommand.PanToWest.ToString(), StringComparison.InvariantCulture))
                    {
                        sunellVideoWindowLegacy1.PTZ_RotateLeft(rotateSpeed);
                    }
                    else if (message.StartsWith(NetworkCommand.StopPanAndTilt.ToString(), StringComparison.InvariantCulture))
                    {
                        sunellVideoWindowLegacy1.PTZ_Stop();
                    }
                    else if (message.StartsWith(NetworkCommand.StopZoom.ToString(), StringComparison.InvariantCulture))
                    {
                        sunellVideoWindowLegacy1.PTZ_Stop();
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

        public void SetOsd()
        {
            Invoke((Action)(() =>
            {
                label = new Label
                {
                    Text = sunellVideoWindowLegacy1.OverlayText,
                    ForeColor = sunellVideoWindowLegacy1.OverlayColor,
                    BackColor = sunellVideoWindowLegacy1.OverlayBackgroundColor,
                    Font = sunellVideoWindowLegacy1.OverlayFont,
                    Parent = Parent,
                    Location = sunellVideoWindowLegacy1.OverlayLocation,
                    AutoSize = true
                };
                Controls.Add(label);
                label.BringToFront();
                Invalidate();
            }));
        }
        
        private void SunellLegacyCameraWindow_Load(object sender, EventArgs e)
        {
            Location = new Point(rectangle.X, rectangle.Y);
            if (Boolean.TryParse(ConfigurationManager.AppSettings["UseMiniSizeForFullscreenWindows"], out var useMiniWindowattach) && useMiniWindowattach)
            {
                Size = new Size(100, 100);
            }
            else
            {
                Size = new Size(rectangle.Width, rectangle.Height);
            }
        }

        private void SunellLegacyCameraWindow_Shown(object sender, EventArgs e)
        {
            var userId = permissionManager.CurrentUser.Tag.Id;
            var largeFontSize = personalOptionsRepository.Get(Setting.CameraLargeFontSize, userId, 30);
            //var smallFontSize = personalOptionsRepository.Get(Setting.CameraSmallFontSize, userId, 15);
            sunellVideoWindowLegacy1.OverlayFont = new Font(personalOptionsRepository.Get(Setting.CameraFont, userId, "Arial"), largeFontSize, FontStyle.Bold);
            sunellVideoWindowLegacy1.OverlayColor = Color.FromArgb(personalOptionsRepository.Get(Setting.CameraFontColor, userId, Color.White.ToArgb()));
            sunellVideoWindowLegacy1.OverlayBackgroundColor = Color.FromArgb(personalOptionsRepository.Get(Setting.CameraFontShadowColor, userId, Color.Black.ToArgb()));
            var text = personalOptionsRepository.GetCameraName(userId, sunellLegacyCameraInfo.CameraIp);
            if (gridCamera?.Frame ?? false)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
                Text = text;
            }
            else
            {
                if (gridCamera?.Osd ?? false)
                {
                    sunellVideoWindowLegacy1.OverlayText = text;
                }
            }
            if (gridCamera?.ShowDateTime ?? false)
            {
                sunellVideoWindowLegacy1.OverlayText += DateTime.Now.ToString();
            }

            sunellVideoWindowLegacy1.VideoSignalChanged += SunellVideoWindowLegacy1_VideoSignalChanged;
            sunellVideoWindowLegacy1.Connect(sunellLegacyCameraInfo.CameraIp, sunellLegacyCameraInfo.CameraPort, sunellLegacyCameraInfo.Username, sunellLegacyCameraInfo.Password, sunellLegacyCameraInfo.StreamId);
            sunellVideoWindowLegacy1.PTZ_Open(sunellLegacyCameraInfo.CameraId);
            SetOsd();
        }

        private void SunellVideoWindowLegacy1_VideoSignalChanged(object sender, VideoSignalChangedEventArgs e)
        {
            Invoke((Action)(() => sunellVideoWindowLegacy1.Visible = e.HasSignal));
        }

        private void OnExit()
        {
            client?.Send($"{NetworkCommand.UnregisterCamera}", true);
        }

        private void SunellLegacyCameraWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            kBD300ASimulatorServer?.Stop();
            sunellVideoWindowLegacy1.PTZ_Close();
            sunellVideoWindowLegacy1.Disconnect();
        }
    }
}

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
using Mtf.Controls.Sunell.IPR67;
using Mtf.Controls.Sunell.IPR67.Enums;
using Mtf.Controls.Sunell.IPR67.SunellSdk;
using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Network.EventArg;
using Mtf.Permissions.Services;
using System;
using System.Configuration;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraForms.Forms
{
    public partial class SunellCameraWindow : Form
    {
        private readonly KBD300ASimulatorServer kBD300ASimulatorServer;
        private readonly IPersonalOptionsRepository personalOptionsRepository;
        private readonly PermissionManager<User> permissionManager;

        private Rectangle rectangle;
        private SunellCameraInfo sunellCameraInfo;
        private Client client;
        private CancellationTokenSource cts;
        private Label label;
        private GridCamera gridCamera;

        public SunellCameraWindow(PermissionManager<User> permissionManager, IPersonalOptionsRepository personalOptionsRepository, SunellCameraInfo sunellCameraInfo, Rectangle rectangle, GridCamera gridCamera)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            this.sunellCameraInfo = sunellCameraInfo;
            this.rectangle = rectangle;
            this.permissionManager = permissionManager;
            this.personalOptionsRepository = personalOptionsRepository;
            this.gridCamera = gridCamera;

            if (gridCamera?.Frame ?? false)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
            }
        }

        public SunellCameraWindow(ServiceProvider serviceProvider, long userId, long cameraId, long? displayId)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            personalOptionsRepository = serviceProvider.GetRequiredService<IPersonalOptionsRepository>();
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

            personalOptionsRepository = serviceProvider.GetRequiredService<IPersonalOptionsRepository>();
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
                CameraId = camera.CameraId ?? 1,
                StreamId = camera.StreamId ?? 1
            };

            if (fullScreen)
            {
                kBD300ASimulatorServer.StartPipeServerAsync("KBD300A_Pipe");
                client = CameraRegister.RegisterCamera(userId, cameraId, display, ClientDataArrivedEventHandler, CameraMode.SunellCamera);

                Console.CancelKeyPress += (sender, e) => OnExit();
                Application.ApplicationExit += (sender, e) => OnExit();
                AppDomain.CurrentDomain.ProcessExit += (sender, e) => OnExit();
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
                        sunellVideoWindow1.PtzRotate(PtzRotateOperation.Rigth);
                    }
                    else if (message.StartsWith(NetworkCommand.TiltToNorth.ToString(), StringComparison.InvariantCulture))
                    {
                        sunellVideoWindow1.PtzRotate(PtzRotateOperation.Up);
                    }
                    else if (message.StartsWith(NetworkCommand.PanToEastAndTiltToNorth.ToString(), StringComparison.InvariantCulture))
                    {
                        sunellVideoWindow1.PtzRotate(PtzRotateOperation.Rigth);
                        sunellVideoWindow1.PtzRotate(PtzRotateOperation.Up);
                    }
                    else if (message.StartsWith(NetworkCommand.PanToWestAndTiltToNorth.ToString(), StringComparison.InvariantCulture))
                    {
                        sunellVideoWindow1.PtzRotate(PtzRotateOperation.Left);
                        sunellVideoWindow1.PtzRotate(PtzRotateOperation.Up);
                    }
                    else if (message.StartsWith(NetworkCommand.MoveToPresetZero.ToString(), StringComparison.InvariantCulture))
                    {
                    }
                    else if (message.StartsWith(NetworkCommand.TiltToSouth.ToString(), StringComparison.InvariantCulture))
                    {
                        sunellVideoWindow1.PtzRotate(PtzRotateOperation.Down);
                    }
                    else if (message.StartsWith(NetworkCommand.PanToEastAndTiltToSouth.ToString(), StringComparison.InvariantCulture))
                    {
                        sunellVideoWindow1.PtzRotate(PtzRotateOperation.Rigth);
                        sunellVideoWindow1.PtzRotate(PtzRotateOperation.Down);
                    }
                    else if (message.StartsWith(NetworkCommand.PanToWestAndTiltToSouth.ToString(), StringComparison.InvariantCulture))
                    {
                        sunellVideoWindow1.PtzRotate(PtzRotateOperation.Left);
                        sunellVideoWindow1.PtzRotate(PtzRotateOperation.Down);
                    }
                    else if (message.StartsWith(NetworkCommand.PanToWest.ToString(), StringComparison.InvariantCulture))
                    {
                        sunellVideoWindow1.PtzRotate(PtzRotateOperation.Left);
                    }
                    else if (message.StartsWith(NetworkCommand.StopPanAndTilt.ToString(), StringComparison.InvariantCulture))
                    {
                        sunellVideoWindow1.PtzRotate(PtzRotateOperation.Stop);
                    }
                    else if (message.StartsWith(NetworkCommand.StopZoom.ToString(), StringComparison.InvariantCulture))
                    {
                        sunellVideoWindow1.PtzZoom(PtzZoomOperation.Stop);
                    }
                    else if (message.StartsWith(NetworkCommand.ZoomIn.ToString(), StringComparison.InvariantCulture))
                    {
                        sunellVideoWindow1.PtzZoom(PtzZoomOperation.In);
                    }
                    else if (message.StartsWith(NetworkCommand.ZoomOut.ToString(), StringComparison.InvariantCulture))
                    {
                        sunellVideoWindow1.PtzZoom(PtzZoomOperation.Out);
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
            if (Boolean.TryParse(ConfigurationManager.AppSettings["UseMiniSizeForFullscreenWindows"], out var useMiniWindowattach) && useMiniWindowattach)
            {
                Size = new Size(100, 100);
            }
            else
            {
                Size = new Size(rectangle.Width, rectangle.Height);
            }
        }

        private void SunellCameraWindow_Shown(object sender, EventArgs e)
        {
            var userId = permissionManager.CurrentUser.Tag.Id;
            var largeFontSize = personalOptionsRepository.Get(Setting.CameraLargeFontSize, userId, 30);
            //var smallFontSize = personalOptionsRepository.Get(Setting.CameraSmallFontSize, userId, 15);
            sunellVideoWindow1.OverlayFont = new Font(personalOptionsRepository.Get(Setting.CameraFont, userId, "Arial"), largeFontSize, FontStyle.Bold);
            sunellVideoWindow1.OverlayColor = Color.FromArgb(personalOptionsRepository.Get(Setting.CameraFontColor, userId, Color.White.ToArgb()));
            sunellVideoWindow1.OverlayBackgroundColor = Color.FromArgb(personalOptionsRepository.Get(Setting.CameraFontShadowColor, userId, Color.Black.ToArgb()));

            var text = personalOptionsRepository.GetCameraName(userId, sunellCameraInfo.CameraIp);
            if (gridCamera?.Frame ?? false)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
                Text = text;
            }
            else
            {
                if (gridCamera?.Osd ?? false)
                {
                    sunellVideoWindow1.OverlayText = text;
                }
            }
            if (gridCamera?.ShowDateTime ?? false)
            {
                sunellVideoWindow1.OverlayText += DateTime.Now.ToString();
            }

            var streamId = Connect();
            if (streamId == SunellVideoWindow.NoStream)
            {
                cts?.Cancel();
                cts = new CancellationTokenSource();
                _ = TryReconnectAsync(cts.Token);
            }
            SetOsd();
        }

        public void SetOsd()
        {
            Invoke((Action)(() =>
            {
                label = new Label
                {
                    Text = sunellVideoWindow1.OverlayText,
                    ForeColor = sunellVideoWindow1.OverlayColor,
                    BackColor = sunellVideoWindow1.OverlayBackgroundColor,
                    Font = sunellVideoWindow1.OverlayFont,
                    Parent = Parent,
                    Location = sunellVideoWindow1.OverlayLocation,
                    AutoSize = true
                };
                Controls.Add(label);
                label.BringToFront();
                Invalidate();
            }));
        }

        private int Connect()
        {
            return sunellVideoWindow1.Connect(sunellCameraInfo.CameraIp, sunellCameraInfo.CameraPort, sunellCameraInfo.Username, sunellCameraInfo.Password, sunellCameraInfo.StreamId, 1, StreamType.D1, true);
        }

        private async Task TryReconnectAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (Connect() != SunellVideoWindow.NoStream)
                {
                    return;
                }

                try
                {
                    await Task.Delay(1000, cancellationToken).ConfigureAwait(false);
                }
                catch (TaskCanceledException)
                {
                    return;
                }
            }
        }


        private void OnExit()
        {
            kBD300ASimulatorServer?.Stop();
            sunellVideoWindow1.Disconnect();
            client?.Send($"{NetworkCommand.UnregisterCamera}", true);
        }

        private void SunellCameraWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnExit();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
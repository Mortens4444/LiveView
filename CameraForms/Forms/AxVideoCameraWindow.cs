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
using Mtf.LanguageService;
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
    public partial class AxVideoCameraWindow : Form
    {
        private Client client;
        private short cameraMoveValue;

        private readonly DisplayDto display;
        private readonly long cameraId;
        private readonly PermissionManager<User> permissionManager;
        private readonly KBD300ASimulatorServer kBD300ASimulatorServer;
        private readonly ICameraRepository cameraRepository;
        private readonly IServerRepository serverRepository;
        private readonly IPersonalOptionsRepository personalOptionsRepository;

        private readonly Database.Models.Server server;
        private readonly Camera camera;
        private readonly Rectangle rectangle;
        private CancellationToken cancellationToken;
        private GridCamera gridCamera;

        public AxVideoCameraWindow(PermissionManager<User> permissionManager, IServerRepository serverRepository, ICameraRepository cameraRepository,
            IPersonalOptionsRepository personalOptionsRepository, Camera camera, Database.Models.Server server, Rectangle rectangle, GridCamera gridCamera,
            CancellationToken cancellationToken)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            this.rectangle = rectangle;
            this.server = server;
            this.camera = camera;
            this.cancellationToken = cancellationToken;
            this.permissionManager = permissionManager;
            this.cameraRepository = cameraRepository;
            this.serverRepository = serverRepository;
            this.personalOptionsRepository = personalOptionsRepository;
            
            cameraId = camera?.Id ?? 0;
            Initialize(permissionManager?.CurrentUser?.Tag.Id ?? 0, cameraId, false);
            this.gridCamera = gridCamera;

            if (gridCamera?.Frame ?? false)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
            }
        }

        public AxVideoCameraWindow(IServiceProvider serviceProvider, long userId, long cameraId, Point location, Size size)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            kBD300ASimulatorServer = new KBD300ASimulatorServer();
            permissionManager = PermissionManagerBuilder.Build(serviceProvider, this, userId);
            personalOptionsRepository = serviceProvider.GetRequiredService<IPersonalOptionsRepository>();
            cameraRepository = serviceProvider.GetRequiredService<ICameraRepository>();
            serverRepository = serviceProvider.GetRequiredService<IServerRepository>();
            this.cameraId = cameraId;
            Initialize(userId, cameraId, true);

            rectangle = new Rectangle(location, size);
            axVideoPlayerWindow.ContextMenuStrip = null;
        }

        public AxVideoCameraWindow(IServiceProvider serviceProvider, long userId, long cameraId, long? displayId)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            kBD300ASimulatorServer = new KBD300ASimulatorServer();
            permissionManager = PermissionManagerBuilder.Build(serviceProvider, this, userId);
            personalOptionsRepository = serviceProvider.GetRequiredService<IPersonalOptionsRepository>();
            cameraRepository = serviceProvider.GetRequiredService<ICameraRepository>();
            serverRepository = serviceProvider.GetRequiredService<IServerRepository>();
            this.cameraId = cameraId;
            Initialize(userId, cameraId, true);
            display = DisplayProvider.Get(displayId);
            rectangle = display.Bounds;
        }

        private void Initialize(long userId, long cameraId, bool fullScreen)
        {
            var generalOptionsRepository = new GeneralOptionsRepository();
            cameraMoveValue = generalOptionsRepository.Get<short>(Setting.CameraMoveValue, 7500);

            if (fullScreen)
            {
                kBD300ASimulatorServer.StartPipeServerAsync("KBD300A_Pipe");
                client = CameraRegister.RegisterCamera(userId, cameraId, display, ClientDataArrivedEventHandler, CameraMode.AxVideoPlayer);

                Console.CancelKeyPress += (sender, e) => OnExit();
                Application.ApplicationExit += (sender, e) => OnExit();
                AppDomain.CurrentDomain.ProcessExit += (sender, e) => OnExit();
            }

            closeToolStripMenuItem.Text = Lng.Elem("Close");
            //closeToolStripMenuItem.Enabled = permissionManager.CurrentUser.HasPermission(WindowManagementPermissions.Close);
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
                        axVideoPlayerWindow.AxVideoPlayer.CameraMove(0, cameraMoveValue);
                    }
                    else if (message.StartsWith(NetworkCommand.TiltToNorth.ToString(), StringComparison.InvariantCulture))
                    {
                        axVideoPlayerWindow.AxVideoPlayer.CameraMove((short)-cameraMoveValue, 0);
                    }
                    else if (message.StartsWith(NetworkCommand.PanToEastAndTiltToNorth.ToString(), StringComparison.InvariantCulture))
                    {
                        axVideoPlayerWindow.AxVideoPlayer.CameraMove((short)-cameraMoveValue, cameraMoveValue);
                    }
                    else if (message.StartsWith(NetworkCommand.PanToWestAndTiltToNorth.ToString(), StringComparison.InvariantCulture))
                    {
                        axVideoPlayerWindow.AxVideoPlayer.CameraMove((short)-cameraMoveValue, (short)-cameraMoveValue);
                    }
                    else if (message.StartsWith(NetworkCommand.MoveToPresetZero.ToString(), StringComparison.InvariantCulture))
                    {
                        axVideoPlayerWindow.AxVideoPlayer.CameraGoToPreset(0);
                    }
                    else if (message.StartsWith(NetworkCommand.TiltToSouth.ToString(), StringComparison.InvariantCulture))
                    {
                        axVideoPlayerWindow.AxVideoPlayer.CameraMove(cameraMoveValue, 0);
                    }
                    else if (message.StartsWith(NetworkCommand.PanToEastAndTiltToSouth.ToString(), StringComparison.InvariantCulture))
                    {
                        axVideoPlayerWindow.AxVideoPlayer.CameraMove(cameraMoveValue, cameraMoveValue);
                    }
                    else if (message.StartsWith(NetworkCommand.PanToWestAndTiltToSouth.ToString(), StringComparison.InvariantCulture))
                    {
                        axVideoPlayerWindow.AxVideoPlayer.CameraMove(cameraMoveValue, (short)-cameraMoveValue);
                    }
                    else if (message.StartsWith(NetworkCommand.PanToWest.ToString(), StringComparison.InvariantCulture))
                    {
                        axVideoPlayerWindow.AxVideoPlayer.CameraMove(0, (short)-cameraMoveValue);
                    }
                    else if (message.StartsWith(NetworkCommand.StopPanAndTilt.ToString(), StringComparison.InvariantCulture))
                    {
                        axVideoPlayerWindow.AxVideoPlayer.CameraMove(0, 0);
                    }
                    else if (message.StartsWith(NetworkCommand.StopZoom.ToString(), StringComparison.InvariantCulture))
                    {
                        axVideoPlayerWindow.AxVideoPlayer.CameraZoom(0);
                    }
                    else if (message.StartsWith(NetworkCommand.ZoomIn.ToString(), StringComparison.InvariantCulture))
                    {
                        axVideoPlayerWindow.AxVideoPlayer.CameraZoom(cameraMoveValue);
                    }
                    else if (message.StartsWith(NetworkCommand.ZoomOut.ToString(), StringComparison.InvariantCulture))
                    {
                        axVideoPlayerWindow.AxVideoPlayer.CameraZoom((short)-cameraMoveValue);
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

        private void AxVideoCameraWindow_Load(object sender, EventArgs e)
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

        private void AxVideoCameraWindow_Shown(object sender, EventArgs e)
        {
            //axVideoPlayerWindow.AxVideoPicture.Visible = false;
            //axVideoPlayerWindow.AxVideoPlayer.ConnectFailed += AxVideoPlayer_ConnectionFailed;
            //axVideoPlayerWindow.AxVideoPlayer.Disconnected += AxVideoPlayer_Disconnected;
            var userId = permissionManager.CurrentUser.Tag.Id;
            var camera = cameraRepository.Select(cameraId);
            if (camera == null)
            {
                DebugErrorBox.Show("Camera is null", $"Cannot find camera with Id: {cameraId}");
            }
            var server = serverRepository.Select(camera.ServerId);
            if (server == null)
            {
                DebugErrorBox.Show("Server is null", $"Cannot find server with Id: {camera.ServerId}");
            }

            var largeFontSize = personalOptionsRepository.Get(Setting.CameraLargeFontSize, userId, 30);
            //var smallFontSize = personalOptionsRepository.Get(Setting.CameraSmallFontSize, userId, 15);
            axVideoPlayerWindow.OverlayFont = new Font(personalOptionsRepository.Get(Setting.CameraFont, userId, "Arial"), largeFontSize, FontStyle.Bold);
            axVideoPlayerWindow.OverlayBrush = new SolidBrush(Color.FromArgb(personalOptionsRepository.Get(Setting.CameraFontColor, userId, Color.White.ToArgb())));
            //var shadowColor = Color.FromArgb(personalOptionsRepository.Get(Setting.CameraFontShadowColor, userId, Color.Black.ToArgb()));

            var text = personalOptionsRepository.GetCameraName(userId, server, camera);
            if (gridCamera?.Frame ?? false)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
                Text = text;
            }
            else
            {
                if (gridCamera?.Osd ?? false)
                {
                    axVideoPlayerWindow.OverlayText = text;
                }
            }
            if (gridCamera?.ShowDateTime ?? false)
            {
                axVideoPlayerWindow.OverlayText += DateTime.Now.ToString();
            }

            axVideoPlayerWindow.AxVideoPlayer.Start(server.IpAddress, camera.Guid, server.Username, server.Password);
        }

        //private void Start(int waitTimeInMs = 500)
        //{
        //    if (waitTimeInMs <= 2000)
        //    {
        //        waitTimeInMs *= 2;
        //    }
        //    axVideoPlayerWindow.AxVideoPlayer.WaitForConnect(waitTimeInMs);
        //    axVideoPlayerWindow.AxVideoPlayer.Start(server.IpAddress, camera.Guid, server.Username, server.Password);
        //    //axVideoPlayerWindow.AxVideoPicture.Connect(server.IpAddress, camera.Guid, server.Username, server.Password);
        //}

        //private void AxVideoPlayer_Disconnected(object sender, EventArgs e)
        //{
        //    axVideoPlayerWindow.AxVideoPlayer.Stop();
        //    //Start();
        //}

        //private void AxVideoPlayer_ConnectionFailed(object sender, AxVIDEOCONTROL4Lib._DVideoPictureEvents_onConnectFailedEvent e)
        //{
        //    axVideoPlayerWindow.AxVideoPlayer.Stop();
        //    //Start();
        //}

        private void AxVideoCameraWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnExit();
        }

        private void OnExit()
        {
            kBD300ASimulatorServer?.Stop();
            axVideoPlayerWindow.AxVideoPlayer.Stop();
            axVideoPlayerWindow.AxVideoPlayer.Dispose();
            client?.Send($"{NetworkCommand.UnregisterCamera}", true);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

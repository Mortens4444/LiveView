using CameraForms.Dto;
using Database.Models;
using Database.Repositories;
using LiveView.Core.CustomEventArgs;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Network;
using LiveView.Core.Extensions;
using LiveView.Core.Services;
using LiveView.Core.Services.Net;
using LiveView.Core.Services.Pipe;
using Mtf.LanguageService;
using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Network.EventArg;
using Mtf.Permissions.Services;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace CameraForms.Forms
{
    public partial class VideoSourceCameraWindow : Form
    {
        private readonly DisplayDto display;
        private readonly Point location;
        private readonly Size size;
        private readonly string serverIp;
        private readonly string videoCaptureSource;
        private readonly PermissionManager<User> permissionManager;

        private Image lastImage;
        private Timer frameTimer;
        private readonly int frameTimeout = 1500;

        private VideoCaptureClient videoCaptureClient;
        private readonly KBD300ASimulatorServer kBD300ASimulatorServer = new KBD300ASimulatorServer();

        private readonly ManualResetEvent initializationCompleted = new ManualResetEvent(false);
        private readonly Rectangle rectangle;
        private Client client;

        private VideoCaptureSourceCameraInfo videoCaptureSourceCameraInfo;

        public VideoSourceCameraWindow(Client client, PermissionManager<User> permissionManager, VideoCaptureSourceCameraInfo videoCaptureSourceCameraInfo, Rectangle rectangle)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            this.client = client;
            this.rectangle = rectangle;
            this.permissionManager = permissionManager;
            this.videoCaptureSourceCameraInfo = videoCaptureSourceCameraInfo;
            StartVideoCapture();
        }

        public VideoSourceCameraWindow(long userId, string serverIp, string videoCaptureSource, Point location, Size size)
        {
            InitializeComponent();

            this.serverIp = serverIp;
            this.videoCaptureSource = videoCaptureSource;
            permissionManager = new PermissionManager<User>();
            Initialize(userId, serverIp, videoCaptureSource);
#if DEBUG
            this.location = new Point(0, 0);
            this.size = new Size(100, 100);
            TopMost = false;
#else
            this.location = location;
            this.size = size;
#endif
        }

        public VideoSourceCameraWindow(long userId, string serverIp, string videoCaptureSource, long? displayId)
        {
            InitializeComponent();
            this.serverIp = serverIp;
            this.videoCaptureSource = videoCaptureSource;
            permissionManager = new PermissionManager<Database.Models.User>();
            Initialize(userId, serverIp, videoCaptureSource);

            var displayRepository = new DisplayRepository();
            var fullScreenDisplay = (displayId.HasValue ? displayRepository.Select(displayId.Value) : displayRepository.GetFullscreenDisplay()) ?? throw new InvalidOperationException("Choose fullscreen display first.");
            var displayManager = new DisplayManager();
            var displays = displayManager.GetAll();

            display = displays.FirstOrDefault(d => d.GetId() == fullScreenDisplay.Id);
            if (display == null)
            {
                throw new InvalidOperationException("Choose another fullscreen display.");
            }
        }

        private void Initialize(long userId, string serverIp, string videoCaptureSource)
        {
            Console.CancelKeyPress += (sender, e) => OnExit();
            Application.ApplicationExit += (sender, e) => OnExit();
            AppDomain.CurrentDomain.ProcessExit += (sender, e) => OnExit();
            FormClosing += (sender, e) => OnExit();

            kBD300ASimulatorServer.StartPipeServerAsync("KBD300A_Pipe");

            var liveViewServerIp = ConfigurationManager.AppSettings["LiveViewServer.IpAddress"];
            var listenerPort = ConfigurationManager.AppSettings["LiveViewServer.ListenerPort"];
            if (UInt16.TryParse(listenerPort, out var serverPort))
            {
                try
                {
                    client = new Client(liveViewServerIp, serverPort);
                    client.DataArrived += ClientDataArrivedEventHandler;
                    client.Connect();
                    var displayId = display?.Id ?? "";
#if NET481
                    client.Send($"{NetworkCommand.RegisterVideoSource}|{client.Socket.LocalEndPoint}|{userId}|{serverIp}|{videoCaptureSource}|{displayId}|{Process.GetCurrentProcess().Id}", true);
#else
                    client.Send($"{NetworkCommand.RegisterVideoSource}|{client.Socket.LocalEndPoint}|{userId}|{serverIp}|{videoCaptureSource}|{displayId}|{Environment.ProcessId}", true);
#endif
                }
                catch (Exception ex)
                {
                    DebugErrorBox.Show(ex);
                }
            }
            else
            {
                ErrorBox.Show("General error", "LiveViewServer.ListenerPort cannot be parsed as an ushort.");
            }

            mtfCamera.SetOsdText("Arial", 20, FontStyle.Bold, Color.Red, $"{liveViewServerIp}:{listenerPort} - {videoCaptureSource}");

            frameTimer = new Timer(frameTimeout);
            frameTimer.Elapsed += (s, e) =>
            {
                Invoke((Action)(() =>
                {
                    mtfCamera.SetImage(Properties.Resources.nosignal, false);
                }));
                frameTimer.Stop();
            };

            frameTimer.AutoReset = false;

            closeToolStripMenuItem.Text = Lng.Elem("Close");

            var userRepository = new UserRepository();
            var user = userRepository.Select(userId);

            permissionManager.SetUser(this, new Mtf.Permissions.Models.User<Database.Models.User>
            {

            });
            //closeToolStripMenuItem.Enabled = permissionManager.CurrentUser.HasPermission(WindowManagementPermissions.Close);
        }

        private void StartVideoCapture()
        {
            var agentRepository = new AgentRepository();

            Task.Run(() =>
            {
                Agent agent = null;
                do
                {
                    var agents = agentRepository.SelectAll();
                    agent = agents.FirstOrDefault(a => a.ServerIp == videoCaptureSourceCameraInfo.ServerIp && a.VideoCaptureSourceName == videoCaptureSourceCameraInfo.VideoSourceName);
                    Thread.Sleep(500);
                }
                while (agent == null);

                videoCaptureClient = new VideoCaptureClient(agent.ServerIp, agent.Port);
                videoCaptureClient.FrameArrived += VideoCaptureClient_FrameArrived;
                videoCaptureClient.Start();
                initializationCompleted.Set();
                Invoke((Action)(() =>
                {
                    frameTimer = new Timer(frameTimeout);
                    frameTimer.Elapsed += (s, e) =>
                    {
                        Invoke((Action)(() =>
                        {
                            mtfCamera.SetImage(Properties.Resources.nosignal, false);
                            client.Send($"{NetworkCommand.AgentDisconnected}|{videoCaptureSourceCameraInfo.ServerIp}", true);
                            Thread.Sleep(200);
                            ReconnectVideoCapture();
                        }));
                        frameTimer.Stop();
                    };
                    frameTimer.AutoReset = false;
                }));
            });
        }

        /// <summary>
        /// Can only be called after the Agents table has been cleared.
        /// </summary>
        private void ReconnectVideoCapture()
        {
            Task.Run(() =>
            {
                videoCaptureClient.FrameArrived -= VideoCaptureClient_FrameArrived;
                videoCaptureClient?.Stop();
                videoCaptureClient = null;
                StartVideoCapture();
            });
        }

        private void OnExit()
        {
#if NET481
            client?.Send($"{NetworkCommand.UnregisterVideoSource}", true);
#else
            client?.Send($"{NetworkCommand.UnregisterVideoSource}", true);
#endif
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
                        //videoCaptureClient.
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

        private void VideoSourceCameraWindow_Load(object sender, EventArgs e)
        {
#if DEBUG
            Location = new Point(0, 0);
            Size = new Size(100, 100);
            TopMost = false;
#else
            if (display != null)
            {
                Location = new Point(display.X, display.Y);
                Size = new Size(display.MaxWidth, display.MaxHeight);
            }
            else
            {
                Location = location;
                Size = size;
            }
#endif
        }

        private void VideoSourceCameraWindow_Shown(object sender, EventArgs e)
        {
            var agentRepository = new AgentRepository();
            var agents = agentRepository.SelectAll();
            var agent = agents.FirstOrDefault(a => a.ServerIp == serverIp && a.VideoCaptureSourceName == videoCaptureSource);
            if (agent != null)
            {
                videoCaptureClient = new VideoCaptureClient(agent.ServerIp, agent.Port);
                videoCaptureClient.FrameArrived += VideoCaptureClient_FrameArrived;

                videoCaptureClient.Start();
                frameTimer.Start();
            }

            //Task.Run(() =>
            //{
            //    initializationCompleted.WaitOne();
            //    videoCaptureClient?.Start();
            //});
            //frameTimer?.Start();
            //mtfCamera.SetOsdText("Arial", 20, FontStyle.Bold, Color.Red, $"{videoCaptureSourceCameraInfo.ServerIp} - {videoCaptureSourceCameraInfo.GridCamera.VideoSourceName}");
        }

        private void VideoCaptureClient_FrameArrived(object sender, FrameArrivedEventArgs e)
        {
            try
            {
                frameTimer.Stop();
                lastImage?.Dispose();
                mtfCamera.SetImage(e.Frame, true);
                lastImage = e.Frame;
                frameTimer.Start();
            }
            catch (InvalidOperationException)
            {
                mtfCamera.SetImage(Properties.Resources.nosignal, false);
            }
            catch (Exception ex)
            {
                mtfCamera.SetImage(Properties.Resources.nosignal, false);
                DebugErrorBox.Show(ex);
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            videoCaptureClient?.Stop();
            Application.Exit();
        }

        private void VideoSourceCameraWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            frameTimer?.Stop();
            videoCaptureClient?.Stop();
        }
    }
}

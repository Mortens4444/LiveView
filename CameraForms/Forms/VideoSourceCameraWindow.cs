using CameraForms.Dto;
using CameraForms.Services;
using Database.Enums;
using Database.Interfaces;
using Database.Models;
using Database.Repositories;
using LiveView.Core.CustomEventArgs;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Network;
using LiveView.Core.Extensions;
using LiveView.Core.Services;
using LiveView.Core.Services.Net;
using LiveView.Core.Services.Pipe;
using Microsoft.Extensions.DependencyInjection;
using Mtf.LanguageService;
using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Permissions.Services;
using System;
using System.Configuration;
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
        private readonly PermissionManager<User> permissionManager;
        private readonly ICameraFunctionRepository cameraFunctionRepository;
        private readonly IPersonalOptionsRepository personalOptionsRepository;
        private readonly KBD300ASimulatorServer kBD300ASimulatorServer;
        private readonly int frameTimeout = 1500;
        private readonly Rectangle rectangle;

        private Image lastImage;
        private Timer frameTimer;
        private Client client;
        private VideoCaptureClient videoCaptureClient;
        private VideoCaptureSourceCameraInfo videoCaptureSourceCameraInfo;
        private FullScreenCameraMessageHandler fullScreenCameraMessageHandler;

        private int largeFontSize;
        private string fontFamily;
        private Color fontColor;
        private SolidBrush fontBrush;
        private Point location = new Point(10, 10);
        private string cameraName;
        private GridCamera gridCamera;

        public VideoSourceCameraWindow(Client client, PermissionManager<User> permissionManager, ICameraFunctionRepository cameraFunctionRepository, IPersonalOptionsRepository personalOptionsRepository, VideoCaptureSourceCameraInfo videoCaptureSourceCameraInfo, Rectangle rectangle, GridCamera gridCamera)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            this.client = client;
            this.rectangle = rectangle;
            this.permissionManager = permissionManager;
            this.videoCaptureSourceCameraInfo = videoCaptureSourceCameraInfo;
            this.cameraFunctionRepository = cameraFunctionRepository;
            this.personalOptionsRepository = personalOptionsRepository;
            StartVideoCaptureImageReceiver();
            SetOsdParameters(permissionManager?.CurrentUser?.Tag?.Id ?? 0, videoCaptureSourceCameraInfo?.ServerIp, videoCaptureSourceCameraInfo?.VideoSourceName);
            this.gridCamera = gridCamera;

            if (gridCamera?.Frame ?? false)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
            }
        }

        public VideoSourceCameraWindow(ServiceProvider serviceProvider, long userId, string serverIp, string videoCaptureSource, Point location, Size size)
        {
            InitializeComponent();

            rectangle = new Rectangle(location, size);
            permissionManager = PermissionManagerBuilder.Build(serviceProvider, this, userId);
            personalOptionsRepository = serviceProvider.GetRequiredService<IPersonalOptionsRepository>();
            kBD300ASimulatorServer = new KBD300ASimulatorServer();

            Initialize(userId, serverIp, videoCaptureSource, true);
        }

        public VideoSourceCameraWindow(ServiceProvider serviceProvider, long userId, string serverIp, string videoCaptureSource, long? displayId)
        {
            InitializeComponent();

            permissionManager = PermissionManagerBuilder.Build(serviceProvider, this, userId);
            cameraFunctionRepository = serviceProvider.GetRequiredService<ICameraFunctionRepository>();
            personalOptionsRepository = serviceProvider.GetRequiredService<IPersonalOptionsRepository>();
            kBD300ASimulatorServer = new KBD300ASimulatorServer();

            Initialize(userId, serverIp, videoCaptureSource, true);

            var displayRepository = new DisplayRepository();
            var fullScreenDisplay = (displayId.HasValue ? displayRepository.Select(displayId.Value) : displayRepository.GetFullscreenDisplay()) ?? throw new InvalidOperationException("Choose fullscreen display first.");
            var displayManager = new DisplayManager();
            var displays = displayManager.GetAll();

            display = displays.FirstOrDefault(d => d.GetId() == fullScreenDisplay.Id);
            if (display == null)
            {
                throw new InvalidOperationException("Choose another fullscreen display.");
            }
            rectangle = display.Bounds;
        }

        private void Initialize(long userId, string serverIp, string videoCaptureSource, bool fullScreen)
        {
            videoCaptureSourceCameraInfo = new VideoCaptureSourceCameraInfo
            {
                ServerIp = serverIp,
                VideoSourceName = videoCaptureSource,
                GridCamera = null
            };
            StartVideoCaptureImageReceiver();
            SetOsdParameters(userId, serverIp, videoCaptureSource);

            if (fullScreen)
            {
                kBD300ASimulatorServer.StartPipeServerAsync("KBD300A_Pipe");
                var displayId = display?.Id ?? String.Empty;
                fullScreenCameraMessageHandler = new FullScreenCameraMessageHandler(userId, serverIp, videoCaptureSource, this, display, CameraMode.VideoSource, cameraFunctionRepository);

                Console.CancelKeyPress += (sender, e) => OnExit();
                Application.ApplicationExit += (sender, e) => OnExit();
                AppDomain.CurrentDomain.ProcessExit += (sender, e) => OnExit();
            }

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
            //closeToolStripMenuItem.Enabled = permissionManager.CurrentUser.HasPermission(WindowManagementPermissions.Close);
        }

        private void SetOsdParameters(long userId, string serverIp, string videoCaptureSource)
        {
            largeFontSize = personalOptionsRepository.Get(Setting.CameraLargeFontSize, userId, 30);
            //var smallFontSize = personalOptionsRepository.Get(Setting.CameraSmallFontSize, userId, 15);
            fontFamily = personalOptionsRepository.Get(Setting.CameraFont, userId, "Arial");
            fontColor = Color.FromArgb(personalOptionsRepository.Get(Setting.CameraFontColor, userId, Color.White.ToArgb()));
            fontBrush = new SolidBrush(fontColor);

            var text = personalOptionsRepository.GetCameraName(userId, serverIp, videoCaptureSource);
            if (gridCamera?.Frame ?? false)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
                Text = text;
            }
            else
            {
                if (gridCamera?.Osd ?? false)
                {
                    cameraName = text;
                }
            }
            if (gridCamera?.ShowDateTime ?? false)
            {
                cameraName += DateTime.Now.ToString();
            }

            mtfCamera.SetOsdText(fontFamily, largeFontSize, FontStyle.Bold, fontColor, cameraName);
            mtfCamera.Paint += MtfCamera_Paint;
        }

        private void MtfCamera_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!String.IsNullOrEmpty(cameraName))
            {
                var graphics = e.Graphics;
                {
                    //_ = graphics.MeasureString(OverlayText, OverlayFont);
                    graphics.DrawString(cameraName, mtfCamera.Font, fontBrush, location);
                }
            }
        }

        private void StartVideoCaptureImageReceiver()
        {
            var agentRepository = new AgentRepository();
            var videoSourceRepository = new VideoSourceRepository();

            Task.Run(() =>
            {
                Agent agent = null;
                VideoSource videoSource = null;
                do
                {
                    var agents = agentRepository.SelectAll();
                    var videoSources = videoSourceRepository.SelectAll();
                    videoSource = videoSources.FirstOrDefault(a => a.ServerIp == videoCaptureSourceCameraInfo.ServerIp && a.VideoSourceName == videoCaptureSourceCameraInfo.VideoSourceName);
                    agent = agents.FirstOrDefault(a => a.VideoSourceId == videoSource.Id);
                    Thread.Sleep(500);
                }
                while (agent == null);

                videoCaptureClient = new VideoCaptureClient(videoSource.ServerIp, agent.Port);
                videoCaptureClient.FrameArrived += VideoCaptureClient_FrameArrived;
                videoCaptureClient.Start();
                Invoke((Action)(() =>
                {
                    frameTimer = new Timer(frameTimeout);
                    frameTimer.Elapsed += (s, e) =>
                    {
                        Invoke((Action)(() =>
                        {
                            mtfCamera.SetImage(Properties.Resources.nosignal, false);

                            client?.Send($"{NetworkCommand.AgentDisconnected}|{videoCaptureSourceCameraInfo.ServerIp}|{videoCaptureSourceCameraInfo.VideoSourceName}", true);
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
                StartVideoCaptureImageReceiver();
            });
        }

        private void VideoSourceCameraWindow_Load(object sender, EventArgs e)
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

        private void VideoSourceCameraWindow_Shown(object sender, EventArgs e)
        {
            var agentRepository = new AgentRepository();
            var videoSourceRepository = new VideoSourceRepository();

            var videoSources = videoSourceRepository.SelectAll();
            var videoSource = videoSources.FirstOrDefault(a => a.ServerIp == videoCaptureSourceCameraInfo.ServerIp && a.VideoSourceName == videoCaptureSourceCameraInfo.VideoSourceName);
            var agents = agentRepository.SelectAll();
            var agent = agents.FirstOrDefault(a => a.VideoSourceId == videoSource.Id);

            if (agent != null)
            {
                videoCaptureClient = new VideoCaptureClient(videoSource.ServerIp, agent.Port);
                videoCaptureClient.FrameArrived += VideoCaptureClient_FrameArrived;
                videoCaptureClient.Start();
                frameTimer.Start();
            }
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
            Close();
        }

        private void OnExit()
        {
            fullScreenCameraMessageHandler.ExitVideoSource();
            kBD300ASimulatorServer?.Stop();
            frameTimer?.Stop();
            videoCaptureClient?.Stop();
        }

        private void VideoSourceCameraWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnExit();
        }
    }
}

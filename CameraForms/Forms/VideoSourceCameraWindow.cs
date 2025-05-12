using CameraForms.Dto;
using CameraForms.Services;
using Database.Enums;
using Database.Interfaces;
using Database.Models;
using Database.Repositories;
using LiveView.Core.Dto;
using LiveView.Core.Extensions;
using LiveView.Core.Services;
using LiveView.Core.Services.Net;
using LiveView.Core.Services.Pipe;
using Microsoft.Extensions.DependencyInjection;
using Mtf.LanguageService;
using Mtf.MessageBoxes;
using Mtf.Network.EventArg;
using Mtf.Permissions.Services;
using System;
using System.Drawing;
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
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        private Image lastImage;
        private Timer frameTimer;
        private MyVideoCaptureClient videoCaptureClient;
        private VideoCaptureSourceCameraInfo videoCaptureSourceCameraInfo;
        private FullScreenCameraMessageHandler fullScreenCameraMessageHandler;

        private bool frameUnchanged;
        private int largeFontSize;
        private string fontFamily;
        private Color fontColor;
        private SolidBrush fontBrush;
        private Point location = new Point(10, 10);
        private string cameraName;
        private GridCamera gridCamera;
        private Pen red = new Pen(new SolidBrush(Color.Red), 3);
        private int reconnectTimeout;

        public VideoSourceCameraWindow(PermissionManager<User> permissionManager, ICameraFunctionRepository cameraFunctionRepository, IPersonalOptionsRepository personalOptionsRepository, VideoCaptureSourceCameraInfo videoCaptureSourceCameraInfo, Rectangle rectangle, GridCamera gridCamera)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            this.rectangle = rectangle;
            this.permissionManager = permissionManager;
            this.videoCaptureSourceCameraInfo = videoCaptureSourceCameraInfo;
            this.cameraFunctionRepository = cameraFunctionRepository;
            this.personalOptionsRepository = personalOptionsRepository;
            SetOsdParameters(permissionManager?.CurrentUser?.Tag?.Id ?? 0, videoCaptureSourceCameraInfo?.ServerIp, videoCaptureSourceCameraInfo?.VideoSourceName);
            this.gridCamera = gridCamera;
            reconnectTimeout = AppConfig.GetInt32(LiveView.Core.Constants.VideoSourceCameraWindowReconnectTimeout, 5000);

            if (gridCamera?.Frame ?? false)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
            }
        }

        public VideoSourceCameraWindow(IServiceProvider serviceProvider, CameraLaunchContext cameraLaunchContext)
        {
            if (cameraLaunchContext == null)
            {
                throw new ArgumentNullException(nameof(cameraLaunchContext));
            }

            InitializeComponent();

            cameraFunctionRepository = serviceProvider.GetRequiredService<ICameraFunctionRepository>();
            display = DisplayProvider.Get(cameraLaunchContext.DisplayId);
            
            permissionManager = PermissionManagerBuilder.Build(serviceProvider, this, cameraLaunchContext.UserId);
            personalOptionsRepository = serviceProvider.GetRequiredService<IPersonalOptionsRepository>();
            kBD300ASimulatorServer = new KBD300ASimulatorServer();
            rectangle = cameraLaunchContext.GetDisplay()?.Bounds ?? cameraLaunchContext.Rectangle;
            reconnectTimeout = AppConfig.GetInt32(LiveView.Core.Constants.VideoSourceCameraWindowReconnectTimeout, 5000);

            Initialize(cameraLaunchContext.UserId, cameraLaunchContext.ServerIp, cameraLaunchContext.VideoCaptureSource, true);
        }

        private void Initialize(long userId, string serverIp, string videoCaptureSource, bool fullScreen)
        {
            videoCaptureSourceCameraInfo = new VideoCaptureSourceCameraInfo
            {
                ServerIp = serverIp,
                VideoSourceName = videoCaptureSource,
                GridCamera = null
            };
            SetOsdParameters(userId, serverIp, videoCaptureSource);

            if (fullScreen)
            {
                kBD300ASimulatorServer.StartPipeServerAsync(LiveView.Core.Constants.PipeServerName);
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
                cameraName += DateUtils.GetNowFriendlyString();
            }

            Text = cameraName;
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
                    if (frameUnchanged)
                    {
                        graphics.DrawRectangle(red, Bounds);
                    }
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
                    try
                    {
                        var videoSourceInfo = videoSourceRepository.SelectVideoSourceAndAgentInfoByName(videoCaptureSourceCameraInfo.ServerIp, videoCaptureSourceCameraInfo.VideoSourceName);
                        agent = videoSourceInfo?.Item1;
                        if (agent == null)
                        {
                            ErrorBox.Show(Lng.Elem("General error"), String.Concat(Lng.Elem("Agent not found."), " ", videoCaptureSourceCameraInfo));
                            break;
                        }

                        videoSource = videoSourceInfo?.Item2;
                        if (videoSource == null)
                        {
                            var message = String.Format(Lng.Elem("VideoSource ({0}) is not registered."), videoCaptureSourceCameraInfo.ToString());
                            ErrorBox.Show(Lng.Elem("General error"), message);
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        DebugErrorBox.Show(ex);
                    }
                }
                while (agent == null);

                if (agent == null)
                {
                    return;
                }

                while (!cancellationTokenSource.Token.IsCancellationRequested)
                {
                    try
                    {
                        videoCaptureClient = new MyVideoCaptureClient(agent.ServerIp, videoSource.Port);
                        videoCaptureClient.FrameUnchanged += VideoCaptureClient_FrameUnchanged;
                        videoCaptureClient.FrameArrived += VideoCaptureClient_FrameArrived;
                        videoCaptureClient.Start();
                        cancellationTokenSource.Cancel();
                    }
                    catch (Exception ex)
                    {
                        DebugErrorBox.Show(ex);
                        Thread.Sleep(reconnectTimeout);
                    }
                }

                Invoke((Action)(() =>
                {
                    frameTimer = new Timer(frameTimeout);
                    frameTimer.Elapsed += (s, e) =>
                    {
                        Invoke((Action)(() =>
                        {
                            mtfCamera.SetImage(Properties.Resources.nosignal, false);

                            //client?.Send($"{NetworkCommand.AgentDisconnected}|{videoCaptureSourceCameraInfo.ServerIp}|{videoCaptureSourceCameraInfo.VideoSourceName}", true);
                            Thread.Sleep(200);
                            ReconnectVideoCapture();
                        }));
                        frameTimer.Stop();
                    };
                    frameTimer.AutoReset = false;
                }));
            });
        }

        private void VideoCaptureClient_FrameUnchanged(object sender, EventArgs e)
        {
            frameUnchanged = true;
        }

        /// <summary>
        /// Can only be called after the Agents table has been cleared.
        /// </summary>
        private void ReconnectVideoCapture()
        {
            Task.Run(() =>
            {
                if (videoCaptureClient != null)
                {
                    videoCaptureClient.FrameUnchanged -= VideoCaptureClient_FrameUnchanged;
                    videoCaptureClient.FrameArrived -= VideoCaptureClient_FrameArrived;
                    videoCaptureClient.Stop();
                    videoCaptureClient = null;
                }
                StartVideoCaptureImageReceiver();
            });
        }

        private void VideoSourceCameraWindow_Load(object sender, EventArgs e)
        {
            this.SetFormSizeAndPosition(rectangle);
        }

        private void VideoSourceCameraWindow_Shown(object sender, EventArgs e)
        {
            if (videoCaptureSourceCameraInfo.IsEmpty())
            {
                try
                {
                    throw new InvalidOperationException("Server and video capture source are not initialized.");
                }
                catch (Exception ex)
                {
                    DebugErrorBox.Show(ex);
                }
            }

            StartVideoCaptureImageReceiver();
        }

        private void VideoCaptureClient_FrameArrived(object sender, FrameArrivedEventArgs e)
        {
            frameUnchanged = false;
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
            fullScreenCameraMessageHandler?.ExitVideoSource();
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

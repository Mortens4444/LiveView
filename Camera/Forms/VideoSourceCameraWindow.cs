using Database.Repositories;
using LiveView.Core.CustomEventArgs;
using LiveView.Core.Dto;
using LiveView.Core.Extensions;
using LiveView.Core.Services;
using LiveView.Core.Services.Net;
using Mtf.LanguageService;
using Mtf.MessageBoxes;
using Mtf.Permissions.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace CameraApp.Forms
{
    public partial class VideoSourceCameraWindow : Form
    {
        private readonly DisplayDto display;
        private readonly Point location;
        private readonly Size size;
        private readonly string serverIp;
        private readonly string videoCaptureSource;
        private readonly PermissionManager<Database.Models.User> permissionManager;

        private Image lastImage;
        private Timer frameTimer;
        private readonly int frameTimeout = 1500;

        private VideoCaptureClient videoCaptureClient;

        public VideoSourceCameraWindow(long userId, string serverIp, string videoCaptureSource, Point location, Size size)
        {
            InitializeComponent();
            this.serverIp = serverIp;
            this.videoCaptureSource = videoCaptureSource;
            permissionManager = new PermissionManager<Database.Models.User>();
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
            var agent = agents.First(a => a.ServerIp == serverIp && a.VideoCaptureSourceName == videoCaptureSource);
            videoCaptureClient = new VideoCaptureClient(agent.ServerIp, agent.Port);
            videoCaptureClient.FrameArrived += VideoCaptureClient_FrameArrived;

            videoCaptureClient.Start();
            frameTimer.Start();
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
            videoCaptureClient.Stop();
            Application.Exit();
        }
    }
}

using Database.Models;
using Database.Repositories;
using LiveView.Core.CustomEventArgs;
using LiveView.Core.Extensions;
using LiveView.Core.Services.Net;
using Mtf.MessageBoxes;
using Mtf.Permissions.Services;
using Sequence.Dto;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Sequence.Forms
{
    public partial class VideoSourceCamera : Form
    {
        //private int waitTimeInMs = 500;
        private readonly PermissionManager<User> permissionManager;
        private readonly Rectangle rectangle;
        private readonly VideoCaptureClient videoCaptureClient;

        private Image lastImage;
        private Timer frameTimer;
        private readonly int frameTimeout = 1500;

        public VideoSourceCamera(PermissionManager<User> permissionManager, VideoCatureSourceCameraInfo videoCatureSourceCameraInfo, Rectangle rectangle)
        {
            InitializeComponent();
            this.rectangle = rectangle;
            this.permissionManager = permissionManager;
            var agentRepository = new AgentRepository();
            var agents = agentRepository.SelectAll();
            var agent = agents.First(a => a.ServerIp == videoCatureSourceCameraInfo.ServerIp && a.VideoCaptureSourceName == videoCatureSourceCameraInfo.VideoSourceName);
            videoCaptureClient = new VideoCaptureClient(agent.ServerIp, agent.Port);
            videoCaptureClient.FrameArrived += VideoCaptureClient_FrameArrived;

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
        }

        private void VideoSourceCamera_Load(object sender, EventArgs e)
        {
            Location = new Point(rectangle.X, rectangle.Y);
            Size = new Size(rectangle.Width, rectangle.Height);
        }

        private void VideoSourceCamera_Shown(object sender, EventArgs e)
        {
            Start();
            frameTimer.Start();
        }

        private void Start()
        {
            videoCaptureClient.Start();
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

        private void VideoSourceCamera_FormClosing(object sender, FormClosingEventArgs e)
        {
            frameTimer.Stop();
            videoCaptureClient.Stop();
        }
    }
}

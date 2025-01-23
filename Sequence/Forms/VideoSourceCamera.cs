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

namespace Sequence.Forms
{
    public partial class VideoSourceCamera : Form
    {
        //private int waitTimeInMs = 500;
        private readonly PermissionManager<User> permissionManager;
        private readonly Rectangle rectangle;
        private readonly VideoCaptureClient videoCaptureClient;

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
        }

        private void VideoSourceCamera_Load(object sender, EventArgs e)
        {
            Location = new Point(rectangle.X, rectangle.Y);
            Size = new Size(rectangle.Width, rectangle.Height);
        }

        private void VideoSourceCamera_Shown(object sender, EventArgs e)
        {
            Start();
        }

        private void Start()
        {
            videoCaptureClient.Start();
        }
        private Image lastImage = null;

        private void VideoCaptureClient_FrameArrived(object sender, FrameArrivedEventArgs e)
        {
            try
            {
                lastImage?.Dispose();
                mtfCamera.SetImage(e.Frame, true);
                lastImage = e.Frame;
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
            videoCaptureClient.Stop();
        }
    }
}

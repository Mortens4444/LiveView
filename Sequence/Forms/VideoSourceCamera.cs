using Database.Models;
using Database.Repositories;
using LiveView.Core.CustomEventArgs;
using LiveView.Core.Enums.Network;
using LiveView.Core.Extensions;
using LiveView.Core.Services.Net;
using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Permissions.Services;
using Sequence.Dto;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Sequence.Forms
{
    public partial class VideoSourceCamera : Form
    {
        private readonly ManualResetEvent initializationCompleted = new ManualResetEvent(false);
        private readonly PermissionManager<User> permissionManager;
        private readonly Rectangle rectangle;
        private readonly Client client;
        private readonly int frameTimeout = 1500;

        private VideoCaptureSourceCameraInfo videoCaptureSourceCameraInfo;
        private VideoCaptureClient videoCaptureClient;
        private Image lastImage;
        private Timer frameTimer;

        public VideoSourceCamera(Client client, PermissionManager<User> permissionManager, VideoCaptureSourceCameraInfo videoCaptureSourceCameraInfo, Rectangle rectangle)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            this.client = client;
            this.rectangle = rectangle;
            this.permissionManager = permissionManager;
            this.videoCaptureSourceCameraInfo = videoCaptureSourceCameraInfo;
            StartVideoCapture();
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

        private void VideoSourceCamera_Load(object sender, EventArgs e)
        {
            Location = new Point(rectangle.X, rectangle.Y);
            Size = new Size(rectangle.Width, rectangle.Height);
        }

        private void VideoSourceCamera_Shown(object sender, EventArgs e)
        {
            Start();
            frameTimer?.Start();
        }

        private void Start()
        {
            Task.Run(() =>
            {
                initializationCompleted.WaitOne();
                videoCaptureClient?.Start();
            });
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
            frameTimer?.Stop();
            videoCaptureClient?.Stop();
        }
    }
}

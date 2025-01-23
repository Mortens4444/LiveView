using Database.Models;
using Mtf.Permissions.Services;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Sequence.Forms
{
    public partial class AxVideoCamera : Form
    {
        //private int waitTimeInMs = 500;
        private readonly Server server;
        private readonly Camera camera;
        private readonly PermissionManager<User> permissionManager;
        private readonly Rectangle rectangle;
        private CancellationToken cancellationToken;

        public AxVideoCamera(PermissionManager<User> permissionManager, Camera camera, Server server, Rectangle rectangle, CancellationToken cancellationToken)
        {
            InitializeComponent();
            this.rectangle = rectangle;
            this.server = server;
            this.camera = camera;
            this.cancellationToken = cancellationToken;
            this.permissionManager = permissionManager;
        }

        private void AxVideoCamera_Load(object sender, EventArgs e)
        {
            Location = new Point(rectangle.X, rectangle.Y);
            Size = new Size(rectangle.Width, rectangle.Height);
        }

        private void AxVideoCamera_Shown(object sender, EventArgs e)
        {
            axVideoPlayerWindow.AxVideoPicture.Visible = false;
            axVideoPlayerWindow.OverlayText = $"{server.IpAddress} - {camera.CameraName}";
            axVideoPlayerWindow.AxVideoPlayer.ConnectFailed += AxVideoPlayer_ConnectionFailed;
            axVideoPlayerWindow.AxVideoPlayer.Disconnected += AxVideoPlayer_Disconnected;

            Start();
        }

        private void AxVideoPlayer_Disconnected(object sender, EventArgs e)
        {
            axVideoPlayerWindow.AxVideoPlayer.Stop();
            //Start();
        }

        private void AxVideoPlayer_ConnectionFailed(object sender, AxVIDEOCONTROL4Lib._DVideoPictureEvents_onConnectFailedEvent e)
        {
            axVideoPlayerWindow.AxVideoPlayer.Stop();
            //Start();
        }

        private void Start(int waitTimeInMs = 500)
        {
            if (waitTimeInMs <= 2000)
            {
                waitTimeInMs *= 2;
            }
            axVideoPlayerWindow.AxVideoPlayer.WaitForConnect(waitTimeInMs);
            axVideoPlayerWindow.AxVideoPlayer.Start(server.IpAddress, camera.Guid, server.Username, server.Password);
            //axVideoPlayerWindow.AxVideoPicture.Connect(server.IpAddress, camera.Guid, server.Username, server.Password);
        }

        private void AxVideoCamera_FormClosing(object sender, FormClosingEventArgs e)
        {
            axVideoPlayerWindow.AxVideoPlayer.Stop();
            axVideoPlayerWindow.AxVideoPlayer.Dispose();
        }
    }
}

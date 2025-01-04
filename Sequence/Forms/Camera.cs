using Database.Models;
using Mtf.Permissions.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sequence.Forms
{
    public partial class Camera : Form
    {
        private readonly Server server;
        private readonly Database.Models.Camera camera;
        private readonly PermissionManager permissionManager;
        private readonly Point location;
        private readonly Size size;

        public Camera(PermissionManager permissionManager, Database.Models.Camera camera, Server server, Point location, Size size)
        {
            InitializeComponent();
            this.location = location;
            this.size = size;
            this.server = server;
            this.camera = camera;
            this.permissionManager = permissionManager;
        }

        private void Camera_Load(object sender, EventArgs e)
        {
            Location = new Point(location.X, location.Y);
            Size = new Size(size.Width, size.Height);
        }

        private void Camera_Shown(object sender, EventArgs e)
        {
            axVideoPlayerWindow.AxVideoPlayer.Start(server.IpAddress, camera.Guid, server.Username, server.Password);
            axVideoPlayerWindow.OverlayText = $"{server.IpAddress} - {camera.CameraName}";
        }
    }
}

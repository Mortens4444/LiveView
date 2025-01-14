using Database.Repositories;
using LiveView.Core.Dto;
using LiveView.Core.Services;
using Mtf.LanguageService;
using Mtf.MessageBoxes;
using Mtf.Permissions.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CameraApp.Forms
{
    public partial class FullScreenCamera : Form
    {
        private readonly DisplayDto display;
        private readonly Point location;
        private readonly Size size;
        private readonly long cameraId;
        private readonly PermissionManager permissionManager;

        public FullScreenCamera(long userId, long cameraId, Point location, Size size)
        {
            InitializeComponent();
            this.cameraId = cameraId;
            permissionManager = new PermissionManager();
            Initialize(userId, cameraId);
#if DEBUG
            this.location = new Point(0, 0);
            this.size = new Size(100, 100);
            TopMost = false;
#else
            this.location = location;
            this.size = size;
#endif
            axVideoPlayerWindow.ContextMenuStrip = null;
        }

        public FullScreenCamera(long userId, long cameraId, long? displayId)
        {
            InitializeComponent();
            this.cameraId = cameraId;
            permissionManager = new PermissionManager();
            Initialize(userId, cameraId);

            var displayRepository = new DisplayRepository();
            var fullScreenDisplay = displayId.HasValue ? displayRepository.Select(displayId.Value) : displayRepository.GetFullscreenDisplay();
            if (fullScreenDisplay == null)
            {
                throw new InvalidOperationException("Choose fullscreen display first.");
            }
            var displayManager = new DisplayManager();
            var displays = displayManager.GetAll();

            display = displays.FirstOrDefault(d => d.GetId() == fullScreenDisplay.Id);
            if (display == null)
            {
                throw new InvalidOperationException("Choose another fullscreen display.");
            }
        }

        private void Initialize(long userId, long cameraId)
        {
            closeToolStripMenuItem.Text = Lng.Elem("Close");

            var userRepository = new UserRepository();
            var user = userRepository.Select(userId);

            permissionManager.SetUser(this, new Mtf.Permissions.Models.User
            {

            });
            //closeToolStripMenuItem.Enabled = permissionManager.CurrentUser.HasPermission(WindowManagementPermissions.Close);
        }

        private void FullScreenCamera_Load(object sender, EventArgs e)
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

        private void FullScreenCamera_Shown(object sender, EventArgs e)
        {
            var cameraRepository = new CameraRepository();
            var serverRepository = new ServerRepository();
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

            axVideoPlayerWindow.AxVideoPlayer.Start(server.IpAddress, camera.Guid, server.Username, server.Password);
            axVideoPlayerWindow.OverlayText = $"{server.IpAddress} - {camera.CameraName}";
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

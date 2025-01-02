using Database.Repositories;
using LiveView.Core.Dto;
using LiveView.Core.Services;
using Mtf.LanguageService;
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
        private readonly long cameraId;
        private readonly PermissionManager permissionManager;

        public FullScreenCamera(long userId, long cameraId, long? displayId)
        {
            InitializeComponent();
            closeToolStripMenuItem.Text = Lng.Elem("Close");
            this.cameraId = cameraId;

            var userRepository = new UserRepository();
            var user = userRepository.Select(userId);

            permissionManager = new PermissionManager();
            permissionManager.SetUser(this, new Mtf.Permissions.Models.User
            {

            });
            //closeToolStripMenuItem.Enabled = permissionManager.CurrentUser.HasPermission(WindowManagementPermissions.Close);

            var displayRepository = new DisplayRepository();
            var fullScreenDisplay = displayId.HasValue ? displayRepository.Select(displayId.Value) : displayRepository.GetFullscreenDisplay();
            if (fullScreenDisplay == null)
            {
                throw new InvalidOperationException("Choose fullscreen display first.");
            }
            var displayManager = new DisplayManager();
            var displays = displayManager.GetAll();

            display = displays.FirstOrDefault(d => d.Id == fullScreenDisplay.Id);
            if (display == null)
            {
                throw new InvalidOperationException("Choose another fullscreen display.");
            }
        }

        private void FullScreenCamera_Load(object sender, EventArgs e)
        {
            Location = new Point(display.X, display.Y);
            Size = new Size(display.MaxWidth, display.MaxHeight);
        }

        private void FullScreenCamera_Shown(object sender, EventArgs e)
        {
            var cameraRepository = new CameraRepository();
            var serverRepository = new ServerRepository();
            var camera = cameraRepository.Select(cameraId);
            var server = serverRepository.Select(camera.ServerId);

            axVideoPlayerWindow.AxVideoPlayer.Start(server.IpAddress, camera.Guid, server.Username, server.Password);
            axVideoPlayerWindow.OverlayText = $"{server.IpAddress} - {camera.CameraName}";
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

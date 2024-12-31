using Database.Models;
using Database.Repositories;
using Mtf.LanguageService;
using System;
using System.Windows.Forms;

namespace CameraApp.Forms
{
    public partial class FullScreenCamera : Form
    {
        private readonly long cameraId;

        public FullScreenCamera(long cameraId)
        {
            InitializeComponent();
            closeToolStripMenuItem.Text = Lng.Elem("Close");
            this.cameraId = cameraId;
        }

        private void FullScreenCamera_Shown(object sender, EventArgs e)
        {
            var cameraRepository = new CameraRepository<Camera>();
            var serverRepository = new ServerRepository<Server>();
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

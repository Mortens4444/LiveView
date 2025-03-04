using CameraForms.Dto;
using CameraForms.Services;
using Database.Models;
using Database.Repositories;
using Mtf.Controls.Sunell.IPR67.SunellSdk;
using Mtf.Permissions.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CameraForms.Forms
{
    public partial class SunellCameraWindow : Form
    {
        private PermissionManager<User> permissionManager;
        private Rectangle rectangle;
        private SunellCameraInfo sunellCameraInfo;

        public SunellCameraWindow(long userId, long cameraId, long? displayId)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            
            var display = DisplayProvider.Get(displayId);
            rectangle = display.Bounds;
            Initialize(userId, cameraId, rectangle);
        }

        public SunellCameraWindow(long userId, long cameraId, Rectangle rectangle)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            
            Initialize(userId, cameraId, rectangle);
        }

        public SunellCameraWindow(PermissionManager<User> permissionManager, SunellCameraInfo sunellCameraInfo, Rectangle rectangle)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            this.sunellCameraInfo = sunellCameraInfo;
            this.rectangle = rectangle;
            this.permissionManager = permissionManager;
        }

        private void Initialize(long userId, long cameraId, Rectangle rectangle)
        {
            var camerasRepository = new CameraRepository();
            var camera = camerasRepository.Select(cameraId);
            sunellCameraInfo = new SunellCameraInfo
            {
                CameraIp = camera.IpAddress,
                CameraPort = SunellLegacyCameraInfo.PagoPort,
                Username = camera.Username,
                Password = camera.Password,
                StreamId = camera.StreamId ?? 1
            };

            this.rectangle = rectangle;

            permissionManager = new PermissionManager<User>();
            var userRepository = new UserRepository();
            var user = userRepository.Select(userId);
            permissionManager.SetUser(this, new Mtf.Permissions.Models.User<User>
            {
                Tag = user
            });
        }

        private void SunellCameraWindow_Load(object sender, EventArgs e)
        {
            Location = new Point(rectangle.X, rectangle.Y);
            Size = new Size(rectangle.Width, rectangle.Height);
        }

        private void SunellCameraWindow_Shown(object sender, EventArgs e)
        {
            sunellVideoWindow1.Connect(sunellCameraInfo.CameraIp, sunellCameraInfo.CameraPort, sunellCameraInfo.Username, sunellCameraInfo.Password, sunellCameraInfo.StreamId, 1, StreamType.HighDensity, false);
        }

        private void SunellCameraWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            sunellVideoWindow1.Disconnect();
        }
    }
}
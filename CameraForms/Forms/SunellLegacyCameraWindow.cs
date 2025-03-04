using CameraForms.Dto;
using CameraForms.Services;
using Database.Models;
using Database.Repositories;
using Mtf.Permissions.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CameraForms.Forms
{
    public partial class SunellLegacyCameraWindow : Form
    {
        private PermissionManager<User> permissionManager;
        private Rectangle rectangle;
        private SunellLegacyCameraInfo sunellLegacyCameraInfo;

        public SunellLegacyCameraWindow(long userId, long cameraId, long? displayId)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            var display = DisplayProvider.Get(displayId);
            Initialize(userId, cameraId, display.Bounds);
        }

        public SunellLegacyCameraWindow(long userId, long cameraId, Rectangle rectangle)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            Initialize(userId, cameraId, rectangle);
        }

        public SunellLegacyCameraWindow(PermissionManager<User> permissionManager, SunellLegacyCameraInfo sunellLegacyCameraInfo, Rectangle rectangle)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            this.sunellLegacyCameraInfo = sunellLegacyCameraInfo;
            this.rectangle = rectangle;
            this.permissionManager = permissionManager;
        }

        private void Initialize(long userId, long cameraId, Rectangle rectangle)
        {
            var camerasRepository = new CameraRepository();
            var camera = camerasRepository.Select(cameraId);
            sunellLegacyCameraInfo = new SunellLegacyCameraInfo
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

        private void SunellLegacyCameraWindow_Load(object sender, EventArgs e)
        {
            Location = new Point(rectangle.X, rectangle.Y);
            Size = new Size(rectangle.Width, rectangle.Height);
        }

        private void SunellLegacyCameraWindow_Shown(object sender, EventArgs e)
        {
            sunellVideoWindowLegacy1.Connect(this, sunellLegacyCameraInfo.CameraIp, sunellLegacyCameraInfo.CameraPort, sunellLegacyCameraInfo.Username, sunellLegacyCameraInfo.Password, sunellLegacyCameraInfo.StreamId);
        }

        private void SunellLegacyCameraWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            sunellVideoWindowLegacy1.Disconnect();
        }
    }
}

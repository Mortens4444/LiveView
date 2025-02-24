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
    public partial class SunellCameraWindow : Form
    {
        private PermissionManager<User> permissionManager;
        private Rectangle rectangle;
        private SunellCameraInfo sunellCameraInfo;

        public SunellCameraWindow(long userId, long cameraId, long? displayId)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            var display = DisplayProvider.Get(displayId);
            rectangle = display.Bounds;
            Initialize(userId, cameraId, rectangle);
        }

        public SunellCameraWindow(long userId, long cameraId, Rectangle rectangle)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            Initialize(userId, cameraId, rectangle);
        }

        public SunellCameraWindow(PermissionManager<User> permissionManager, SunellCameraInfo sunellCameraInfo, Rectangle rectangle)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

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
                CameraPort = 30001,
                Username = camera.Username,
                Password = camera.Password
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
            sunellVideoWindow1.Connect(sunellCameraInfo.CameraIp, sunellCameraInfo.CameraPort, sunellCameraInfo.Username, sunellCameraInfo.Password);
        }

        private void SunellCameraWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            sunellVideoWindow1.Disconnect();
        }
    }
}
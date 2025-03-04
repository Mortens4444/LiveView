using CameraForms.Services;
using Database.Enums;
using Database.Interfaces;
using Database.Models;
using Database.Repositories;
using Mtf.Permissions.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CameraForms.Forms
{
    public partial class MortoGraphyWindow: Form
    {
        private readonly IPersonalOptionsRepository personalOptionsRepository;

        private PermissionManager<User> permissionManager;
        private Rectangle rectangle;
        private string url;

        public MortoGraphyWindow(PermissionManager<User> permissionManager, IPersonalOptionsRepository personalOptionsRepository, string url, Rectangle rectangle)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            this.url = url;
            this.rectangle = rectangle;
            this.permissionManager = permissionManager;
            this.personalOptionsRepository = personalOptionsRepository;
        }

        public MortoGraphyWindow(IPersonalOptionsRepository personalOptionsRepository, long userId, long cameraId, long? displayId)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            this.personalOptionsRepository = personalOptionsRepository;
            var display = DisplayProvider.Get(displayId);
            rectangle = display.Bounds;
            Initialize(userId, cameraId, rectangle);
        }

        public MortoGraphyWindow(IPersonalOptionsRepository personalOptionsRepository, long userId, long cameraId, Rectangle rectangle)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            this.personalOptionsRepository = personalOptionsRepository;
            Initialize(userId, cameraId, rectangle);
        }

        private void Initialize(long userId, long cameraId, Rectangle rectangle)
        {
            var camerasRepository = new CameraRepository();
            var camera = camerasRepository.Select(cameraId);

            this.rectangle = rectangle;
            url = camera.HttpStreamUrl;

            permissionManager = new PermissionManager<User>();
            var userRepository = new UserRepository();
            var user = userRepository.Select(userId);
            permissionManager.SetUser(this, new Mtf.Permissions.Models.User<User>
            {
                Tag = user
            });
        }

        private void MortoGraphyWindow_Load(object sender, EventArgs e)
        {
            Location = new Point(rectangle.X, rectangle.Y);
            Size = new Size(rectangle.Width, rectangle.Height);
        }

        private void MortoGraphyWindow_Shown(object sender, EventArgs e)
        {
            mortoGraphyWindow.Start(url);

            var largeFontSize = personalOptionsRepository.Get(Setting.CameraLargeFontSize, permissionManager.CurrentUser.Tag.Id, 30);
            //var smallFontSize = personalOptionsRepository.Get(Setting.CameraSmallFontSize, permissionManager.CurrentUser.Tag.Id, 15);
            var fontName = personalOptionsRepository.Get(Setting.CameraFont, permissionManager.CurrentUser.Tag.Id, "Arial");
            var fontColor = Color.FromArgb(personalOptionsRepository.Get(Setting.CameraFontColor, permissionManager.CurrentUser.Tag.Id, Color.White.ToArgb()));
            //var shadowColor = Color.FromArgb(personalOptionsRepository.Get(Setting.CameraFontShadowColor, permissionManager.CurrentUser.Tag.Id, Color.Black.ToArgb()));

            var cameraName = personalOptionsRepository.GetCameraName(permissionManager.CurrentUser.Id, url);

            mortoGraphyWindow.OverlayFont = new Font(fontName, largeFontSize, FontStyle.Bold);
            mortoGraphyWindow.OverlayBrush = new SolidBrush(fontColor);
            mortoGraphyWindow.OverlayText = cameraName;
        }

        private void MortoGraphyWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            mortoGraphyWindow.Stop();
        }
    }
}

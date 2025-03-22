using CameraForms.Services;
using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Network;
using LiveView.Core.Services;
using LiveView.Core.Services.Pipe;
using Microsoft.Extensions.DependencyInjection;
using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Network.EventArg;
using Mtf.Permissions.Services;
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace CameraForms.Forms
{
    public partial class OpenCvSharpCameraWindow : Form
    {
        private readonly KBD300ASimulatorServer kBD300ASimulatorServer;
        private readonly PermissionManager<User> permissionManager;
        private readonly ICameraRepository cameraRepository;
        private readonly IPersonalOptionsRepository personalOptionsRepository;
        private readonly ICameraFunctionRepository cameraFunctionRepository;

        private string url;
        private Rectangle rectangle;
        private GridCamera gridCamera;
        private FullScreenCameraMessageHandler fullScreenCameraMessageHandler;

        public OpenCvSharpCameraWindow(PermissionManager<User> permissionManager, ICameraFunctionRepository cameraFunctionRepository, IPersonalOptionsRepository personalOptionsRepository, string url, Rectangle rectangle, GridCamera gridCamera)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            this.url = url;
            this.rectangle = rectangle;
            this.permissionManager = permissionManager;
            this.cameraFunctionRepository = cameraFunctionRepository;
            this.personalOptionsRepository = personalOptionsRepository;
            this.gridCamera = gridCamera;

            if (gridCamera?.Frame ?? false)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
            }
        }

        public OpenCvSharpCameraWindow(ServiceProvider serviceProvider, long userId, long cameraId, long? displayId)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            kBD300ASimulatorServer = new KBD300ASimulatorServer();
            permissionManager = PermissionManagerBuilder.Build(serviceProvider, this, userId);
            cameraRepository = serviceProvider.GetRequiredService<ICameraRepository>();
            cameraFunctionRepository = serviceProvider.GetRequiredService<ICameraFunctionRepository>();
            personalOptionsRepository = serviceProvider.GetRequiredService<IPersonalOptionsRepository>();
            var display = DisplayProvider.Get(displayId);
            rectangle = display.Bounds;
            Initialize(userId, cameraId, rectangle, display, true);
        }

        public OpenCvSharpCameraWindow(ServiceProvider serviceProvider, long userId, long cameraId, Rectangle rectangle)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            kBD300ASimulatorServer = new KBD300ASimulatorServer();
            permissionManager = PermissionManagerBuilder.Build(serviceProvider, this, userId);
            cameraRepository = serviceProvider.GetRequiredService<ICameraRepository>();
            cameraFunctionRepository = serviceProvider.GetRequiredService<ICameraFunctionRepository>();
            personalOptionsRepository = serviceProvider.GetRequiredService<IPersonalOptionsRepository>();
            Initialize(userId, cameraId, rectangle, null, true);
        }

        private void Initialize(long userId, long cameraId, Rectangle rectangle, DisplayDto display, bool fullScreen)
        {
            var camera = cameraRepository.Select(cameraId);
            this.rectangle = rectangle;
            url = camera.HttpStreamUrl;

            if (fullScreen)
            {
                kBD300ASimulatorServer.StartPipeServerAsync("KBD300A_Pipe");
                fullScreenCameraMessageHandler = new FullScreenCameraMessageHandler(userId, cameraId, this, display, CameraMode.OpenCvSharp, cameraFunctionRepository);

                Console.CancelKeyPress += (sender, e) => OnExit();
                Application.ApplicationExit += (sender, e) => OnExit();
                AppDomain.CurrentDomain.ProcessExit += (sender, e) => OnExit();
                FormClosing += (sender, e) => OnExit();
            }
        }

        private void OpenCvSharp_Load(object sender, EventArgs e)
        {
            Location = new Point(rectangle.X, rectangle.Y);
            if (Boolean.TryParse(ConfigurationManager.AppSettings["UseMiniSizeForFullscreenWindows"], out var useMiniWindowattach) && useMiniWindowattach)
            {
                Size = new Size(100, 100);
            }
            else
            {
                Size = new Size(rectangle.Width, rectangle.Height);
            }
        }

        private void OpenCvSharp_Shown(object sender, EventArgs e)
        {
            openCvSharpVideoWindow.Start(url);
            var userId = permissionManager.CurrentUser.Tag.Id;
            var largeFontSize = personalOptionsRepository.Get(Setting.CameraLargeFontSize, userId, 30);
            //var smallFontSize = personalOptionsRepository.Get(Setting.CameraSmallFontSize, userId, 15);
            openCvSharpVideoWindow.OverlayFont = new Font(personalOptionsRepository.Get(Setting.CameraFont, userId, "Arial"), largeFontSize, FontStyle.Bold);
            openCvSharpVideoWindow.OverlayBrush = new SolidBrush(Color.FromArgb(personalOptionsRepository.Get(Setting.CameraFontColor, userId, Color.White.ToArgb())));
            //var shadowColor = Color.FromArgb(personalOptionsRepository.Get(Setting.CameraFontShadowColor, userId, Color.Black.ToArgb()));
            
            var text = personalOptionsRepository.GetCameraName(userId, url);
            if (gridCamera?.Frame ?? false)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
                Text = text;
            }
            else
            {
                if (gridCamera?.Osd ?? false)
                {
                    openCvSharpVideoWindow.OverlayText = text;
                }
            }
            if (gridCamera?.ShowDateTime ?? false)
            {
                openCvSharpVideoWindow.OverlayText += DateTime.Now.ToString();
            }
        }

        private void OnExit()
        {
            fullScreenCameraMessageHandler.Exit();
        }

        private void OpenCvSharp_FormClosing(object sender, FormClosingEventArgs e)
        {
            kBD300ASimulatorServer?.Stop();
            openCvSharpVideoWindow.Stop();
        }
    }
}

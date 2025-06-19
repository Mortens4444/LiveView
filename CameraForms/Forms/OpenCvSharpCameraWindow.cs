using CameraForms.Dto;
using CameraForms.Extensions;
using CameraForms.Services;
using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Core.Dto;
using LiveView.Core.Extensions;
using LiveView.Core.Services;
using LiveView.Core.Services.Pipe;
using Microsoft.Extensions.DependencyInjection;
using Mtf.Permissions.Services;
using System;
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
        private Camera camera;
        private FullScreenCameraMessageHandler fullScreenCameraMessageHandler;

        public OpenCvSharpCameraWindow(PermissionManager<User> permissionManager, ICameraRepository cameraRepository, ICameraFunctionRepository cameraFunctionRepository, IPersonalOptionsRepository personalOptionsRepository, string url, Rectangle rectangle, GridCamera gridCamera)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            this.url = url;
            this.rectangle = rectangle;
            this.permissionManager = permissionManager;
            this.cameraRepository = cameraRepository;
            this.cameraFunctionRepository = cameraFunctionRepository;
            this.personalOptionsRepository = personalOptionsRepository;
            this.gridCamera = gridCamera;
            camera = cameraRepository.Select(gridCamera);

            if (gridCamera?.Frame ?? false)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
            }
        }

        public OpenCvSharpCameraWindow(IServiceProvider serviceProvider, CameraLaunchContext cameraLaunchContext)
        {
            if (cameraLaunchContext == null)
            {
                throw new ArgumentNullException(nameof(cameraLaunchContext));
            }

            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            kBD300ASimulatorServer = new KBD300ASimulatorServer();
            permissionManager = PermissionManagerBuilder.Build(serviceProvider, this, cameraLaunchContext.UserId);
            cameraRepository = serviceProvider.GetRequiredService<ICameraRepository>();
            cameraFunctionRepository = serviceProvider.GetRequiredService<ICameraFunctionRepository>();
            personalOptionsRepository = serviceProvider.GetRequiredService<IPersonalOptionsRepository>();
            var display = cameraLaunchContext.GetDisplay();
            rectangle = display?.Bounds ?? cameraLaunchContext.Rectangle;
            Initialize(cameraLaunchContext.UserId, cameraLaunchContext.CameraId, display, true);
        }

        private void Initialize(long userId, long cameraId, DisplayDto display, bool fullScreen)
        {
            camera = cameraRepository.Select(cameraId);
            url = camera.HttpStreamUrl;

            if (fullScreen)
            {
                kBD300ASimulatorServer.StartPipeServerAsync(LiveView.Core.Constants.PipeServerName);
                fullScreenCameraMessageHandler = new FullScreenCameraMessageHandler(userId, cameraId, this, display, CameraMode.OpenCvSharp, cameraFunctionRepository);

                Console.CancelKeyPress += (sender, e) => OnExit();
                Application.ApplicationExit += (sender, e) => OnExit();
                AppDomain.CurrentDomain.ProcessExit += (sender, e) => OnExit();
            }
        }

        private void OpenCvSharp_Load(object sender, EventArgs e)
        {
            this.SetFormRegion(rectangle);
        }

        private void OpenCvSharp_Shown(object sender, EventArgs e)
        {
            if (!permissionManager.HasCameraAndUser(camera))
            {
                return;
            }

            var userId = permissionManager.CurrentUser.Tag.Id;
            var text = personalOptionsRepository.GetCameraName(userId, url);
            var osdSettings = personalOptionsRepository.GetOsdSettings(userId);
            OsdSetter.SetInfo(this, openCvSharpVideoWindow, gridCamera, osdSettings, text, userId);

            if (permissionManager.HasCameraPermission(camera, openCvSharpVideoWindow))
            {
                openCvSharpVideoWindow.Start(url);
            }
        }

        private void OnExit()
        {
            fullScreenCameraMessageHandler?.Exit();
            kBD300ASimulatorServer?.Stop();
            openCvSharpVideoWindow.Stop();
        }

        private void OpenCvSharp_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnExit();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

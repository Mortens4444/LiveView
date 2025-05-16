using CameraForms.Dto;
using CameraForms.Services;
using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Core.Dto;
using LiveView.Core.Extensions;
using LiveView.Core.Services;
using LiveView.Core.Services.Pipe;
using Microsoft.Extensions.DependencyInjection;
using Mtf.MessageBoxes;
using Mtf.Permissions.Services;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CameraForms.Forms
{
    public partial class MortoGraphyCameraWindow : Form
    {
        private readonly ICameraRepository cameraRepository;
        private readonly ICameraFunctionRepository cameraFunctionRepository;
        private readonly IPersonalOptionsRepository personalOptionsRepository;
        private readonly IVideoSourceRepository videoSourceRepository;
        private readonly KBD300ASimulatorServer kBD300ASimulatorServer;

        private PermissionManager<User> permissionManager;
        private Rectangle rectangle;
        private string url;
        private GridCamera gridCamera;
        private Camera camera;
        private FullScreenCameraMessageHandler fullScreenCameraMessageHandler;
        private int bufferSize;
        private int onExit;

        public MortoGraphyCameraWindow(PermissionManager<User> permissionManager,
            ICameraRepository cameraRepository, ICameraFunctionRepository cameraFunctionRepository,
            IPersonalOptionsRepository personalOptionsRepository, IVideoSourceRepository videoSourceRepository,
            string url, Rectangle rectangle, GridCamera gridCamera)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            this.url = url;
            this.rectangle = rectangle;
            this.cameraRepository = cameraRepository;
            this.cameraFunctionRepository = cameraFunctionRepository;
            this.videoSourceRepository = videoSourceRepository;
            this.permissionManager = permissionManager;
            this.personalOptionsRepository = personalOptionsRepository;
            this.gridCamera = gridCamera;
            camera = cameraRepository.Select(gridCamera);

            if (gridCamera?.Frame ?? false)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
            }
            SetBufferSize();
        }

        public MortoGraphyCameraWindow(IServiceProvider serviceProvider, CameraLaunchContext cameraLaunchContext)
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
            cameraFunctionRepository = serviceProvider.GetRequiredService<ICameraFunctionRepository>();
            cameraRepository = serviceProvider.GetRequiredService<ICameraRepository>();
            videoSourceRepository = serviceProvider.GetRequiredService<IVideoSourceRepository>();
            personalOptionsRepository = serviceProvider.GetRequiredService<IPersonalOptionsRepository>();

            var display = cameraLaunchContext.GetDisplay();
            rectangle = display?.Bounds ?? cameraLaunchContext.Rectangle;

            Initialize(cameraLaunchContext.UserId, cameraLaunchContext.CameraId, display, true);
            if (url == null)
            {
                url = $"{cameraLaunchContext.ServerIp}|{cameraLaunchContext.VideoCaptureSource}";
            }
        }

        private void SetBufferSize()
        {
            bufferSize = AppConfig.GetInt32(LiveView.Core.Constants.VideoCaptureClientBufferSize, 409600);
        }

        private void Initialize(long userId, long cameraId, DisplayDto display, bool fullScreen)
        {
            SetBufferSize();
            camera = cameraRepository.Select(cameraId);
            url = camera?.HttpStreamUrl;

            if (fullScreen)
            {
                kBD300ASimulatorServer.StartPipeServerAsync(LiveView.Core.Constants.PipeServerName);
                fullScreenCameraMessageHandler = new FullScreenCameraMessageHandler(userId, cameraId, this, display, CameraMode.MortoGraphy, cameraFunctionRepository);

                Console.CancelKeyPress += (sender, e) => OnExit();
                Application.ApplicationExit += (sender, e) => OnExit();
                AppDomain.CurrentDomain.ProcessExit += (sender, e) => OnExit();
            }
        }

        private void MortoGraphyWindow_Load(object sender, EventArgs e)
        {
            this.SetFormSizeAndPosition(rectangle);
        }

        private void MortoGraphyWindow_Shown(object sender, EventArgs e)
        {
            var cameraText = camera?.ToString() ?? url;
            if (permissionManager.CurrentUser == null)
            {
                DebugErrorBox.Show(cameraText, "No user is logged in.");
                return;
            }

            var userId = permissionManager.CurrentUser.Tag.Id;
            mortoGraphyWindow.BufferSize = bufferSize;
            var text = personalOptionsRepository.GetCameraName(userId, url);
            OsdSetter.SetInfo(this, mortoGraphyWindow, gridCamera, personalOptionsRepository, text, userId);

            if (url.IndexOf('|') > 0)
            {
                var videoSourceNameInfo = url.Split('|');

                var videoSourceInfo = videoSourceRepository.SelectVideoSourceAndAgentInfoByName(videoSourceNameInfo[0], videoSourceNameInfo[1]);
                url = $"{videoSourceInfo.Item1.ServerIp}:{videoSourceInfo.Item2.Port}";
            }
            try
            {
                if (permissionManager.HasCameraPermission(camera.PermissionCamera))
                {
                    mortoGraphyWindow.Start(url);
                }
                else
                {
                    mortoGraphyWindow.OverlayText = $"No permission: {url}";
                    DebugErrorBox.Show(url, "No permission to view this camera.");
                }
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
        }

        private void OnExit()
        {
            if (Interlocked.Exchange(ref onExit, 1) == 0)
            {
                fullScreenCameraMessageHandler?.Exit();
                kBD300ASimulatorServer?.Stop();
                mortoGraphyWindow.Stop();
            }
        }

        private void MortoGraphyWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnExit();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

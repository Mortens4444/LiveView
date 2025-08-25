using CameraForms.Dto;
using CameraForms.Extensions;
using CameraForms.Interfaces;
using CameraForms.Services;
using Database.Enums;
using Database.Interfaces;
using Database.Models;
using Database.Services;
using LiveView.Core.Dependencies;
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
using Timer = System.Windows.Forms.Timer;

namespace CameraForms.Forms
{
    public partial class MortoGraphyCameraWindow : Form
    {
        private readonly ICameraRepository cameraRepository;
        private readonly ICameraFunctionRepository cameraFunctionRepository;
        private readonly IPersonalOptionsRepository personalOptionsRepository;
        private readonly IVideoSourceRepository videoSourceRepository;
        private readonly KBD300ASimulatorServer kBD300ASimulatorServer;
        private readonly PermissionManager<User> permissionManager;
        private readonly PermissionSetter permissionSetter;
        private readonly GridCamera gridCamera;
        private readonly Camera camera;
        private readonly ICameraRegister cameraRegister;

        private PermissionMonitor permissionMonitor;
        private Rectangle rectangle;
        private string url;
        private FullScreenCameraMessageHandler fullScreenCameraMessageHandler;
        private int bufferSize;
        private int onExit;

        public MortoGraphyCameraWindow(PermissionManager<User> permissionManager,
            ICameraRepository cameraRepository, ICameraFunctionRepository cameraFunctionRepository,
            ICameraPermissionRepository cameraPermissionRepository, IPermissionRepository permissionRepository,
            IOperationRepository operationRepository, IGroupMembersRepository groupMembersRepository,
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

            permissionSetter = new PermissionSetter(new PermissionSetterDependencies(cameraRepository,
                cameraPermissionRepository, permissionRepository, operationRepository, groupMembersRepository));
            permissionSetter.SetGroups(permissionManager.CurrentUser);

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
            cameraRegister = serviceProvider.GetRequiredService<ICameraRegister>();

            permissionSetter = new PermissionSetter(new PermissionSetterDependencies(cameraRepository,
                serviceProvider.GetRequiredService<ICameraPermissionRepository>(),
                serviceProvider.GetRequiredService<IPermissionRepository>(),
                serviceProvider.GetRequiredService<IOperationRepository>(),
                serviceProvider.GetRequiredService<IGroupMembersRepository>()));
            permissionSetter.SetGroups(permissionManager.CurrentUser);

            var display = cameraLaunchContext.GetDisplay();
            rectangle = display?.Bounds ?? cameraLaunchContext.Rectangle;

            SetBufferSize();
            camera = cameraRepository.Select(cameraLaunchContext.CameraId);
            url = camera?.StreamUrl;
            if (url == null)
            {
                url = $"{cameraLaunchContext.ServerIp}|{cameraLaunchContext.VideoCaptureSource}";
            }
            
            SetupFullscreenPtz(cameraLaunchContext.UserId, cameraLaunchContext.CameraId, display);
        }

        private void SetBufferSize()
        {
            bufferSize = AppConfig.GetInt32(Database.Constants.VideoCaptureClientBufferSize, 409600);
        }

        private void SetupFullscreenPtz(long userId, long cameraId, DisplayDto display)
        {
            kBD300ASimulatorServer.StartPipeServerAsync(Database.Constants.PipeServerName);
            fullScreenCameraMessageHandler = new FullScreenCameraMessageHandler(userId, cameraId, this, display, CameraMode.MortoGraphy, cameraFunctionRepository, cameraRegister);

            Console.CancelKeyPress += (sender, e) => OnExit();
            Application.ApplicationExit += (sender, e) => OnExit();
            AppDomain.CurrentDomain.ProcessExit += (sender, e) => OnExit();
        }

        private void MortoGraphyWindow_Load(object sender, EventArgs e)
        {
            this.SetFormRegion(rectangle);
        }

        private void MortoGraphyWindow_Shown(object sender, EventArgs e)
        {
            if (!permissionManager.HasCamera(camera))
            {
                return;
            }

            Initialize();

            if (permissionManager.HasCameraPermission(camera, mortoGraphyWindow))
            {
                mortoGraphyWindow.Start(url);
            }
            else
            {
                permissionMonitor = new PermissionMonitor(
                    () =>
                    {
                        permissionSetter.SetGroups(permissionManager.CurrentUser);
                        return permissionManager.HasCameraPermission(camera, mortoGraphyWindow);
                    },
                    () =>
                    {
                        Initialize();
                        mortoGraphyWindow.Start(url);
                    }
                );
                permissionMonitor.Start();
            }
        }

        private void Initialize()
        {
            var userId = permissionManager.CurrentUser?.Tag.Id ?? 0;
            mortoGraphyWindow.BufferSize = bufferSize;
            var text = personalOptionsRepository.GetCameraName(userId, url);
            var osdSettings = personalOptionsRepository.GetOsdSettings(userId);
            OsdSetter.SetInfo(this, mortoGraphyWindow, gridCamera, osdSettings, text);

            if (url.IndexOf('|') > 0)
            {
                var videoSourceNameInfo = url.Split('|');

                var videoSourceInfo = videoSourceRepository.SelectVideoSourceAndAgentInfoByName(videoSourceNameInfo[0], videoSourceNameInfo[1]);
                url = $"{videoSourceInfo.Item1.ServerIp}:{videoSourceInfo.Item2.Port}";
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
            this.Exit();
        }
    }
}

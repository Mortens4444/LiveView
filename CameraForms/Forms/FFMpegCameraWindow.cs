using CameraForms.Dto;
using CameraForms.Extensions;
using CameraForms.Interfaces;
using CameraForms.Services;
using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Core.Dependencies;
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
    public partial class FFMpegCameraWindow : Form
    {
        private readonly KBD300ASimulatorServer kBD300ASimulatorServer;
        private readonly PermissionManager<User> permissionManager;
        private readonly ICameraRepository cameraRepository;
        private readonly IPersonalOptionsRepository personalOptionsRepository;
        private readonly ICameraFunctionRepository cameraFunctionRepository;
        private readonly PermissionSetter permissionSetter;
        private readonly GridCamera gridCamera;
        private readonly Camera camera;
        private readonly string url;
        private readonly ICameraRegister cameraRegister;

        private Rectangle rectangle;
        private PermissionMonitor permissionMonitor;
        private FullScreenCameraMessageHandler fullScreenCameraMessageHandler;

        public FFMpegCameraWindow(PermissionManager<User> permissionManager, ICameraRepository cameraRepository,
            ICameraPermissionRepository cameraPermissionRepository, IPermissionRepository permissionRepository,
            IOperationRepository operationRepository, IGroupMembersRepository groupMembersRepository,
            ICameraFunctionRepository cameraFunctionRepository, IPersonalOptionsRepository personalOptionsRepository,
            string url, Rectangle rectangle, GridCamera gridCamera)
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

            permissionSetter = new PermissionSetter(new PermissionSetterDependencies(cameraRepository,
                cameraPermissionRepository, permissionRepository, operationRepository, groupMembersRepository));
            permissionSetter.SetGroups(permissionManager.CurrentUser);

            camera = cameraRepository.Select(gridCamera);

            if (gridCamera?.Frame ?? false)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
            }
        }

        public FFMpegCameraWindow(CameraLaunchContext cameraLaunchContext)
        {
            if (cameraLaunchContext == null)
            {
                throw new ArgumentNullException(nameof(cameraLaunchContext));
            }

            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            kBD300ASimulatorServer = new KBD300ASimulatorServer();

            cameraRepository = cameraLaunchContext.ServiceProvider.GetRequiredService<ICameraRepository>();
            cameraFunctionRepository = cameraLaunchContext.ServiceProvider.GetRequiredService<ICameraFunctionRepository>();
            personalOptionsRepository = cameraLaunchContext.ServiceProvider.GetRequiredService<IPersonalOptionsRepository>();
            cameraRegister = cameraLaunchContext.ServiceProvider.GetRequiredService<ICameraRegister>();

            var permission = cameraLaunchContext.CreatePermission(this);
            permissionManager = permission.Item1;
            permissionSetter = permission.Item2;

            var display = cameraLaunchContext.GetDisplay();
            rectangle = display?.Bounds ?? cameraLaunchContext.Rectangle;
            SetupFullscreenPtz(cameraLaunchContext.UserId, cameraLaunchContext.CameraId, display);

            camera = cameraRepository.Select(cameraLaunchContext.CameraId);
            url = camera.StreamUrl;
        }

        private void SetupFullscreenPtz(long userId, long cameraId, DisplayDto display)
        {
            kBD300ASimulatorServer.StartPipeServerAsync(Database.Constants.PipeServerName);
            fullScreenCameraMessageHandler = new FullScreenCameraMessageHandler(userId, cameraId, this, display, CameraMode.FFMpeg, cameraFunctionRepository, cameraRegister);

            Console.CancelKeyPress += (sender, e) => OnExit();
            Application.ApplicationExit += (sender, e) => OnExit();
            AppDomain.CurrentDomain.ProcessExit += (sender, e) => OnExit();
        }

        private void FFMpegCameraWindow_Load(object sender, EventArgs e)
        {
            this.SetFormRegion(rectangle);
        }

        private void FFMpegCameraWindow_Shown(object sender, EventArgs e)
        {
            if (!permissionManager.HasCamera(camera))
            {
                return;
            }

            Initialize();

            if (permissionManager.HasCameraPermission(camera, fFmpegWindow))
            {
                fFmpegWindow.Start(url);
            }
            else
            {
                permissionMonitor = new PermissionMonitor(
                    () =>
                    {
                        permissionSetter.SetGroups(permissionManager.CurrentUser);
                        return permissionManager.HasCameraPermission(camera, fFmpegWindow);
                    },
                    () =>
                    {
                        Initialize();
                        fFmpegWindow.Start(url);
                    }
                );
                permissionMonitor.Start();
            }
        }

        private void Initialize()
        {
            var userId = permissionManager.CurrentUser?.Tag.Id ?? 0;
            var text = personalOptionsRepository.GetCameraName(userId, url);
            var osdSettings = personalOptionsRepository.GetOsdSettings(userId);
            OsdSetter.SetInfo(this, fFmpegWindow, gridCamera, osdSettings, text);
        }

        private void OnExit()
        {
            kBD300ASimulatorServer?.Stop();
            fFmpegWindow.Stop();
            fullScreenCameraMessageHandler?.Exit();
        }

        private void FFMpegCameraWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnExit();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Exit();
        }
    }
}

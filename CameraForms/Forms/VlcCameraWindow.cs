using CameraForms.Dto;
using CameraForms.Extensions;
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
using Mtf.Controls.Enums;
using Mtf.MessageBoxes;
using Mtf.Permissions.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CameraForms.Forms
{
    public partial class VlcCameraWindow : Form
    {
        private readonly KBD300ASimulatorServer kBD300ASimulatorServer;
        private readonly PermissionManager<User> permissionManager;
        private readonly IPersonalOptionsRepository personalOptionsRepository;
        private readonly ICameraFunctionRepository cameraFunctionRepository;
        private readonly PermissionSetter permissionSetter;
        private readonly Camera camera;
        private readonly GridCamera gridCamera;
        private readonly string url;

        private Rectangle rectangle;
        private PermissionMonitor permissionMonitor;
        private FullScreenCameraMessageHandler fullScreenCameraMessageHandler;

        public VlcCameraWindow(PermissionManager<User> permissionManager, ICameraRepository cameraRepository,
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

        public VlcCameraWindow(IServiceProvider serviceProvider, CameraLaunchContext cameraLaunchContext)
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
            var cameraRepository = serviceProvider.GetRequiredService<ICameraRepository>();

            permissionSetter = new PermissionSetter(new PermissionSetterDependencies(cameraRepository,
                serviceProvider.GetRequiredService<ICameraPermissionRepository>(),
                serviceProvider.GetRequiredService<IPermissionRepository>(),
                serviceProvider.GetRequiredService<IOperationRepository>(),
                serviceProvider.GetRequiredService<IGroupMembersRepository>()));
            permissionSetter.SetGroups(permissionManager.CurrentUser);

            camera = cameraRepository.Select(cameraLaunchContext.CameraId);
            cameraFunctionRepository = serviceProvider.GetRequiredService<ICameraFunctionRepository>();
            personalOptionsRepository = serviceProvider.GetRequiredService<IPersonalOptionsRepository>();
            var display = cameraLaunchContext.GetDisplay();
            rectangle = display?.Bounds ?? cameraLaunchContext.Rectangle;

            SetupFullscreenPtz(cameraLaunchContext.UserId, camera, display);
            url = camera.StreamUrl;
        }

        private void SetupFullscreenPtz(long userId, Camera camera, DisplayDto display)
        {
            kBD300ASimulatorServer.StartPipeServerAsync(Database.Constants.PipeServerName);
            fullScreenCameraMessageHandler = new FullScreenCameraMessageHandler(userId, camera.Id, this, display, CameraMode.Vlc, cameraFunctionRepository);

            Console.CancelKeyPress += (sender, e) => OnExit();
            Application.ApplicationExit += (sender, e) => OnExit();
            AppDomain.CurrentDomain.ProcessExit += (sender, e) => OnExit();
        }

        private void VlcCameraWindow_Load(object sender, EventArgs e)
        {
            this.SetFormRegion(rectangle);
        }

        private void VlcCameraWindow_Shown(object sender, EventArgs e)
        {
            if (!permissionManager.HasCamera(camera))
            {
                return;
            }

            Initialize();

            if (permissionManager.HasCameraPermission(camera, vlcWindow))
            {
                vlcWindow.Start(url, true, true, true, 3000, 3000, Demux.none);
            }
            else
            {
                permissionMonitor = new PermissionMonitor(
                    () =>
                    {
                        permissionSetter.SetGroups(permissionManager.CurrentUser);
                        return permissionManager.HasCameraPermission(camera, vlcWindow);
                    },
                    () =>
                    {
                        Initialize();
                        vlcWindow.Start(url, true, true, true, 3000, 3000, Demux.none);
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
            OsdSetter.SetInfo(this, vlcWindow, gridCamera, osdSettings, text);
        }

        private void OnExit()
        {
            kBD300ASimulatorServer?.Stop();
            fullScreenCameraMessageHandler?.Exit();
            try
            {
                vlcWindow.Stop();
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
        }

        private void VlcCameraWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnExit();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Exit();
        }
    }
}

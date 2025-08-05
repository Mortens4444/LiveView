using CameraForms.Dto;
using CameraForms.Extensions;
using CameraForms.Services;
using Database.Enums;
using Database.Interfaces;
using Database.Models;
using Database.Services.PasswordHashers;
using LiveView.Core.Dependencies;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Network;
using LiveView.Core.Extensions;
using LiveView.Core.Services;
using LiveView.Core.Services.Pipe;
using Microsoft.Extensions.DependencyInjection;
using Mtf.LanguageService;
using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Network.EventArg;
using Mtf.Permissions.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CameraForms.Forms
{
    public partial class AxVideoCameraWindow : Form
    {
        private Client client;
        private readonly short cameraMoveValue;
        //private int waitTimeInMs = 0;

        private readonly DisplayDto display;
        private readonly PermissionManager<User> permissionManager;
        private readonly KBD300ASimulatorServer kBD300ASimulatorServer;
        private readonly PermissionSetter permissionSetter;
        private readonly IPersonalOptionsRepository personalOptionsRepository;
        private readonly VideoServer server;
        private readonly Camera camera;
        private readonly Rectangle rectangle;
        private readonly GridCamera gridCamera;

        private PermissionMonitor permissionMonitor;

        public AxVideoCameraWindow(PermissionManager<User> permissionManager, ICameraRepository cameraRepository,
            ICameraPermissionRepository cameraPermissionRepository, IPermissionRepository permissionRepository,
            IOperationRepository operationRepository, IGroupMembersRepository groupMembersRepository,
            IPersonalOptionsRepository personalOptionsRepository, IGeneralOptionsRepository generalOptionsRepository,
            Camera camera, VideoServer server, Rectangle rectangle, GridCamera gridCamera)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            this.rectangle = rectangle;
            this.server = server;
            this.camera = camera;
            this.permissionManager = permissionManager;
            this.personalOptionsRepository = personalOptionsRepository;

            permissionSetter = new PermissionSetter(new PermissionSetterDependencies(cameraRepository,
                cameraPermissionRepository, permissionRepository, operationRepository, groupMembersRepository));
            permissionSetter.SetGroups(permissionManager.CurrentUser);

            var userId = permissionManager?.CurrentUser?.Tag.Id ?? 0;
            var text = personalOptionsRepository.GetCameraName(userId, server, camera);
            var osdSettings = personalOptionsRepository.GetOsdSettings(userId);
            OsdSetter.SetInfo(this, axVideoPlayerWindow, gridCamera, osdSettings, text);

            cameraMoveValue = generalOptionsRepository.Get<short>(Setting.CameraMoveValue, 7500);

            this.gridCamera = gridCamera;

            if (gridCamera?.Frame ?? false)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
            }

            closeToolStripMenuItem.Text = Lng.Elem("Close");
            axVideoPlayerWindow.AxVideoPlayer.Connected += AxVideoPlayer_Connected;
            //closeToolStripMenuItem.Enabled = permissionManager.HasPermission(Mtf.Permissions.Enums.WindowManagementPermissions.Close) == Mtf.Permissions.Enums.AccessResult.Allowed;
        }

        public AxVideoCameraWindow(IServiceProvider serviceProvider, CameraLaunchContext cameraLaunchContext)
        {
            if (cameraLaunchContext == null)
            {
                throw new ArgumentNullException(nameof(cameraLaunchContext));
            }
            personalOptionsRepository = serviceProvider.GetRequiredService<IPersonalOptionsRepository>();
            var cameraRepository = serviceProvider.GetRequiredService<ICameraRepository>();
            camera = cameraRepository.Select(cameraLaunchContext.CameraId);
            var videoServerRepository = serviceProvider.GetRequiredService<IVideoServerRepository>();
            server = videoServerRepository.Select(camera.VideoServerId);
            if (server == null)
            {
                DebugErrorBox.Show("Server is null", $"Cannot find server with Id: {camera.VideoServerId}");
            }

            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            kBD300ASimulatorServer = new KBD300ASimulatorServer();
            permissionManager = PermissionManagerBuilder.Build(serviceProvider, this, cameraLaunchContext.UserId);

            permissionSetter = new PermissionSetter(new PermissionSetterDependencies(cameraRepository,
                serviceProvider.GetRequiredService<ICameraPermissionRepository>(),
                serviceProvider.GetRequiredService<IPermissionRepository>(),
                serviceProvider.GetRequiredService<IOperationRepository>(),
                serviceProvider.GetRequiredService<IGroupMembersRepository>()));
            permissionSetter.SetGroups(permissionManager.CurrentUser);

            var generalOptionsRepository = serviceProvider.GetRequiredService<IGeneralOptionsRepository>();
            cameraMoveValue = generalOptionsRepository.Get<short>(Setting.CameraMoveValue, 7500);

            SetupFullscreenPtz(cameraLaunchContext.UserId, camera.Id);
            display = cameraLaunchContext.GetDisplay();
            rectangle = display?.Bounds ?? cameraLaunchContext.Rectangle;

            axVideoPlayerWindow.ContextMenuStrip = null;

            closeToolStripMenuItem.Text = Lng.Elem("Close");
            axVideoPlayerWindow.AxVideoPlayer.Connected += AxVideoPlayer_Connected;
            //closeToolStripMenuItem.Enabled = permissionManager.HasPermission(Mtf.Permissions.Enums.WindowManagementPermissions.Close) == Mtf.Permissions.Enums.AccessResult.Allowed;
        }

        private void SetupFullscreenPtz(long userId, long cameraId)
        {
            kBD300ASimulatorServer.StartPipeServerAsync(Database.Constants.PipeServerName);
            client = CameraRegister.RegisterCamera(userId, cameraId, display, ClientDataArrivedEventHandler, CameraMode.AxVideoPlayer);

            Console.CancelKeyPress += (sender, e) => OnExit();
            Application.ApplicationExit += (sender, e) => OnExit();
            AppDomain.CurrentDomain.ProcessExit += (sender, e) => OnExit();
        }

        private void ClientDataArrivedEventHandler(object sender, DataArrivedEventArgs e)
        {
            try
            {
                var messages = $"{client.Encoding.GetString(e.Data)}";
                var commands = AxVideoPlayerWindowCommandFactory.Create(this, axVideoPlayerWindow, messages, cameraMoveValue);
                foreach (var command in commands)
                {
                    command.Execute();
                    Console.WriteLine($"{command.GetType().Name} executed in video picture.");
                }
            }
            catch (Exception ex)
            {
                var message = $"Message parse or execution failed in video picture: {ex}.";
                Console.Error.WriteLine(message);
                DebugErrorBox.Show(ex);
            }
        }

        private void AxVideoCameraWindow_Load(object sender, EventArgs e)
        {
            this.SetFormRegion(rectangle);
        }

        private void AxVideoCameraWindow_Shown(object sender, EventArgs e)
        {
            if (!permissionManager.HasCamera(camera))
            {
                return;
            }

            Initialize();

            if (permissionManager.HasCameraPermission(camera, axVideoPlayerWindow))
            {
                Start();
            }
            else
            {
                permissionMonitor = new PermissionMonitor(
                    () =>
                    {
                        permissionSetter.SetGroups(permissionManager.CurrentUser);
                        return permissionManager.HasCameraPermission(camera, axVideoPlayerWindow);
                    },
                    () =>
                    {
                        Initialize();
                        Start();
                    }
                );
                permissionMonitor.Start();
            }
        }

        private void Initialize()
        {
            var userId = permissionManager.CurrentUser?.Tag.Id ?? 0;
            var text = personalOptionsRepository.GetCameraName(userId, server, camera);
            var osdSettings = personalOptionsRepository.GetOsdSettings(userId);
            OsdSetter.SetInfo(this, axVideoPlayerWindow, gridCamera, osdSettings, text);
        }

        private void Start()
        {
            //axVideoPlayerWindow.AxVideoPlayer.WaitForConnect(waitTimeInMs);
            //axVideoPlayerWindow.AxVideoPicture.Connect(server.IpAddress, camera.Guid, server.Username, VideoServerPasswordCryptor.PasswordDecrypt(server.EncryptedPassword));
            axVideoPlayerWindow.AxVideoPlayer.Start(server.IpAddress, camera.Guid, server.Username, VideoServerPasswordCryptor.PasswordDecrypt(server.EncryptedPassword));
            //if (waitTimeInMs <= 2000)
            //{
            //    waitTimeInMs *= 2;
            //    if (waitTimeInMs == 0)
            //    {
            //        waitTimeInMs = 100;
            //    }
            //}
        }

        private void AxVideoPlayer_Connected(object sender, EventArgs e)
        {
            //waitTimeInMs = 0;
        }

        private void AxVideoCameraWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnExit();
        }

        private void OnExit()
        {
            kBD300ASimulatorServer?.Stop();
            axVideoPlayerWindow.AxVideoPlayer.Stop();
            axVideoPlayerWindow.AxVideoPlayer.Dispose();
            client?.Send($"{NetworkCommand.UnregisterCamera}", true);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Exit();
        }
    }
}

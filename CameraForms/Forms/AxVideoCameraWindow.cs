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
        private short cameraMoveValue;

        private readonly DisplayDto display;
        private readonly PermissionManager<User> permissionManager;
        private readonly KBD300ASimulatorServer kBD300ASimulatorServer;

        private readonly Database.Models.VideoServer server;
        private readonly Camera camera;
        private readonly Rectangle rectangle;
        private GridCamera gridCamera;

        public AxVideoCameraWindow(PermissionManager<User> permissionManager, ICameraRepository cameraRepository,
            ICameraPermissionRepository cameraPermissionRepository, IPermissionRepository permissionRepository,
            IOperationRepository operationRepository, IGroupMembersRepository groupMembersRepository,
            IPersonalOptionsRepository personalOptionsRepository, IGeneralOptionsRepository generalOptionsRepository,
            Camera camera, Database.Models.VideoServer server, Rectangle rectangle, GridCamera gridCamera)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            this.rectangle = rectangle;
            this.server = server;
            this.camera = camera;
            this.permissionManager = permissionManager;

            var permissionSetter = new PermissionSetter(new PermissionSetterDependencies(cameraRepository,
                cameraPermissionRepository, permissionRepository, operationRepository, groupMembersRepository));
            permissionSetter.SetGroups(permissionManager.CurrentUser);

            var userId = permissionManager?.CurrentUser?.Tag.Id ?? 0;
            var text = personalOptionsRepository.GetCameraName(userId, server, camera);
            var osdSettings = personalOptionsRepository.GetOsdSettings(userId);
            OsdSetter.SetInfo(this, axVideoPlayerWindow, gridCamera, osdSettings, text, userId);

            cameraMoveValue = generalOptionsRepository.Get<short>(Setting.CameraMoveValue, 7500);

            Initialize(userId, camera.Id, false);
            this.gridCamera = gridCamera;

            if (gridCamera?.Frame ?? false)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
            }
        }

        public AxVideoCameraWindow(IServiceProvider serviceProvider, CameraLaunchContext cameraLaunchContext)
        {
            if (cameraLaunchContext == null)
            {
                throw new ArgumentNullException(nameof(cameraLaunchContext));
            }
            var cameraRepository = serviceProvider.GetRequiredService<ICameraRepository>();
            camera = cameraRepository.Select(cameraLaunchContext.CameraId);
            var videoServerRepository = serviceProvider.GetRequiredService<IVideoServerRepository>();
            server = videoServerRepository.Select(camera.ServerId);
            if (server == null)
            {
                DebugErrorBox.Show("Server is null", $"Cannot find server with Id: {camera.ServerId}");
            }

            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            kBD300ASimulatorServer = new KBD300ASimulatorServer();
            permissionManager = PermissionManagerBuilder.Build(serviceProvider, this, cameraLaunchContext.UserId);

            var permissionSetter = new PermissionSetter(new PermissionSetterDependencies(cameraRepository,
                serviceProvider.GetRequiredService<ICameraPermissionRepository>(),
                serviceProvider.GetRequiredService<IPermissionRepository>(),
                serviceProvider.GetRequiredService<IOperationRepository>(),
                serviceProvider.GetRequiredService<IGroupMembersRepository>()));
            permissionSetter.SetGroups(permissionManager.CurrentUser);

            var personalOptionsRepository = serviceProvider.GetRequiredService<IPersonalOptionsRepository>();
            var text = personalOptionsRepository.GetCameraName(cameraLaunchContext.UserId, server, camera);
            var osdSettings = personalOptionsRepository.GetOsdSettings(cameraLaunchContext.UserId);
            OsdSetter.SetInfo(this, axVideoPlayerWindow, gridCamera, osdSettings, text, cameraLaunchContext.UserId);

            var generalOptionsRepository = serviceProvider.GetRequiredService<IGeneralOptionsRepository>();
            cameraMoveValue = generalOptionsRepository.Get<short>(Setting.CameraMoveValue, 7500);

            Initialize(cameraLaunchContext.UserId, camera.Id, true);
            display = cameraLaunchContext.GetDisplay();
            rectangle = display?.Bounds ?? cameraLaunchContext.Rectangle;

            axVideoPlayerWindow.ContextMenuStrip = null;
        }

        private void Initialize(long userId, long cameraId, bool fullScreen)
        {
            if (fullScreen)
            {
                kBD300ASimulatorServer.StartPipeServerAsync(Database.Constants.PipeServerName);
                client = CameraRegister.RegisterCamera(userId, cameraId, display, ClientDataArrivedEventHandler, CameraMode.AxVideoPlayer);

                Console.CancelKeyPress += (sender, e) => OnExit();
                Application.ApplicationExit += (sender, e) => OnExit();
                AppDomain.CurrentDomain.ProcessExit += (sender, e) => OnExit();
            }

            closeToolStripMenuItem.Text = Lng.Elem("Close");
            //closeToolStripMenuItem.Enabled = permissionManager.HasPermission(WindowManagementPermissions.Close);
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
            if (permissionManager.HasCameraAndUser(camera)
                && permissionManager.HasCameraPermission(camera, axVideoPlayerWindow))
            {
                axVideoPlayerWindow.AxVideoPlayer.StartAsync(server.IpAddress, camera.Guid, server.Username, VideoServerPasswordCryptor.PasswordDecrypt(server.EncryptedPassword));
            }
        }

        //private void Start(int waitTimeInMs = 500)
        //{
        //    if (waitTimeInMs <= 2000)
        //    {
        //        waitTimeInMs *= 2;
        //    }
        //    axVideoPlayerWindow.AxVideoPlayer.WaitForConnect(waitTimeInMs);
        //    axVideoPlayerWindow.AxVideoPlayer.Start(server.IpAddress, camera.Guid, server.Username, server.Password);
        //    //axVideoPlayerWindow.AxVideoPicture.Connect(server.IpAddress, camera.Guid, server.Username, server.Password);
        //}

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
            Close();
        }
    }
}

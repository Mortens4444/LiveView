using CameraForms.Dto;
using CameraForms.Services;
using Database.Enums;
using Database.Interfaces;
using Database.Models;
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
using System.Threading;
using System.Windows.Forms;

namespace CameraForms.Forms
{
    public partial class AxVideoCameraWindow : Form
    {
        private Client client;
        private short cameraMoveValue;

        private readonly DisplayDto display;
        private readonly long cameraId;
        private readonly PermissionManager<User> permissionManager;
        private readonly KBD300ASimulatorServer kBD300ASimulatorServer;
        private readonly ICameraRepository cameraRepository;
        private readonly IServerRepository serverRepository;
        private readonly IPersonalOptionsRepository personalOptionsRepository;
        private readonly IGeneralOptionsRepository generalOptionsRepository;

        private readonly Database.Models.Server server;
        private readonly Camera camera;
        private readonly Rectangle rectangle;
        private CancellationToken cancellationToken;
        private GridCamera gridCamera;

        public AxVideoCameraWindow(PermissionManager<User> permissionManager, IServerRepository serverRepository, ICameraRepository cameraRepository,
            IPersonalOptionsRepository personalOptionsRepository, IGeneralOptionsRepository generalOptionsRepository,
            Camera camera, Database.Models.Server server, Rectangle rectangle, GridCamera gridCamera, CancellationToken cancellationToken)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            this.rectangle = rectangle;
            this.server = server;
            this.camera = camera;
            this.cancellationToken = cancellationToken;
            this.permissionManager = permissionManager;
            this.cameraRepository = cameraRepository;
            this.serverRepository = serverRepository;
            this.personalOptionsRepository = personalOptionsRepository;
            this.generalOptionsRepository = generalOptionsRepository;
            
            cameraId = camera?.Id ?? 0;
            Initialize(permissionManager?.CurrentUser?.Tag.Id ?? 0, cameraId, false);
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

            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            kBD300ASimulatorServer = new KBD300ASimulatorServer();
            permissionManager = PermissionManagerBuilder.Build(serviceProvider, this, cameraLaunchContext.UserId);
            personalOptionsRepository = serviceProvider.GetRequiredService<IPersonalOptionsRepository>();
            cameraRepository = serviceProvider.GetRequiredService<ICameraRepository>();
            serverRepository = serviceProvider.GetRequiredService<IServerRepository>();
            generalOptionsRepository = serviceProvider.GetRequiredService<IGeneralOptionsRepository>();
            cameraId = cameraLaunchContext.CameraId;
            Initialize(cameraLaunchContext.UserId, cameraId, true);

            display = cameraLaunchContext.GetDisplay();
            rectangle = display?.Bounds ?? cameraLaunchContext.Rectangle;

            axVideoPlayerWindow.ContextMenuStrip = null;
        }

        private void Initialize(long userId, long cameraId, bool fullScreen)
        {
            cameraMoveValue = generalOptionsRepository.Get<short>(Setting.CameraMoveValue, 7500);

            if (fullScreen)
            {
                kBD300ASimulatorServer.StartPipeServerAsync(LiveView.Core.Constants.PipeServerName);
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
            this.SetFormSizeAndPosition(rectangle);
        }

        private void AxVideoCameraWindow_Shown(object sender, EventArgs e)
        {
            if (permissionManager.CurrentUser == null)
            {
                return;
            }

            //axVideoPlayerWindow.AxVideoPicture.Visible = false;
            //axVideoPlayerWindow.AxVideoPlayer.ConnectFailed += AxVideoPlayer_ConnectionFailed;
            //axVideoPlayerWindow.AxVideoPlayer.Disconnected += AxVideoPlayer_Disconnected;
            var userId = permissionManager.CurrentUser.Tag.Id;
            var camera = cameraRepository.Select(cameraId);
            if (camera == null)
            {
                DebugErrorBox.Show("Camera is null", $"Cannot find camera with Id: {cameraId}");
            }
            var server = serverRepository.Select(camera.ServerId);
            if (server == null)
            {
                DebugErrorBox.Show("Server is null", $"Cannot find server with Id: {camera.ServerId}");
            }

            var text = personalOptionsRepository.GetCameraName(userId, server, camera);
            OsdSetter.SetInfo(this, axVideoPlayerWindow, gridCamera, personalOptionsRepository, text, userId);
            try
            {
                if (permissionManager.HasCameraPermission(camera.PermissionCamera))
                {
                    //axVideoPlayerWindow.AxVideoPlayer.Start(server.IpAddress, camera.Guid, server.Username, server.Password);
                    axVideoPlayerWindow.AxVideoPlayer.StartAsync(server.IpAddress, camera.Guid, server.Username, server.Password);
                }
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
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

        //private void AxVideoPlayer_Disconnected(object sender, EventArgs e)
        //{
        //    axVideoPlayerWindow.AxVideoPlayer.Stop();
        //    //Start();
        //}

        //private void AxVideoPlayer_ConnectionFailed(object sender, AxVIDEOCONTROL4Lib._DVideoPictureEvents_onConnectFailedEvent e)
        //{
        //    axVideoPlayerWindow.AxVideoPlayer.Stop();
        //    //Start();
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

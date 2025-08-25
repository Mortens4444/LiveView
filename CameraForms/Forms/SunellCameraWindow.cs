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
using Mtf.Controls.Video.Sunell.IPR67;
using Mtf.Controls.Video.Sunell.IPR67.SunellSdk;
using Mtf.Extensions;
using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Network.EventArg;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using Mtf.Windows.Forms.Extensions;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraForms.Forms
{
    public partial class SunellCameraWindow : Form
    {
        private readonly KBD300ASimulatorServer kBD300ASimulatorServer;
        private readonly IPersonalOptionsRepository personalOptionsRepository;
        private readonly PermissionManager<User> permissionManager;
        private readonly PermissionSetter permissionSetter;
        private readonly GridCamera gridCamera;
        private readonly Camera camera;
        private readonly SunellVideoWindowCommandFactory sunellVideoWindowCommandFactory;

        private Rectangle rectangle;
        private SunellCameraInfo sunellCameraInfo;
        private Client client;
        private CancellationTokenSource cts;
        private Label label;
        private PermissionMonitor permissionMonitor;

        public SunellCameraWindow(PermissionManager<User> permissionManager, ICameraRepository cameraRepository,
            ICameraPermissionRepository cameraPermissionRepository, IPermissionRepository permissionRepository,
            IOperationRepository operationRepository, IGroupMembersRepository groupMembersRepository,
            IPersonalOptionsRepository personalOptionsRepository, SunellCameraInfo sunellCameraInfo,
            Rectangle rectangle, GridCamera gridCamera)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            this.sunellCameraInfo = sunellCameraInfo;
            this.rectangle = rectangle;
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

            sunellVideoWindowCommandFactory = new SunellVideoWindowCommandFactory(this, sunellVideoWindow1);
        }

        public SunellCameraWindow(IServiceProvider serviceProvider, CameraLaunchContext cameraLaunchContext)
        {
            if (cameraLaunchContext == null)
            {
                throw new ArgumentNullException(nameof(cameraLaunchContext));
            }

            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            var cameraRepository = serviceProvider.GetRequiredService<ICameraRepository>();
            camera = cameraRepository.Select(cameraLaunchContext.CameraId);
            personalOptionsRepository = serviceProvider.GetRequiredService<IPersonalOptionsRepository>();
            kBD300ASimulatorServer = new KBD300ASimulatorServer();
            permissionManager = PermissionManagerBuilder.Build(serviceProvider, this, cameraLaunchContext.UserId);

            permissionSetter = new PermissionSetter(new PermissionSetterDependencies(cameraRepository,
                serviceProvider.GetRequiredService<ICameraPermissionRepository>(),
                serviceProvider.GetRequiredService<IPermissionRepository>(),
                serviceProvider.GetRequiredService<IOperationRepository>(),
                serviceProvider.GetRequiredService<IGroupMembersRepository>()));
            permissionSetter.SetGroups(permissionManager.CurrentUser);

            var display = cameraLaunchContext.GetDisplay();
            rectangle = display?.Bounds ?? cameraLaunchContext.Rectangle;
            SetupFullscreenPtz(cameraLaunchContext.UserId, camera, display);

            sunellVideoWindowCommandFactory = new SunellVideoWindowCommandFactory(this, sunellVideoWindow1);
        }

        private void SetupFullscreenPtz(long userId, Camera camera, DisplayDto display)
        {
            if (camera.IpAddress == null)
            {
                throw new MissingFieldException(nameof(Camera), nameof(camera.IpAddress));
            }
            if (camera.Username == null)
            {
                throw new MissingFieldException(nameof(Camera), nameof(camera.Username));
            }
            if (camera.EncryptedPassword == null)
            {
                throw new MissingFieldException(nameof(Camera), nameof(camera.EncryptedPassword));
            }

            sunellCameraInfo = new SunellCameraInfo
            {
                CameraIp = camera.IpAddress,
                CameraPort = SunellLegacyCameraInfo.PagoPort,
                Username = camera.Username,
                Password = CameraPasswordCryptor.PasswordDecrypt(camera.EncryptedPassword),
                CameraId = camera.CameraId ?? 1,
                StreamId = camera.StreamId ?? 1
            };

            kBD300ASimulatorServer.StartPipeServerAsync(Database.Constants.PipeServerName);
            client = CameraRegister.RegisterCamera(userId, camera.Id, display, ClientDataArrivedEventHandler, CameraMode.SunellCamera);

            Console.CancelKeyPress += (sender, e) => OnExit();
            Application.ApplicationExit += (sender, e) => OnExit();
            AppDomain.CurrentDomain.ProcessExit += (sender, e) => OnExit();
        }

        private void ClientDataArrivedEventHandler(object sender, DataArrivedEventArgs e)
        {
            try
            {
                var messages = $"{client.Encoding.GetString(e.Data)}";
                var commands = sunellVideoWindowCommandFactory.CreateCommands(messages);
                foreach (var command in commands)
                {
                    command.Execute();
                    Console.WriteLine($"{command.GetType().Name} executed in Sunell video window.");
                }
            }
            catch (Exception ex)
            {
                var message = $"Message parse or execution failed in Sunell video window: {ex}.";
                Console.Error.WriteLine(message);
                DebugErrorBox.Show(ex);
            }
        }

        private void SunellCameraWindow_Load(object sender, EventArgs e)
        {
            this.SetFormRegion(rectangle);
        }

        private void SunellCameraWindow_Shown(object sender, EventArgs e)
        {
            Activate();

            if (!permissionManager.HasCamera(camera))
            {
                return;
            }

            Initialize();

            if (permissionManager.HasCameraPermission(camera, sunellVideoWindow1))
            {
                ConnectToCamera();
            }
            else
            {
                permissionMonitor = new PermissionMonitor(
                    () =>
                    {
                        permissionSetter.SetGroups(permissionManager.CurrentUser);
                        return permissionManager.HasCameraPermission(camera, sunellVideoWindow1);
                    },
                    () =>
                    {
                        Initialize();
                        ConnectToCamera();
                    }
                );
                permissionMonitor.Start();
            }
        }

        private void Initialize()
        {
            var userId = permissionManager.CurrentUser?.Tag.Id ?? 0;
            var text = personalOptionsRepository.GetCameraName(userId, sunellCameraInfo.CameraIp);
            var osdSettings = personalOptionsRepository.GetOsdSettings(userId);
            OsdSetter.SetInfo(this, sunellVideoWindow1, gridCamera, osdSettings, text);
        }

        private void ConnectToCamera()
        {
            try
            {
                var streamId = Connect();
                if (streamId == SunellVideoWindow.NoStream || streamId == SunellVideoWindow.NoSdkHandler)
                {
                    cts?.Cancel();
                    cts = new CancellationTokenSource();
                    _ = TryReconnectAsync(cts.Token);
                }
                SetOsd();
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
        }

        public void SetOsd()
        {
            this.InvokeIfRequired(() =>
            {
                label = new Label
                {
                    Text = sunellVideoWindow1.OverlayText,
                    ForeColor = sunellVideoWindow1.OverlayBrush.ToColor(),
                    BackColor = sunellVideoWindow1.OverlayBackgroundColor,
                    Font = sunellVideoWindow1.OverlayFont,
                    Parent = Parent,
                    Location = sunellVideoWindow1.OverlayLocation,
                    AutoSize = true
                };
                Controls.Add(label);
                label.BringToFront();
                Invalidate();
            });
        }

        private int Connect()
        {
            var accessResult = permissionManager.HasCameraPermission(camera.PermissionCamera);
            if (accessResult == AccessResult.Allowed)
            {
                return sunellVideoWindow1.Connect(sunellCameraInfo.CameraIp, sunellCameraInfo.CameraPort, sunellCameraInfo.Username, sunellCameraInfo.Password, sunellCameraInfo.StreamId, 1, StreamType.D1, true);
            }
            else
            {
                sunellVideoWindow1.OverlayText = $"No permission ({accessResult}): {camera} ({camera.PermissionCamera}) - {permissionManager.CurrentUser?.Username} ({permissionManager.CurrentUser?.Id ?? 0})";
                DebugErrorBox.Show(camera.ToString(), "No permission to view this camera.");
                return SunellVideoWindow.NoPermission;
            }
        }

        private async Task TryReconnectAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var connectResult = Connect();
                if (connectResult != SunellVideoWindow.NoStream && connectResult != SunellVideoWindow.NoSdkHandler)
                {
                    return;
                }

                try
                {
                    await Task.Delay(1000, cancellationToken).ConfigureAwait(false);
                }
                catch (TaskCanceledException)
                {
                    return;
                }
            }
        }

        private void OnExit()
        {
            kBD300ASimulatorServer?.Stop();
            sunellVideoWindow1.Disconnect();
            client?.Send($"{NetworkCommand.UnregisterCamera}", true);
            client?.Dispose();
        }

        private void SunellCameraWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnExit();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Exit();
        }
    }
}
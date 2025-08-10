using CameraForms.Dto;
using CameraForms.Extensions;
using CameraForms.Services;
using Database.Enums;
using Database.Interfaces;
using Database.Models;
using Database.Services;
using Database.Services.PasswordHashers;
using LiveView.Core.Dependencies;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Network;
using LiveView.Core.Extensions;
using LiveView.Core.Services;
using LiveView.Core.Services.Pipe;
using Microsoft.Extensions.DependencyInjection;
using Mtf.Controls.Video.Sunell.IPR66.CustomEventArgs;
using Mtf.Extensions;
using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Network.EventArg;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using Mtf.Windows.Forms.Extensions;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CameraForms.Forms
{
    public partial class SunellLegacyCameraWindow : Form
    {
        private readonly KBD300ASimulatorServer kBD300ASimulatorServer;
        private readonly IPersonalOptionsRepository personalOptionsRepository;
        private readonly PermissionManager<User> permissionManager;
        private readonly PermissionSetter permissionSetter;
        private readonly Camera camera;
        private readonly GridCamera gridCamera;
        private readonly short rotateSpeed = 50;

        private Rectangle rectangle;
        private SunellLegacyCameraInfo sunellLegacyCameraInfo;
        private Client client;
        private Label label;
        private bool fullScreen;
        private PermissionMonitor permissionMonitor;

        public SunellLegacyCameraWindow(PermissionManager<User> permissionManager, ICameraRepository cameraRepository,
            ICameraPermissionRepository cameraPermissionRepository, IPermissionRepository permissionRepository,
            IOperationRepository operationRepository, IGroupMembersRepository groupMembersRepository,
            IPersonalOptionsRepository personalOptionsRepository, SunellLegacyCameraInfo sunellLegacyCameraInfo,
            Rectangle rectangle, GridCamera gridCamera)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            rotateSpeed = AppConfig.GetInt16(Database.Constants.SunellLegacyCameraWindowRotateSpeed, 50);

            this.sunellLegacyCameraInfo = sunellLegacyCameraInfo;
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
        }

        public SunellLegacyCameraWindow(IServiceProvider serviceProvider, CameraLaunchContext cameraLaunchContext)
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

            fullScreen = true;
            sunellLegacyCameraInfo = new SunellLegacyCameraInfo
            {
                CameraIp = camera.IpAddress,
                CameraPort = SunellLegacyCameraInfo.PagoPort,
                Username = camera.Username,
                Password = CameraPasswordCryptor.PasswordDecrypt(camera.EncryptedPassword),
                CameraId = camera.CameraId ?? 1,
                StreamId = camera.StreamId ?? 1
            };

            kBD300ASimulatorServer.StartPipeServerAsync(Database.Constants.PipeServerName);
            client = CameraRegister.RegisterCamera(userId, camera.Id, display, ClientDataArrivedEventHandler, CameraMode.SunellLegacyCamera);

            Console.CancelKeyPress += (sender, e) => OnExit();
            Application.ApplicationExit += (sender, e) => OnExit();
            AppDomain.CurrentDomain.ProcessExit += (sender, e) => OnExit();
        }

        private void ClientDataArrivedEventHandler(object sender, DataArrivedEventArgs e)
        {
            try
            {
                var messages = $"{client.Encoding.GetString(e.Data)}";
                var commands = SunellLegacyVideoWindowCommandFactory.Create(this, sunellVideoWindowLegacy1, messages, rotateSpeed);
                foreach (var command in commands)
                {
                    command.Execute();
                    Console.WriteLine($"{command.GetType().Name} executed in Sunell legacy camera window.");
                }
            }
            catch (Exception ex)
            {
                var message = $"Message parse or execution failed in Sunell legacy camera window: {ex}.";
                Console.Error.WriteLine(message);
                DebugErrorBox.Show(ex);
            }
        }

        public void SetOsd()
        {
            this.InvokeIfRequired(() =>
            {
                label = new Label
                {
                    Text = sunellVideoWindowLegacy1.OverlayText,
                    ForeColor = sunellVideoWindowLegacy1.OverlayBrush.ToColor(),
                    BackColor = sunellVideoWindowLegacy1.OverlayBackgroundColor,
                    Font = sunellVideoWindowLegacy1.OverlayFont,
                    Parent = Parent,
                    Location = sunellVideoWindowLegacy1.OverlayLocation,
                    AutoSize = true
                };
                Controls.Add(label);
                label.BringToFront();
                Invalidate();
            });
        }

        private void SunellLegacyCameraWindow_Load(object sender, EventArgs e)
        {
            this.SetFormRegion(rectangle);
        }

        private void SunellLegacyCameraWindow_Shown(object sender, EventArgs e)
        {
            Activate();

            if (!permissionManager.HasCamera(camera))
            {
                return;
            }

            Initialize();

            if (permissionManager.HasCameraPermission(camera, sunellVideoWindowLegacy1))
            {
                ConnectToCamera();
            }
            else
            {
                permissionMonitor = new PermissionMonitor(
                    () =>
                    {
                        permissionSetter.SetGroups(permissionManager.CurrentUser);
                        return permissionManager.HasCameraPermission(camera, sunellVideoWindowLegacy1);
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
            var text = personalOptionsRepository.GetCameraName(userId, sunellLegacyCameraInfo.CameraIp);
            var osdSettings = personalOptionsRepository.GetOsdSettings(userId);
            OsdSetter.SetInfo(this, sunellVideoWindowLegacy1, gridCamera, osdSettings, text);
        }

        private void ConnectToCamera()
        {
            try
            {
                var accessResult = permissionManager.HasCameraPermission(camera.PermissionCamera);
                if (accessResult == AccessResult.Allowed)
                {
                    sunellVideoWindowLegacy1.VideoSignalChanged += SunellVideoWindowLegacy1_VideoSignalChanged;
                    sunellVideoWindowLegacy1.Connect(sunellLegacyCameraInfo.CameraIp, sunellLegacyCameraInfo.CameraPort, sunellLegacyCameraInfo.Username, sunellLegacyCameraInfo.Password, sunellLegacyCameraInfo.StreamId);
                    if (fullScreen)
                    {
                        sunellVideoWindowLegacy1.PTZ_Open(sunellLegacyCameraInfo.CameraId);
                    }
                    SetOsd();
                }
                else
                {
                    sunellVideoWindowLegacy1.OverlayText = $"No permission ({accessResult}): {camera} ({camera.PermissionCamera}) - {permissionManager.CurrentUser?.Username} ({permissionManager.CurrentUser?.Id ?? 0})";
                    DebugErrorBox.Show(camera.ToString(), "No permission to view this camera.");
                }
            }
            catch (Exception ex)
            {
                DebugErrorBox.Show(ex);
            }
        }

        private void SunellVideoWindowLegacy1_VideoSignalChanged(object sender, VideoSignalChangedEventArgs e)
        {
            this.InvokeIfRequired(() => sunellVideoWindowLegacy1.Visible = e.HasSignal);
        }

        private void OnExit()
        {
            kBD300ASimulatorServer?.Stop();
            if (fullScreen)
            {
                sunellVideoWindowLegacy1.PTZ_Close();
            }
            sunellVideoWindowLegacy1.Disconnect();
            client?.Send($"{NetworkCommand.UnregisterCamera}", true);
            client?.Dispose();
        }

        private void SunellLegacyCameraWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnExit();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Exit();
        }
    }
}

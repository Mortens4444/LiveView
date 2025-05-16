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
using Mtf.Controls.Sunell.IPR66.CustomEventArgs;
using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Network.EventArg;
using Mtf.Permissions.Services;
using System;
using System.Drawing;
using System.Security.Policy;
using System.Windows.Forms;

namespace CameraForms.Forms
{
    public partial class SunellLegacyCameraWindow : Form
    {
        private readonly KBD300ASimulatorServer kBD300ASimulatorServer;
        private readonly IPersonalOptionsRepository personalOptionsRepository;
        private readonly PermissionManager<User> permissionManager;
        private readonly Camera camera;

        private Rectangle rectangle;
        private SunellLegacyCameraInfo sunellLegacyCameraInfo;
        private Client client;
        private Label label;
        private GridCamera gridCamera;
        private short rotateSpeed = 50;
        private bool fullScreen;

        public SunellLegacyCameraWindow(PermissionManager<User> permissionManager, ICameraRepository cameraRepository, IPersonalOptionsRepository personalOptionsRepository, SunellLegacyCameraInfo sunellLegacyCameraInfo, Rectangle rectangle, GridCamera gridCamera)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            rotateSpeed = AppConfig.GetInt16(LiveView.Core.Constants.SunellLegacyCameraWindowRotateSpeed, 50);

            this.sunellLegacyCameraInfo = sunellLegacyCameraInfo;
            this.rectangle = rectangle;
            this.permissionManager = permissionManager;
            this.personalOptionsRepository = personalOptionsRepository;
            this.gridCamera = gridCamera;
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

            var display = cameraLaunchContext.GetDisplay();
            rectangle = display?.Bounds ?? cameraLaunchContext.Rectangle;
            Initialize(cameraLaunchContext.UserId, camera, display);
        }

        private void Initialize(long userId, Camera camera, DisplayDto display)
        {
            fullScreen = true;
            sunellLegacyCameraInfo = new SunellLegacyCameraInfo
            {
                CameraIp = camera.IpAddress,
                CameraPort = SunellLegacyCameraInfo.PagoPort,
                Username = camera.Username,
                Password = camera.Password,
                CameraId = camera.CameraId ?? 1,
                StreamId = camera.StreamId ?? 1
            };

            kBD300ASimulatorServer.StartPipeServerAsync(LiveView.Core.Constants.PipeServerName);
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
                    ForeColor = sunellVideoWindowLegacy1.OverlayColor,
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
            this.SetFormSizeAndPosition(rectangle);
        }

        private void SunellLegacyCameraWindow_Shown(object sender, EventArgs e)
        {
            if (permissionManager.CurrentUser == null)
            {
                DebugErrorBox.Show(camera.ToString(), "No user is logged in.");
                return;
            }

            var userId = permissionManager.CurrentUser.Tag.Id;
            var largeFontSize = personalOptionsRepository.Get(Setting.CameraLargeFontSize, userId, 30);
            //var smallFontSize = personalOptionsRepository.Get(Setting.CameraSmallFontSize, userId, 15);
            sunellVideoWindowLegacy1.OverlayFont = new Font(personalOptionsRepository.Get(Setting.CameraFont, userId, "Arial"), largeFontSize, FontStyle.Bold);
            sunellVideoWindowLegacy1.OverlayColor = Color.FromArgb(personalOptionsRepository.Get(Setting.CameraFontColor, userId, Color.White.ToArgb()));
            sunellVideoWindowLegacy1.OverlayBackgroundColor = Color.FromArgb(personalOptionsRepository.Get(Setting.CameraFontShadowColor, userId, Color.Black.ToArgb()));
            var text = personalOptionsRepository.GetCameraName(userId, sunellLegacyCameraInfo.CameraIp);
            //OsdSetter.SetInfo(this, sunellVideoWindowLegacy1, gridCamera, text);
            if (gridCamera?.Frame ?? false)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
                Text = text;
            }
            else
            {
                if (gridCamera?.Osd ?? false)
                {
                    sunellVideoWindowLegacy1.OverlayText = text;
                }
            }
            if (gridCamera?.ShowDateTime ?? false)
            {
                sunellVideoWindowLegacy1.OverlayText += DateUtils.GetNowFriendlyString();
            }

            try
            {
                if (permissionManager.HasCameraPermission(camera.PermissionCamera))
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
                    sunellVideoWindowLegacy1.OverlayText = $"No permission: {camera}";
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
            Close();
        }
    }
}

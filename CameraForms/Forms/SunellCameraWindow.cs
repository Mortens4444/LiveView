using CameraForms.Dto;
using CameraForms.Extensions;
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
using Mtf.Controls.Interfaces;
using Mtf.Controls.Sunell.IPR67;
using Mtf.Controls.Sunell.IPR67.SunellSdk;
using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Network.EventArg;
using Mtf.Permissions.Services;
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

        private Rectangle rectangle;
        private SunellCameraInfo sunellCameraInfo;
        private Client client;
        private CancellationTokenSource cts;
        private Label label;
        private GridCamera gridCamera;
        private Camera camera;

        public SunellCameraWindow(PermissionManager<User> permissionManager, ICameraRepository cameraRepository, IPersonalOptionsRepository personalOptionsRepository, SunellCameraInfo sunellCameraInfo, Rectangle rectangle, GridCamera gridCamera)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            this.sunellCameraInfo = sunellCameraInfo;
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

            var display = cameraLaunchContext.GetDisplay();
            rectangle = display?.Bounds ?? cameraLaunchContext.Rectangle;
            Initialize(cameraLaunchContext.UserId, camera, display, true);
        }

        private void Initialize(long userId, Camera camera, DisplayDto display, bool fullScreen)
        {
            sunellCameraInfo = new SunellCameraInfo
            {
                CameraIp = camera.IpAddress,
                CameraPort = SunellLegacyCameraInfo.PagoPort,
                Username = camera.Username,
                Password = camera.Password,
                CameraId = camera.CameraId ?? 1,
                StreamId = camera.StreamId ?? 1
            };

            if (fullScreen)
            {
                kBD300ASimulatorServer.StartPipeServerAsync(LiveView.Core.Constants.PipeServerName);
                client = CameraRegister.RegisterCamera(userId, camera.Id, display, ClientDataArrivedEventHandler, CameraMode.SunellCamera);

                Console.CancelKeyPress += (sender, e) => OnExit();
                Application.ApplicationExit += (sender, e) => OnExit();
                AppDomain.CurrentDomain.ProcessExit += (sender, e) => OnExit();
            }
        }

        private void ClientDataArrivedEventHandler(object sender, DataArrivedEventArgs e)
        {
            try
            {
                var messages = $"{client.Encoding.GetString(e.Data)}";
                var commands = SunellVideoWindowCommandFactory.Create(this, sunellVideoWindow1, messages);
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
            this.SetFormSizeAndPosition(rectangle);
        }

        private void SunellCameraWindow_Shown(object sender, EventArgs e)
        {
            if (!permissionManager.HasCameraAndUser(camera))
            {
                return;
            }

            var userId = permissionManager.CurrentUser.Tag.Id;
            var largeFontSize = personalOptionsRepository.Get(Setting.CameraLargeFontSize, userId, 30);
            //var smallFontSize = personalOptionsRepository.Get(Setting.CameraSmallFontSize, userId, 15);
            sunellVideoWindow1.OverlayFont = new Font(personalOptionsRepository.Get(Setting.CameraFont, userId, "Arial"), largeFontSize, FontStyle.Bold);
            sunellVideoWindow1.OverlayColor = Color.FromArgb(personalOptionsRepository.Get(Setting.CameraFontColor, userId, Color.White.ToArgb()));
            sunellVideoWindow1.OverlayBackgroundColor = Color.FromArgb(personalOptionsRepository.Get(Setting.CameraFontShadowColor, userId, Color.Black.ToArgb()));

            var text = personalOptionsRepository.GetCameraName(userId, sunellCameraInfo.CameraIp);
            //OsdSetter.SetInfo(this, sunellVideoWindow1, gridCamera, text);
            if (gridCamera?.Frame ?? false)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
                Text = text;
            }
            else
            {
                if (gridCamera?.Osd ?? false)
                {
                    sunellVideoWindow1.OverlayText = text;
                }
            }
            if (gridCamera?.ShowDateTime ?? false)
            {
                sunellVideoWindow1.OverlayText += DateUtils.GetNowFriendlyString();
            }

            try
            {
                var streamId = Connect();
                if (streamId == SunellVideoWindow.NoStream)
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
                    ForeColor = sunellVideoWindow1.OverlayColor,
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
            if (permissionManager.HasCameraPermission(camera.PermissionCamera))
            {
                return sunellVideoWindow1.Connect(sunellCameraInfo.CameraIp, sunellCameraInfo.CameraPort, sunellCameraInfo.Username, sunellCameraInfo.Password, sunellCameraInfo.StreamId, 1, StreamType.D1, true);
            }
            else
            {
                sunellVideoWindow1.OverlayText = $"No permission: {camera} ({camera.PermissionCamera}) - {permissionManager.CurrentUser.Username} ({permissionManager.CurrentUser.Id})";
                DebugErrorBox.Show(camera.ToString(), "No permission to view this camera.");
                return SunellVideoWindow.NoPermission;
            }
        }

        private async Task TryReconnectAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (Connect() != SunellVideoWindow.NoStream)
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
            Close();
        }
    }
}
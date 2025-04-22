using CameraForms.Extensions;
using CameraForms.Services;
using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Core.Dto;
using LiveView.Core.Services;
using LiveView.Core.Services.Pipe;
using Microsoft.Extensions.DependencyInjection;
using Mtf.Permissions.Services;
using System;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CameraForms.Forms
{
    public partial class MortoGraphyCameraWindow : Form
    {
        private readonly IAgentRepository agentRepository;
        private readonly ICameraRepository cameraRepository;
        private readonly ICameraFunctionRepository cameraFunctionRepository;
        private readonly IPersonalOptionsRepository personalOptionsRepository;
        private readonly IVideoSourceRepository videoSourceRepository;
        private readonly KBD300ASimulatorServer kBD300ASimulatorServer;

        private PermissionManager<User> permissionManager;
        private Rectangle rectangle;
        private string url;
        private GridCamera gridCamera;
        private FullScreenCameraMessageHandler fullScreenCameraMessageHandler;
        private int bufferSize;
        private int onExit;

        public MortoGraphyCameraWindow(PermissionManager<User> permissionManager, IAgentRepository agentRepository,
            ICameraRepository cameraRepository, ICameraFunctionRepository cameraFunctionRepository,
            IPersonalOptionsRepository personalOptionsRepository, IVideoSourceRepository videoSourceRepository,
            string url, Rectangle rectangle, GridCamera gridCamera)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            this.url = url;
            this.rectangle = rectangle;
            this.agentRepository = agentRepository;
            this.cameraRepository = cameraRepository;
            this.cameraFunctionRepository = cameraFunctionRepository;
            this.videoSourceRepository = videoSourceRepository;
            this.permissionManager = permissionManager;
            this.personalOptionsRepository = personalOptionsRepository;
            this.gridCamera = gridCamera;

            if (gridCamera?.Frame ?? false)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
            }
            SetBufferSize();
        }

        public MortoGraphyCameraWindow(IServiceProvider serviceProvider, long userId, long cameraId, long? displayId)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            kBD300ASimulatorServer = new KBD300ASimulatorServer();
            permissionManager = PermissionManagerBuilder.Build(serviceProvider, this, userId);
            cameraFunctionRepository = serviceProvider.GetRequiredService<ICameraFunctionRepository>();
            cameraRepository = serviceProvider.GetRequiredService<ICameraRepository>();
            agentRepository = serviceProvider.GetRequiredService<IAgentRepository>();
            videoSourceRepository = serviceProvider.GetRequiredService<IVideoSourceRepository>();
            personalOptionsRepository = serviceProvider.GetRequiredService<IPersonalOptionsRepository>();
            var display = DisplayProvider.Get(displayId);
            rectangle = display.Bounds;
            Initialize(userId, cameraId, display, true);
        }

        public MortoGraphyCameraWindow(IServiceProvider serviceProvider, long userId, long cameraId, Rectangle rectangle)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            this.rectangle = rectangle;
            kBD300ASimulatorServer = new KBD300ASimulatorServer();
            permissionManager = PermissionManagerBuilder.Build(serviceProvider, this, userId);
            cameraFunctionRepository = serviceProvider.GetRequiredService<ICameraFunctionRepository>();
            cameraRepository = serviceProvider.GetRequiredService<ICameraRepository>();
            agentRepository = serviceProvider.GetRequiredService<IAgentRepository>();
            videoSourceRepository = serviceProvider.GetRequiredService<IVideoSourceRepository>();
            personalOptionsRepository = serviceProvider.GetRequiredService<IPersonalOptionsRepository>();
            Initialize(userId, cameraId, null, true);
        }

        public MortoGraphyCameraWindow(IServiceProvider serviceProvider, long userId, string ipAddress, string videoSourceName, long? displayId)
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            kBD300ASimulatorServer = new KBD300ASimulatorServer();
            permissionManager = PermissionManagerBuilder.Build(serviceProvider, this, userId);
            cameraFunctionRepository = serviceProvider.GetRequiredService<ICameraFunctionRepository>();
            cameraRepository = serviceProvider.GetRequiredService<ICameraRepository>();
            agentRepository = serviceProvider.GetRequiredService<IAgentRepository>();
            videoSourceRepository = serviceProvider.GetRequiredService<IVideoSourceRepository>();
            personalOptionsRepository = serviceProvider.GetRequiredService<IPersonalOptionsRepository>();

            SetBufferSize();
            url = $"{ipAddress}|{videoSourceName}";

            kBD300ASimulatorServer.StartPipeServerAsync(LiveView.Core.Constants.PipeServerName);
            var display = DisplayProvider.Get(displayId);
            rectangle = display.Bounds;
            fullScreenCameraMessageHandler = new FullScreenCameraMessageHandler(userId, ipAddress, videoSourceName, this, display, CameraMode.MortoGraphy, cameraFunctionRepository);

            Console.CancelKeyPress += (sender, e) => OnExit();
            Application.ApplicationExit += (sender, e) => OnExit();
            AppDomain.CurrentDomain.ProcessExit += (sender, e) => OnExit();
        }

        private void SetBufferSize()
        {
            var videoCaptureClientBufferSize = ConfigurationManager.AppSettings[LiveView.Core.Constants.VideoCaptureClientBufferSize];
            if (!Int32.TryParse(videoCaptureClientBufferSize, out bufferSize))
            {
                bufferSize = 409600;
            }
        }

        private void Initialize(long userId, long cameraId, DisplayDto display, bool fullScreen)
        {
            SetBufferSize();
            var camera = cameraRepository.Select(cameraId);
            url = camera.HttpStreamUrl;

            if (fullScreen)
            {
                kBD300ASimulatorServer.StartPipeServerAsync(LiveView.Core.Constants.PipeServerName);
                fullScreenCameraMessageHandler = new FullScreenCameraMessageHandler(userId, cameraId, this, display, CameraMode.MortoGraphy, cameraFunctionRepository);

                Console.CancelKeyPress += (sender, e) => OnExit();
                Application.ApplicationExit += (sender, e) => OnExit();
                AppDomain.CurrentDomain.ProcessExit += (sender, e) => OnExit();
            }
        }

        private void MortoGraphyWindow_Load(object sender, EventArgs e)
        {
            this.SetFormSizeAndPosition(rectangle);
        }

        private void MortoGraphyWindow_Shown(object sender, EventArgs e)
        {
            var userId = permissionManager.CurrentUser.Tag.Id;
            var largeFontSize = personalOptionsRepository.Get(Setting.CameraLargeFontSize, userId, 30);
            //var smallFontSize = personalOptionsRepository.Get(Setting.CameraSmallFontSize, userId, 15);
            var fontName = personalOptionsRepository.Get(Setting.CameraFont, userId, "Arial");
            var fontColor = Color.FromArgb(personalOptionsRepository.Get(Setting.CameraFontColor, userId, Color.White.ToArgb()));
            //var shadowColor = Color.FromArgb(personalOptionsRepository.Get(Setting.CameraFontShadowColor, userId, Color.Black.ToArgb()));

            var cameraName = personalOptionsRepository.GetCameraName(userId, url);
            mortoGraphyWindow.OverlayFont = new Font(fontName, largeFontSize, FontStyle.Bold);
            mortoGraphyWindow.OverlayBrush = new SolidBrush(fontColor);
            mortoGraphyWindow.BufferSize = bufferSize;
            if (gridCamera?.Frame ?? false)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
                Text = cameraName;
            }
            else
            {
                if (gridCamera?.Osd ?? false)
                {
                    mortoGraphyWindow.OverlayText = cameraName;
                }
            }
            if (gridCamera?.ShowDateTime ?? false)
            {
                mortoGraphyWindow.OverlayText += DateTime.Now.ToString();
            }

            if (url.IndexOf('|') > 0)
            {
                var videoSourceNameInfo = url.Split('|');
                var agent = agentRepository.SelectWhere(new { ServerIp = videoSourceNameInfo[0] }).FirstOrDefault();
                if (agent != null)
                {
                    var videoSource = videoSourceRepository.SelectWhere(new { AgentId = agent.Id, Name = videoSourceNameInfo[1] }).FirstOrDefault();
                    if (videoSource != null)
                    {
                        url = $"{videoSourceNameInfo[0]}:{videoSource.Port}";
                    }
                }
            }
            mortoGraphyWindow.Start(url);
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
            Close();
        }
    }
}

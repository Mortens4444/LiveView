using Database.Interfaces;
using Database.Models;
using Database.Repositories;
using LibVLCSharp.Shared;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Network;
using LiveView.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Network.EventArg;
using Mtf.Network.Extensions;
using Mtf.Permissions.Services;
using Sequence.Services;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sequence.Forms
{
    internal partial class MainForm : Form
    {
        private static Client client;

        private readonly long sequenceId;
        private readonly DisplayDto display;
        private readonly PermissionManager<User> permissionManager;
        private readonly GridSequenceManager gridSequenceManager;
        private readonly ILogger<MainForm> logger;

        public MainForm(IServiceProvider serviceProvider, long userId, long sequenceId, long displayId, bool isMdi)
        {
            logger = serviceProvider.GetRequiredService<ILogger<MainForm>>();

            var serverIp = ConfigurationManager.AppSettings[LiveView.Core.Constants.LiveViewServerIpAddress];
            var listenerPort = ConfigurationManager.AppSettings[LiveView.Core.Constants.LiveViewServerListenerPort];
            if (UInt16.TryParse(listenerPort, out var serverPort))
            {
                try
                {
                    client = new Client(serverIp, serverPort);
                    client.DataArrived += ClientDataArrivedEventHandler;
                    client.Connect();
#if NET6_0_OR_GREATER
                    client.Send($"{NetworkCommand.RegisterSequence}|{client.Socket.LocalEndPoint}|{userId}|{sequenceId}|{displayId}|{isMdi}|{Environment.ProcessId}", true);
#else
                    client.Send($"{NetworkCommand.RegisterSequence}|{client.Socket.LocalEndPoint}|{userId}|{sequenceId}|{displayId}|{isMdi}|{Process.GetCurrentProcess().Id}", true);
#endif
                }
                catch (Exception ex)
                {
#if NET6_0_OR_GREATER
                    logger.LogError(ex, "Connection failed.");
#else
                    logger.LogError($"Connection failed: {ex}");
#endif
                    DebugErrorBox.Show(ex);
                }
            }
            else
            {
                ErrorBox.Show("General error", $"{LiveView.Core.Constants.LiveViewServerListenerPort} cannot be parsed as an ushort.");
            }

            Console.CancelKeyPress += async (sender, e) => await OnExitAsync().ConfigureAwait(false);
            Application.ApplicationExit += async (sender, e) => await OnExitAsync().ConfigureAwait(false);
            AppDomain.CurrentDomain.ProcessExit += async (sender, e) => await OnExitAsync().ConfigureAwait(false);
            FormClosing += async (sender, e) => await OnExitAsync().ConfigureAwait(false);

            InitializeComponent();
            //closeToolStripMenuItem.Text = Lng.Elem("Close");
            this.sequenceId = sequenceId;

            permissionManager = PermissionManagerBuilder.Build(serviceProvider, this, userId);
            //closeToolStripMenuItem.Enabled = permissionManager.CurrentUser.HasPermission(WindowManagementPermissions.Close);

            var displayRepository = new DisplayRepository();
            var sequenceDisplay = displayRepository.Select(displayId) ?? throw new InvalidOperationException($"Display not found in repository with Id '{displayId}'.");
            var displayManager = new DisplayManager();
            var displays = displayManager.GetAll();

            display = displays.FirstOrDefault(d => d.GetId() == sequenceDisplay.Id);
            if (display == null)
            {
                throw new InvalidOperationException($"Display not found with Id '{displayId}'.");
            }

            var serverRepository = serviceProvider.GetRequiredService<IServerRepository>();
            var cameraRepository = serviceProvider.GetRequiredService<ICameraRepository>();
            var cameraFunctionRepository = serviceProvider.GetRequiredService<ICameraFunctionRepository>();
            var gridCameraRepository = serviceProvider.GetRequiredService<IGridCameraRepository>();
            var personalOptionsRepository = serviceProvider.GetRequiredService<IPersonalOptionsRepository>();
            var gridSequenceManagerLogger = serviceProvider.GetRequiredService<ILogger<GridSequenceManager>>();
            var agentRepository = serviceProvider.GetRequiredService<IAgentRepository>();
            var videoSourceRepository = serviceProvider.GetRequiredService<IVideoSourceRepository>();

            gridSequenceManager = new GridSequenceManager(permissionManager, agentRepository, videoSourceRepository, serverRepository, cameraRepository, cameraFunctionRepository, gridCameraRepository, personalOptionsRepository, gridSequenceManagerLogger, client, this, display, isMdi);
            HandleCreated += MainForm_HandleCreated;
        }

        private void MainForm_HandleCreated(object sender, EventArgs e)
        {
            gridSequenceManager.StartSequence(sequenceId);
        }

        private void ClientDataArrivedEventHandler(object sender, DataArrivedEventArgs e)
        {
            try
            {
                var messages = $"{client?.Encoding.GetString(e.Data)}";
                var allMessages = messages.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var message in allMessages)
                {
                    var messageParts = message.Split('|');
                    if (message.StartsWith(NetworkCommand.Close.ToString(), StringComparison.InvariantCulture))
                    {
                        Invoke((Action)(() => Close()));
                    }
                    else if (message.StartsWith(NetworkCommand.Kill.ToString(), StringComparison.InvariantCulture))
                    {
                        Invoke((Action)(() => Close()));
                    }
                    else if (message.StartsWith(NetworkCommand.PlayOrPauseSequence.ToString(), StringComparison.InvariantCulture))
                    {
                        gridSequenceManager.ChangeIsPausedState();
                    }
                    else if (message.StartsWith(NetworkCommand.RearrangeGrids.ToString(), StringComparison.InvariantCulture))
                    {
                    }
                    else if (message.StartsWith(NetworkCommand.ShowNextGrid.ToString(), StringComparison.InvariantCulture))
                    {
                        gridSequenceManager.ShowNextGrid();
                    }
                    else if (message.StartsWith(NetworkCommand.ShowPreviousGrid.ToString(), StringComparison.InvariantCulture))
                    {
                        gridSequenceManager.ShowPreviousGrid();
                    }
                }
            }
            catch (Exception ex)
            {
#if NET6_0_OR_GREATER
                logger.LogError(ex, "Client data cannot be parsed.");
#else
                logger.LogError($"Client data cannot be parsed: {ex}");
#endif

                DebugErrorBox.Show(ex);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Location = new Point(display.X, display.Y);
            if (Boolean.TryParse(ConfigurationManager.AppSettings[LiveView.Core.Constants.UseMiniSizeForFullscreenWindows], out var useMiniWindowattach) && useMiniWindowattach)
            {
                Size = new Size(100, 100);
            }
            else
            {
                Size = new Size(display.MaxWidth, display.MaxHeight);
            }

            if (gridSequenceManager.Invalid)
            {
                ErrorBox.Show(Lng.Elem("General error"), Lng.Elem("Sequence does not exists."));
                Close();
            }
        }

        private async Task OnExitAsync()
        {
            gridSequenceManager.StopGridSequence();
            await gridSequenceManager.DisposeCameraWindowsAsync().ConfigureAwait(false);

            try
            {
#if NET6_0_OR_GREATER
                var processId = Environment.ProcessId;
#else
                var processId = Process.GetCurrentProcess().Id;
#endif
                var hostInfo = client?.Socket?.LocalEndPoint?.GetEndPointInfo();
                client?.Send($"{NetworkCommand.UnregisterSequence}|{hostInfo}|{sequenceId}|{processId}", true);
            }
            catch (Exception ex)
            {
#if NET6_0_OR_GREATER
                logger.LogError(ex, "Cannot unregister sequence application.");
#else
                logger.LogError($"Cannot unregister sequence application: {ex}");
#endif

                DebugErrorBox.Show(ex);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }

        private async void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await OnExitAsync().ConfigureAwait(false);
        }
    }
}

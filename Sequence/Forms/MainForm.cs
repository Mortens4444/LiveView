using CameraForms.Extensions;
using CameraForms.Interfaces;
using Database.Interfaces;
using Database.Models;
using Database.Services;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Network;
using LiveView.Core.Extensions;
using LiveView.Core.Interfaces;
using LiveView.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mtf.Extensions;
using Mtf.LanguageService;
using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Network.EventArg;
using Mtf.Network.Services;
using Mtf.Permissions.Services;
using Sequence.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sequence.Forms
{
    internal partial class MainForm : Form
    {
#if DEBUG
        private static Server server;
#endif
        private static Client client;

        private readonly long sequenceId;
        private readonly DisplayDto display;
        private readonly PermissionManager<User> permissionManager;
        private readonly GridSequenceManager gridSequenceManager;
        private readonly IUserRepository userRepository;
        private readonly ILogger<MainForm> logger;
        private int onExit;

        public MainForm(IServiceProvider serviceProvider, long agentId, long userId, long sequenceId, long displayId, bool isMdi)
        {
            logger = serviceProvider.GetRequiredService<ILogger<MainForm>>();

            var serverIp = AppConfig.GetString(Database.Constants.LiveViewServerIpAddress);
            var serverPort = AppConfig.GetUInt16WithThrowOnError(Database.Constants.LiveViewServerListenerPort);
            if (serverPort != default)
            {
                try
                {
#if DEBUG
                    try
                    {
                        server = new Server(listenerPort: 4444);
                        server.Start();
                    }
                    catch (Exception ex)
                    {
                        DebugErrorBox.Show(ex);
                    }
#endif

                    client = new Client(serverIp, serverPort);
                    client.DataArrived += ClientDataArrivedEventHandler;
                    client.Connect();
                    var processId = LiveView.Core.Services.ProcessUtils.GetProcessId();
                    client.Send($"{NetworkCommand.RegisterSequence}|{client.Socket.LocalEndPoint}|{userId}|{sequenceId}|{displayId}|{isMdi}|{processId}|{agentId}", true);
                }
                catch (Exception ex)
                {
                    logger.LogException(ex, "Connection failed.");
                    DebugErrorBox.Show(ex);
                }
            }
            else
            {
                ErrorBox.Show("General error", $"{Database.Constants.LiveViewServerListenerPort} cannot be parsed as an ushort.");
            }

            Console.CancelKeyPress += async (sender, e) => await OnExitAsync().ConfigureAwait(false);
            Application.ApplicationExit += async (sender, e) => await OnExitAsync().ConfigureAwait(false);
            AppDomain.CurrentDomain.ProcessExit += async (sender, e) => await OnExitAsync().ConfigureAwait(false);
            FormClosing += async (sender, e) => await OnExitAsync().ConfigureAwait(false);

            InitializeComponent();
            //closeToolStripMenuItem.Text = Lng.Elem("Close");
            this.sequenceId = sequenceId;

            permissionManager = PermissionManagerBuilder.Build(serviceProvider, this, userId);
            //closeToolStripMenuItem.Enabled = permissionManager.HasPermission(WindowManagementPermissions.Close);

            var displayRepository = serviceProvider.GetRequiredService<IDisplayRepository>();
            var sequenceDisplay = displayRepository.Select(displayId) ?? throw new InvalidOperationException($"Display not found in repository with Id '{displayId}'.");
            var displayManager = serviceProvider.GetRequiredService<IDisplayManager>();
            var displays = displayManager.GetAll();

            display = displays.FirstOrDefault(d => d.GetId() == sequenceDisplay.Id);
            if (display == null)
            {
                throw new InvalidOperationException($"Display not found with Id '{displayId}'.");
            }

            if (!display.CanShowSequence)
            {
                throw new InvalidOperationException(Lng.FormattedElem("This display '{0}' is forbidden to show sequence windows.", args: displayId));
            }

            var sequenceRepository = serviceProvider.GetRequiredService<ISequenceRepository>();
            var gridRepository = serviceProvider.GetRequiredService<IGridRepository>();
            var sequenceGridsRepository = serviceProvider.GetRequiredService<ISequenceGridsRepository>();
            var videoServerRepository = serviceProvider.GetRequiredService<IVideoServerRepository>();
            var agentRepository = serviceProvider.GetRequiredService<IAgentRepository>();
            var cameraRepository = serviceProvider.GetRequiredService<ICameraRepository>();
            var cameraPermissionRepository = serviceProvider.GetRequiredService<ICameraPermissionRepository>();
            var permissionRepository = serviceProvider.GetRequiredService<IPermissionRepository>();
            var operationRepository = serviceProvider.GetRequiredService<IOperationRepository>();
            var groupMembersRepository = serviceProvider.GetRequiredService<IGroupMembersRepository>();
            var cameraFunctionRepository = serviceProvider.GetRequiredService<ICameraFunctionRepository>();
            var gridCameraRepository = serviceProvider.GetRequiredService<IGridCameraRepository>();
            var personalOptionsRepository = serviceProvider.GetRequiredService<IPersonalOptionsRepository>();
            var gridSequenceManagerLogger = serviceProvider.GetRequiredService<ILogger<GridSequenceManager>>();
            var videoSourceRepository = serviceProvider.GetRequiredService<IVideoSourceRepository>();
            var generalOptionsRepository = serviceProvider.GetRequiredService<IGeneralOptionsRepository>();
            var cameraRegister = serviceProvider.GetRequiredService<ICameraRegister>();
            userRepository = serviceProvider.GetRequiredService<IUserRepository>();

            gridSequenceManager = new GridSequenceManager(permissionManager, sequenceRepository, sequenceGridsRepository, gridRepository, agentRepository,
                videoSourceRepository, videoServerRepository, cameraRepository, cameraPermissionRepository, permissionRepository, operationRepository, groupMembersRepository,
                cameraFunctionRepository, gridCameraRepository, personalOptionsRepository, generalOptionsRepository, gridSequenceManagerLogger, cameraRegister, client, this, display, isMdi);
            HandleCreated += MainForm_HandleCreated;
        }

        private async void MainForm_HandleCreated(object sender, EventArgs e)
        {
            await gridSequenceManager.StartSequenceAsync(sequenceId).ConfigureAwait(false);
        }

        private void ClientDataArrivedEventHandler(object sender, DataArrivedEventArgs e)
        {
            try
            {
                var messages = $"{client.Encoding.GetString(e.Data)}";
                var commands = SequenceCommandFactory.Create(this, gridSequenceManager,
                    permissionManager, userRepository, messages);
                foreach (var command in commands)
                {
                    command.Execute();
                    Console.WriteLine($"{command.GetType().Name} executed in sequence window.");
                }
            }
            catch (Exception ex)
            {
                logger.LogException(ex, "Client data cannot be parsed by sequence window.");
                var message = $"Message parse or execution failed in sequence window: {ex}.";
                Console.Error.WriteLine(message);
                DebugErrorBox.Show(ex);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Location = new Point(display.X, display.Y);
            this.SetFormRegion(display.Bounds);

            if (gridSequenceManager.Invalid)
            {
                ErrorBox.Show(Lng.Elem("General error"), Lng.Elem("Sequence does not exists."));
                Close();
            }
        }

        private async Task OnExitAsync()
        {
            if (Interlocked.Exchange(ref onExit, 1) != 0)
            {
                return;
            }

#if DEBUG
            if (server != null)
            {
                server.Stop();
                server.Dispose();
            }
#endif
            gridSequenceManager.StopGridSequence();
            await gridSequenceManager.DisposeCameraWindowsAsync().ConfigureAwait(false);

            try
            {
                var processId = LiveView.Core.Services.ProcessUtils.GetProcessId();
                var hostInfo = client?.Socket?.LocalEndPoint?.GetEndPointInfo(NetUtils.GetLocalIPAddresses);
                client?.SendAsync($"{NetworkCommand.UnregisterSequence}|{hostInfo}|{sequenceId}|{processId}", true);
            }
            catch (Exception ex)
            {
                logger.LogException(ex, "Cannot unregister sequence application.");
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

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Exit();
        }
    }
}

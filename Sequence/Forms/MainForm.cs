using Database.Models;
using Database.Repositories;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Display;
using LiveView.Core.Enums.Network;
using LiveView.Core.Enums.Window;
using LiveView.Core.Services;
using Mtf.LanguageService;
using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Network.EventArg;
using Mtf.Permissions.Services;
using Sequence.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sequence.Forms
{
    internal partial class MainForm : Form
    {
        private int disposed;
        private Task gridChanger;
        private CancellationTokenSource cts;

        private static readonly ReadOnlyCollection<Database.Models.Server> servers = new ServerRepository().SelectAll();
        private static readonly ReadOnlyCollection<Database.Models.Camera> allCameras = new CameraRepository().SelectAll();
        private static readonly ReadOnlyCollection<GridCamera> gridCameras = new GridCameraRepository().SelectAll();
        private static Client client;

        private readonly bool isMdi;
        private readonly long sequenceId;
        private readonly DisplayDto display;
        private readonly PermissionManager<User> permissionManager;

        private readonly Dictionary<long, List<Form>> cameraForms = new Dictionary<long, List<Form>>();
        private readonly Dictionary<long, List<Process>> processes = new Dictionary<long, List<Process>>();

        public MainForm(long userId, long sequenceId, long displayId, bool isMdi)
        {
            var serverIp = ConfigurationManager.AppSettings["LiveViewServer.IpAddress"];
            var listenerPort = ConfigurationManager.AppSettings["LiveViewServer.ListenerPort"];
            if (UInt16.TryParse(listenerPort, out var serverPort))
            {
                try
                {
                    client = new Client(serverIp, serverPort);
                    client.DataArrived += ClientDataArrivedEventHandler;
                    client.Connect();
#if NET481
                    client.Send($"{NetworkCommand.RegisterSequence}|{client.Socket.LocalEndPoint}|{userId}|{sequenceId}|{displayId}|{isMdi}|{Process.GetCurrentProcess().Id}", true);
#else
                    client.Send($"{NetworkCommand.RegisterSequence}|{client.Socket.LocalEndPoint}|{userId}|{sequenceId}|{displayId}|{isMdi}|{Environment.ProcessId}", true);
#endif
                }
                catch (Exception ex)
                {
                    DebugErrorBox.Show(ex);
                }
            }
            else
            {
                ErrorBox.Show("General error", "LiveViewServer.ListenerPort cannot be parsed as an ushort.");
            }

            Console.CancelKeyPress += async (sender, e) => await OnExitAsync().ConfigureAwait(false);
            Application.ApplicationExit += async (sender, e) => await OnExitAsync().ConfigureAwait(false);
            AppDomain.CurrentDomain.ProcessExit += async (sender, e) => await OnExitAsync().ConfigureAwait(false);
            FormClosing += async (sender, e) => await OnExitAsync().ConfigureAwait(false);

            InitializeComponent();
            //closeToolStripMenuItem.Text = Lng.Elem("Close");
            this.isMdi = isMdi;
            this.sequenceId = sequenceId;

            var userRepository = new UserRepository();
            var user = userRepository.Select(userId);

            permissionManager = new PermissionManager<Database.Models.User>();
            permissionManager.SetUser(this, new Mtf.Permissions.Models.User<Database.Models.User>
            {

            });
            //closeToolStripMenuItem.Enabled = permissionManager.CurrentUser.HasPermission(WindowManagementPermissions.Close);

            var displayRepository = new DisplayRepository();
            var sequenceDisplay = displayRepository.Select(displayId) ?? throw new InvalidOperationException($"Display does not found in repository with Id '{displayId}'.");
            var displayManager = new DisplayManager();
            var displays = displayManager.GetAll();

            display = displays.FirstOrDefault(d => d.GetId() == sequenceDisplay.Id);
            if (display == null)
            {
                throw new InvalidOperationException($"Display does not found with Id '{displayId}'.");
            }
        }

        private void ClientDataArrivedEventHandler(object sender, DataArrivedEventArgs e)
        {
            var messages = $"{client?.Encoding.GetString(e.Data)}";
            var allMessages = messages.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var message in allMessages)
            {
                var messageParts = message.Split('|');

                if (message.StartsWith(NetworkCommand.Close.ToString(), StringComparison.InvariantCulture))
                {
                    Close();
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Location = new Point(display.X, display.Y);
            Size = new Size(display.MaxWidth, display.MaxHeight);
        }

        private async void MainForm_Shown(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            var sequenceRepository = new SequenceRepository();
            var gridInSequeneRepository = new GridInSequenceRepository();
            var gridRepository = new GridRepository();
            var sequence = sequenceRepository.Select(sequenceId);
            var gridsInSequene = gridInSequeneRepository.SelectWhere(new { SequenceId = sequenceId });
            var grids = gridRepository.SelectAll()
                .SelectMany(grid => gridsInSequene
                .Where(gridInSequence => gridInSequence.GridId == grid.Id)
                .Select(gridInSequence => (grid, gridInSequence)))
                .OrderBy(gridInSequence => gridInSequence.gridInSequence.Number)
                .ToList();

            if (grids.Count > 1)
            {
                gridChanger = ShowGridsAsync(grids, cts.Token);
                await gridChanger.ConfigureAwait(false);
            }
            else if (grids.Count == 1)
            {
                var gridCameras = GetCameras(grids[0]);
                ShowGrid(grids, grids[0], gridCameras, cts.Token);
            }
            else
            {
                ErrorBox.Show(Lng.Elem("General error"), Lng.Elem("No grids in sequence."));
            }
        }

        private async Task OnExitAsync()
        {
            DisposeCameraWindows();

            if (cts != null && !cts.IsCancellationRequested)
            {
#if NET481
                client?.Send($"{NetworkCommand.UnregisterSequence}|{client.Socket.LocalEndPoint}|{sequenceId}|{Process.GetCurrentProcess().Id}", true);
                cts.Cancel();
                await Task.Delay(0).ConfigureAwait(false);
#else
                client?.Send($"{NetworkCommand.UnregisterSequence}|{client.Socket.LocalEndPoint}|{sequenceId}|{Environment.ProcessId}", true);
                await cts.CancelAsync().ConfigureAwait(false);
#endif
            }
        }

        private List<Form> ShowGridInWindow(List<(Grid grid, GridInSequence gridInSequence)> grids, (Grid grid, GridInSequence gridInSequence) gridInSequence, List<CameraInfo> gridCameras, CancellationToken cancellationToken)
        {
            var result = new List<Form>();
            foreach (var camera in gridCameras)
            {
                var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Window);

                Invoke((Action)(() =>
                {
                    if (camera is AxVideoPictureCameraInfo videoPictureCameraInfo)
                    {
                        var cameraForm = new AxVideoCamera(permissionManager, videoPictureCameraInfo.Camera, videoPictureCameraInfo.Server, rectangle, cancellationToken)
                        {
                            MdiParent = this
                        };
                        cameraForm.Show();
                        result.Add(cameraForm);
                    }
                    else if (camera is VideoCatureSourceCameraInfo videoCatureSourceCameraInfo)
                    {
                        var cameraForm = new VideoSourceCamera(permissionManager, videoCatureSourceCameraInfo, rectangle)
                        {
                            MdiParent = this
                        };
                        cameraForm.Show();
                        result.Add(cameraForm);
                    }
                }));
            }
            return result;
        }

        private List<Process> ShowGridOnScreen(List<(Grid grid, GridInSequence gridInSequence)> grids, (Grid grid, GridInSequence gridInSequence) gridInSequence)
        {
            var result = new List<Process>();
            var cameras = GetCameras(gridInSequence);

            foreach (var camera in cameras)
            {
                var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Screen);
                if (camera is AxVideoPictureCameraInfo videoPictureCameraInfo)
                {
                    result.Add(AppStarter.Start(LiveView.Core.Constants.CameraExe, $"{permissionManager.CurrentUser.Id} {videoPictureCameraInfo.Camera.Id} {rectangle.Left} {rectangle.Top} {rectangle.Width} {rectangle.Height}"));
                }
                else if (camera is VideoCatureSourceCameraInfo videoCatureSourceCameraInfo)
                {
                    result.Add(AppStarter.Start(LiveView.Core.Constants.CameraExe, $"{permissionManager.CurrentUser.Id} {videoCatureSourceCameraInfo.ServerIp} {videoCatureSourceCameraInfo.VideoSourceName} {rectangle.Left} {rectangle.Top} {rectangle.Width} {rectangle.Height}"));
                }
            }
            return result;
        }

        private static List<CameraInfo> GetCameras((Grid grid, GridInSequence gridInSequence) grid)
        {
            return gridCameras
                .Where(gc => gc.GridId == grid.grid.Id)
                .Select(gridCamera =>
                {
                    if (gridCamera.CameraId == null)
                    {
                        // Use VideoCatureSourceCameraInfo when CameraId is null
                        return new VideoCatureSourceCameraInfo
                        {
                            GridCamera = gridCamera,
                            ServerIp = gridCamera.ServerIp, // Assuming these fields are populated
                            VideoSourceName = gridCamera.VideoSourceName
                        } as CameraInfo;
                    }
                    else
                    {
                        // Use AxVideoPictureCameraInfo when CameraId is not null
                        var camera = allCameras.First(c => c.Id == gridCamera.CameraId);
                        return new AxVideoPictureCameraInfo
                        {
                            GridCamera = gridCamera,
                            Camera = camera,
                            Server = servers.First(s => s.Id == camera.ServerId)
                        };
                    }
                })
                .ToList();
        }

        private async Task ShowGridsAsync(List<(Grid grid, GridInSequence gridInSequence)> sequenceGrids, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                foreach (var grid in sequenceGrids)
                {
                    var gridCameras = GetCameras(grid);
                    ShowGrid(sequenceGrids, grid, gridCameras, token);
                    await WaitWithCancellationAsync(grid.gridInSequence.TimeToShow * 1000, token).ConfigureAwait(false);
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }
                    HideCameraWindows(grid.grid.Id);
                }
            }
        }

        private static async Task WaitWithCancellationAsync(int millisecondsDelay, CancellationToken token, int checkInterval = 100)
        {
#if NET481
            var start = Environment.TickCount;
            while (Environment.TickCount - start < millisecondsDelay)
#else
            var start = Environment.TickCount64;
            while (Environment.TickCount64 - start < millisecondsDelay)
#endif
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }
                await Task.Delay(checkInterval, CancellationToken.None).ConfigureAwait(false);
            }
        }

        private void HideCameraWindows(long gridId)
        {
            if (isMdi)
            {
                if (cameraForms.TryGetValue(gridId, out var value))
                {
                    FormUtils.HideMdiChildForms(this, value);
                }
            }
            else
            {
                if (processes.TryGetValue(gridId, out var value))
                {
                    ProcessUtils.ChangeExternalProcessesVisibility(value, CmdShow.Hide);
                }
            }
        }

        private void DisposeCameraWindows()
        {
            if (Interlocked.Exchange(ref disposed, 1) == 0)
            {
                if (isMdi)
                {
                    FormUtils.DisposeMdiChildForms(this, cameraForms.Values.SelectMany(forms => forms).ToList());
                }
                ProcessUtils.Kill(processes.Values.SelectMany(windows => windows).ToList());
            }
        }

        private void ShowGrid(List<(Grid grid, GridInSequence gridInSequence)> sequenceGrids, (Grid grid, GridInSequence gridInSequence) grid, List<CameraInfo> gridCameras, CancellationToken cancellationToken)
        {
            if (cts.Token.IsCancellationRequested)
            {
                return;
            }
            if (isMdi)
            {
                if (cameraForms.TryGetValue(grid.grid.Id, out var value))
                {
                    FormUtils.ShowMdiChildForms(this, value);
                }
                else
                {
                    cameraForms[grid.grid.Id] = ShowGridInWindow(sequenceGrids, grid, gridCameras, cancellationToken);
                }
            }
            else
            {
                if (processes.TryGetValue(grid.grid.Id, out var value))
                {
                    ProcessUtils.ChangeExternalProcessesVisibility(value, CmdShow.Show);
                }
                else
                {
                    processes[grid.grid.Id] = ShowGridOnScreen(sequenceGrids, grid);
                }
            }
        }

        private async void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await OnExitAsync().ConfigureAwait(false);
        }
    }
}

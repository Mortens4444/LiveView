using CameraForms.Dto;
using Database.Interfaces;
using Database.Models;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Display;
using LiveView.Core.Enums.Network;
using LiveView.Core.Enums.Window;
using LiveView.Core.Services;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Permissions.Services;
using Mtf.Windows.Forms.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sequence.Services
{
    public class GridSequenceManager : IDisposable
    {
        private readonly Dictionary<long, List<Form>> cameraForms = new Dictionary<long, List<Form>>();
        private readonly Dictionary<long, List<Process>> processes = new Dictionary<long, List<Process>>();

        private readonly ReadOnlyCollection<Database.Models.Server> servers;
        private readonly ReadOnlyCollection<Camera> allCameras;
        private readonly ReadOnlyCollection<GridCamera> gridCameras;
        private readonly Form parentForm;
        private readonly DisplayDto display;
        private readonly ILogger<GridSequenceManager> logger;
        private readonly PermissionManager<User> permissionManager;
        private readonly IAgentRepository agentRepository;
        private readonly IVideoSourceRepository videoSourceRepository;
        private readonly IGeneralOptionsRepository generalOptionsRepository;
        private readonly ISequenceRepository sequenceRepository;
        private readonly IGridInSequenceRepository gridInSequeneRepository;
        private readonly IGridRepository gridRepository;

        private readonly bool isMdi;
        private readonly Client client;
        private readonly CameraWindowBuilder cameraWindowBuilder;

        private List<(Grid grid, GridInSequence gridInSequence)> sequenceGrids;
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private int currentGridIndex;
        private int disposed;
        private bool showNextGrid, showPreviousGrid;

        public bool IsPaused { get; private set; }

        public bool Invalid { get; private set; }

        public GridSequenceManager(PermissionManager<User> permissionManager,
            ISequenceRepository sequenceRepository,
            IGridInSequenceRepository gridInSequenceRepository,
            IGridRepository gridRepository,
            IAgentRepository agentRepository,
            IVideoSourceRepository videoSourceRepository,
            IServerRepository serverRepository,
            ICameraRepository cameraRepository,
            ICameraRightRepository cameraRightRepository,
            IRightRepository rightRepository,
            IOperationRepository operationRepository,
            IUsersInGroupsRepository usersInGroupsRepository,
            ICameraFunctionRepository cameraFunctionRepository,
            IGridCameraRepository gridCameraRepository,
            IPersonalOptionsRepository personalOptionsRepository,
            IGeneralOptionsRepository generalOptionsRepository,
            ILogger<GridSequenceManager> logger,
            Client client, Form parentForm, DisplayDto display, bool isMdi)
        {
            this.client = client;
            this.parentForm = parentForm;
            this.display = display;
            this.isMdi = isMdi;
            //this.isMdi = false;

            this.permissionManager = permissionManager;
            this.agentRepository = agentRepository;
            this.videoSourceRepository = videoSourceRepository;
            this.sequenceRepository = sequenceRepository;
            this.gridInSequeneRepository = gridInSequenceRepository;
            this.gridRepository = gridRepository;
            this.generalOptionsRepository = generalOptionsRepository;
            this.logger = logger;

            servers = serverRepository?.SelectAll() ?? throw new ArgumentNullException(nameof(serverRepository));
            allCameras = cameraRepository?.SelectAll() ?? throw new ArgumentNullException(nameof(cameraRepository));
            gridCameras = gridCameraRepository?.SelectAll() ?? throw new ArgumentNullException(nameof(gridCameraRepository));

            cameraWindowBuilder = new CameraWindowBuilder(permissionManager, logger, agentRepository, cameraRepository, cameraRightRepository,
                rightRepository, operationRepository, cameraFunctionRepository, personalOptionsRepository,
                usersInGroupsRepository, videoSourceRepository, generalOptionsRepository);
        }

        public async Task StartSequenceAsync(long sequenceId)
        {
            var sequence = sequenceRepository.Select(sequenceId);
            if (sequence == null)
            {
                Invalid = true;
                return;
            }

            var gridsInSequence = gridInSequeneRepository.SelectWhere(new { SequenceId = sequenceId });
            var grids = gridRepository.SelectAll()
                .SelectMany(grid => gridsInSequence
                .Where(gridInSequence => gridInSequence.GridId == grid.Id)
                .Select(gridInSequence => (grid, gridInSequence)))
                .OrderBy(gridInSequence => gridInSequence.gridInSequence.Number)
                .ToList();

            if (grids.Count > 1)
            {
                sequenceGrids = grids;
                await Task.Run(() => ShowGridsAsync()).ConfigureAwait(true);
            }
            else if (grids.Count == 1)
            {
                var gridCameras = GetCameras(grids[0]);
                ShowGrid(grids[0], gridCameras);
            }
            else
            {
                ErrorBox.Show(Lng.Elem("General error"), Lng.Elem("No grids in sequence."));
            }
        }

        ~GridSequenceManager()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Interlocked.Exchange(ref disposed, 1) == 0 && disposing)
            {
                cancellationTokenSource?.Dispose();
                cancellationTokenSource = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void HideCameraWindows(long gridId)
        {
            if (isMdi)
            {
                if (cameraForms.TryGetValue(gridId, out var value))
                {
                    FormUtils.HideMdiChildForms(parentForm, value);
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

        private List<Form> ShowGridInWindow((Grid grid, GridInSequence gridInSequence) gridInSequence, List<CameraInfo> gridCameras)
        {
            var result = new List<Form>();
            foreach (var camera in gridCameras)
            {
                Task.Run(() =>
                {
                    parentForm.InvokeIfRequired(() => result.Add(cameraWindowBuilder.ShowVideoWindow(display, parentForm, camera, gridInSequence, cancellationTokenSource)));
                });
            }
            return result;
        }

        private List<Process> ShowGridOnScreen((Grid grid, GridInSequence gridInSequence) gridInSequence)
        {
            var result = new List<Process>();
            var cameras = GetCameras(gridInSequence);

            foreach (var camera in cameras)
            {
                Task.Run(() =>
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Screen);
                    var cameraId = camera is VideoCaptureSourceCameraInfo videoCaptureSourceCameraInfo ? $"{videoCaptureSourceCameraInfo.ServerIp} {videoCaptureSourceCameraInfo.VideoSourceName}" : camera.GridCamera.CameraId?.ToString(CultureInfo.InvariantCulture) ?? "0";
                    result.Add(AppStarter.Start(LiveView.Core.Constants.CameraAppExe, $"{permissionManager.CurrentUser.Tag.Id} {cameraId} {rectangle.Left} {rectangle.Top} {rectangle.Width} {rectangle.Height} {(int)camera.GridCamera.CameraMode}", logger));
                });
            }
            return result;
        }

        private async Task WaitWithCancellationAsync((Grid grid, GridInSequence gridInSequence) gridInfo, int checkInterval = 100)
        {

#if NET6_0_OR_GREATER
            long millisecondsDelay = gridInfo.gridInSequence.TimeToShow * 1000;
            var start = Environment.TickCount64;
            var elapsedMilliseconds = Environment.TickCount64 - start;
#else
            var millisecondsDelay = gridInfo.gridInSequence.TimeToShow * 1000;
            var start = (uint)Environment.TickCount;
            var elapsedMilliseconds = ((uint)Environment.TickCount - start);
#endif
            while ((elapsedMilliseconds < millisecondsDelay || IsPaused) && !(showPreviousGrid || showNextGrid))
            {
                var secondsLeft = Math.Max(0, (millisecondsDelay - elapsedMilliseconds) / 1000);
                var secondsLeftStr = IsPaused ? "Paused" : secondsLeft.ToString(CultureInfo.InvariantCulture);
                await (client?.SendAsync($"{NetworkCommand.SecondsLeftFromGrid}|{gridInfo.grid.Id}|{secondsLeftStr}", true)).ConfigureAwait(false);
                if (cancellationTokenSource.Token.IsCancellationRequested)
                {
                    break;
                }
                await Task.Delay(checkInterval, CancellationToken.None).ConfigureAwait(false);
#if NET6_0_OR_GREATER
                elapsedMilliseconds = Environment.TickCount64 - start;
#else
                elapsedMilliseconds = ((uint)Environment.TickCount - start);
#endif
            }
        }

        private void ShowGrid((Grid grid, GridInSequence gridInSequence) grid, List<CameraInfo> gridCameras)
        {
            if (cancellationTokenSource.Token.IsCancellationRequested)
            {
                return;
            }
            if (isMdi)
            {
                if (cameraForms.TryGetValue(grid.grid.Id, out var value))
                {
                    FormUtils.ShowMdiChildForms(parentForm, value);
                }
                else
                {
                    cameraForms[grid.grid.Id] = ShowGridInWindow(grid, gridCameras);
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
                    processes[grid.grid.Id] = ShowGridOnScreen(grid);
                }
            }
        }

        private List<CameraInfo> GetCameras((Grid grid, GridInSequence gridInSequence) grid)
        {
            return gridCameras
                .Where(gc => gc.GridId == grid.grid.Id)
                .Select(gridCamera =>
                {
                    var camera = allCameras.First(c => c.Id == gridCamera.CameraId);
                    var videoSourceInfo = videoSourceRepository.SelectVideoSourceInfo(camera.VideoSourceId);
                    return CameraInfoBuilder.GetCameraInfo(servers, gridCamera, camera, videoSourceInfo);
                })
                .ToList();
        }

        public void StopGridSequence()
        {
            cancellationTokenSource.Cancel();
        }

        public void ShowNextGrid()
        {
            showNextGrid = true;
        }

        public void ShowPreviousGrid()
        {
            showPreviousGrid = true;
        }

        public void ChangeIsPausedState()
        {
            IsPaused = !IsPaused;
        }

        private async Task ShowGridsAsync()
        {
            try
            {
                while (!cancellationTokenSource.Token.IsCancellationRequested)
                {
                    for (int i = currentGridIndex; i < sequenceGrids.Count; i++)
                    {
                        currentGridIndex = GetCurrentGridIndex(i);
                        var gridInfo = sequenceGrids[i];
                        var gridCameras = GetCameras(gridInfo);

                        ShowGrid(gridInfo, gridCameras);
                        parentForm.ResumeLayout();
                        await WaitWithCancellationAsync(gridInfo).ConfigureAwait(false);
                        parentForm.SuspendLayout();
                        HideCameraWindows(gridInfo.grid.Id);
                    }

                    currentGridIndex = 0;
                }
            }
            catch (TaskCanceledException)
            {
            }
        }

        private int GetCurrentGridIndex(int i)
        {
            if (showPreviousGrid)
            {
                showPreviousGrid = false;
                return (currentGridIndex - 1 + sequenceGrids.Count) % sequenceGrids.Count;
            }
            if (showNextGrid)
            {
                showNextGrid = false;
                return (currentGridIndex + 1) % sequenceGrids.Count;
            }
            return i;
        }

        public async Task DisposeCameraWindowsAsync()
        {
#if NET6_0_OR_GREATER
            await cancellationTokenSource.CancelAsync().ConfigureAwait(false);
#else
            cancellationTokenSource.Cancel();
#endif
            await Task.Delay(0).ConfigureAwait(false);

            if (isMdi)
            {
                FormUtils.DisposeMdiChildForms(parentForm, cameraForms.Values.SelectMany(forms => forms).ToList());
            }
            ProcessUtils.Kill(processes.Values.SelectMany(windows => windows).ToList());
        }
    }
}

using Mtf.LanguageService;
using Mtf.MessageBoxes;
using Mtf.Permissions.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System;
using Database.Models;
using Database.Repositories;
using LiveView.Core.Dto;
using System.Linq;
using LiveView.Core.Services;
using LiveView.Core.Enums.Window;
using Sequence.Dto;
using Sequence.Forms;
using LiveView.Core.Enums.Display;

namespace Sequence.Services
{
    public class GridSequenceManager : IDisposable
    {
        private static readonly ReadOnlyCollection<Server> servers = new ServerRepository().SelectAll();
        private static readonly ReadOnlyCollection<Camera> allCameras = new CameraRepository().SelectAll();
        private static readonly ReadOnlyCollection<GridCamera> gridCameras = new GridCameraRepository().SelectAll();

        private readonly Dictionary<long, List<Form>> cameraForms = new Dictionary<long, List<Form>>();
        private readonly Dictionary<long, List<Process>> processes = new Dictionary<long, List<Process>>();
        private readonly Form parentForm;
        private readonly DisplayDto display;
        private readonly PermissionManager<User> permissionManager;
        private readonly bool isMdi;
        private readonly List<(Grid grid, GridInSequence gridInSequence)> sequenceGrids;

        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private int currentGridIndex;
        private int disposed;
        private bool showNextGrid, showPreviousGrid;

        public bool IsPaused { get; set; }

        public GridSequenceManager(PermissionManager<User> permissionManager, Form parentForm, DisplayDto display, bool isMdi, long sequenceId)
        {
            this.permissionManager = permissionManager;
            this.parentForm = parentForm;
            this.display = display;
            this.isMdi = isMdi;

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
                sequenceGrids = grids;
                Task.Run(() => InitializeGridChangerAsync());
            }
            else if (grids.Count == 1)
            {
                var gridCameras = GetCameras(grids[0]);
                ShowGrid(grids, grids[0], gridCameras);
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

        protected virtual async void Dispose(bool disposing)
        {
            if (Interlocked.Exchange(ref disposed, 1) == 0 && disposing)
            {
                await DisposeCameraWindowsAsync().ConfigureAwait(false);
                
                cancellationTokenSource?.Dispose();
                cancellationTokenSource = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private async Task InitializeGridChangerAsync()
        {
            await ShowGridsAsync().ConfigureAwait(false);
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

        private List<Form> ShowGridInWindow(List<(Grid grid, GridInSequence gridInSequence)> grids, (Grid grid, GridInSequence gridInSequence) gridInSequence, List<CameraInfo> gridCameras)
        {
            var result = new List<Form>();
            foreach (var camera in gridCameras)
            {
                var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Window);

                parentForm.Invoke((Action)(() =>
                {
                    if (camera is AxVideoPictureCameraInfo videoPictureCameraInfo)
                    {
                        var cameraForm = new AxVideoCamera(permissionManager, videoPictureCameraInfo.Camera, videoPictureCameraInfo.Server, rectangle, cancellationTokenSource.Token)
                        {
                            MdiParent = parentForm
                        };
                        cameraForm.Show();
                        result.Add(cameraForm);
                    }
                    else if (camera is VideoCaptureSourceCameraInfo videoCaptureSourceCameraInfo)
                    {
                        var cameraForm = new VideoSourceCamera(permissionManager, videoCaptureSourceCameraInfo, rectangle)
                        {
                            MdiParent = parentForm
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
                else if (camera is VideoCaptureSourceCameraInfo videoCatureSourceCameraInfo)
                {
                    result.Add(AppStarter.Start(LiveView.Core.Constants.CameraExe, $"{permissionManager.CurrentUser.Id} {videoCatureSourceCameraInfo.ServerIp} {videoCatureSourceCameraInfo.VideoSourceName} {rectangle.Left} {rectangle.Top} {rectangle.Width} {rectangle.Height}"));
                }
            }
            return result;
        }

        private async Task WaitWithCancellationAsync(int millisecondsDelay, int checkInterval = 100)
        {
#if NET481
            var start = Environment.TickCount;
            while (Environment.TickCount - start < millisecondsDelay)
#else
            var start = Environment.TickCount64;
            while ((Environment.TickCount64 - start < millisecondsDelay || IsPaused) && !(showPreviousGrid || showNextGrid))
#endif
            {
                if (cancellationTokenSource.Token.IsCancellationRequested)
                {
                    break;
                }
                await Task.Delay(checkInterval, CancellationToken.None).ConfigureAwait(false);
            }
        }

        private void ShowGrid(List<(Grid grid, GridInSequence gridInSequence)> sequenceGrids, (Grid grid, GridInSequence gridInSequence) grid, List<CameraInfo> gridCameras)
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
                    cameraForms[grid.grid.Id] = ShowGridInWindow(sequenceGrids, grid, gridCameras);
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

        private static List<CameraInfo> GetCameras((Grid grid, GridInSequence gridInSequence) grid)
        {
            return gridCameras
                .Where(gc => gc.GridId == grid.grid.Id)
                .Select(gridCamera =>
                {
                    if (gridCamera.CameraId == null)
                    {
                        return new VideoCaptureSourceCameraInfo
                        {
                            GridCamera = gridCamera,
                            ServerIp = gridCamera.ServerIp,
                            VideoSourceName = gridCamera.VideoSourceName
                        } as CameraInfo;
                    }
                    else
                    {
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
                        var grid = sequenceGrids[i];
                        var gridCameras = GetCameras(grid);

                        ShowGrid(sequenceGrids, grid, gridCameras);
                        await WaitWithCancellationAsync(grid.gridInSequence.TimeToShow * 1000).ConfigureAwait(false);
                        HideCameraWindows(grid.grid.Id);
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
#if NET481
            cancellationTokenSource.Cancel();
#else
            await cancellationTokenSource.CancelAsync().ConfigureAwait(false);
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

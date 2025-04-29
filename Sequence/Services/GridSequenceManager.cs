using CameraForms.Dto;
using CameraForms.Forms;
using Database.Enums;
using Database.Interfaces;
using Database.Models;
using Database.Repositories;
using LiveView.Core.Dto;
using LiveView.Core.Enums.Display;
using LiveView.Core.Enums.Network;
using LiveView.Core.Enums.Window;
using LiveView.Core.Extensions;
using LiveView.Core.Services;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using Mtf.MessageBoxes;
using Mtf.Network;
using Mtf.Permissions.Services;
using Sequence.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        private readonly IPersonalOptionsRepository personalOptionsRepository;
        private readonly IAgentRepository agentRepository;
        private readonly IVideoSourceRepository videoSourceRepository;
        private readonly IServerRepository serverRepository;
        private readonly ICameraRepository cameraRepository;
        private readonly ICameraFunctionRepository cameraFunctionRepository;
        private readonly bool isMdi;
        private readonly Client client;
        
        private List<(Grid grid, GridInSequence gridInSequence)> sequenceGrids;
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private int currentGridIndex;
        private int disposed;
        private bool showNextGrid, showPreviousGrid;

        public bool IsPaused { get; private set; }

        public bool Invalid { get; private set; }

        public GridSequenceManager(PermissionManager<User> permissionManager,
            IAgentRepository agentRepository,
            IVideoSourceRepository videoSourceRepository,
            IServerRepository serverRepository,
            ICameraRepository cameraRepository,
            ICameraFunctionRepository cameraFunctionRepository,
            IGridCameraRepository gridCameraRepository,
            IPersonalOptionsRepository personalOptionsRepository,
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
            this.cameraRepository = cameraRepository;
            this.cameraFunctionRepository = cameraFunctionRepository;
            this.serverRepository = serverRepository;
            this.personalOptionsRepository = personalOptionsRepository;
            this.logger = logger;

            servers = serverRepository.SelectAll();
            allCameras = cameraRepository.SelectAll();
            gridCameras = gridCameraRepository.SelectAll();
            //StartSequence(sequenceId);
        }

        public void StartSequence(long sequenceId)
        {
            var sequenceRepository = new SequenceRepository();
            var gridInSequeneRepository = new GridInSequenceRepository();
            var gridRepository = new GridRepository();
            var sequence = sequenceRepository.Select(sequenceId);
            if (sequence == null)
            {
                Invalid = true;
            }
            else
            {
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
                    ShowGrid(grids[0], gridCameras);
                }
                else
                {
                    ErrorBox.Show(Lng.Elem("General error"), Lng.Elem("No grids in sequence."));
                }
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

        private List<Form> ShowGridInWindow((Grid grid, GridInSequence gridInSequence) gridInSequence, List<CameraInfo> gridCameras)
        {
            var result = new List<Form>();
            foreach (var camera in gridCameras)
            {
                Task.Run(() =>
                {
                    if (parentForm.InvokeRequired)
                    {
                        parentForm.Invoke((Action)(() => ShowVideoWindow(result, camera, gridInSequence)));
                    }
                    else
                    {
                        ShowVideoWindow(result, camera, gridInSequence);
                    }
                });
            }
            return result;
        }

        private void ShowVideoWindow(List<Form> result, CameraInfo camera, (Grid grid, GridInSequence gridInSequence) gridInSequence)
        {
            try
            {
                Form videoForm = null;

                if (camera is AxVideoPictureCameraInfo videoPictureCameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Window);
                    videoForm = new AxVideoCameraWindow(permissionManager, serverRepository, cameraRepository, personalOptionsRepository, videoPictureCameraInfo.Camera, videoPictureCameraInfo.Server, rectangle, camera.GridCamera, cancellationTokenSource.Token)
                    {
                        MdiParent = parentForm
                    };
                }
                else if (camera is VideoCaptureSourceCameraInfo videoCaptureSourceCameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Window);
                    videoForm = new VideoSourceCameraWindow(client, permissionManager, cameraFunctionRepository, personalOptionsRepository, videoCaptureSourceCameraInfo, rectangle, camera.GridCamera)
                    {
                        MdiParent = parentForm
                    };
                }
                else if (camera is FFMpegCameraInfo fFMpegCameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Window);
                    videoForm = new FFMpegCameraWindow(permissionManager, cameraFunctionRepository, personalOptionsRepository, fFMpegCameraInfo.Url, rectangle, camera.GridCamera)
                    {
                        MdiParent = parentForm
                    };
                }
                else if (camera is MortoGraphyCameraInfo mortoGraphyCameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Window);
                    videoForm = new MortoGraphyCameraWindow(permissionManager, agentRepository, cameraRepository, cameraFunctionRepository, personalOptionsRepository, videoSourceRepository, mortoGraphyCameraInfo.Url, rectangle, camera.GridCamera)
                    {
                        MdiParent = parentForm
                    };
                }
                else if (camera is VlcCameraInfo vlcCameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Window);
                    videoForm = new VlcCameraWindow(permissionManager, cameraFunctionRepository, personalOptionsRepository, vlcCameraInfo.Url, rectangle, camera.GridCamera)
                    {
                        MdiParent = parentForm
                    };
                }
                else if (camera is OpenCvSharpCameraInfo openCvSharpCameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Window);
                    videoForm = new OpenCvSharpCameraWindow(permissionManager, cameraFunctionRepository, personalOptionsRepository, openCvSharpCameraInfo.Url, rectangle, camera.GridCamera)
                    {
                        MdiParent = parentForm
                    };
                }
                else if (camera is OpenCvSharp4CameraInfo openCvSharp4CameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Window);
                    videoForm = new OpenCvSharp4CameraWindow(permissionManager, cameraFunctionRepository, personalOptionsRepository, openCvSharp4CameraInfo.Url, rectangle, camera.GridCamera)
                    {
                        MdiParent = parentForm
                    };
                }
                else if (camera is SunellCameraInfo sunellCameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Screen);
                    videoForm = new SunellCameraWindow(permissionManager, personalOptionsRepository, sunellCameraInfo, rectangle, camera.GridCamera)
                    {
                        TopMost = true
                    };
                }
                else if (camera is SunellLegacyCameraInfo sunellLegacyCameraInfo)
                {
                    var rectangle = GridCameraLayoutService.Get(display, gridInSequence.grid, camera.GridCamera, LocationType.Screen);
                    videoForm = new SunellLegacyCameraWindow(permissionManager, personalOptionsRepository, sunellLegacyCameraInfo, rectangle, camera.GridCamera)
                    {
                        TopMost = true
                    };
                }

                if (videoForm != null)
                {
                    videoForm.Show();
                    result.Add(videoForm);
                }
            }
            catch (Exception ex)
            {
#if NET6_0_OR_GREATER
                logger.LogError(ex, "Cannot open video window.");
#else
                logger.LogError($"Cannot open video window: {ex}");
#endif
            }
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
                    if (camera is AxVideoPictureCameraInfo videoPictureCameraInfo)
                    {
                        result.Add(AppStarter.Start(LiveView.Core.Constants.CameraAppExe, $"{permissionManager.CurrentUser.Tag.Id} {videoPictureCameraInfo.Camera.Id} {rectangle.Left} {rectangle.Top} {rectangle.Width} {rectangle.Height} {(int)camera.GridCamera.CameraMode}", logger));
                    }
                    else if (camera is VideoCaptureSourceCameraInfo videoCatureSourceCameraInfo)
                    {
                        result.Add(AppStarter.Start(LiveView.Core.Constants.CameraAppExe, $"{permissionManager.CurrentUser.Tag.Id} {videoCatureSourceCameraInfo.ServerIp} {videoCatureSourceCameraInfo.VideoSourceName} {rectangle.Left} {rectangle.Top} {rectangle.Width} {rectangle.Height} {(int)camera.GridCamera.CameraMode}", logger));
                    }
                    else if (camera is FFMpegCameraInfo fFMpegCameraInfo)
                    {
                        result.Add(AppStarter.Start(LiveView.Core.Constants.CameraAppExe, $"{permissionManager.CurrentUser.Tag.Id} {fFMpegCameraInfo.GridCamera.CameraId} {rectangle.Left} {rectangle.Top} {rectangle.Width} {rectangle.Height} {(int)camera.GridCamera.CameraMode}", logger));
                    }
                    else if (camera is MortoGraphyCameraInfo mortoGraphyCameraInfo)
                    {
                        result.Add(AppStarter.Start(LiveView.Core.Constants.CameraAppExe, $"{permissionManager.CurrentUser.Tag.Id} {mortoGraphyCameraInfo.GridCamera.CameraId} {rectangle.Left} {rectangle.Top} {rectangle.Width} {rectangle.Height} {(int)camera.GridCamera.CameraMode}", logger));
                    }
                    else if (camera is VlcCameraInfo vlcCameraInfo)
                    {
                        result.Add(AppStarter.Start(LiveView.Core.Constants.CameraAppExe, $"{permissionManager.CurrentUser.Tag.Id} {vlcCameraInfo.GridCamera.CameraId} {rectangle.Left} {rectangle.Top} {rectangle.Width} {rectangle.Height} {(int)camera.GridCamera.CameraMode}", logger));
                    }
                    else if (camera is OpenCvSharpCameraInfo openCvSharpCameraInfo)
                    {
                        result.Add(AppStarter.Start(LiveView.Core.Constants.CameraAppExe, $"{permissionManager.CurrentUser.Tag.Id} {openCvSharpCameraInfo.GridCamera.CameraId} {rectangle.Left} {rectangle.Top} {rectangle.Width} {rectangle.Height} {(int)camera.GridCamera.CameraMode}", logger));
                    }
                    else if (camera is OpenCvSharp4CameraInfo openCvSharp4CameraInfo)
                    {
                        result.Add(AppStarter.Start(LiveView.Core.Constants.CameraAppExe, $"{permissionManager.CurrentUser.Tag.Id} {openCvSharp4CameraInfo.GridCamera.CameraId} {rectangle.Left} {rectangle.Top} {rectangle.Width} {rectangle.Height} {(int)camera.GridCamera.CameraMode}", logger));
                    }
                    else if (camera is SunellCameraInfo sunellCameraInfo)
                    {
                        result.Add(AppStarter.Start(LiveView.Core.Constants.CameraAppExe, $"{permissionManager.CurrentUser.Tag.Id} {sunellCameraInfo.GridCamera.CameraId} {rectangle.Left} {rectangle.Top} {rectangle.Width} {rectangle.Height} {(int)camera.GridCamera.CameraMode}", logger));
                    }
                    else if (camera is SunellLegacyCameraInfo sunellLegacyCameraInfo)
                    {
                        result.Add(AppStarter.Start(LiveView.Core.Constants.CameraAppExe, $"{permissionManager.CurrentUser.Tag.Id} {sunellLegacyCameraInfo.GridCamera.CameraId} {rectangle.Left} {rectangle.Top} {rectangle.Width} {rectangle.Height} {(int)camera.GridCamera.CameraMode}", logger));
                    }
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
                var secondsLeftStr = IsPaused ? "Paused" : secondsLeft.ToString();
                client?.Send($"{NetworkCommand.SecondsLeftFromGrid}|{gridInfo.grid.Id}|{secondsLeftStr}", true);
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
                    switch (gridCamera.CameraMode)
                    {
                        case CameraMode.AxVideoPlayer:
                            return new AxVideoPictureCameraInfo
                            {
                                GridCamera = gridCamera,
                                Camera = camera,
                                Server = servers.First(s => s.Id == camera.ServerId)
                            };

                        case CameraMode.VideoSource:
                            if (camera.VideoSourceId.HasValue)
                            {
                                var videoSourceInfo = videoSourceRepository.SelectVideoSourceInfo(camera.VideoSourceId);
                                return new VideoCaptureSourceCameraInfo
                                {
                                    GridCamera = gridCamera,
                                    ServerIp = videoSourceInfo?.Item1,
                                    VideoSourceName = videoSourceInfo?.Item2
                                } as CameraInfo;
                            }
                            else
                            {
                                try
                                {
                                    var videoSourceInfo = camera.HttpStreamUrl?.GetVideoSourceInfo();
                                    return new VideoCaptureSourceCameraInfo
                                    {
                                        GridCamera = gridCamera,
                                        ServerIp = videoSourceInfo?.Item1,
                                        VideoSourceName = videoSourceInfo?.Item2
                                    };
                                }
                                catch (ArgumentException)
                                {
                                    return new VideoCaptureSourceCameraInfo
                                    {
                                        GridCamera = gridCamera
                                    };
                                }
                            }
                        case CameraMode.Vlc:
                                    return new VlcCameraInfo
                                    {
                                        GridCamera = gridCamera,
                                        Url = camera.HttpStreamUrl
                                    };

                                case CameraMode.MortoGraphy:
                                    return new MortoGraphyCameraInfo
                                    {
                                        GridCamera = gridCamera,
                                        Url = camera.HttpStreamUrl
                                    };

                                case CameraMode.FFMpeg:
                                    return new FFMpegCameraInfo
                                    {
                                        GridCamera = gridCamera,
                                        Url = camera.HttpStreamUrl
                                    };

                                case CameraMode.OpenCvSharp:
                                    return new OpenCvSharpCameraInfo
                                    {
                                        GridCamera = gridCamera,
                                        Url = camera.HttpStreamUrl
                                    };

                                case CameraMode.OpenCvSharp4:
                                    return new OpenCvSharp4CameraInfo
                                    {
                                        GridCamera = gridCamera,
                                        Url = camera.HttpStreamUrl
                                    };

                                case CameraMode.SunellLegacyCamera:
                                    return new SunellLegacyCameraInfo
                                    {
                                        GridCamera = gridCamera,
                                        CameraIp = camera.IpAddress,
                                        CameraPort = SunellLegacyCameraInfo.PagoPort,
                                        Username = camera.Username,
                                        Password = camera.Password,
                                        CameraId = camera.CameraId ?? 1,
                                        StreamId = camera.StreamId ?? 1
                                    };

                                case CameraMode.SunellCamera:
                                    return new SunellCameraInfo
                                    {
                                        GridCamera = gridCamera,
                                        CameraIp = camera.IpAddress,
                                        CameraPort = SunellLegacyCameraInfo.PagoPort,
                                        Username = camera.Username,
                                        Password = camera.Password,
                                        CameraId = camera.CameraId ?? 1,
                                        StreamId = camera.StreamId ?? 1
                                    };

                                default:
                                    throw new NotSupportedException($"CameraMode is not supported: {gridCamera.CameraMode}");
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

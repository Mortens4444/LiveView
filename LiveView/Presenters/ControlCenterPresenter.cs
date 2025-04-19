using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Core.CustomEventArgs;
using LiveView.Core.Enums.Network;
using LiveView.Core.Services;
using LiveView.Dto;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.Joystick;
using Mtf.LanguageService;
using Mtf.MessageBoxes;
using Mtf.Network.Extensions;
using Mtf.Permissions.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class ControlCenterPresenter : BaseDisplayPresenter
    {
        private const string StreamUrlFormatErrorMessage = "Stream URL should be in this format: '[IP address]|[Video source name]', example: '192.168.0.1|0'";
        private const string SelectDisplayFirst = "Select a display first.";

        private IControlCenterView view;
        private SequenceProcessInfo selectedSequenceProcess;

        private readonly IGridRepository gridRepository;
        private readonly IGridCameraRepository gridCameraRepository;
        private readonly IGridInSequenceRepository gridInSequenceRepository;
        private readonly ITemplateRepository templateRepository;
        private readonly ITemplateProcessRepository templateProcessRepository;
        private readonly ISequenceRepository sequenceRepository;
        private readonly ICameraRepository cameraRepository;
        private readonly PermissionManager<User> permissionManager;
        private readonly ILogger<ControlCenter> logger;
        private readonly List<Process> sequenceProcesses;
        public static Process CameraProcess { get; set; }

        public ControlCenterPresenter(ControlCenterPresenterDependencies dependencies)
            : base(dependencies)
        {
            gridRepository = dependencies.GridRepository;
            gridInSequenceRepository = dependencies.GridInSequenceRepository;
            gridCameraRepository = dependencies.GridCameraRepository;
            templateRepository = dependencies.TemplateRepository;
            templateProcessRepository = dependencies.TemplateProcessRepository;
            sequenceRepository = dependencies.SequenceRepository;
            cameraRepository = dependencies.CameraRepository;
            permissionManager = dependencies.PermissionManager;
            logger = dependencies.Logger;
            sequenceProcesses = new List<Process>();
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IControlCenterView;
        }

        public static void CalibrateJoystick()
        {
            JoystickHandler.CalibrateJoystick();
        }

        public void CloseFullScreenCameraApplication()
        {
            if (CameraProcess != null)
            {
                foreach (var cameraProcessInfo in Globals.CameraProcessInfo)
                {
                    if (CameraProcess == null || cameraProcessInfo.Value.ProcessId == CameraProcess.Id)
                    {
                        Globals.Server.SendMessageToClient(cameraProcessInfo.Key, NetworkCommand.Close.ToString());
                        Globals.CameraProcessInfo.TryRemove(cameraProcessInfo.Key, out _);
                        break;
                    }
                }
                ProcessUtils.Kill(CameraProcess);
                CameraProcess = null;
            }
            else
            {
                foreach (var remoteCameraProcess in Globals.CameraProcesses)
                {
                    MainPresenter.SentToClient(remoteCameraProcess.Key, NetworkCommand.Kill, Core.Constants.CameraAppExe, remoteCameraProcess.Value);
                    Globals.CameraProcesses.Remove(remoteCameraProcess.Key);
                }
            }
        }

        public void CloseSequenceApplications()
        {
            ProcessUtils.Kill(sequenceProcesses);
            sequenceProcesses.Clear();
            foreach (var agent in Globals.Agents)
            {
                MainPresenter.SentToClient(agent.Key, NetworkCommand.KillAll, Core.Constants.SequenceExe);
            }
        }

        public void AddSequence(Process sequenceProcess)
        {
            sequenceProcesses.Add(sequenceProcess);
        }

        public int RemoveSequence(int sequenceId)
        {
            return sequenceProcesses.RemoveAll(sp => sp.Id == sequenceId);
        }

        public void MoveToEast()
        {
            MainPresenter.SendMessageToFullScreenCamera(NetworkCommand.PanToEast.ToString());
        }

        public void MoveToNorth()
        {
            MainPresenter.SendMessageToFullScreenCamera(NetworkCommand.TiltToNorth.ToString());
        }

        public void MoveToNorthEast()
        {
            MainPresenter.SendMessageToFullScreenCamera(NetworkCommand.PanToEastAndTiltToNorth.ToString());
        }

        public void MoveToNorthWest()
        {
            MainPresenter.SendMessageToFullScreenCamera(NetworkCommand.PanToWestAndTiltToNorth.ToString());
        }

        public void MoveToPresetZero()
        {
            MainPresenter.SendMessageToFullScreenCamera(NetworkCommand.MoveToPresetZero.ToString());
        }

        public void MoveToSouth()
        {
            MainPresenter.SendMessageToFullScreenCamera(NetworkCommand.TiltToSouth.ToString());
        }

        public void MoveToSouthEast()
        {
            MainPresenter.SendMessageToFullScreenCamera(NetworkCommand.PanToEastAndTiltToSouth.ToString());
        }

        public void MoveToSouthWest()
        {
            MainPresenter.SendMessageToFullScreenCamera(NetworkCommand.PanToWestAndTiltToSouth.ToString());
        }

        public void MoveToWest()
        {
            MainPresenter.SendMessageToFullScreenCamera(NetworkCommand.PanToWest.ToString());
        }

        public void PlayOrPauseSequence()
        {
            var selectedDisplay = view.CachedDisplays.FirstOrDefault(d => d.Selected);
            MainPresenter.SendMessageToSequenceOnDisplay(selectedDisplay, $"{NetworkCommand.PlayOrPauseSequence}");
        }

        public void RearrangeGrids()
        {
            var selectedDisplay = view.CachedDisplays.FirstOrDefault(d => d.Selected);
            if (selectedDisplay != null)
            {
                MainPresenter.SendMessageToSequenceOnDisplay(selectedDisplay, $"{NetworkCommand.RearrangeGrids}");
            }
            else
            {
                ShowError(SelectDisplayFirst);
            }
        }

        public void ShowNextGrid()
        {
            var selectedDisplay = view.CachedDisplays.FirstOrDefault(d => d.Selected);
            if (selectedDisplay != null)
            {
                MainPresenter.SendMessageToSequenceOnDisplay(selectedDisplay, $"{NetworkCommand.ShowNextGrid}");
            }
            else
            {
                ShowError(SelectDisplayFirst);
            }
        }

        public void ShowPreviousGrid()
        {
            var selectedDisplay = view.CachedDisplays.FirstOrDefault(d => d.Selected);
            if (selectedDisplay != null)
            {
                MainPresenter.SendMessageToSequenceOnDisplay(selectedDisplay, $"{NetworkCommand.ShowPreviousGrid}");
            }
            else
            {
                ShowError(SelectDisplayFirst);
            }
        }

        public void StopMoving()
        {
            MainPresenter.SendMessageToFullScreenCamera(NetworkCommand.StopPanAndTilt.ToString());
        }

        public void StopZoom()
        {
            MainPresenter.SendMessageToFullScreenCamera(NetworkCommand.StopZoom.ToString());
        }

        public void ZoomIn()
        {
            MainPresenter.SendMessageToFullScreenCamera(NetworkCommand.ZoomIn.ToString());
        }

        public void ZoomOut()
        {
            MainPresenter.SendMessageToFullScreenCamera(NetworkCommand.ZoomOut.ToString());
        }

        public override void Load()
        {
            view.InitializeMouseUpdateTimer(view.PDisplayDevices);

            view.LvSequences.AddItems(sequenceRepository.SelectAll(), sequence => new ListViewItem(sequence.Name) { Tag = sequence });
            view.LvTemplates.AddItems(templateRepository.SelectAll(), template => new ListViewItem(template.TemplateName) { Tag = template });

            RefreshAgents();
        }

        public void RefreshAgents()
        {
            LoadItems();
            Globals.Agents.Changed += (object sender, DictionaryChangedEventArgs<string, Socket> e) =>
            {
                LoadItems();
            };
        }

        private void LoadItems()
        {
            if (!view.GetSelf().IsDisposed)
            {
                CameraListProvider.AddCameras(view.LvCameras, cameraRepository.SelectAll());
            }
        }

        public void SelectDisplay(Point location)
        {
            if (view.CachedDisplays == null)
            {
                return;
            }

            foreach (KeyValuePair<string, Rectangle> bounds in view.CachedBounds)
            {
                var display = view.CachedDisplays.FirstOrDefault(d => d.Id == bounds.Key);
                if (display != null)
                {
                    display.Selected = bounds.Value.Contains(location);
                }
            }
        }

        public bool StartCameraApp(Camera camera, CameraMode cameraMode)
        {
            if (camera == null)
            {
                return false;
            }

            if (cameraMode == CameraMode.VideoSource)
            {
                var videoCaptureSourceParts = camera.HttpStreamUrl.Split('|');
                if (videoCaptureSourceParts.Length != 2)
                {
                    ShowError(StreamUrlFormatErrorMessage);
                    return false;
                }
                else
                {
                    var serverIp = videoCaptureSourceParts[0];
                    if (IPAddress.TryParse(serverIp, out var ipAddress))
                    {
                        var videoSource = new VideoSourceDto
                        {
                            EndPoint = $"{videoCaptureSourceParts[0]}:0",
                            Name = videoCaptureSourceParts[1]
                        };
                        return StartCameraApp(videoSource);
                    }
                    else
                    {
                        ShowError(StreamUrlFormatErrorMessage);
                        return false;
                    }
                }
            }

            var parameters = new[]
            {
                permissionManager.CurrentUser.Tag.Id.ToString(),
                camera.Id.ToString(),
                ((int)cameraMode).ToString()
            };

            return StartCameraAppInternal(parameters);
        }

        public bool StartCameraApp(VideoSourceDto videoSource)
        {
            if (videoSource == null)
            {
                return false;
            }

            var parameters = new[]
            {
                permissionManager.CurrentUser.Tag.Id.ToString(),
                videoSource.Agent.ServerIp,
                videoSource.Name,
                ((int)CameraMode.VideoSource).ToString()
            };

            return StartCameraAppInternal(parameters);
        }

        public Process StartCamera(List<string> protectedParameters)
        {
            return AppStarter.Start(Core.Constants.CameraAppExe, String.Join(" ", protectedParameters), logger);
        }

        private bool StartCameraAppInternal(string[] parameters)
        {
            ProcessUtils.Kill(CameraProcess);
            CameraProcess = null;

            var protectedParameters = parameters.Select(p => p.Contains(' ') ? $"\"{p}\"" : p).ToList();

            if (generalOptionsRepository.Get<bool>(Setting.ShowOnSelectedDisplayWhenOpenedFromControlCenter))
            {
                var selectedDisplay = view.CachedDisplays?.FirstOrDefault(d => d.Selected);
                if (selectedDisplay != null)
                {
                    var displayId = selectedDisplay.Id.ToString().Remove(selectedDisplay.Host);
                    protectedParameters.Insert(protectedParameters.Count - 1, displayId);
                    StartCameraApp(protectedParameters);
                }
                else
                {
                    ShowError(SelectDisplayFirst);
                    return false;
                }
            }
            else
            {
                if (generalOptionsRepository.Get(Setting.ShowOnFullscreenDisplayWhenOpenedFromControlCenter, true))
                {
                    StartCameraApp(protectedParameters);
                }
            }
            return true;
        }

        private void StartCameraApp(List<string> protectedParameters)
        {
            var selectedDisplay = view.CachedDisplays.FirstOrDefault(d => d.Selected);
            if (selectedDisplay.AgentId == null)
            {
                CameraProcess = StartCamera(protectedParameters);
            }
            else
            {
                MainPresenter.SentToClient(selectedDisplay.AgentHostInfo, Core.Constants.CameraAppExe, protectedParameters.ToArray());
            }
        }

        public Process StartSequence(long sequenceId, string selectedDisplayId, bool isMdi)
        {
            CloseSequenceOnDisplay(selectedDisplayId);
            return AppStarter.Start(Core.Constants.SequenceExe, $"{permissionManager.CurrentUser.Tag.Id} {sequenceId} {selectedDisplayId} {isMdi}", logger);
        }

        public bool StartSequenceApp(Database.Models.Sequence sequence)
        {
            var selectedDisplay = view.CachedDisplays?.FirstOrDefault(d => d.Selected);
            if (selectedDisplay != null)
            {
                var isMdi = generalOptionsRepository.Get(Setting.StartSequenceAsAnMdiParent, true);
                if (selectedDisplay.AgentId == null)
                {
                    sequenceProcesses.Add(StartSequence(sequence.Id, selectedDisplay.Id, isMdi));
                }
                else
                {
                    MainPresenter.SentToClient(selectedDisplay.AgentHostInfo, Core.Constants.SequenceExe, permissionManager.CurrentUser.Tag.Id, sequence.Id, selectedDisplay.Id, isMdi);
                }
                return true;
            }
            else
            {
                ShowError(SelectDisplayFirst);
                return false;
            }
        }

        public void CloseSequenceOnDisplay(string displayId)
        {
            var keysToRemove = Globals.SequenceProcesses
                .Where(sp => sp.Value.DisplayId.ToString() == displayId)
                .Select(sp => sp.Key)
                .ToList();

            foreach (var key in keysToRemove)
            {
                if (Globals.SequenceProcesses.TryRemove(key, out var sequenceProcess))
                {
                    Globals.Server.SendMessageToClient(sequenceProcess.Socket, NetworkCommand.Close.ToString(), true);
                }
            }
        }


        public void StartTemplate(Template template)
        {
            foreach (var sequenceProcess in Globals.SequenceProcesses)
            {
                Globals.Server.SendMessageToClient(sequenceProcess.Value.Socket, NetworkCommand.Close.ToString(), true);
            }

            var processes = templateProcessRepository.SelectWhere(new { TemplateId = template.Id });
            foreach (var process in processes)
            {
                if (process.ProcessName == Core.Constants.CameraAppExe)
                {
                    CameraProcess = AppStarter.Start(process.ProcessName, process.ProcessParameters, logger);
                }
                else
                {
                    sequenceProcesses.Add(AppStarter.Start(process.ProcessName, process.ProcessParameters, logger));
                }
            }
        }

        public void ShowSequenceProcessData(SequenceProcessInfo sequenceProcess)
        {
            try
            {
                if (sequenceProcess == null)
                {
                    selectedSequenceProcess = null;
                    view.LblSequenceName.Text = String.Empty;
                    view.LblGridName.Text = String.Empty;
                    view.LblNumberOfCameras.Text = String.Empty;
                    view.LblSecondsLeft.Text = String.Empty;
                    view.LblGridNumber.Text = String.Empty;
                    return;
                }

                if (selectedSequenceProcess != sequenceProcess && sequenceProcess.SequenceId.HasValue)
                {
                    selectedSequenceProcess = sequenceProcess;
                    var sequence = sequenceRepository.Select(selectedSequenceProcess.SequenceId.Value);
                    if (sequence != null)
                    {
                        var gridsInSequence = gridInSequenceRepository.SelectWhere(new { SequenceId = sequence.Id });
                        if (gridsInSequence.Count == 0)
                        {
                            view.LblGridName.Text = $"{Lng.Elem("Grid name")}: N/A";
                            view.LblNumberOfCameras.Text = $"{Lng.Elem("Number of cameras")}: 0/0";
                            view.LblGridNumber.Text = "0/0";
                            view.LblSecondsLeft.Text = Lng.Elem("No grids in sequence.");
                        }
                        else if (gridsInSequence.Count == 1)
                        {
                            var grid = gridRepository.Select(gridsInSequence.Single().GridId);
                            var gridCameras = gridCameraRepository.SelectWhere(new { GridId = grid.Id });
                            view.LblGridName.Text = $"{Lng.Elem("Grid name")}: {grid.Name}";
                            view.LblNumberOfCameras.Text = $"{Lng.Elem("Number of cameras")}: {gridCameras.Count}/{gridCameras.Count}";
                            view.LblGridNumber.Text = "1/1";
                            view.LblSecondsLeft.Text = Lng.Elem("Continuous playing.");
                        }

                        view.LblSequenceName.Text = $"{Lng.Elem("Sequence name")}: {sequence.Name}";
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                DebugErrorBox.Show(ex);
            }
        }

        public void ShowGridInfo(long gridId, string secondsLeft)
        {
            if (selectedSequenceProcess == null || !selectedSequenceProcess.SequenceId.HasValue)
            {
                return;
            }

            var grid = gridRepository.Select(gridId);
            var sequence = sequenceRepository.Select(selectedSequenceProcess.SequenceId.Value);
            var gridsInSequence = gridInSequenceRepository.SelectWhere(new { SequenceId = sequence.Id });
            var gridCameras = gridCameraRepository.SelectWhere(new { GridId = grid.Id });
            var allCameraCount = sequenceRepository.SelectCameraCount(selectedSequenceProcess.SequenceId.Value);

            try
            {
                view.InvokeAction(() =>
                {
                    view.LblGridName.Text = $"{Lng.Elem("Grid name")}: {grid.Name}";
                    view.LblNumberOfCameras.Text = $"{Lng.Elem("Number of cameras")}: {gridCameras.Count}/{allCameraCount}";
                    view.LblGridNumber.Text = $"1/{gridsInSequence.Count}";
                    view.LblSecondsLeft.Text = secondsLeft == "Paused" ? Lng.Elem("Continuous playing.") : secondsLeft.ToString();
                });
            }
            catch (InvalidOperationException ex)
            {
                DebugErrorBox.Show(ex);
            }
        }
    }
}

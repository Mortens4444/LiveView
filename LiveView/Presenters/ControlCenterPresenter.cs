using Database.Enums;
using Database.Interfaces;
using Database.Models;
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
using Mtf.Permissions.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class ControlCenterPresenter : BaseDisplayPresenter
    {
        private IControlCenterView view;
        private readonly IDisplayRepository displayRepository;
        private readonly ITemplateRepository templateRepository;
        private readonly ITemplateProcessRepository templateProcessRepository;
        private readonly ISequenceRepository sequenceRepository;
        private readonly ICameraRepository cameraRepository;
        private readonly PermissionManager<User> permissionManager;
        private readonly ILogger<ControlCenter> logger;
        private readonly DisplayManager displayManager;
        private readonly List<Process> sequenceProcesses;
        public static Process CameraProcess { get; private set; }

        public ControlCenterPresenter(ControlCenterPresenterDependencies dependencies)
            : base(dependencies)
        {
            templateRepository = dependencies.TemplateRepository;
            templateProcessRepository = dependencies.TemplateProcessRepository;
            displayRepository = dependencies.DisplayRepository;
            sequenceRepository = dependencies.SequenceRepository;
            cameraRepository = dependencies.CameraRepository;
            displayManager = dependencies.DisplayManager;
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
            if (view.CbAgents.SelectedIndex == 0)
            {
                ProcessUtils.Kill(CameraProcess);
                CameraProcess = null;
            }
            else
            {
                if (MainPresenter.CameraProcesses.TryGetValue(view.CbAgents.Text, out var cameraProcessId))
                {
                    MainPresenter.SentToClient(view.CbAgents.Text, NetworkCommand.Kill, Core.Constants.CameraExe, cameraProcessId);
                    MainPresenter.CameraProcesses.Remove(view.CbAgents.Text);
                }
            }
        }

        public void CloseSequenceApplications()
        {
            if (view.CbAgents.SelectedIndex == 0)
            {
                ProcessUtils.Kill(sequenceProcesses);
                sequenceProcesses.Clear();
            }
            else
            {
                MainPresenter.SentToClient(view.CbAgents.Text, NetworkCommand.KillAll, Core.Constants.SequenceExe);
            }
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
                ShowError("Select a display first.");
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
                ShowError("Select a display first.");
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
                ShowError("Select a display first.");
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
            CameraListProvider.AddCameras(view.LvCameras, cameraRepository.SelectAll());
            
            view.LvTemplates.AddItems(templateRepository.SelectAll(), template => new ListViewItem(template.TemplateName) { Tag = template });

            RefreshAgents();
        }

        public void RefreshAgents()
        {
            if (!view.GetSelf().IsDisposed)
            {
                view.CbAgents.Invoke((Action)(() =>
                {
                    var selected = view.CbAgents.SelectedItem;
                    view.CbAgents.Items.Clear();
                    view.CbAgents.Items.Add(Lng.Elem("Localhost"));
                    view.CbAgents.Items.AddRange(MainPresenter.Agents.OrderBy(agent => agent).ToArray());
                    view.CbAgents.SelectedIndex = GetSelectedIndex(selected);
                }));
            }
        }

        private int GetSelectedIndex(object selected)
        {
            if (selected == null)
            {
                return 0;
            }
            var index = view.CbAgents.Items.IndexOf(selected);
            return index == -1 ? 0 : index;
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

        public void StartCameraApp(IHaveId<long> camera)
        {
            if (camera == null)
            {
                return;
            }

            var parameters = new[]
            {
                permissionManager.CurrentUser.Tag.Id.ToString(),
                camera.Id.ToString()
            };

            StartCameraAppInternal(parameters);
        }

        public void StartCameraApp(VideoSource videoSource)
        {
            if (videoSource == null)
            {
                return;
            }

            var parameters = new[]
            {
                permissionManager.CurrentUser.Tag.Id.ToString(),
                videoSource.ServerIp,
                videoSource.Name
            };

            StartCameraAppInternal(parameters);
        }

        private void StartCameraAppInternal(string[] parameters)
        {
            ProcessUtils.Kill(CameraProcess);

            var protectedParameters = parameters.Select(p => p.Contains(' ') ? $"\"{p}\"" : p);

            if (generalOptionsRepository.Get<bool>(Setting.ShowOnSelectedDisplayWhenOpenedFromControlCenter))
            {
                var selectedDisplay = view.CachedDisplays?.FirstOrDefault(d => d.Selected);
                if (selectedDisplay != null)
                {
                    var displayId = selectedDisplay.Id.ToString();
                    if (view.CbAgents.SelectedIndex == 0)
                    {
                        CameraProcess = AppStarter.Start(Core.Constants.CameraExe, $"{string.Join(" ", protectedParameters)} {displayId}");
                    }
                    else
                    {
                        MainPresenter.SentToClient(view.CbAgents.Text, Core.Constants.CameraExe, protectedParameters.Concat(new[] { displayId }).ToArray());
                    }
                }
                else
                {
                    ShowError("Select a display first.");
                }
            }
            else
            {
                if (generalOptionsRepository.Get(Setting.ShowOnFullscreenDisplayWhenOpenedFromControlCenter, true))
                {
                    if (view.CbAgents.SelectedIndex == 0)
                    {
                        CameraProcess = AppStarter.Start(Core.Constants.CameraExe, string.Join(" ", protectedParameters));
                    }
                    else
                    {
                        MainPresenter.SentToClient(view.CbAgents.Text, Core.Constants.CameraExe, protectedParameters.ToArray());
                    }
                }
            }
        }

        public void StartSequenceApp(Database.Models.Sequence sequence)
        {
            var selectedDisplay = view.CachedDisplays?.FirstOrDefault(d => d.Selected);
            if (selectedDisplay != null)
            {
                var isMdi = generalOptionsRepository.Get(Setting.StartSequenceAsAnMdiParent, true);
                if (view.CbAgents.SelectedIndex == 0)
                {
                    sequenceProcesses.Add(AppStarter.Start(Core.Constants.SequenceExe, $"{permissionManager.CurrentUser.Tag.Id} {sequence.Id} {selectedDisplay.Id} {isMdi}"));
                }
                else
                {
                    MainPresenter.SentToClient(view.CbAgents.Text, Core.Constants.SequenceExe, permissionManager.CurrentUser.Tag.Id, sequence.Id, selectedDisplay.Id, isMdi);
                }
            }
            else
            {
                ShowError("Select a display first.");
            }
        }

        public void StartTemplate(Template template)
        {
            foreach (var sequenceProcess in MainPresenter.SequenceProcesses)
            {
                MainPresenter.Server.SendMessageToClient(sequenceProcess.Value.Socket, NetworkCommand.Close.ToString(), true);
            }

            var processes = templateProcessRepository.SelectWhere(new { TemplateId = template.Id });
            foreach (var process in processes)
            {
                sequenceProcesses.Add(AppStarter.Start(process.ProcessName, process.ProcessParameters));
            }
        }
    }
}

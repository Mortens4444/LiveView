using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Core.Enums.Network;
using LiveView.Core.Services;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using Mtf.Joystick;
using Mtf.LanguageService;
using Mtf.Permissions.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private readonly PermissionManager<Database.Models.User> permissionManager;
        private readonly ILogger<ControlCenter> logger;
        private readonly DisplayManager displayManager;
        private readonly List<Process> sequenceProcesses;
        public static Process CameraProcess { get; private set; }

        public static BindingList<string> Agents { get; } = new BindingList<string>();

        public ControlCenterPresenter(ControlCenterPresenterDependencies controlCenterPresenterDependencies)
            : base(controlCenterPresenterDependencies)
        {
            templateRepository = controlCenterPresenterDependencies.TemplateRepository;
            templateProcessRepository = controlCenterPresenterDependencies.TemplateProcessRepository;
            displayRepository = controlCenterPresenterDependencies.DisplayRepository;
            sequenceRepository = controlCenterPresenterDependencies.SequenceRepository;
            cameraRepository = controlCenterPresenterDependencies.CameraRepository;
            displayManager = controlCenterPresenterDependencies.DisplayManager;
            permissionManager = controlCenterPresenterDependencies.PermissionManager;
            logger = controlCenterPresenterDependencies.Logger;
            sequenceProcesses = new List<Process>();
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IControlCenterView;
        }

        public void CalibrateJoystick()
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
            throw new NotImplementedException();
        }

        public void MoveToNorth()
        {
            throw new NotImplementedException();
        }

        public void MoveToNorthEast()
        {
            throw new NotImplementedException();
        }

        public void MoveToNorthWest()
        {
            throw new NotImplementedException();
        }

        public void MoveToPresetZero()
        {
            throw new NotImplementedException();
        }

        public void MoveToSouth()
        {
            throw new NotImplementedException();
        }

        public void MoveToSouthEast()
        {
            throw new NotImplementedException();
        }

        public void MoveToSouthWest()
        {
            throw new NotImplementedException();
        }

        public void MoveToWest()
        {
            throw new NotImplementedException();
        }

        public void PlayOrPauseSequence()
        {
            throw new NotImplementedException();
        }

        public void RearrangeGrids()
        {
            throw new NotImplementedException();
        }

        public void ShowNextGrid()
        {
            throw new NotImplementedException();
        }

        public void ShowPreviousGrid()
        {
            throw new NotImplementedException();
        }

        public void StopMoving()
        {
            throw new NotImplementedException();
        }

        public void StopZoom()
        {
            throw new NotImplementedException();
        }

        public void ZoomIn()
        {
            throw new NotImplementedException();
        }

        public void ZoomOut()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            view.InitializeMouseUpdateTimer(view.PDisplayDevices);

            view.LvSequences.AddItems(sequenceRepository.SelectAll(), sequence => new ListViewItem(sequence.Name) { Tag = sequence });
            view.LvCameras.AddItems(cameraRepository.SelectAll(), camera => new ListViewItem(camera.CameraName) { Tag = camera });
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
                    view.CbAgents.Items.AddRange(Agents.OrderBy(agent => agent).ToArray());
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
            ProcessUtils.Kill(CameraProcess);

            if (generalOptionsRepository.Get<bool>(Setting.ShowOnSelectedDisplayWhenOpenedFromControlCenter))
            {
                var selectedDisplay = view.CachedDisplays?.FirstOrDefault(d => d.Selected);
                if (selectedDisplay != null)
                {
                    if (view.CbAgents.SelectedIndex == 0)
                    {
                        CameraProcess = AppStarter.Start(Core.Constants.CameraExe, $"{permissionManager.CurrentUser.Id} {camera.Id} {selectedDisplay.Id}");
                    }
                    else
                    {
                        MainPresenter.SentToClient(view.CbAgents.Text, Core.Constants.CameraExe, permissionManager.CurrentUser.Id, camera.Id, selectedDisplay.Id);
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
                        CameraProcess = AppStarter.Start(Core.Constants.CameraExe, $"{permissionManager.CurrentUser.Id} {camera.Id}");
                    }
                    else
                    {
                        MainPresenter.SentToClient(view.CbAgents.Text, Core.Constants.CameraExe, permissionManager.CurrentUser.Id, camera.Id);
                    }
                }
            }
        }

        public void StartSequenceApp(Database.Models.Sequence sequence)
        {
            var selectedDisplay = view.CachedDisplays.FirstOrDefault(d => d.Selected);
            if (selectedDisplay != null)
            {
                var isMdi = generalOptionsRepository.Get(Setting.StartSequenceAsAnMdiParent, true);
                if (view.CbAgents.SelectedIndex == 0)
                {
                    sequenceProcesses.Add(AppStarter.Start(Core.Constants.SequenceExe, $"{permissionManager.CurrentUser.Id} {sequence.Id} {selectedDisplay.Id} {isMdi}"));
                }
                else
                {
                    MainPresenter.SentToClient(view.CbAgents.Text, Core.Constants.SequenceExe, permissionManager.CurrentUser.Id, sequence.Id, selectedDisplay.Id, isMdi);
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
                MainPresenter.Server.SendMessageToClient(sequenceProcess.Value.socket, NetworkCommand.Close.ToString());
            }

            var processes = templateProcessRepository.SelectWhere(new { TemplateId = template.Id });
            foreach (var process in processes)
            {
                AppStarter.Start(process.ProcessName, process.ProcessParameters);
            }
        }
    }
}

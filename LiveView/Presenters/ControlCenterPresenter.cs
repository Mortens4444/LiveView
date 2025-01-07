using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Core.Services;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using Mtf.Permissions.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private IControlCenterView view;
        private readonly IDisplayRepository displayRepository;
        private readonly ITemplateRepository templateRepository;
        private readonly ISequenceRepository sequenceRepository;
        private readonly ICameraRepository cameraRepository;
        private readonly PermissionManager permissionManager;
        private readonly ILogger<ControlCenter> logger;
        private readonly DisplayManager displayManager;
        private Process cameraProcess;

        public static BindingList<string> Agents { get; } = new BindingList<string>();

        public ControlCenterPresenter(ControlCenterPresenterDependencies controlCenterPresenterDependencies)
            : base(controlCenterPresenterDependencies)
        {
            templateRepository = controlCenterPresenterDependencies.TemplateRepository;
            displayRepository = controlCenterPresenterDependencies.DisplayRepository;
            sequenceRepository = controlCenterPresenterDependencies.SequenceRepository;
            cameraRepository = controlCenterPresenterDependencies.CameraRepository;
            displayManager = controlCenterPresenterDependencies.DisplayManager;
            permissionManager = controlCenterPresenterDependencies.PermissionManager;
            logger = controlCenterPresenterDependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IControlCenterView;
        }

        public void CalibrateJoystick()
        {
            throw new NotImplementedException();
        }

        public void CloseFullScreenCameraApplication()
        {
            throw new NotImplementedException();
        }

        public void CloseSequenceApplication()
        {
            throw new NotImplementedException();
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

            var sequences = sequenceRepository.SelectAll();
            view.LvSequences.Items.Clear();
            foreach (var sequence in sequences)
            {
                view.AddToItems(view.LvSequences, new ListViewItem(sequence.Name) { Tag = sequence });
            }

            var cameras = cameraRepository.SelectAll();
            view.LvCameras.Items.Clear();
            foreach (var camera in cameras)
            {
                view.AddToItems(view.LvCameras, new ListViewItem(camera.CameraName) { Tag = camera });
            }

            var templates = templateRepository.SelectAll();
            view.LvTemplates.Items.Clear();
            foreach (var template in templates)
            {
                view.AddToItems(view.LvTemplates, new ListViewItem(template.TemplateName) { Tag = template });
            }

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
            foreach (KeyValuePair<string, Rectangle> bounds in view.CachedBounds)
            {
                var display = view.CachedDisplays.FirstOrDefault(d => d.Id == bounds.Key);
                if (display != null)
                {
                    display.Selected = bounds.Value.Contains(location);
                }
            }
        }

        public void StartCameraApp(Camera camera)
        {
            if (view.CbAgents.SelectedIndex == 0)
            {
                if (cameraProcess != null)
                {
                    cameraProcess.Kill();
                }

                if (generalOptionsRepository.Get<bool>(Setting.ShowOnSelectedDisplayWhenOpenedFromControlCenter))
                {
                    var selectedDisplay = view.CachedDisplays.FirstOrDefault(d => d.Selected);
                    if (selectedDisplay != null)
                    {
                        cameraProcess = AppStarter.Start("Camera.exe", $"{permissionManager.CurrentUser.Id} {camera.Id} {selectedDisplay.Id}");
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
                        cameraProcess = AppStarter.Start("Camera.exe", $"{permissionManager.CurrentUser.Id} {camera.Id}");
                    }
                }
            }
            else
            {
                if (generalOptionsRepository.Get<bool>(Setting.ShowOnSelectedDisplayWhenOpenedFromControlCenter))
                {
                    var selectedDisplay = view.CachedDisplays.FirstOrDefault(d => d.Selected);
                    if (selectedDisplay != null)
                    {

                        SentToClient(view.CbAgents.Text, $"Camera.exe|{permissionManager.CurrentUser.Id} {camera.Id} {selectedDisplay.Id}");
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
                        SentToClient(view.CbAgents.Text, $"Camera.exe|{permissionManager.CurrentUser.Id} {camera.Id}");
                    }
                }
            }
        }

        private static void SentToClient(string clientAddress, string message)
        {
            using (var clientSocket = CreateSocket(clientAddress))
            {
                MainPresenter.Server.SendMessageToClient(clientSocket, message);
            }
        }

        private static Socket CreateSocket(string clientAddress)
        {
            var parts = clientAddress.Split(':');
            string ipString = parts[0];
            int port = int.Parse(parts[1]);

            var ipAddress = IPAddress.Parse(ipString);
            var endPoint = new IPEndPoint(ipAddress, port);
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(endPoint);
            return socket;
        }

        public void StartSequenceApp(Database.Models.Sequence sequence)
        {
            var selectedDisplay = view.CachedDisplays.FirstOrDefault(d => d.Selected);
            if (selectedDisplay != null)
            {
                AppStarter.Start("Sequence.exe", $"{permissionManager.CurrentUser.Id} {sequence.Id} {selectedDisplay.Id} True");
            }
            else
            {
                ShowError("Select a display first.");
            }
        }
    }
}

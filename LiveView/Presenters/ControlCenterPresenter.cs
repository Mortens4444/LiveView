using Database.Interfaces;
using Database.Models;
using LiveView.Core.Services;
using LiveView.Dto;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.MessageBoxes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Reflection;
using System.Threading;
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
        private readonly ILogger<ControlCenter> logger;
        private readonly DisplayManager displayManager;

        public ControlCenterPresenter(ControlCenterPresenterDependencies controlCenterPresenterDependencies)
            : base(controlCenterPresenterDependencies)
        {
            templateRepository = controlCenterPresenterDependencies.TemplateRepository;
            displayRepository = controlCenterPresenterDependencies.DisplayRepository;
            sequenceRepository = controlCenterPresenterDependencies.SequenceRepository;
            cameraRepository = controlCenterPresenterDependencies.CameraRepository;
            displayManager = controlCenterPresenterDependencies.DisplayManager;
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

        public void CloseSequenceApplications()
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
        }

        //public ReadOnlyCollection<Display> GetDisplays()
        //{
        //    var displays = displayRepository.GetAll();
        //    if (displays.Count == 0)
        //    {
        //        var displayDtos = displayManager.GetAll();
        //        foreach (var displayDto in displayDtos)
        //        {
        //            displayRepository.Insert(displayDto.ToDisplay());
        //        }
        //        displays = displayRepository.GetAll();
        //    }
        //    return displays;
        //}
    }
}

using Database.Interfaces;
using Database.Models;
using LiveView.Dto;
using LiveView.Forms;
using LiveView.Interfaces;
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
    public class ControlCenterPresenter : BasePresenter
    {
        private readonly IControlCenterView controlCenterView;
        private readonly IDisplayRepository<Display> displayRepository;
        private readonly ITemplateRepository<Template> templateRepository;
        private readonly ICameraRepository<Camera> cameraRepository;
        private readonly ILogger<ControlCenter> logger;
        private readonly DisplayManager displayManager;

        public ControlCenterPresenter(IControlCenterView controlCenterView, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, FormFactory formFactory, ITemplateRepository<Template> templateRepository, IDisplayRepository<Display> displayRepository,
            ICameraRepository<Camera> cameraRepository, DisplayManager displayManager, ILogger<ControlCenter> logger)
            : base(controlCenterView, generalOptionsRepository, formFactory)
        {
            this.controlCenterView = controlCenterView;
            this.templateRepository = templateRepository;
            this.displayRepository = displayRepository;
            this.cameraRepository = cameraRepository;
            this.displayManager = displayManager;
            this.logger = logger;
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

        public void IdentifyDisplays()
        {
            var displays = displayManager.GetAll();
            foreach(var display in displays)
            {
                ShowForm<DisplayDeviceIdentifier>(display);
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
            controlCenterView.InitializeMouseUpdateTimer();
        }

        public List<DisplayDto> GetDisplays()
        {
            return displayManager.GetAll();
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

        public List<SequenceEnvironment> GetSequenceEnvironments()
        {
            throw new NotImplementedException();
            //return Display.GetSequenceEnvironments(displayId);
        }

        public Point GetMouseLocation(Size drawnSize)
        {
            var (screenBounds, deltaPoint) = displayManager.GetScreensBounds();
            var diminutive = displayManager.GetScaleFactor(screenBounds, drawnSize);
            var point = new POINT();
            WinAPI.GetCursorPos(out point);
            var mouseLeft = (int)(screenBounds.Left + point.X / diminutive + DisplayManager.FrameWidth / 2 + 1);
            var mouseTop = (int)(screenBounds.Top + point.Y / diminutive + DisplayManager.FrameWidth / 2 + 1);
            return new Point(mouseLeft + deltaPoint.X, mouseTop + deltaPoint.Y);
        }

        public Dictionary<int, Rectangle> GetScaledDisplayBounds(List<DisplayDto> displays, Size size)
        {
            return displayManager.GetScaledDisplayBounds(displays, size);
        }
    }
}

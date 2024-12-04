using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class ControlCenterPresenter : BasePresenter
    {
        private readonly IControlCenterView controlCenterView;
        private readonly IDisplayRepository<Display> displayRepository;
        private readonly ITemplateRepository<Template> templateRepository;
        private readonly ICameraRepository<Camera> cameraRepository;
        private readonly ILogger<ControlCenter> logger;

        public ControlCenterPresenter(IControlCenterView controlCenterView, ITemplateRepository<Template> templateRepository, IDisplayRepository<Display> displayRepository, ICameraRepository<Camera> cameraRepository, ILogger<ControlCenter> logger)
            : base(controlCenterView)
        {
            this.controlCenterView = controlCenterView;
            this.templateRepository = templateRepository;
            this.displayRepository = displayRepository;
            this.cameraRepository = cameraRepository;
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
            throw new NotImplementedException();
        }
    }
}

using Database.Interfaces;
using Database.Models;
using LiveView.Dto;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Services;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace LiveView.Presenters
{
    public class BaseDisplayPresenter : BasePresenter, IDisplayPresenter
    {
        private readonly DisplayManager displayManager;

        public BaseDisplayPresenter(IView view, DisplayManager displayManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, FormFactory formFactory)
            : base(view, generalOptionsRepository, formFactory)
        {
            this.displayManager = displayManager;
        }

        public void IdentifyDisplays()
        {
            var displays = displayManager.GetAll();
            foreach (var display in displays)
            {
                ShowForm<DisplayDeviceIdentifier>(display);
            }
        }

        public List<DisplayDto> GetDisplays()
        {
            return displayManager.GetAll();
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

        public List<SequenceEnvironment> GetSequenceEnvironments()
        {
            throw new NotImplementedException();
            //return Display.GetSequenceEnvironments(displayId);
        }
    }
}

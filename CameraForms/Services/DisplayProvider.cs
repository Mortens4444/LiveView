using Database.Repositories;
using LiveView.Core.Dto;
using LiveView.Core.Services;
using System;
using System.Linq;

namespace CameraForms.Services
{
    public static class DisplayProvider
    {
        public static DisplayDto Get(long? displayId)
        {
            var displayRepository = new DisplayRepository();
            var fullScreenDisplay = displayId.HasValue ? displayRepository.Select(displayId.Value) : displayRepository.GetFullscreenDisplay();
            if (fullScreenDisplay == null)
            {
                throw new InvalidOperationException("Choose a fullscreen display first.");
            }
            var displayManager = new DisplayManager();
            var displays = displayManager.GetAll();

            var display = displays.FirstOrDefault(d => d.GetId() == fullScreenDisplay.Id);
            if (display == null)
            {
                throw new InvalidOperationException("Choose another fullscreen display.");
            }
            return display;
        }
    }
}

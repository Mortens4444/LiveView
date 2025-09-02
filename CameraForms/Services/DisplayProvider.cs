using CameraForms.Interfaces;
using Database.Interfaces;
using LiveView.Core.Dto;
using LiveView.Core.Interfaces;
using System;
using System.Linq;

namespace CameraForms.Services
{
    public class DisplayProvider : IDisplayProvider
    {
        private readonly IDisplayRepository displayRepository;
        private readonly IDisplayManager displayManager;

        public DisplayProvider(IDisplayRepository displayRepository, IDisplayManager displayManager)
        {
            this.displayRepository = displayRepository;
            this.displayManager = displayManager;
        }

        public DisplayDto GetDisplay(int? displayId)
        {
            var fullScreenDisplay = (displayId.HasValue ? displayRepository.Select(displayId.Value) : displayRepository.GetFullscreenDisplay()) ?? throw new InvalidOperationException("Choose a fullscreen display first.");
            var displays = displayManager.GetAll();
            var display = displays.FirstOrDefault(d => d.GetId() == fullScreenDisplay.Id);
            return display ?? throw new InvalidOperationException("Choose another fullscreen display.");
        }
    }
}

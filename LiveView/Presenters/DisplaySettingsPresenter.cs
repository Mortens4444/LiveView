using Database.Interfaces;
using Database.Models;
using LiveView.Core.Services;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;

namespace LiveView.Presenters
{
    public class DisplaySettingsPresenter : BaseDisplayPresenter
    {
        private IDisplaySettingsView view;
        private readonly IDisplayRepository displayRepository;
        private readonly ILogger<DisplaySettings> logger;
        private readonly ReadOnlyCollection<Display> displays;

        public DisplaySettingsPresenter(IGeneralOptionsRepository generalOptionsRepository,
            IDisplayRepository displayRepository, DisplayManager displayManager, ILogger<DisplaySettings> logger, FormFactory formFactory)
            : base(displayManager, generalOptionsRepository, formFactory)
        {
            this.displayRepository = displayRepository;
            this.logger = logger;
            displays = displayRepository.SelectAll();
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IDisplaySettingsView;
        }

        public void ResetDisplays()
        {
            foreach (var display in view.CachedDisplays)
            {
                display.Fullscreen = false;
                display.CanShowFullscreen = true;
                display.CanShowSequence = true;
                display.SziltechId = $"M-{display.Id}";
            }
        }

        public void SaveDisplaySettings()
        {
            foreach (var display in view.CachedDisplays)
            {
                displayRepository.Update(display.ToModel());
            }
            logger.LogInfo("Display settings saved.");
        }

        public override void Load()
        {
            foreach (var cachedDisplay in view.CachedDisplays)
            {
                var display = displays.FirstOrDefault(d => d.Id == cachedDisplay.Id);
                if (display != null)
                {
                    cachedDisplay.Fullscreen = display.Fullscreen;
                    cachedDisplay.CanShowFullscreen = display.CanShowFullscreen;
                    cachedDisplay.CanShowSequence = display.CanShowSequence;
                    cachedDisplay.SziltechId = display.SziltechId;
                }
            }
        }

        public void ChangeDisplayFunction(Point location)
        {
            foreach (KeyValuePair<int, Rectangle> bounds in view.CachedBounds)
            {
                if (bounds.Value.Contains(location))
                {
                    var display = view.CachedDisplays.FirstOrDefault(d => d.Id == bounds.Key);
                    if (display != null)
                    {
                        if (display.CanShowSequence && display.CanShowFullscreen)
                        {
                            display.CanShowFullscreen = false;
                        }
                        else if (display.CanShowSequence)
                        {
                            display.CanShowSequence = false;
                            display.CanShowFullscreen = true;
                        }
                        else if (display.CanShowFullscreen)
                        {
                            display.CanShowFullscreen = false;
                        }
                        else
                        {
                            display.CanShowFullscreen = true;
                            display.CanShowSequence = true;
                        }
                    }
                }
            }
            view.Invalidate(view.FunctionChooser);
        }

        public void SelectFullscreenDisplay(Point location)
        {
            foreach (KeyValuePair<int, Rectangle> bounds in view.CachedBounds)
            {
                var display = view.CachedDisplays.FirstOrDefault(d => d.Id == bounds.Key);
                if (display != null)
                {
                    display.Fullscreen = bounds.Value.Contains(location);
                }
            }
            view.Invalidate(view.FullScreenDisplay);
        }
    }
}

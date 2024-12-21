using Database.Interfaces;
using Database.Models;
using LiveView.Dto;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class DisplaySettingsPresenter : BaseDisplayPresenter
    {
        private readonly IDisplaySettingsView view;
        private readonly IDisplayRepository<Display> displayRepository;
        private readonly ILogger<DisplaySettings> logger;
        private readonly DisplayManager displayManager;

        public DisplaySettingsPresenter(IDisplaySettingsView view, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository,
            IDisplayRepository<Display> displayRepository, DisplayManager displayManager, ILogger<DisplaySettings> logger, FormFactory formFactory)
            : base(view, displayManager, generalOptionsRepository, formFactory)
        {
            this.view = view;
            this.displayManager = displayManager;
            this.displayRepository = displayRepository;
            this.logger = logger;
        }

        public void ResetDisplays()
        {
            throw new NotImplementedException();
        }

        public void SaveDisplaySettings()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }

        public void ChangeDisplay(bool fullscreen, int ex, int ey)
        {
            //DisplayDto fs = null;
            var panel = fullscreen ? view.FullScreenDisplay : view.FunctionChooser;

            var displays = GetDisplays();
            var bounds = GetScaledDisplayBounds(displays, panel.Size);
            
            foreach (var display in displays)
            {
                //if (display.Fullscreen)
                //{
                //    fs = display;
                //}

                var r2 = bounds[display.Id];
                if (r2.Contains(ex, ey))
                {
                    if (fullscreen)
                    {
                        MainForm.FullScreenDisplay = display;
                    }
                    else
                    {
                        AdjustDisplayCapabilities(display);
                        UpdateFunctionChooserControls(display);
                    }
                }
            }

            view.Invalidate(panel);
        }

        private void AdjustDisplayCapabilities(DisplayDto display)
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
                display.CanShowSequence = true;
                display.CanShowFullscreen = true;
            }
        }

        private void UpdateFunctionChooserControls(DisplayDto display)
        {
            foreach (Control control in view.FunctionChooser.Controls)
            {
                if (control is CheckBox checkBox && control.Tag is Display tagDisplay && tagDisplay.Id == display.Id)
                {
                    checkBox.Checked = checkBox.Name.StartsWith("cb_seq") ? display.CanShowSequence : display.CanShowFullscreen;
                }
            }
        }
    }
}

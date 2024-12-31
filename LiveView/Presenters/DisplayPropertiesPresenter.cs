using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace LiveView.Presenters
{
    public class DisplayPropertiesPresenter : BasePresenter
    {
        private IDisplayPropertiesView view;
        private readonly IDisplayRepository displayRepository;
        private readonly ILogger<DisplayProperties> logger;

        public DisplayPropertiesPresenter(DisplayPropertiesPresenterDependencies displayPropertiesPresenterDependencies)
            : base(displayPropertiesPresenterDependencies)
        {
            displayRepository = displayPropertiesPresenterDependencies.DisplayRepository;
            logger = displayPropertiesPresenterDependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IDisplayPropertiesView;
        }

        public override void Load()
        {
            var display = displayRepository.SelectWhere(new { PnPDeviceId = view.Display.PnPDeviceId }).FirstOrDefault();

            view.TbDisplayDeviceSziltechID.Text = view.Display.SziltechId;
            view.TbDisplayDeviceIdentifier.Text = view.Display.DeviceId;
            view.TbDisplayName.Text = view.Display.DeviceName;
            view.TbAdapterName.Text = view.Display.AdapterName;
            view.TbTopLeftCoordinate.Text = $"{view.Display.X}, {view.Display.Y}";
            view.TbResolution.Text = $"{view.Display.MaxWidth}, {view.Display.MaxHeight}"; ;
            view.TbWorkPlaceArea.Text = $"{view.Display.Width}, {view.Display.Height}";
            view.ChkShowSequences.Checked = display.CanShowSequence;
            view.ChkRemovable.Checked = view.Display.Removable;
            view.ChkAttachedToDesktop.Checked = view.Display.AttachedToDesktop;
            view.ChkDefaultFullScreenDevice.Checked = display.Fullscreen;
        }
    }
}

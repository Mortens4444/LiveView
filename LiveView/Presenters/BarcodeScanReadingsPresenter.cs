using Database.Interfaces;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using Mtf.Windows.Forms.Extensions;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class BarcodeScanReadingsPresenter : BasePresenter
    {
        private IBarcodeReadingsView view;
        private readonly IBarcodeScanReadingRepository barcodeScanReadingRepository;
        private readonly ILogger<BarcodeReadings> logger;

        public BarcodeScanReadingsPresenter(BarcodeScanReadingsPresenterDependencies dependencies)
            : base(dependencies)
        {
            barcodeScanReadingRepository = dependencies.BarcodeScanReadingRepository;
            logger = dependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IBarcodeReadingsView;
        }

        public void Query()
        {
            var readings = barcodeScanReadingRepository.SelectAll();
            view.LvScans.AddItems(readings, barcodeScan => new ListViewItem(barcodeScan.Value)
            {
                Tag = barcodeScan
            });
        }

        public override void Load()
        {
            Query();
        }
    }
}

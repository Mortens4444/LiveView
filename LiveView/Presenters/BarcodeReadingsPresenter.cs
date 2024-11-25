using Database.Interfaces;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class BarcodeReadingsPresenter : BasePresenter
    {
        private readonly IBarcodeReadingsView barcodeReadingsView;
        private readonly ILogger<BarcodeReadings> logger;

        public BarcodeReadingsPresenter(IBarcodeReadingsView barcodeReadingsView, ILogger<BarcodeReadings> logger)
            : base(barcodeReadingsView)
        {
            this.barcodeReadingsView = barcodeReadingsView;
            this.logger = logger;
        }
    }
}

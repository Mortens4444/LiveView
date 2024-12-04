using Database.Interfaces;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

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

        public void Query()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }
    }
}

using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class BarcodeReadingsPresenter : BasePresenter
    {
        private readonly IBarcodeReadingsView view;
        private readonly ILogger<BarcodeReadings> logger;

        public BarcodeReadingsPresenter(IBarcodeReadingsView view, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<BarcodeReadings> logger)
            : base(view, generalOptionsRepository)
        {
            this.view = view;
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

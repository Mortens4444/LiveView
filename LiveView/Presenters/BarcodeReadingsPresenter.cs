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
        private IBarcodeReadingsView view;
        private readonly ILogger<BarcodeReadings> logger;

        public BarcodeReadingsPresenter(IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<BarcodeReadings> logger)
            : base(generalOptionsRepository)
        {
            this.logger = logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IBarcodeReadingsView;
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

using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class IOPortSettingsPresenter : BasePresenter
    {
        private IIOPortSettingsView view;
        private readonly IIOPortRepository ioPortRepository;
        private readonly ILogger<IOPortSettings> logger;

        public IOPortSettingsPresenter(IGeneralOptionsRepository generalOptionsRepository, IIOPortRepository ioPortRepository, ILogger<IOPortSettings> logger)
            : base(generalOptionsRepository)
        {
            this.ioPortRepository = ioPortRepository;
            this.logger = logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IIOPortSettingsView;
        }

        public void AddRule()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }
    }
}

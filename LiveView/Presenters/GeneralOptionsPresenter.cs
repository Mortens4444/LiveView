using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class GeneralOptionsPresenter : BasePresenter
    {
        private readonly IGeneralOptionsView view;
        private readonly ILogger<GeneralOptionsForm> logger;

        public GeneralOptionsPresenter(IGeneralOptionsView view, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<GeneralOptionsForm> logger)
            : base(view, generalOptionsRepository)
        {
            this.view = view;
            this.logger = logger;
        }

        public void LoadDefaultSettings()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }

        public void LoadStandardSettings()
        {
            throw new NotImplementedException();
        }

        public void SelectNoSignalImage()
        {
            throw new NotImplementedException();
        }

        public void SaveSettings()
        {
            throw new NotImplementedException();
        }
    }
}

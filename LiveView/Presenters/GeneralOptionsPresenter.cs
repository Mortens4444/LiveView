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
        private readonly IGeneralOptionsView generalOptionsView;
        private readonly IGeneralOptionsRepository<GeneralOptions> generalOptionsRepository;
        private readonly ILogger<GeneralOptionsForm> logger;

        public GeneralOptionsPresenter(IGeneralOptionsView generalOptionsView, IGeneralOptionsRepository<GeneralOptions> generalOptionsRepository, ILogger<GeneralOptionsForm> logger)
            : base(generalOptionsView)
        {
            this.generalOptionsView = generalOptionsView;
            this.generalOptionsRepository = generalOptionsRepository;
            this.logger = logger;
        }

        internal void LoadDefaultSettings()
        {
            throw new NotImplementedException();
        }

        internal void LoadSettings()
        {
            throw new NotImplementedException();
        }

        internal void LoadStandardSettings()
        {
            throw new NotImplementedException();
        }
    }
}

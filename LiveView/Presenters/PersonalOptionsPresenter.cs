using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class PersonalOptionsPresenter : BasePresenter
    {
        private readonly IPersonalOptionsView view;
        private readonly IPersonalOptionsRepository<PersonalOptions> personalOptionsRepository;
        private readonly ILogger<PersonalOptionsForm> logger;

        public PersonalOptionsPresenter(IPersonalOptionsView view, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IPersonalOptionsRepository<PersonalOptions> personalOptionsRepository, ILogger<PersonalOptionsForm> logger)
            : base(view, generalOptionsRepository)
        {
            this.view = view;
            this.personalOptionsRepository = personalOptionsRepository;
            this.logger = logger;
        }

        public void SaveSettings()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }
    }
}

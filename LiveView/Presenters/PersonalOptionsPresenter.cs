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
        private IPersonalOptionsView view;
        private readonly IPersonalOptionsRepository<PersonalOptions> personalOptionsRepository;
        private readonly ILogger<PersonalOptionsForm> logger;

        public PersonalOptionsPresenter(IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IPersonalOptionsRepository<PersonalOptions> personalOptionsRepository, ILogger<PersonalOptionsForm> logger)
            : base(generalOptionsRepository)
        {
            this.personalOptionsRepository = personalOptionsRepository;
            this.logger = logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IPersonalOptionsView;
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

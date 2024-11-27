using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class PersonalOptionsPresenter : BasePresenter
    {
        private readonly IPersonalOptionsView personalOptionsView;
        private readonly IPersonalOptionsRepository<PersonalOptions> personalOptionsRepository;
        private readonly ILogger<PersonalOptionsForm> logger;

        public PersonalOptionsPresenter(IPersonalOptionsView personalOptionsView, IPersonalOptionsRepository<PersonalOptions> personalOptionsRepository, ILogger<PersonalOptionsForm> logger)
            : base(personalOptionsView)
        {
            this.personalOptionsView = personalOptionsView;
            this.personalOptionsRepository = personalOptionsRepository;
            this.logger = logger;
        }
    }
}

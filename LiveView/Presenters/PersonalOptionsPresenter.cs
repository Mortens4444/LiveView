using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class PersonalOptionsPresenter
    {
        private readonly IPersonalOptionsView personalOptionsView;
        private readonly IPersonalOptionsRepository personalOptionsRepository;

        public PersonalOptionsPresenter(IPersonalOptionsView personalOptionsView, IPersonalOptionsRepository personalOptionsRepository)
        {
            this.personalOptionsView = personalOptionsView;
            this.personalOptionsRepository = personalOptionsRepository;
        }
    }
}

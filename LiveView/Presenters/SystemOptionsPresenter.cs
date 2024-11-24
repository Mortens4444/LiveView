using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class SystemOptionsPresenter
    {
        private readonly ISystemOptionsView systemOptionsView;
        private readonly IOptionsRepository optionsRepository;

        public SystemOptionsPresenter(ISystemOptionsView systemOptionsView, IOptionsRepository optionsRepository)
        {
            this.systemOptionsView = systemOptionsView;
            this.optionsRepository = optionsRepository;
        }
    }
}

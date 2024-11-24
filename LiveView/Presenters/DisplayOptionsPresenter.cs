using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class DisplayOptionsPresenter
    {
        private readonly IDisplayOptionsView displayOptionsView;
        private readonly IDisplayRepository displayRepository;

        public DisplayOptionsPresenter(IDisplayOptionsView displayOptionsView, IDisplayRepository displayRepository)
        {
            this.displayOptionsView = displayOptionsView;
            this.displayRepository = displayRepository;
        }
    }
}

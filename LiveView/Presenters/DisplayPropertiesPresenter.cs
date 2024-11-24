using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class DisplayPropertiesPresenter
    {
        private readonly IDisplayPropertiesView displayPropertiesView;
        private readonly IDisplayRepository displayRepository;

        public DisplayPropertiesPresenter(IDisplayPropertiesView displayPropertiesView, IDisplayRepository displayRepository)
        {
            this.displayPropertiesView = displayPropertiesView;
            this.displayRepository = displayRepository;
        }
    }
}

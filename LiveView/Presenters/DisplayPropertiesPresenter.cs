using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class DisplayPropertiesPresenter : BasePresenter
    {
        private readonly IDisplayPropertiesView displayPropertiesView;
        private readonly IDisplayRepository<Display> displayRepository;
        private readonly ILogger<DisplayProperties> logger;

        public DisplayPropertiesPresenter(IDisplayPropertiesView displayPropertiesView, IDisplayRepository<Display> displayRepository, ILogger<DisplayProperties> logger)
            : base(displayPropertiesView)
        {
            this.displayPropertiesView = displayPropertiesView;
            this.displayRepository = displayRepository;
            this.logger = logger;
        }
    }
}

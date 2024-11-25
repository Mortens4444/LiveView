using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class DisplayOptionsPresenter : BasePresenter
    {
        private readonly IDisplayOptionsView displayOptionsView;
        private readonly IDisplayRepository<Display> displayRepository;
        private readonly ILogger<DisplayOptions> logger;

        public DisplayOptionsPresenter(IDisplayOptionsView displayOptionsView, IDisplayRepository<Display> displayRepository, ILogger<DisplayOptions> logger)
            : base(displayOptionsView)
        {
            this.displayOptionsView = displayOptionsView;
            this.displayRepository = displayRepository;
            this.logger = logger;
        }
    }
}

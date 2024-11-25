using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class SystemOptionsPresenter : BasePresenter
    {
        private readonly ISystemOptionsView systemOptionsView;
        private readonly IOptionsRepository<Options> optionsRepository;
        private readonly ILogger<SystemOptions> logger;

        public SystemOptionsPresenter(ISystemOptionsView systemOptionsView, IOptionsRepository<Options> optionsRepository, ILogger<SystemOptions> logger)
            : base(systemOptionsView)
        {
            this.systemOptionsView = systemOptionsView;
            this.optionsRepository = optionsRepository;
            this.logger = logger;
        }
    }
}

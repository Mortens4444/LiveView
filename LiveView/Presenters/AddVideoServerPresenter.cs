using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class AddVideoServerPresenter : BasePresenter
    {
        private readonly IAddVideoServerView addVideoServerView;
        private readonly IServerRepository<Sequence> serverRepository;
        private readonly ILogger<AddVideoServer> logger;

        public AddVideoServerPresenter(IAddVideoServerView addVideoServerView, IServerRepository<Sequence> serverRepository, ILogger<AddVideoServer> logger)
            : base(addVideoServerView)
        {
            this.addVideoServerView = addVideoServerView;
            this.serverRepository = serverRepository;
            this.logger = logger;
        }
    }
}

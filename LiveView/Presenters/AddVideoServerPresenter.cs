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
        private readonly IServerRepository<Server> serverRepository;
        private readonly ILogger<AddVideoServer> logger;

        public AddVideoServerPresenter(IAddVideoServerView addVideoServerView, IServerRepository<Server> serverRepository, ILogger<AddVideoServer> logger)
            : base(addVideoServerView)
        {
            this.addVideoServerView = addVideoServerView;
            this.serverRepository = serverRepository;
            this.logger = logger;
        }

        public void Add()
        {
            var server = addVideoServerView.GetServer();
            serverRepository.Insert(Server.From(server));
            logger.LogInformation($"Videoserver '{server}' has been created.");
        }
    }
}

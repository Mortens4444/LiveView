using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Network;
using LiveView.Services.Network;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

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

        public void AddOrModify(Server server)
        {
            var serverDto = addVideoServerView.GetServerDto();
            var newServer = serverDto.ToModel();
            if (server == null)
            {
                serverRepository.Insert(newServer);
            }
            else
            {
                newServer.Id = server.Id;
                serverRepository.Update(newServer);
            }

            logger.LogInformation($"Videoserver '{serverDto}' has been created.");
        }

        public async Task SearchForHostsAsync()
        {
            HostDiscoveryService.HostDiscovered += OnHostDiscovered;
            await Task.Run(HostDiscoveryService.Discovery);
            HostDiscoveryService.HostDiscovered -= OnHostDiscovered;
        }

        public void LoadData(Server server)
        {
            addVideoServerView.LoadData(server);
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }

        private void OnHostDiscovered(HostDiscoveryResult result)
        {
            addVideoServerView.AddToServerSelector(result);
        }
    }
}

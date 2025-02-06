using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Network;
using LiveView.Services;
using LiveView.Services.Network;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using System.Threading.Tasks;

namespace LiveView.Presenters
{
    public class AddVideoServerPresenter : BasePresenter
    {
        private IAddVideoServerView view;
        private readonly IServerRepository serverRepository;
        private readonly ILogger<AddVideoServer> logger;
        private readonly SziltechDeviceChecker sziltechDeviceChecker = new SziltechDeviceChecker();

        public AddVideoServerPresenter(IGeneralOptionsRepository generalOptionsRepository, IServerRepository serverRepository, ILogger<AddVideoServer> logger)
            : base(generalOptionsRepository)
        {
            this.serverRepository = serverRepository;
            this.logger = logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IAddVideoServerView;
        }

        public void AddOrModify(Server server)
        {
            var serverDto = view.GetServerDto();
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

            logger.LogInfo("Video server '{0}' has been created.", serverDto);
        }

        public async Task SearchForHostsAsync()
        {
            HostDiscoveryService.HostDiscovered += OnHostDiscovered;
            await Task.Run(HostDiscoveryService.Discovery);
            HostDiscoveryService.HostDiscovered -= OnHostDiscovered;
        }

        public void LoadData(Server server)
        {
            view.LoadData(server);
        }

        public void Validate()
        {
            var iszSziltechDeice = sziltechDeviceChecker.IsSziltechDevice(view.TbSziltechSerialNumber.Text, out var deviceInfo);
            if (iszSziltechDeice)
            {
                view.TbModel.Text = Lng.Elem(deviceInfo.Model);
            }
            else
            {
                ShowError("Validation failed! Sziltech SN is not recognized.");
            }
        }

        private void OnHostDiscovered(HostDiscoveryResult result)
        {
            view.AddToServerSelector(result);
        }
    }
}

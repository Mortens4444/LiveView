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
using Mtf.Permissions.Enums;
using System.Threading.Tasks;

namespace LiveView.Presenters
{
    public class AddVideoServerPresenter : BasePresenter
    {
        private IAddVideoServerView view;
        private readonly IVideoServerRepository videoServerRepository;
        private readonly ILogger<AddVideoServer> logger;

        public AddVideoServerPresenter(IGeneralOptionsRepository generalOptionsRepository, IVideoServerRepository videoServerRepository, ILogger<AddVideoServer> logger)
            : base(generalOptionsRepository)
        {
            this.videoServerRepository = videoServerRepository;
            this.logger = logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IAddVideoServerView;
        }

        public void AddOrModify(VideoServer server)
        {
            var serverDto = view.GetServerDto();
            var newServer = serverDto.ToModel();
            if (server == null)
            {
                videoServerRepository.Insert(newServer);
                logger.LogInfo(ServerManagementPermissions.Create, "Video server '{0}' has been created.", serverDto);
            }
            else
            {
                newServer.Id = server.Id;
                videoServerRepository.Update(newServer);
                logger.LogInfo(ServerManagementPermissions.Update, "Video server '{0}' has been updated.", serverDto);
            }
        }

        public async Task SearchForHostsAsync()
        {
            HostDiscoveryService.HostDiscovered += OnHostDiscovered;
            await Task.Run(HostDiscoveryService.Discovery);
            HostDiscoveryService.HostDiscovered -= OnHostDiscovered;
        }

        public void LoadData(VideoServer server)
        {
            view.LoadData(server);
        }

        public void Validate()
        {
            var iszSziltechDeice = SziltechDeviceChecker.IsSziltechDevice(view.TbSziltechSerialNumber.Text, out var deviceInfo);
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

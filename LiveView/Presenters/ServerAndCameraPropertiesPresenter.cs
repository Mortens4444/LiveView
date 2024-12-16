using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class ServerAndCameraPropertiesPresenter : BasePresenter
    {
        private readonly IServerAndCameraPropertiesView serverAndCameraPropertiesView;
        private readonly IServerRepository<Server> serverRepository;
        private readonly ICameraRepository<Camera> cameraRepository;
        private readonly ILogger<ServerAndCameraProperties> logger;

        public ServerAndCameraPropertiesPresenter(IServerAndCameraPropertiesView serverAndCameraPropertiesView, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IServerRepository<Server> serverRepository, ICameraRepository<Camera> cameraRepository, ILogger<ServerAndCameraProperties> logger)
            : base(serverAndCameraPropertiesView, generalOptionsRepository)
        {
            this.serverAndCameraPropertiesView = serverAndCameraPropertiesView;
            this.serverRepository = serverRepository;
            this.cameraRepository = cameraRepository;
            this.logger = logger;
        }

        internal void ExportCameraList()
        {
            throw new NotImplementedException();
        }

        internal void ExportHadwareInfo()
        {
            throw new NotImplementedException();
        }

        internal void GetHardwareInfo()
        {
            throw new NotImplementedException();
        }

        internal void Refresh()
        {
            throw new NotImplementedException();
        }

        internal void ShowPassword()
        {
            throw new NotImplementedException();
        }

        internal void WakeOnLan()
        {
            throw new NotImplementedException();
        }
    }
}

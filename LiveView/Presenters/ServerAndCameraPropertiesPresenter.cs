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
        private IServerAndCameraPropertiesView view;
        private readonly IServerRepository<Server> serverRepository;
        private readonly ICameraRepository<Camera> cameraRepository;
        private readonly ILogger<ServerAndCameraProperties> logger;

        public ServerAndCameraPropertiesPresenter(IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IServerRepository<Server> serverRepository, ICameraRepository<Camera> cameraRepository, ILogger<ServerAndCameraProperties> logger)
            : base(generalOptionsRepository)
        {
            this.serverRepository = serverRepository;
            this.cameraRepository = cameraRepository;
            this.logger = logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IServerAndCameraPropertiesView;
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

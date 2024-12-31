using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class ServerAndCameraPropertiesPresenter : BasePresenter
    {
        private IServerAndCameraPropertiesView view;
        private readonly IServerRepository serverRepository;
        private readonly ICameraRepository cameraRepository;
        private readonly ILogger<ServerAndCameraProperties> logger;

        public ServerAndCameraPropertiesPresenter(ServerAndCameraPropertiesPresenterDependencies serverAndCameraPropertiesPresenterDependencies)
            : base(serverAndCameraPropertiesPresenterDependencies)
        {
            serverRepository = serverAndCameraPropertiesPresenterDependencies.ServerRepository;
            cameraRepository = serverAndCameraPropertiesPresenterDependencies.CameraRepository;
            logger = serverAndCameraPropertiesPresenterDependencies.Logger;
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

using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class ServerAndCameraManagementPresenter : BasePresenter
    {
        private readonly IServerAndCameraManagementView serverAndCameraManagementView;
        private readonly IServerRepository<Server> serverRepository;
        private readonly ICameraRepository<Camera> cameraRepository;
        private readonly ILogger<ServerAndCameraManagement> logger;

        public ServerAndCameraManagementPresenter(FormFactory formFactory, IServerAndCameraManagementView serverAndCameraManagementView, IServerRepository<Server> serverRepository, ICameraRepository<Camera> cameraRepository, ILogger<ServerAndCameraManagement> logger)
            : base(serverAndCameraManagementView, formFactory)
        {
            this.serverAndCameraManagementView = serverAndCameraManagementView;
            this.serverRepository = serverRepository;
            this.cameraRepository = cameraRepository;
            this.logger = logger;
        }

        public void CreateNewCameraForm()
        {
            long serverId = 0;
            ShowForm<AddCameras>(serverId);
        }

        public void ModifyServer()
        {
            throw new NotImplementedException();
        }

        public void RemoveServer()
        {
            throw new NotImplementedException();
        }

        public void Syncronize()
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            var servers = serverRepository.GetAll();
            foreach (var server in servers)
            {
                serverAndCameraManagementView.AddServer(server);
            }
        }
    }
}

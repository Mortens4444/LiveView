using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class ServerAndCameraManagementPresenter : BasePresenter
    {
        private readonly IServerAndCameraManagementView serverAndCameraManagementView;
        private readonly IServerRepository<Server> serverRepository;
        private readonly ICameraRepository<Camera> cameraRepository;
        private readonly ILogger<ServerAndCameraManagement> logger;

        private const int ServerIconIndex = 1;
        private const int CameraIconIndex = 2;
        private const int UpdateServerIconIndex = 3;
        private const int UpdateCameraIconIndex = 4;
        private const int DeleteServerIconIndex = 5;
        private const int DeleteCameraIconIndex = 6;
        private const int DatabaseServerIconIndex = 7;

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
            var node = serverAndCameraManagementView.GetSelectedItem();
            if (node?.Tag is Server server)
            {
                ShowForm<AddCameras>(server);
            }
            else
            {
                ShowForm<AddCameras>();
            }
        }

        public void Modify()
        {
            var node = serverAndCameraManagementView.GetSelectedItem();
            if (node.Tag is Server server)
            {
                ShowDialog<AddVideoServer>(server);
            }
            else if (node.Tag is Camera)
            {
                throw new NotImplementedException();
            }
            else if (node.Tag is DatabaseServer)
            {
                throw new NotImplementedException();
            }
        }

        public void Remove()
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
            var treeNodes = servers.Select(server =>
                new TreeNode(server.Hostname, ServerIconIndex, ServerIconIndex)
                {
                    Name = server.Id.ToString(),
                    Tag = server
                });
            serverAndCameraManagementView.ShowServerNodes(treeNodes);
        }
    }
}

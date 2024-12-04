using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
            var node = serverAndCameraManagementView.GetSelectedItem(serverAndCameraManagementView.ServersAndCameras);
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
            var node = serverAndCameraManagementView.GetSelectedItem(serverAndCameraManagementView.ServersAndCameras);
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

        public override void Load()
        {
            var servers = serverRepository.GetAll();
            var cameras = cameraRepository.GetAll();
            var videoServerTreeNodes = new List<TreeNode>();
            foreach (var server in servers)
            {
                var serverTreeNode = new TreeNode(server.Hostname, ServerIconIndex, ServerIconIndex)
                {
                    Name = server.Id.ToString(),
                    Tag = server,
                    ToolTipText = server.IpAddress
                };

                var serverCameras = cameras.Where(camera => camera.ServerId == server.Id);
                foreach (var serverCamera in serverCameras)
                {
                    var cameraTreeNode = new TreeNode(serverCamera.CameraName, CameraIconIndex, CameraIconIndex)
                    {
                        Name = serverCamera.Guid,
                        Tag = serverCamera,
                        ToolTipText = serverCamera.Guid
                    };
                    serverTreeNode.Nodes.Add(cameraTreeNode);
                }

                videoServerTreeNodes.Add(serverTreeNode);
            }

            var serversNode = serverAndCameraManagementView.ServersAndCameras.Nodes["Servers"];
            serverAndCameraManagementView.AddNodes(serversNode, videoServerTreeNodes);
            serverAndCameraManagementView.ExpandAll(serversNode);
        }
    }
}

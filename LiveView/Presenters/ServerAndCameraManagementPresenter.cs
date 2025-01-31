using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using LiveView.Services.VideoServer;
using Microsoft.Extensions.Logging;
using Mtf.MessageBoxes.Enums;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OpenCvSharp.ML.DTrees;
using Server = Database.Models.Server;

namespace LiveView.Presenters
{
    public class ServerAndCameraManagementPresenter : BasePresenter
    {
        private IServerAndCameraManagementView view;
        private readonly IServerRepository serverRepository;
        private readonly IDatabaseServerRepository databaseServerRepository;
        private readonly ICameraRepository cameraRepository;
        private readonly ILogger<ServerAndCameraManagement> logger;
        private readonly PermissionManager<Database.Models.User> permissionManager;

        private const int ServerIconIndex = 1;
        private const int CameraIconIndex = 2;
        private const int UpdateServerIconIndex = 3;
        private const int UpdateCameraIconIndex = 4;
        private const int DeleteServerIconIndex = 5;
        private const int DeleteCameraIconIndex = 6;
        private const int DatabaseServerIconIndex = 7;
        private const int AgentIconIndex = 8;

        public ServerAndCameraManagementPresenter(ServerAndCameraManagementPresenterDependencies serverAndCameraManagementPresenterDependencies)
            : base(serverAndCameraManagementPresenterDependencies)
        {
            serverRepository = serverAndCameraManagementPresenterDependencies.ServerRepository;
            databaseServerRepository = serverAndCameraManagementPresenterDependencies.DatabaseServerRepository;
            cameraRepository = serverAndCameraManagementPresenterDependencies.CameraRepository;
            logger = serverAndCameraManagementPresenterDependencies.Logger;
            permissionManager = serverAndCameraManagementPresenterDependencies.PermissionManager;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IServerAndCameraManagementView;
        }

        public void CreateNewCameraForm()
        {
            var node = view.GetSelectedItem(view.ServersAndCameras);
            if (ShowDialog<AddCameras>(node?.Tag as Server))
            {
                Load();
            }
        }

        public void Modify()
        {
            var node = view.GetSelectedItem(view.ServersAndCameras);
            if (node != null)
            {
                if (node.Tag is Server server)
                {
                    if (permissionManager.CurrentUser.HasPermission(ServerManagementPermissions.Update))
                    {
                        if (ShowDialog<AddVideoServer>(server))
                        {
                            logger.LogInfo("Video server '{0}' has been modified.", server);
                        }
                    }
                    else
                    {
                        logger.LogError("User '{0}' has no permission to modify video server.", permissionManager.CurrentUser);
                        throw new UnauthorizedAccessException();
                    }
                }
                else if (node.Tag is Camera camera)
                {
                    if (permissionManager.CurrentUser.HasPermission(CameraManagementPermissions.Update))
                    {
                        if (ShowDialog<CameraProperties>(camera))
                        {
                            logger.LogInfo("Camera '{0}' has been modified.", camera);
                        }
                    }
                    else
                    {
                        logger.LogError("User '{0}' has no permission to modify camera.", permissionManager.CurrentUser);
                        throw new UnauthorizedAccessException();
                    }
                }
                else if (node.Tag is DatabaseServer databaseServer)
                {
                    if (permissionManager.CurrentUser.HasPermission(DatabaseServerManagementPermissions.Update))
                    {
                        if (ShowDialog<AddDatabaseServer>(databaseServer))
                        {
                            logger.LogInfo("Database server '{0}' has been modified.", databaseServer);
                        }
                    }
                    else
                    {
                        logger.LogError("User '{0}' has no permission to modify database server.", permissionManager.CurrentUser);
                        throw new UnauthorizedAccessException();
                    }
                }
                Load();
            }
        }

        public void Remove()
        {
            if (!ShowConfirm("Are you sure you want to delete this item?", Decide.No))
            {
                return;
            }

            var node = view.GetSelectedItem(view.ServersAndCameras);
            if (node != null)
            {
                if (node.Tag is Server server)
                {
                    if (permissionManager.CurrentUser.HasPermission(ServerManagementPermissions.Delete))
                    {
                        serverRepository.Delete(server.Id);
                        logger.LogInfo("Video server '{0}' has been deleted.", server);
                    }
                    else
                    {
                        logger.LogError("User '{0}' has no permission to delete video server.", permissionManager.CurrentUser);
                        throw new UnauthorizedAccessException();
                    }
                }
                else if (node.Tag is Camera camera)
                {
                    if (permissionManager.CurrentUser.HasPermission(CameraManagementPermissions.Delete))
                    {
                        cameraRepository.Delete(camera.Id);
                        logger.LogInfo("Camera '{0}' has been deleted.", camera);
                    }
                    else
                    {
                        logger.LogError("User '{0}' has no permission to delete camera.", permissionManager.CurrentUser);
                        throw new UnauthorizedAccessException();
                    }
                }
                else if (node.Tag is DatabaseServer databaseServer)
                {
                    if (permissionManager.CurrentUser.HasPermission(DatabaseServerManagementPermissions.Delete))
                    {
                        databaseServerRepository.Delete(databaseServer.Id);
                        logger.LogInfo("Database server '{0}' has been deleted.", databaseServer);
                    }
                    else
                    {
                        logger.LogError("User '{0}' has no permission to delete database server.", permissionManager.CurrentUser);
                        throw new UnauthorizedAccessException();
                    }
                }
                Load();
            }
        }

        public async Task SyncronizeAsync()
        {
            if (permissionManager.CurrentUser.HasPermission(CameraManagementPermissions.Update))
            {
                var syncMode = view.GetSyncronizationMode();

                if (view.ServersAndCameras.SelectedNode?.Tag is Server server)
                {
                    var camerasInDatabase = cameraRepository.SelectWhere(new { ServerId = server.Id });
                    var connectionResult = await VideoServerConnector.ConnectAsync(view.GetSelf<IVideoServerView>(), server);
                    if (connectionResult.ErrorCode == VideoServerErrorHandler.Success)
                    {
                        foreach (var camera in connectionResult.Cameras)
                        {
                            switch (syncMode)
                            {
                                case SyncronizationMode.Guid:
                                    var actualCamera = camerasInDatabase.FirstOrDefault(cameraInDatabase => cameraInDatabase.Guid == camera.Guid);
                                    if (actualCamera != null)
                                    {
                                        actualCamera.CameraName = camera.Name;
                                        actualCamera.RecorderIndex = camera.Index;
                                        cameraRepository.Update(actualCamera);
                                        logger.LogInfo("Camera '{0}' syncronized by GUID.", actualCamera);
                                    }
                                    break;
                                case SyncronizationMode.RecorderIndex:
                                    var actualCamera2 = camerasInDatabase.FirstOrDefault(cameraInDatabase => cameraInDatabase.RecorderIndex == camera.Index);
                                    if (actualCamera2 != null)
                                    {
                                        actualCamera2.CameraName = camera.Name;
                                        actualCamera2.Guid = camera.Guid;
                                        cameraRepository.Update(actualCamera2);
                                        logger.LogInfo("Camera '{0}' syncronized by recorder index.", actualCamera2);
                                    }
                                    break;
                                case SyncronizationMode.CameraName:
                                    var actualCamera3 = camerasInDatabase.FirstOrDefault(cameraInDatabase => cameraInDatabase.CameraName == camera.Name);
                                    if (actualCamera3 != null)
                                    {
                                        actualCamera3.RecorderIndex = camera.Index;
                                        actualCamera3.Guid = camera.Guid;
                                        cameraRepository.Update(actualCamera3);
                                        logger.LogInfo("Camera '{0}' syncronized by camera name.", actualCamera3);
                                    }
                                    break;
                                default:
                                    throw new NotSupportedException($"SyncronizationMode '{syncMode}' is not supported yet.");
                            }
                        }
                    }
                    else
                    {
                        ShowError("Connection failed", VideoServerErrorHandler.GetMessage(connectionResult.ErrorCode));
                    }
                    Load();
                }
            }
            else
            {
                throw new UnauthorizedAccessException();
            }
        }

        public override void Load()
        {
            var servers = serverRepository.SelectAll();
            var cameras = cameraRepository.SelectAll();
            var videoServerTreeNodes = CreateServerAndCamerasTreeNodes(servers, cameras);
            AddNodes("Servers", videoServerTreeNodes);

            var dbServers = databaseServerRepository.SelectAll();
            var dbServerTreeNodes = CreateDatabaseTreeNodes(dbServers);
            AddNodes("DBServers", dbServerTreeNodes);

            var agentTreeNodes = CreateAgentTreeNodes();
            AddNodes("Agents", agentTreeNodes);
        }

        private static List<TreeNode> CreateAgentTreeNodes()
        {
            var agentTreeNodes = new List<TreeNode>();
            foreach (var agent in MainPresenter.VideoCaptureSources.Keys)
            {
                var endPoint = agent.LocalEndPoint.ToString();
                var agentTreeNode = new TreeNode(endPoint.ToString(), AgentIconIndex, AgentIconIndex)
                {
                    Name = endPoint.ToString()
                };
                var agentCameras = MainPresenter.VideoCaptureSources[agent];
                foreach (var agentCamera in agentCameras)
                {
                    var cameraTreeNode = new TreeNode(agentCamera.Key, CameraIconIndex, CameraIconIndex)
                    {
                        Name = agentCamera.Key,
                        ToolTipText = agentCamera.Value
                    };
                    agentTreeNode.Nodes.Add(cameraTreeNode);
                }

                agentTreeNodes.Add(agentTreeNode);
            }
            return agentTreeNodes;
        }

        private static List<TreeNode> CreateDatabaseTreeNodes(ReadOnlyCollection<DatabaseServer> dbServers)
        {
            var dbServerTreeNodes = new List<TreeNode>();
            foreach (var dbServer in dbServers)
            {
                var dbServerTreeNode = new TreeNode(dbServer.Hostname, DatabaseServerIconIndex, DatabaseServerIconIndex)
                {
                    Name = dbServer.Id.ToString(),
                    Tag = dbServer,
                    ToolTipText = dbServer.IpOrHost
                };

                dbServerTreeNodes.Add(dbServerTreeNode);
            }

            return dbServerTreeNodes;
        }

        private static List<TreeNode> CreateServerAndCamerasTreeNodes(ReadOnlyCollection<Server> servers, ReadOnlyCollection<Camera> cameras)
        {
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

            return videoServerTreeNodes;
        }

        private void AddNodes(string nodeName, IEnumerable<TreeNode> newNodes)
        {
            var parentNode = view.ServersAndCameras.Nodes[nodeName];
            parentNode.Nodes.Clear();
            view.AddNodes(parentNode, newNodes);
            view.ExpandAll(parentNode);
        }

        public void ChangeButtonStates(TreeNode treeNode)
        {
            var cameraSelected = treeNode?.Tag is Camera;
            var serverSelected = treeNode?.Tag is Server;
            var dbServerSelected = treeNode?.Tag is DatabaseServer;

            view.BtnModify.Enabled = (permissionManager.CurrentUser.HasPermission(CameraManagementPermissions.Update) && cameraSelected) ||
                (permissionManager.CurrentUser.HasPermission(ServerManagementPermissions.Update) && serverSelected) ||
                (permissionManager.CurrentUser.HasPermission(DatabaseServerManagementPermissions.Update) && dbServerSelected);
            view.BtnRemove.Enabled = (permissionManager.CurrentUser.HasPermission(CameraManagementPermissions.Delete) && cameraSelected) ||
                (permissionManager.CurrentUser.HasPermission(ServerManagementPermissions.Delete) && serverSelected) ||
                (permissionManager.CurrentUser.HasPermission(DatabaseServerManagementPermissions.Delete) && dbServerSelected);
            view.BtnProperties.Enabled = permissionManager.CurrentUser.HasPermission(ServerManagementPermissions.Select) && serverSelected ||
                (permissionManager.CurrentUser.HasPermission(CameraManagementPermissions.Update) && cameraSelected);
            view.BtnMotionDetection.Enabled = permissionManager.CurrentUser.HasPermission(CameraManagementPermissions.Update) && cameraSelected;
            view.BtnSyncronize.Enabled = permissionManager.CurrentUser.HasPermission(CameraManagementPermissions.Update) && serverSelected;
        }

        public void ShowServerAndCameraProperties()
        {
            if (view.ServersAndCameras.SelectedNode?.Tag is Server server)
            {
                if (permissionManager.CurrentUser.HasPermission(ServerManagementPermissions.Select))
                {
                    ShowForm<ServerAndCameraProperties>(server);
                }
                else
                {
                    logger.LogError("User '{0}' has no permission to view server and camera properties.", permissionManager.CurrentUser);
                }
            }
            else if (view.ServersAndCameras.SelectedNode?.Tag is Camera camera)
            {
                if (permissionManager.CurrentUser.HasPermission(CameraManagementPermissions.Update))
                {
                    if (ShowDialog<CameraProperties>(camera))
                    {
                        logger.LogInfo("Camera '{0}' has been modified.", camera);
                    }
                }
                else
                {
                    logger.LogError("User '{0}' has no permission to modify camera.", permissionManager.CurrentUser);
                    throw new UnauthorizedAccessException();
                }
            }
        }
    }
}

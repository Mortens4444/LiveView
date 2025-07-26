using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using LiveView.Services.VideoServer;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using Mtf.MessageBoxes.Enums;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoServer = Database.Models.VideoServer;

namespace LiveView.Presenters
{
    public class ServerAndCameraManagementPresenter : BasePresenter
    {
        private IServerAndCameraManagementView view;
        private readonly IVideoServerRepository videoServerRepository;
        private readonly IDatabaseServerRepository databaseServerRepository;
        private readonly ICameraRepository cameraRepository;
        private readonly ILogger<ServerAndCameraManagement> logger;
        private readonly PermissionManager<User> permissionManager;

        private const int ServerIconIndex = 1;
        private const int CameraIconIndex = 2;
        private const int UpdateServerIconIndex = 3;
        private const int UpdateCameraIconIndex = 4;
        private const int DeleteServerIconIndex = 5;
        private const int DeleteCameraIconIndex = 6;
        private const int DatabaseServerIconIndex = 7;
        private const int AgentIconIndex = 8;

        public ServerAndCameraManagementPresenter(ServerAndCameraManagementPresenterDependencies dependencies)
            : base(dependencies)
        {
            videoServerRepository = dependencies.VideoServerRepository;
            databaseServerRepository = dependencies.DatabaseServerRepository;
            cameraRepository = dependencies.CameraRepository;
            logger = dependencies.Logger;
            permissionManager = dependencies.PermissionManager;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IServerAndCameraManagementView;
        }

        public void CreateNewCameraForm()
        {
            var node = view.GetSelectedItem(view.ServersAndCameras);
            ShowDialog<AddCameras>(node?.Tag as VideoServer);
            Load();
        }

        public void Modify()
        {
            var node = view.GetSelectedItem(view.ServersAndCameras);
            if (node != null)
            {
                if (node.Tag is VideoServer server)
                {
                    if (permissionManager.HasPermission(ServerManagementPermissions.Update))
                    {
                        if (ShowDialog<AddVideoServer>(server))
                        {
                            logger.LogInfo(ServerManagementPermissions.Update, "Video server '{0}' has been modified.", server);
                        }
                    }
                    else
                    {
                        var message = Lng.FormattedElem("User '{0}' has no permission to modify video server.", args: permissionManager.CurrentUser);
                        logger.LogError(message);
                        throw new UnauthorizedAccessException(message);
                    }
                }
                else if (node.Tag is Camera camera)
                {
                    if (permissionManager.HasPermission(CameraManagementPermissions.Update))
                    {
                        if (ShowDialog<CameraProperties>(camera))
                        {
                            logger.LogInfo(CameraManagementPermissions.Update, "Camera '{0}' has been modified.", camera);
                        }
                    }
                    else
                    {
                        var message = Lng.FormattedElem("User '{0}' has no permission to modify camera.", args: permissionManager.CurrentUser);
                        logger.LogError(message);
                        throw new UnauthorizedAccessException(message);
                    }
                }
                else if (node.Tag is DatabaseServer databaseServer)
                {
                    if (permissionManager.HasPermission(DatabaseServerManagementPermissions.Update))
                    {
                        if (ShowDialog<AddDatabaseServer>(databaseServer))
                        {
                            logger.LogInfo(DatabaseServerManagementPermissions.Update, "Database server '{0}' has been modified.", databaseServer);
                        }
                    }
                    else
                    {
                        var message = Lng.FormattedElem("User '{0}' has no permission to modify database server.", args: permissionManager.CurrentUser);
                        logger.LogError(message);
                        throw new UnauthorizedAccessException(message);
                    }
                }
                Load();
            }
        }

        public void Remove()
        {
            var node = view.GetSelectedItem(view.ServersAndCameras);
            if (node != null)
            {
                if (node.Tag is VideoServer server)
                {
                    if (!ShowConfirm("Are you sure you want to delete this server?", Decide.No))
                    {
                        return;
                    }

                    if (permissionManager.HasPermission(ServerManagementPermissions.Delete))
                    {
                        videoServerRepository.Delete(server.Id);
                        logger.LogInfo(ServerManagementPermissions.Delete, "Video server '{0}' has been deleted.", server);
                    }
                    else
                    {
                        var message = Lng.FormattedElem("User '{0}' has no permission to delete video server.", args: permissionManager.CurrentUser);
                        logger.LogError(message);
                        throw new UnauthorizedAccessException(message);
                    }
                }
                else if (node.Tag is Camera camera)
                {
                    if (!ShowConfirm("Are you sure you want to delete this camera?", Decide.No))
                    {
                        return;
                    }

                    if (permissionManager.HasPermission(CameraManagementPermissions.Delete))
                    {
                        cameraRepository.Delete(camera.Id);
                        logger.LogInfo(CameraManagementPermissions.Delete, "Camera '{0}' has been deleted.", camera);
                    }
                    else
                    {
                        var message = Lng.FormattedElem("User '{0}' has no permission to delete camera.", args: permissionManager.CurrentUser);
                        logger.LogError(message);
                        throw new UnauthorizedAccessException(message);
                    }
                }
                else if (node.Tag is DatabaseServer databaseServer)
                {
                    if (!ShowConfirm("Are you sure you want to delete this database server?", Decide.No))
                    {
                        return;
                    }

                    if (permissionManager.HasPermission(DatabaseServerManagementPermissions.Delete))
                    {
                        databaseServerRepository.Delete(databaseServer.Id);
                        logger.LogInfo(DatabaseServerManagementPermissions.Delete, "Database server '{0}' has been deleted.", databaseServer);
                    }
                    else
                    {
                        var message = Lng.FormattedElem("User '{0}' has no permission to delete database server.", args: permissionManager.CurrentUser);
                        logger.LogError(message);
                        throw new UnauthorizedAccessException(message);
                    }
                }
                else
                {
                    ShowError("No item has been selected.");
                }
                Load();
            }
        }

        public async Task SynchronizeAsync()
        {
            if (permissionManager.HasPermission(CameraManagementPermissions.Update))
            {
                var syncMode = view.GetSynchronizationMode();

                if (view.ServersAndCameras.SelectedNode?.Tag is VideoServer videoServer)
                {
                    var camerasInDatabase = cameraRepository.SelectWhere(new { VideoServerId = videoServer.Id });
                    var connectionTimeout = generalOptionsRepository.Get(Setting.MaximumTimeToWaitForAVideoServerIs, 500);
                    var connectionResult = await VideoServerConnector.ConnectAsync(view.GetSelf<IVideoServerView>(), videoServer, connectionTimeout);
                    if (connectionResult.ErrorCode == VideoServerErrorHandler.Success)
                    {
                        foreach (var camera in connectionResult.Cameras)
                        {
                            switch (syncMode)
                            {
                                case SynchronizationMode.Guid:
                                    var actualCamera = camerasInDatabase.FirstOrDefault(cameraInDatabase => cameraInDatabase.Guid == camera.Guid);
                                    if (actualCamera != null)
                                    {
                                        actualCamera.CameraName = camera.Name;
                                        actualCamera.RecorderIndex = camera.Index;
                                        cameraRepository.Update(actualCamera);
                                        logger.LogInfo(CameraManagementPermissions.Update, "Camera '{0}' synchronized by GUID.", actualCamera);
                                    }
                                    break;
                                case SynchronizationMode.RecorderIndex:
                                    var actualCamera2 = camerasInDatabase.FirstOrDefault(cameraInDatabase => cameraInDatabase.RecorderIndex == camera.Index);
                                    if (actualCamera2 != null)
                                    {
                                        actualCamera2.CameraName = camera.Name;
                                        actualCamera2.Guid = camera.Guid;
                                        cameraRepository.Update(actualCamera2);
                                        logger.LogInfo(CameraManagementPermissions.Update, "Camera '{0}' synchronized by recorder index.", actualCamera2);
                                    }
                                    break;
                                case SynchronizationMode.CameraName:
                                    var actualCamera3 = camerasInDatabase.FirstOrDefault(cameraInDatabase => cameraInDatabase.CameraName == camera.Name);
                                    if (actualCamera3 != null)
                                    {
                                        actualCamera3.RecorderIndex = camera.Index;
                                        actualCamera3.Guid = camera.Guid;
                                        cameraRepository.Update(actualCamera3);
                                        logger.LogInfo(CameraManagementPermissions.Update, "Camera '{0}' synchronized by camera name.", actualCamera3);
                                    }
                                    break;
                                default:
                                    throw new NotSupportedException($"SynchronizationMode '{syncMode}' is not supported yet.");
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
                var message = Lng.FormattedElem("User '{0}' has no permission to synchronize cameras.", args: permissionManager.CurrentUser);
                logger.LogError(message);
                throw new UnauthorizedAccessException(message);
            }
        }

        public override void Load()
        {
            var videoServers = videoServerRepository.SelectAll();
            var cameras = cameraRepository.SelectAll();
            var videoServerTreeNodes = CreateServerAndCamerasTreeNodes(videoServers, cameras);
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
            foreach (var agent in Globals.VideoCaptureSources.Keys)
            {
                var endPoint = agent.RemoteEndPoint.ToString();
                var agentTreeNode = new TreeNode(endPoint.ToString(), AgentIconIndex, AgentIconIndex)
                {
                    Name = endPoint.ToString()
                };
                var agentCameras = Globals.VideoCaptureSources[agent];
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
                    ToolTipText = dbServer.IpAddress
                };

                dbServerTreeNodes.Add(dbServerTreeNode);
            }

            return dbServerTreeNodes;
        }

        private static List<TreeNode> CreateServerAndCamerasTreeNodes(ReadOnlyCollection<VideoServer> videoServers, ReadOnlyCollection<Camera> cameras)
        {
            var videoServerTreeNodes = new List<TreeNode>();
            foreach (var videoServer in videoServers)
            {
                var serverTreeNode = new TreeNode(videoServer.Hostname, ServerIconIndex, ServerIconIndex)
                {
                    Name = videoServer.Id.ToString(),
                    Tag = videoServer,
                    ToolTipText = videoServer.IpAddress
                };

                var videoServerCameras = cameras.Where(camera => camera.VideoServerId == videoServer.Id);
                foreach (var videoServerCamera in videoServerCameras)
                {
                    var cameraTreeNode = new TreeNode(videoServerCamera.CameraName, CameraIconIndex, CameraIconIndex)
                    {
                        Name = videoServerCamera.Guid,
                        Tag = videoServerCamera,
                        ToolTipText = videoServerCamera.Guid
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
            var serverSelected = treeNode?.Tag is VideoServer;
            var dbServerSelected = treeNode?.Tag is DatabaseServer;

            view.BtnNewCamera.Enabled = permissionManager.HasPermission(CameraManagementPermissions.Create) &&
                permissionManager.HasPermission(ServerManagementPermissions.Update) && serverSelected;

            view.BtnModify.Enabled = (permissionManager.HasPermission(CameraManagementPermissions.Update) && cameraSelected) ||
                (permissionManager.HasPermission(ServerManagementPermissions.Update) && serverSelected) ||
                (permissionManager.HasPermission(DatabaseServerManagementPermissions.Update) && dbServerSelected);
            
            view.BtnRemove.Enabled = (permissionManager.HasPermission(CameraManagementPermissions.Delete) && cameraSelected) ||
                (permissionManager.HasPermission(ServerManagementPermissions.Delete) && serverSelected) ||
                (permissionManager.HasPermission(DatabaseServerManagementPermissions.Delete) && dbServerSelected);
            
            view.BtnProperties.Enabled = permissionManager.HasPermission(ServerManagementPermissions.Select) && serverSelected ||
                (permissionManager.HasPermission(CameraManagementPermissions.Update) && cameraSelected);
            
            view.BtnMotionDetection.Enabled = permissionManager.HasPermission(CameraManagementPermissions.Update) && cameraSelected;
            
            view.BtnSynchronize.Enabled = permissionManager.HasPermission(CameraManagementPermissions.Update) && serverSelected;
        }

        public void ShowServerAndCameraProperties()
        {
            if (view.ServersAndCameras.SelectedNode?.Tag is VideoServer server)
            {
                if (permissionManager.HasPermission(ServerManagementPermissions.Select))
                {
                    ShowForm<ServerAndCameraProperties>(server);
                }
                else
                {
                    var message = Lng.FormattedElem("User '{0}' has no permission to view server and camera properties.", args: permissionManager.CurrentUser);
                    logger.LogError(message);
                    throw new UnauthorizedAccessException(message);
                }
            }
            else if (view.ServersAndCameras.SelectedNode?.Tag is Camera camera)
            {
                if (permissionManager.HasPermission(CameraManagementPermissions.Update))
                {
                    if (ShowDialog<CameraProperties>(camera))
                    {
                        logger.LogInfo(CameraManagementPermissions.Update, "Camera '{0}' has been modified.", camera);
                    }
                }
                else
                {
                    var message = Lng.FormattedElem("User '{0}' has no permission to modify camera.", args: permissionManager.CurrentUser);
                    logger.LogError(message);
                    throw new UnauthorizedAccessException(message);
                }
            }
        }
    }
}

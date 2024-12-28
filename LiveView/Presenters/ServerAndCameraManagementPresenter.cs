using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Services;
using LiveView.Services.VideoServer;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using Mtf.MessageBoxes.Enums;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class ServerAndCameraManagementPresenter : BasePresenter
    {
        private IServerAndCameraManagementView view;
        private readonly IServerRepository<Server> serverRepository;
        private readonly IDatabaseServerRepository<DatabaseServer> databaseServerRepository;
        private readonly ICameraRepository<Camera> cameraRepository;
        private readonly ILogger<ServerAndCameraManagement> logger;
        private readonly PermissionManager permissionManager;

        private const int ServerIconIndex = 1;
        private const int CameraIconIndex = 2;
        private const int UpdateServerIconIndex = 3;
        private const int UpdateCameraIconIndex = 4;
        private const int DeleteServerIconIndex = 5;
        private const int DeleteCameraIconIndex = 6;
        private const int DatabaseServerIconIndex = 7;

        public ServerAndCameraManagementPresenter(FormFactory formFactory,
            IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IServerRepository<Server> serverRepository,
            IDatabaseServerRepository<DatabaseServer> databaseServerRepository, ICameraRepository<Camera> cameraRepository,
            ILogger<ServerAndCameraManagement> logger, PermissionManager permissionManager)
            : base(generalOptionsRepository, formFactory)
        {
            this.serverRepository = serverRepository;
            this.databaseServerRepository = databaseServerRepository;
            this.cameraRepository = cameraRepository;
            this.logger = logger;
            this.permissionManager = permissionManager;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IServerAndCameraManagementView;
        }

        public void CreateNewCameraForm()
        {
            var node = view.GetSelectedItem(view.ServersAndCameras);
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
                        //logger.LogInfo("Camera '{0}' has been modified.", camera);
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
            if (!ShowConfirm("Confirmation", "Are you sure you want to delete this item?", Decide.No))
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
                        logger.LogInfo("Videoserver '{0}' has been deleted.", server);
                    }
                    else
                    {
                        logger.LogError($"User '{0}' has no permission to delete video server.", permissionManager.CurrentUser);
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
                    var camerasInDatabase = cameraRepository.GetWhere(new { ServerId = server.Id });
                    var connectionResult = await VideoServerConnector.ConnectAsync(view.GetSelf() as IVideoServerView, server);
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
                                    throw new NotImplementedException();
                            }
                        }
                    }
                    else
                    {
                        view.ShowError("Connection failed", VideoServerErrorHandler.GetMessage(connectionResult.ErrorCode));
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
            var servers = serverRepository.GetAll();
            var cameras = cameraRepository.GetAll();
            var dbServers = databaseServerRepository.GetAll();

            var videoServerTreeNodes = new List<TreeNode>();
            var dbServerTreeNodes = new List<TreeNode>();
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

            var serversNode = view.ServersAndCameras.Nodes["Servers"];
            serversNode.Nodes.Clear();
            view.AddNodes(serversNode, videoServerTreeNodes);
            var dbServersNode = view.ServersAndCameras.Nodes["DBServers"];
            dbServersNode.Nodes.Clear();
            view.AddNodes(dbServersNode, dbServerTreeNodes);
            view.ExpandAll(serversNode);
            view.ExpandAll(dbServersNode);
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
            view.BtnProperties.Enabled = permissionManager.CurrentUser.HasPermission(ServerManagementPermissions.Update) && serverSelected;
            view.BtnMotionDetection.Enabled = permissionManager.CurrentUser.HasPermission(CameraManagementPermissions.Update) && cameraSelected;
            view.BtnSyncronize.Enabled = permissionManager.CurrentUser.HasPermission(CameraManagementPermissions.Update) && serverSelected;
        }
    }
}

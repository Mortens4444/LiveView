using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;

namespace LiveView.Models.Dependencies
{
    public class ServerAndCameraManagementPresenterDependencies : BasePresenterDependencies
    {
        public ServerAndCameraManagementPresenterDependencies(
            FormFactory formFactory,
            PermissionManager permissionManager,
            IGeneralOptionsRepository<GeneralOption> generalOptionsRepository,
            IDatabaseServerRepository<DatabaseServer> databaseServerRepository,
            IServerRepository<Server> serverRepository,
            ICameraRepository<Camera> cameraRepository,
            ILogger<ServerAndCameraManagement> logger)
            : base(generalOptionsRepository, formFactory)
        {
            PermissionManager = permissionManager;
            DatabaseServerRepository = databaseServerRepository;
            ServerRepository = serverRepository;
            CameraRepository = cameraRepository;
            Logger = logger;
        }

        public PermissionManager PermissionManager { get; private set; }

        public IDatabaseServerRepository<DatabaseServer> DatabaseServerRepository { get; private set; }

        public IServerRepository<Server> ServerRepository { get; private set; }

        public ICameraRepository<Camera> CameraRepository { get; private set; }
        
        public ILogger<ServerAndCameraManagement> Logger { get; private set; }
    }
}

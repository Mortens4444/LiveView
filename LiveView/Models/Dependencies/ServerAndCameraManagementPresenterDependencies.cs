using Database.Interfaces;
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
            PermissionManager<Database.Models.User> permissionManager,
            IGeneralOptionsRepository generalOptionsRepository,
            IDatabaseServerRepository databaseServerRepository,
            IServerRepository serverRepository,
            ICameraRepository cameraRepository,
            ILogger<ServerAndCameraManagement> logger)
            : base(generalOptionsRepository, formFactory)
        {
            PermissionManager = permissionManager;
            DatabaseServerRepository = databaseServerRepository;
            ServerRepository = serverRepository;
            CameraRepository = cameraRepository;
            Logger = logger;
        }

        public PermissionManager<Database.Models.User> PermissionManager { get; private set; }

        public IDatabaseServerRepository DatabaseServerRepository { get; private set; }

        public IServerRepository ServerRepository { get; private set; }

        public ICameraRepository CameraRepository { get; private set; }
        
        public ILogger<ServerAndCameraManagement> Logger { get; private set; }
    }
}

using Database.Interfaces;
using LiveView.Forms;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;

namespace LiveView.Models.Dependencies
{
    public class CameraPropertiesPresenterDependencies : BasePresenterDependencies
    {
        public CameraPropertiesPresenterDependencies(
            FormFactory formFactory,
            PermissionManager<Database.Models.User> permissionManager,
            IGeneralOptionsRepository generalOptionsRepository,
            ICameraRepository cameraRepository,
            ILogger<CameraProperties> logger)
            : base(generalOptionsRepository, formFactory)
        {
            PermissionManager = permissionManager;
            CameraRepository = cameraRepository;
            Logger = logger;
        }

        public PermissionManager<Database.Models.User> PermissionManager { get; private set; }

        public ICameraRepository CameraRepository { get; private set; }

        public ILogger<CameraProperties> Logger { get; private set; }
    }
}

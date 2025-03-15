using Database.Interfaces;
using LiveView.Forms;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;

namespace LiveView.Models.Dependencies
{
    public class SearchCameraUrlDependencies : BasePresenterDependencies
    {
        public SearchCameraUrlDependencies(
            PermissionManager<Database.Models.User> permissionManager,
            IGeneralOptionsRepository generalOptionsRepository,
            IUserRepository userRepository,
            ILogger<SearchCameraUrlForm> logger)
            : base(generalOptionsRepository)
        {
            PermissionManager = permissionManager;
            UserRepository = userRepository;
            Logger = logger;
        }

        public PermissionManager<Database.Models.User> PermissionManager { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public ILogger<SearchCameraUrlForm> Logger { get; private set; }
    }
}

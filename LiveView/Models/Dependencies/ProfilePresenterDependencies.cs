using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;

namespace LiveView.Models.Dependencies
{
    public class ProfilePresenterDependencies : BasePresenterDependencies
    {
        public ProfilePresenterDependencies(
            PermissionManager<Database.Models.User> permissionManager,
            IGeneralOptionsRepository generalOptionsRepository,
            IUserRepository userRepository,
            ILogger<Profile> logger)
            : base(generalOptionsRepository)
        {
            PermissionManager = permissionManager;
            UserRepository = userRepository;
            Logger = logger;
        }

        public PermissionManager<Database.Models.User> PermissionManager { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public ILogger<Profile> Logger { get; private set; }
    }
}

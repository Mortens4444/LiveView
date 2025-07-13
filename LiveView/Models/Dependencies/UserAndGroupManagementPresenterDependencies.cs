using Database.Interfaces;
using LiveView.Core.Services;
using LiveView.Forms;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;

namespace LiveView.Models.Dependencies
{
    public class UserAndGroupManagementPresenterDependencies : BasePresenterDependencies
    {
        public UserAndGroupManagementPresenterDependencies(
            PermissionManager<Database.Models.User> permissionManager,
            FormFactory formfactory,
            IGeneralOptionsRepository generalOptionsRepository,
            IGroupRepository groupRepository,
            IUserRepository userRepository,
            IGroupMembersRepository groupMembersRepository,
            ILogger<UserAndGroupManagement> logger)
            : base(generalOptionsRepository, formfactory)
        {
            PermissionManager = permissionManager;
            GroupRepository = groupRepository;
            UserRepository = userRepository;
            GroupMembersRepository = groupMembersRepository;
            Logger = logger;
        }

        public IGroupRepository GroupRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public PermissionManager<Database.Models.User> PermissionManager { get; private set; }

        public ILogger<UserAndGroupManagement> Logger { get; private set; }

        public IGroupMembersRepository GroupMembersRepository { get; private set; }
    }
}

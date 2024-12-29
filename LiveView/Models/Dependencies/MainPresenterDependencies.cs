using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;

namespace LiveView.Models.Dependencies
{
    public class MainPresenterDependencies : BasePresenterDependencies
    {
        public MainPresenterDependencies(
            PermissionManager permissionManager,
            FormFactory formfactory,
            IGeneralOptionsRepository<GeneralOption> generalOptionsRepository,
            IGroupRepository<Group> groupRepository,
            IUserRepository<User> userRepository,
            IUsersInGroupsRepository<UserGroup> userGroupRepository,
            ILogger<MainForm> logger)
            : base(generalOptionsRepository, formfactory)
        {
            GroupRepository = groupRepository;
            UserRepository = userRepository;
            UserGroupRepository = userGroupRepository;
            Logger = logger;
        }

        public IGroupRepository<Group> GroupRepository { get; private set; }

        public IUserRepository<User> UserRepository { get; private set; }

        public ILogger<MainForm> Logger { get; private set; }
        
        public IUsersInGroupsRepository<UserGroup> UserGroupRepository { get; private set; }
    }
}

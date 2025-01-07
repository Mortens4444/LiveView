using Database.Interfaces;
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
            IDisplayRepository displayRepository,
            IGeneralOptionsRepository generalOptionsRepository,
            IGroupRepository groupRepository,
            IUserRepository userRepository,
            IUsersInGroupsRepository userGroupRepository,
            ILogger<MainForm> logger)
            : base(generalOptionsRepository, formfactory)
        {
            DisplayRepository = displayRepository;
            GroupRepository = groupRepository;
            UserRepository = userRepository;
            UserGroupRepository = userGroupRepository;
            Logger = logger;
        }

        public IDisplayRepository DisplayRepository { get; private set; }

        public IGroupRepository GroupRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public ILogger<MainForm> Logger { get; private set; }
        
        public IUsersInGroupsRepository UserGroupRepository { get; private set; }
    }
}

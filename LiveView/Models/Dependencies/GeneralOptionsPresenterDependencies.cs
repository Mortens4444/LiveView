using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;

namespace LiveView.Models.Dependencies
{
    public class GeneralOptionsPresenterDependencies : BasePresenterDependencies
    {
        public GeneralOptionsPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            ITemplateRepository templateRepository,
            IUserRepository userRepository,
            IGroupRepository groupRepository,
            IUsersInGroupsRepository userGroupRepository,
            PermissionManager<User> permissionManager,
            ILogger<GeneralOptionsForm> logger)
            : base(generalOptionsRepository)
        {
            TemplateRepository = templateRepository;
            UserRepository = userRepository;
            GroupRepository = groupRepository;
            UserGroupRepository = userGroupRepository;
            PermissionManager = permissionManager;
            Logger = logger;
        }

        public ITemplateRepository TemplateRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }
        
        public IGroupRepository GroupRepository { get; private set; }
        
        public IUsersInGroupsRepository UserGroupRepository { get; private set; }

        public ILogger<GeneralOptionsForm> Logger { get; private set; }

        public PermissionManager<User> PermissionManager { get; internal set; }
    }
}

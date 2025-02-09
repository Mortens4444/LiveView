using Database.Interfaces;
using LiveView.Forms;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;
using System;

namespace LiveView.Models.Dependencies
{
    public class MainPresenterDependencies : BasePresenterDependencies
    {
        public MainPresenterDependencies(
            PermissionManager<Database.Models.User> permissionManager,
            FormFactory formfactory,
            IRightRepository rightRepository,
            ICameraRepository cameraRepository,
            IServiceProvider serviceProvider,
            IMapRepository mapRepository,
            IMapObjectRepository mapObjectRepository,
            IDisplayRepository displayRepository,
            IGeneralOptionsRepository generalOptionsRepository,
            IGroupRepository groupRepository,
            IUserRepository userRepository,
            ITemplateRepository templateRepository,
            IUsersInGroupsRepository userGroupRepository,
            IPersonalOptionsRepository personalOptionsRepository,
            IAgentRepository agentRepository,
            IOperationRepository operationRepository,
            IUserEventRepository userEventRepository,
            ILogger<MainForm> logger)
            : base(generalOptionsRepository, formfactory)
        {
            CameraRepository = cameraRepository;
            RightRepository = rightRepository;
            ServiceProvider = serviceProvider;
            DisplayRepository = displayRepository;
            GroupRepository = groupRepository;
            UserRepository = userRepository;
            UserGroupRepository = userGroupRepository;
            PersonalOptionsRepository = personalOptionsRepository;
            PermissionManager = permissionManager;
            MapRepository = mapRepository;
            MapObjectRepository = mapObjectRepository;
            AgentRepository = agentRepository;
            TemplateRepository = templateRepository;
            OperationRepository = operationRepository;
            UserEventRepository = userEventRepository;
            Logger = logger;
        }

        public IAgentRepository AgentRepository { get; private set; }

        public IRightRepository RightRepository { get; private set; }

        public IServiceProvider ServiceProvider { get; private set; }

        public IDisplayRepository DisplayRepository { get; private set; }

        public IGroupRepository GroupRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public IPersonalOptionsRepository PersonalOptionsRepository { get; private set; }

        public ILogger<MainForm> Logger { get; private set; }
        
        public IUsersInGroupsRepository UserGroupRepository { get; private set; }

        public PermissionManager<Database.Models.User> PermissionManager { get; private set; }

        public IMapRepository MapRepository { get; private set; }

        public IMapObjectRepository MapObjectRepository { get; private set; }

        public ITemplateRepository TemplateRepository { get; private set; }

        public IOperationRepository OperationRepository { get; private set; }

        public ICameraRepository CameraRepository { get; private set; }

        public IUserEventRepository UserEventRepository { get; private set; }
    }
}

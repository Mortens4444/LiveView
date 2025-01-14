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
            PermissionManager permissionManager,
            FormFactory formfactory,
            IServiceProvider serviceProvider,
            IMapRepository mapRepository,
            IMapObjectRepository mapObjectRepository,
            IDisplayRepository displayRepository,
            IGeneralOptionsRepository generalOptionsRepository,
            IGroupRepository groupRepository,
            IUserRepository userRepository,
            IUsersInGroupsRepository userGroupRepository,
            IPersonalOptionsRepository personalOptionsRepository,
            ILogger<MainForm> logger)
            : base(generalOptionsRepository, formfactory)
        {
            ServiceProvider = serviceProvider;
            DisplayRepository = displayRepository;
            GroupRepository = groupRepository;
            UserRepository = userRepository;
            UserGroupRepository = userGroupRepository;
            PersonalOptionsRepository = personalOptionsRepository;
            PermissionManager = permissionManager;
            MapRepository = mapRepository;
            MapObjectRepository = mapObjectRepository;
            Logger = logger;
        }

        public IServiceProvider ServiceProvider { get; private set; }

        public IDisplayRepository DisplayRepository { get; private set; }

        public IGroupRepository GroupRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public IPersonalOptionsRepository PersonalOptionsRepository { get; private set; }

        public ILogger<MainForm> Logger { get; private set; }
        
        public IUsersInGroupsRepository UserGroupRepository { get; private set; }

        public PermissionManager PermissionManager { get; private set; }

        public IMapRepository MapRepository { get; private set; }

        public IMapObjectRepository MapObjectRepository { get; private set; }
    }
}

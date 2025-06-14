using Database.Interfaces;
using LiveView.Core.Services;
using LiveView.Forms;
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
            ICameraRepository cameraRepository,
            IServiceProvider serviceProvider,
            IMapRepository mapRepository,
            IMapObjectRepository mapObjectRepository,
            IGeneralOptionsRepository generalOptionsRepository,
            IUserRepository userRepository,
            ITemplateRepository templateRepository,
            IPersonalOptionsRepository personalOptionsRepository,
            IAgentRepository agentRepository,
            IUserEventRepository userEventRepository,
            IVideoSourceRepository videoSourceRepository,
            ITemplateProcessRepository templateProcessRepository,
            ILogger<MainForm> logger)
            : base(generalOptionsRepository, formfactory)
        {
            CameraRepository = cameraRepository;
            ServiceProvider = serviceProvider;
            UserRepository = userRepository;
            PersonalOptionsRepository = personalOptionsRepository;
            PermissionManager = permissionManager;
            MapRepository = mapRepository;
            MapObjectRepository = mapObjectRepository;
            AgentRepository = agentRepository;
            TemplateRepository = templateRepository;
            UserEventRepository = userEventRepository;
            VideoSourceRepository = videoSourceRepository;
            TemplateProcessRepository = templateProcessRepository;
            Logger = logger;
        }
        
        public IVideoSourceRepository VideoSourceRepository { get; private set; }

        public IAgentRepository AgentRepository { get; private set; }

        public IServiceProvider ServiceProvider { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public IPersonalOptionsRepository PersonalOptionsRepository { get; private set; }

        public ILogger<MainForm> Logger { get; private set; }

        public PermissionManager<Database.Models.User> PermissionManager { get; private set; }

        public IMapRepository MapRepository { get; private set; }

        public IMapObjectRepository MapObjectRepository { get; private set; }

        public ITemplateRepository TemplateRepository { get; private set; }

        public ICameraRepository CameraRepository { get; private set; }

        public IUserEventRepository UserEventRepository { get; private set; }

        public ITemplateProcessRepository TemplateProcessRepository { get; private set; }
    }
}

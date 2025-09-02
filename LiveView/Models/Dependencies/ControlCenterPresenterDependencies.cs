using Database.Interfaces;
using LiveView.Core.Interfaces;
using LiveView.Core.Services;
using LiveView.Forms;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;

namespace LiveView.Models.Dependencies
{
    public class ControlCenterPresenterDependencies : BasePresenterDependencies
    {
        public ControlCenterPresenterDependencies(
            IGridRepository gridRepository,
            IGridCameraRepository gridCameraRepository,
            ISequenceGridsRepository sequenceGridsRepository,
            IGeneralOptionsRepository generalOptionsRepository,
            IDisplayRepository displayRepository,
            ITemplateRepository templateRepository,
            ITemplateProcessRepository templateProcessRepository,
            ISequenceRepository sequenceRepository,
            ICameraRepository cameraRepository,
            IAgentRepository agentRepository,
            PermissionManager<Database.Models.User> permissionManager,
            IDisplayManager displayManager,
            FormFactory formFactory,
            ILogger<ControlCenter> logger)
            : base(generalOptionsRepository, formFactory)
        {
            AgentRepository = agentRepository;
            PermissionManager = permissionManager;
            GridRepository = gridRepository;
            GridCameraRepository = gridCameraRepository;
            SequenceGridsRepository = sequenceGridsRepository;
            TemplateRepository = templateRepository;
            TemplateProcessRepository = templateProcessRepository;
            CameraRepository = cameraRepository;
            DisplayManager = displayManager;
            DisplayRepository = displayRepository;
            SequenceRepository = sequenceRepository;
            Logger = logger;
        }

        public PermissionManager<Database.Models.User> PermissionManager { get; private set; }

        public IGridRepository GridRepository { get; private set; }

        public IGridCameraRepository GridCameraRepository { get; private set; }

        public ISequenceGridsRepository SequenceGridsRepository { get; private set; }

        public ITemplateRepository TemplateRepository { get; private set; }

        public ITemplateProcessRepository TemplateProcessRepository { get; private set; }

        public IDisplayRepository DisplayRepository { get; private set; }
        
        public IDisplayManager DisplayManager { get; private set; }
        
        public ICameraRepository CameraRepository { get; private set; }

        public ISequenceRepository SequenceRepository { get; private set; }

        public ILogger<ControlCenter> Logger { get; private set; }

        public IAgentRepository AgentRepository { get; private set; }
    }
}

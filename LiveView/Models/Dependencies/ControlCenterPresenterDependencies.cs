using Database.Interfaces;
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
            IGridInSequenceRepository gridInSequenceRepository,
            IGeneralOptionsRepository generalOptionsRepository,
            IDisplayRepository displayRepository,
            ITemplateRepository templateRepository,
            ITemplateProcessRepository templateProcessRepository,
            ISequenceRepository sequenceRepository,
            ICameraRepository cameraRepository,
            PermissionManager<Database.Models.User> permissionManager,
            DisplayManager displayManager,
            FormFactory formFactory,
            ILogger<ControlCenter> logger)
            : base(generalOptionsRepository, formFactory)
        {
            PermissionManager = permissionManager;
            GridRepository = gridRepository;
            GridCameraRepository = gridCameraRepository;
            GridInSequenceRepository = gridInSequenceRepository;
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

        public IGridInSequenceRepository GridInSequenceRepository { get; private set; }

        public ITemplateRepository TemplateRepository { get; private set; }

        public ITemplateProcessRepository TemplateProcessRepository { get; private set; }

        public IDisplayRepository DisplayRepository { get; private set; }
        
        public DisplayManager DisplayManager { get; private set; }
        
        public ICameraRepository CameraRepository { get; private set; }

        public ISequenceRepository SequenceRepository { get; private set; }

        public ILogger<ControlCenter> Logger { get; private set; }
    }
}

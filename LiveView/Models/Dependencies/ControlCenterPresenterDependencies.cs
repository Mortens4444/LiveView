using Database.Interfaces;
using LiveView.Core.Services;
using LiveView.Forms;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;

namespace LiveView.Models.Dependencies
{
    public class ControlCenterPresenterDependencies : BasePresenterDependencies
    {
        public ControlCenterPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            IDisplayRepository displayRepository,
            ITemplateRepository templateRepository,
            ISequenceRepository sequenceRepository,
            ICameraRepository cameraRepository,
            PermissionManager permissionManager,
            DisplayManager displayManager,
            FormFactory formFactory,
            ILogger<ControlCenter> logger)
            : base(generalOptionsRepository, formFactory)
        {
            PermissionManager = permissionManager;
            TemplateRepository = templateRepository;
            CameraRepository = cameraRepository;
            DisplayManager = displayManager;
            DisplayRepository = displayRepository;
            SequenceRepository = sequenceRepository;
            Logger = logger;
        }

        public PermissionManager PermissionManager { get; private set; }

        public ITemplateRepository TemplateRepository { get; private set; }
        
        public IDisplayRepository DisplayRepository { get; private set; }
        
        public DisplayManager DisplayManager { get; private set; }
        
        public ICameraRepository CameraRepository { get; private set; }

        public ISequenceRepository SequenceRepository { get; private set; }

        public ILogger<ControlCenter> Logger { get; private set; }
    }
}

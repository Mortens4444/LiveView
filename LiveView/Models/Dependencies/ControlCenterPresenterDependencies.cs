using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Services;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class ControlCenterPresenterDependencies : BasePresenterDependencies
    {
        public ControlCenterPresenterDependencies(
            IGeneralOptionsRepository<GeneralOption> generalOptionsRepository,
            IDisplayRepository<Display> displayRepository,
            ITemplateRepository<Template> templateRepository,
            ISequenceRepository<Sequence> sequenceRepository,
            ICameraRepository<Camera> cameraRepository,
            DisplayManager displayManager,
            ILogger<ControlCenter> logger)
            : base(generalOptionsRepository)
        {
            TemplateRepository = templateRepository;
            CameraRepository = cameraRepository;
            DisplayManager = displayManager;
            DisplayRepository = displayRepository;
            SequenceRepository = sequenceRepository;
            Logger = logger;
        }

        public ITemplateRepository<Template> TemplateRepository { get; private set; }
        
        public IDisplayRepository<Display> DisplayRepository { get; private set; }
        
        public DisplayManager DisplayManager { get; private set; }
        
        public ICameraRepository<Camera> CameraRepository { get; private set; }

        public ISequenceRepository<Sequence> SequenceRepository { get; private set; }

        public ILogger<ControlCenter> Logger { get; private set; }
    }
}

using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class AutoCreateWizardPresenterDependencies : BasePresenterDependencies
    {
        public AutoCreateWizardPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            ISequenceRepository sequenceRepository,
            ICameraRepository cameraRepository,
            IGridRepository gridRepository,
            IGridCameraRepository gridCameraRepository,
            ISequenceGridsRepository sequenceGridsRepository,
            ILogger<AutoCreateWizard> logger)
            : base(generalOptionsRepository)
        {
            SequenceRepository = sequenceRepository;
            GridRepository = gridRepository;
            GridCameraRepository = gridCameraRepository;
            SequenceGridsRepository = sequenceGridsRepository;
            CameraRepository = cameraRepository;
            Logger = logger;
        }

        public ISequenceRepository SequenceRepository { get; private set; }

        public ICameraRepository CameraRepository { get; private set; }

        public IGridRepository GridRepository { get; private set; }

        public ILogger<AutoCreateWizard> Logger { get; private set; }

        public IGridCameraRepository GridCameraRepository { get; private set; }

        public ISequenceGridsRepository SequenceGridsRepository { get; private set; }
    }
}

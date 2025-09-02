using Database.Interfaces;
using LiveView.Core.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class AddGridPresenterDependencies : BasePresenterDependencies
    {
        public AddGridPresenterDependencies(
            IDisplayManager displayManager,
            IVideoSourceRepository videoSourceRepository,
            IGeneralOptionsRepository generalOptionsRepository,
            IGridRepository gridRepository,
            IVideoServerRepository videoServerRepository,
            ICameraRepository cameraRepository,
            IGridCameraRepository gridCameraRepository,
            ISequenceRepository sequenceRepository,
            ISequenceGridsRepository sequenceGridsRepository,
            ILogger<AddGrid> logger)
            : base(generalOptionsRepository)
        {
            VideoSourceRepository = videoSourceRepository;
            DisplayManager = displayManager;
            GridRepository = gridRepository;
            VideoServerRepository = videoServerRepository;
            CameraRepository = cameraRepository;
            GridCameraRepository = gridCameraRepository;
            SequenceRepository = sequenceRepository;
            SequenceGridsRepository = sequenceGridsRepository;
            Logger = logger;
        }

        public IDisplayManager DisplayManager { get; private set; }

        public IVideoSourceRepository VideoSourceRepository { get; private set; }

        public IGridRepository GridRepository { get; private set; }

        public IVideoServerRepository VideoServerRepository { get; private set; }

        public ICameraRepository CameraRepository { get; private set; }

        public IGridCameraRepository GridCameraRepository { get; private set; }

        public ISequenceRepository SequenceRepository { get; private set; }

        public ISequenceGridsRepository SequenceGridsRepository { get; private set; }

        public ILogger<AddGrid> Logger { get; private set; }
    }
}

using Database.Interfaces;
using LiveView.Core.Services;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class AddGridPresenterDependencies : BasePresenterDependencies
    {
        public AddGridPresenterDependencies(
            DisplayManager displayManager,
            IVideoSourceRepository videoSourceRepository,
            IGeneralOptionsRepository generalOptionsRepository,
            IGridRepository gridRepository,
            IServerRepository serverRepository,
            ICameraRepository cameraRepository,
            IGridCameraRepository gridCameraRepository,
            ISequenceRepository sequenceRepository,
            IGridInSequenceRepository gridInSequenceRepository,
            ILogger<AddGrid> logger)
            : base(generalOptionsRepository)
        {
            VideoSourceRepository = videoSourceRepository;
            DisplayManager = displayManager;
            GridRepository = gridRepository;
            ServerRepository = serverRepository;
            CameraRepository = cameraRepository;
            GridCameraRepository = gridCameraRepository;
            SequenceRepository = sequenceRepository;
            GridInSequenceRepository = gridInSequenceRepository;
            Logger = logger;
        }

        public DisplayManager DisplayManager { get; private set; }

        public IVideoSourceRepository VideoSourceRepository { get; private set; }

        public IGridRepository GridRepository { get; private set; }

        public IServerRepository ServerRepository { get; private set; }

        public ICameraRepository CameraRepository { get; private set; }

        public IGridCameraRepository GridCameraRepository { get; private set; }

        public ISequenceRepository SequenceRepository { get; private set; }

        public IGridInSequenceRepository GridInSequenceRepository { get; private set; }

        public ILogger<AddGrid> Logger { get; private set; }
    }
}

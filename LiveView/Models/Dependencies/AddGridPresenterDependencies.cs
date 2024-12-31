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
            IGeneralOptionsRepository generalOptionsRepository,
            IGridRepository gridRepository,
            IServerRepository serverRepository,
            ICameraRepository cameraRepository,
            IGridCameraRepository gridCameraRepository,
            ILogger<AddGrid> logger)
            : base(generalOptionsRepository)
        {
            DisplayManager = displayManager;
            GridRepository = gridRepository;
            ServerRepository = serverRepository;
            CameraRepository = cameraRepository;
            GridCameraRepository = gridCameraRepository;
            Logger = logger;
        }

        public DisplayManager DisplayManager { get; private set; }

        public IGridRepository GridRepository { get; private set; }

        public IServerRepository ServerRepository { get; private set; }

        public ICameraRepository CameraRepository { get; private set; }

        public IGridCameraRepository GridCameraRepository { get; private set; }
        
        public ILogger<AddGrid> Logger { get; private set; }
    }
}

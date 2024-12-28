using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Services;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class AddGridPresenterDependencies : BasePresenterDependencies
    {
        public AddGridPresenterDependencies(
            DisplayManager displayManager,
            IGeneralOptionsRepository<GeneralOption> generalOptionsRepository,
            IGridRepository<Grid> gridRepository,
            ICameraRepository<Camera> cameraRepository,
            IGridCameraRepository<GridCamera> gridCameraRepository,
            ILogger<AddGrid> logger)
            : base(generalOptionsRepository)
        {
            DisplayManager = displayManager;
            GridRepository = gridRepository;
            CameraRepository = cameraRepository;
            GridCameraRepository = gridCameraRepository;
            Logger = logger;
        }

        public DisplayManager DisplayManager { get; private set; }

        public IGridRepository<Grid> GridRepository { get; private set; }

        public ICameraRepository<Camera> CameraRepository { get; private set; }

        public IGridCameraRepository<GridCamera> GridCameraRepository { get; private set; }
        
        public ILogger<AddGrid> Logger { get; private set; }
    }
}

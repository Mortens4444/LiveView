using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;

namespace LiveView.Models.Dependencies
{
    public class GridManagerPresenterDependencies : BasePresenterDependencies
    {
        public GridManagerPresenterDependencies(
            FormFactory formFactory,
            IGridRepository<Grid> gridRepository,
            IGridCameraRepository<GridCamera> gridCameraRepository,
            ICameraRepository<Camera> cameraRepository,
            IServerRepository<Server> serverRepository,
            IGeneralOptionsRepository<GeneralOption> generalOptionsRepository,
            ILogger<GridManager> logger)
            : base(generalOptionsRepository, formFactory)
        {
            GridRepository = gridRepository;
            GridCameraRepository = gridCameraRepository;
            ServerRepository = serverRepository;
            CameraRepository = cameraRepository;
            Logger = logger;
        }

        public PermissionManager PermissionManager { get; private set; }

        public IGridRepository<Grid> GridRepository { get; private set; }

        public IGridCameraRepository<GridCamera> GridCameraRepository { get; private set; }

        public IServerRepository<Server> ServerRepository { get; private set; }

        public ICameraRepository<Camera> CameraRepository { get; private set; }
        
        public ILogger<GridManager> Logger { get; private set; }
    }
}

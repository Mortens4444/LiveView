using Database.Interfaces;
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
            IGridRepository gridRepository,
            IGridCameraRepository gridCameraRepository,
            ICameraRepository cameraRepository,
            IServerRepository serverRepository,
            IGeneralOptionsRepository generalOptionsRepository,
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

        public IGridRepository GridRepository { get; private set; }

        public IGridCameraRepository GridCameraRepository { get; private set; }

        public IServerRepository ServerRepository { get; private set; }

        public ICameraRepository CameraRepository { get; private set; }
        
        public ILogger<GridManager> Logger { get; private set; }
    }
}

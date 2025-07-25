using Database.Interfaces;
using LiveView.Core.Services;
using LiveView.Forms;
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
            IVideoServerRepository videoServerRepository,
            IGeneralOptionsRepository generalOptionsRepository,
            ILogger<GridManager> logger)
            : base(generalOptionsRepository, formFactory)
        {
            GridRepository = gridRepository;
            GridCameraRepository = gridCameraRepository;
            VideoServerRepository = videoServerRepository;
            CameraRepository = cameraRepository;
            Logger = logger;
        }

        public PermissionManager<Database.Models.User> permissionManager { get; private set; }

        public IGridRepository GridRepository { get; private set; }

        public IGridCameraRepository GridCameraRepository { get; private set; }

        public IVideoServerRepository VideoServerRepository { get; private set; }

        public ICameraRepository CameraRepository { get; private set; }
        
        public ILogger<GridManager> Logger { get; private set; }
    }
}

using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;

namespace LiveView.Models.Dependencies
{
    public class MapCreatorPresenterDependencies : BasePresenterDependencies
    {
        public MapCreatorPresenterDependencies(
            IServerRepository serverRepository,
            ICameraRepository cameraRepository,
            IGridCameraRepository gridCameraRepository,
            IGeneralOptionsRepository generalOptionsRepository,
            IMapRepository mapRepository,
            IMapObjectRepository mapObjectRepository,
            IObjectInMapRepository objectInMapRepositoryRepository,
            ILogger<MapCreator> logger)
            : base(generalOptionsRepository)
        {
            CameraRepository = cameraRepository;
            GridCameraRepository = gridCameraRepository;
            ServerRepository = serverRepository;
            MapRepository = mapRepository;
            MapObjectRepository = mapObjectRepository;
            ObjectInMapRepository = objectInMapRepositoryRepository;
            Logger = logger;
        }

        public PermissionManager<Database.Models.User> permissionManager { get; private set; }

        public IServerRepository ServerRepository { get; private set; }
        
        public ICameraRepository CameraRepository { get; private set; }

        public IGridCameraRepository GridCameraRepository { get; private set; }

        public IMapRepository MapRepository { get; private set; }

        public IMapObjectRepository MapObjectRepository { get; private set; }

        public IObjectInMapRepository ObjectInMapRepository { get; private set; }
        
        public ILogger<MapCreator> Logger { get; private set; }
    }
}

using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;

namespace LiveView.Models.Dependencies
{
    public class MapCreatorPresenterDependencies : BasePresenterDependencies
    {
        public MapCreatorPresenterDependencies(
            IAgentRepository agentRepository,
            IServerRepository serverRepository,
            ICameraRepository cameraRepository,
            IVideoSourceRepository videoSourceRepository,
            IGridCameraRepository gridCameraRepository,
            IGeneralOptionsRepository generalOptionsRepository,
            IMapRepository mapRepository,
            IMapObjectRepository mapObjectRepository,
            IObjectInMapRepository objectInMapRepositoryRepository,
            ILogger<MapCreator> logger)
            : base(generalOptionsRepository)
        {
            AgentRepository = agentRepository;
            CameraRepository = cameraRepository;
            GridCameraRepository = gridCameraRepository;
            ServerRepository = serverRepository;
            MapRepository = mapRepository;
            MapObjectRepository = mapObjectRepository;
            ObjectInMapRepository = objectInMapRepositoryRepository;
            VideoSourceRepository = videoSourceRepository;
            Logger = logger;
        }

        public PermissionManager<Database.Models.User> permissionManager { get; private set; }

        public IAgentRepository AgentRepository { get; private set; }

        public IServerRepository ServerRepository { get; private set; }
        
        public ICameraRepository CameraRepository { get; private set; }

        public IGridCameraRepository GridCameraRepository { get; private set; }

        public IMapRepository MapRepository { get; private set; }

        public IMapObjectRepository MapObjectRepository { get; private set; }

        public IObjectInMapRepository ObjectInMapRepository { get; private set; }

        public IVideoSourceRepository VideoSourceRepository { get; private set; }

        public ILogger<MapCreator> Logger { get; private set; }
    }
}

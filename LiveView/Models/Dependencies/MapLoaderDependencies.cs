using Database.Interfaces;

namespace LiveView.Models.Dependencies
{
    public class MapLoaderDependencies
    {
        public MapLoaderDependencies(
            IMapRepository mapRepository,
            ICameraRepository cameraRepository,
            IVideoSourceRepository videoSourceRepository,
            IAgentRepository agentRepository,
            IMapObjectRepository mapObjectRepository)
        {
            AgentRepository = agentRepository;
            CameraRepository = cameraRepository;
            MapRepository = mapRepository;
            MapObjectRepository = mapObjectRepository;
            VideoSourceRepository = videoSourceRepository;
        }

        public IAgentRepository AgentRepository { get; private set; }

        public IMapRepository MapRepository { get; private set; }

        public ICameraRepository CameraRepository { get; private set; }

        public IMapObjectRepository MapObjectRepository { get; private set; }
        
        public IVideoSourceRepository VideoSourceRepository { get; private set; }
    }
}

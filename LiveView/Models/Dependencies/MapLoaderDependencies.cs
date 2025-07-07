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
            IActionObjectRepository actionObjectRepository)
        {
            AgentRepository = agentRepository;
            CameraRepository = cameraRepository;
            MapRepository = mapRepository;
            ActionObjectRepository = actionObjectRepository;
            VideoSourceRepository = videoSourceRepository;
        }

        public IAgentRepository AgentRepository { get; private set; }

        public IMapRepository MapRepository { get; private set; }

        public ICameraRepository CameraRepository { get; private set; }

        public IActionObjectRepository ActionObjectRepository { get; private set; }
        
        public IVideoSourceRepository VideoSourceRepository { get; private set; }
    }
}

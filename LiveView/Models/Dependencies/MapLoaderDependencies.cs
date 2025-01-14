using Database.Interfaces;

namespace LiveView.Models.Dependencies
{
    public class MapLoaderDependencies
    {
        public MapLoaderDependencies(
            IMapRepository mapRepository,
            IServerRepository serverRepository,
            ICameraRepository cameraRepository,
            IMapObjectRepository mapObjectRepository)
        {
            ServerRepository = serverRepository;
            CameraRepository = cameraRepository;
            MapRepository = mapRepository;
            MapObjectRepository = mapObjectRepository;
        }

        public IMapRepository MapRepository { get; private set; }

        public IServerRepository ServerRepository { get; private set; }

        public ICameraRepository CameraRepository { get; private set; }

        public IMapObjectRepository MapObjectRepository { get; private set; }
    }
}

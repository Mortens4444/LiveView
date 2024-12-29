using Database.Interfaces;
using Database.Models;

namespace LiveView.Models.Dependencies
{
    public class MapLoaderDependencies
    {
        public MapLoaderDependencies(
            IMapRepository<Map> mapRepository,
            IServerRepository<Server> serverRepository,
            ICameraRepository<Camera> cameraRepository,
            IMapObjectRepository<MapObject> mapObjectRepository,
            IObjectInMapRepository<ObjectInMap> objectInMapRepositoryRepository)
        {
            ServerRepository = serverRepository;
            CameraRepository = cameraRepository;
            MapRepository = mapRepository;
            MapObjectRepository = mapObjectRepository;
            ObjectInMapRepositoryRepository = objectInMapRepositoryRepository;
        }

        public IMapRepository<Map> MapRepository { get; private set; }

        public IServerRepository<Server> ServerRepository { get; private set; }

        public ICameraRepository<Camera> CameraRepository { get; private set; }

        public IMapObjectRepository<MapObject> MapObjectRepository { get; private set; }

        public IObjectInMapRepository<ObjectInMap> ObjectInMapRepositoryRepository { get; private set; }
    }
}

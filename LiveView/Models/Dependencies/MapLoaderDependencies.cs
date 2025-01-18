using Database.Interfaces;

namespace LiveView.Models.Dependencies
{
    public class MapLoaderDependencies
    {
        public MapLoaderDependencies(
            IMapRepository mapRepository,
            ICameraRepository cameraRepository,
            IMapObjectRepository mapObjectRepository)
        {
            CameraRepository = cameraRepository;
            MapRepository = mapRepository;
            MapObjectRepository = mapObjectRepository;
        }

        public IMapRepository MapRepository { get; private set; }

        public ICameraRepository CameraRepository { get; private set; }

        public IMapObjectRepository MapObjectRepository { get; private set; }
    }
}

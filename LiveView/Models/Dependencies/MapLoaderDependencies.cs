using Database.Interfaces;

namespace LiveView.Models.Dependencies
{
    public class MapLoaderDependencies
    {
        public MapLoaderDependencies(
            IMapRepository mapRepository,
            ICameraRepository cameraRepository,
            IGridCameraRepository gridCameraRepository,
            IMapObjectRepository mapObjectRepository)
        {
            CameraRepository = cameraRepository;
            GridCameraRepository = gridCameraRepository;
            MapRepository = mapRepository;
            MapObjectRepository = mapObjectRepository;
        }

        public IMapRepository MapRepository { get; private set; }

        public ICameraRepository CameraRepository { get; private set; }

        public IGridCameraRepository GridCameraRepository { get; internal set; }

        public IMapObjectRepository MapObjectRepository { get; private set; }
    }
}

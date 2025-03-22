using Database.Interfaces;

namespace LiveView.Models.Dependencies
{
    public class MapLoaderDependencies
    {
        public MapLoaderDependencies(
            IMapRepository mapRepository,
            ICameraRepository cameraRepository,
            IGridCameraRepository gridCameraRepository,
            IVideoSourceRepository videoSourceRepository,
            IMapObjectRepository mapObjectRepository)
        {
            CameraRepository = cameraRepository;
            GridCameraRepository = gridCameraRepository;
            MapRepository = mapRepository;
            MapObjectRepository = mapObjectRepository;
            VideoSourceRepository = videoSourceRepository;
        }

        public IMapRepository MapRepository { get; private set; }

        public ICameraRepository CameraRepository { get; private set; }

        public IGridCameraRepository GridCameraRepository { get; private set; }

        public IMapObjectRepository MapObjectRepository { get; private set; }
        
        public IVideoSourceRepository VideoSourceRepository { get; private set; }
    }
}

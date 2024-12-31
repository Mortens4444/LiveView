using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;

namespace LiveView.Models.Dependencies
{
    public class MapCreatorPresenterDependencies : BasePresenterDependencies
    {
        public MapCreatorPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            IMapRepository mapRepository,
            IMapObjectRepository mapObjectRepository,
            IObjectInMapRepository objectInMapRepositoryRepository,
            ILogger<MapCreator> logger)
            : base(generalOptionsRepository)
        {
            MapRepository = mapRepository;
            MapObjectRepository = mapObjectRepository;
            ObjectInMapRepositoryRepository = objectInMapRepositoryRepository;
            Logger = logger;
        }

        public PermissionManager PermissionManager { get; private set; }

        public IMapRepository MapRepository { get; private set; }

        public IMapObjectRepository MapObjectRepository { get; private set; }

        public IObjectInMapRepository ObjectInMapRepositoryRepository { get; private set; }
        
        public ILogger<MapCreator> Logger { get; private set; }
    }
}

using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;

namespace LiveView.Models.Dependencies
{
    public class MapCreatorPresenterDependencies : BasePresenterDependencies
    {
        public MapCreatorPresenterDependencies(
            IGeneralOptionsRepository<GeneralOption> generalOptionsRepository,
            IMapRepository<Map> mapRepository,
            IMapObjectRepository<MapObject> mapObjectRepository,
            IObjectInMapRepository<ObjectInMap> objectInMapRepositoryRepository,
            ILogger<MapCreator> logger)
            : base(generalOptionsRepository)
        {
            MapRepository = mapRepository;
            MapObjectRepository = mapObjectRepository;
            ObjectInMapRepositoryRepository = objectInMapRepositoryRepository;
            Logger = logger;
        }

        public PermissionManager PermissionManager { get; private set; }

        public IMapRepository<Map> MapRepository { get; private set; }

        public IMapObjectRepository<MapObject> MapObjectRepository { get; private set; }

        public IObjectInMapRepository<ObjectInMap> ObjectInMapRepositoryRepository { get; private set; }
        
        public ILogger<MapCreator> Logger { get; private set; }
    }
}

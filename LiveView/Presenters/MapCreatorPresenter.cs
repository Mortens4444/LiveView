using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class MapCreatorPresenter : BasePresenter
    {
        private IMapCreatorView view;
        private readonly IMapRepository<Map> mapRepository;
        private readonly IMapObjectRepository<MapObject> mapObjectRepository;
        private readonly IObjectInMapRepository<ObjectInMap> objectInMapRepositoryRepository;
        private readonly ILogger<MapCreator> logger;

        public MapCreatorPresenter(IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IMapRepository<Map> mapRepository,
            IObjectInMapRepository<ObjectInMap> objectInMapRepositoryRepository, IMapObjectRepository<MapObject> mapObjectRepository,
            ILogger<MapCreator> logger)
            : base(generalOptionsRepository)
        {
            this.mapRepository = mapRepository;
            this.mapObjectRepository = mapObjectRepository;
            this.objectInMapRepositoryRepository = objectInMapRepositoryRepository;
            this.logger = logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IMapCreatorView;
        }

        public void AddObject()
        {
            throw new NotImplementedException();
        }

        public void DeleteMap()
        {
            throw new NotImplementedException();
        }

        public void LoadMapImage()
        {
            throw new NotImplementedException();
        }

        public void SaveMap()
        {
            throw new NotImplementedException();
        }
    }
}

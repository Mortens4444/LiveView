using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
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

        public MapCreatorPresenter(MapCreatorPresenterDependencies mapCreatorPresenterDependencies)
            : base(mapCreatorPresenterDependencies)
        {
            mapRepository = mapCreatorPresenterDependencies.MapRepository;
            mapObjectRepository = mapCreatorPresenterDependencies.MapObjectRepository;
            objectInMapRepositoryRepository = mapCreatorPresenterDependencies.ObjectInMapRepositoryRepository;
            logger = mapCreatorPresenterDependencies.Logger;
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

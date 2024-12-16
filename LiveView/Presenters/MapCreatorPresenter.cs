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
        private readonly IMapCreatorView mapCreatorView;
        private readonly IMapRepository<Map> mapRepository;
        private readonly ILogger<MapCreator> logger;

        public MapCreatorPresenter(IMapCreatorView mapCreatorView, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IMapRepository<Map> mapRepository, ILogger<MapCreator> logger)
            : base(mapCreatorView, generalOptionsRepository)
        {
            this.mapCreatorView = mapCreatorView;
            this.mapRepository = mapRepository;
            this.logger = logger;
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

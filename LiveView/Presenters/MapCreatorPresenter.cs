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
        private readonly IMapCreatorView view;
        private readonly IMapRepository<Map> mapRepository;
        private readonly ILogger<MapCreator> logger;

        public MapCreatorPresenter(IMapCreatorView view, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IMapRepository<Map> mapRepository, ILogger<MapCreator> logger)
            : base(view, generalOptionsRepository)
        {
            this.view = view;
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

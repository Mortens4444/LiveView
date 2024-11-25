using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class MapCreatorPresenter : BasePresenter
    {
        private readonly IMapCreatorView mapCreatorView;
        private readonly IMapRepository<Map> mapRepository;
        private readonly ILogger<MapCreator> logger;

        public MapCreatorPresenter(IMapCreatorView mapCreatorView, IMapRepository<Map> mapRepository, ILogger<MapCreator> logger)
            : base(mapCreatorView)
        {
            this.mapCreatorView = mapCreatorView;
            this.mapRepository = mapRepository;
            this.logger = logger;
        }
    }
}

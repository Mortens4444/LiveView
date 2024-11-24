using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class MapCreatorPresenter
    {
        private readonly IMapCreatorView mapCreatorView;
        private readonly ICameraRepository cameraRepository;

        public MapCreatorPresenter(IMapCreatorView mapCreatorView, ICameraRepository cameraRepository)
        {
            this.mapCreatorView = mapCreatorView;
            this.cameraRepository = cameraRepository;
        }
    }
}

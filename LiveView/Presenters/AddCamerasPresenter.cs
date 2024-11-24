using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class AddCamerasPresenter
    {
        private readonly IAddCamerasView addCamerasView;
        private readonly ICameraRepository cameraRepository;

        public AddCamerasPresenter(IAddCamerasView addCamerasView, ICameraRepository cameraRepository)
        {
            this.addCamerasView = addCamerasView;
            this.cameraRepository = cameraRepository;
        }
    }
}

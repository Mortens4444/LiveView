using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class CameraPropertiesPresenter
    {
        private readonly ICameraPropertiesView cameraPropertiesView;
        private readonly ICameraRepository cameraRepository;

        public CameraPropertiesPresenter(ICameraPropertiesView cameraPropertiesView, ICameraRepository cameraRepository)
        {
            this.cameraPropertiesView = cameraPropertiesView;
            this.cameraRepository = cameraRepository;
        }
    }
}

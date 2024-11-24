using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class CameraMotionOptionsPresenter
    {
        private readonly ICameraMotionOptionsView cameraMotionOptionsView;
        private readonly ICameraRepository cameraRepository;

        public CameraMotionOptionsPresenter(ICameraMotionOptionsView cameraMotionOptionsView, ICameraRepository cameraRepository)
        {
            this.cameraMotionOptionsView = cameraMotionOptionsView;
            this.cameraRepository = cameraRepository;
        }
    }
}

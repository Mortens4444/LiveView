using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class ServerAndCameraPropertiesPresenter
    {
        private readonly IServerAndCameraPropertiesView serverAndCameraPropertiesView;
        private readonly IServerRepository serverRepository;
        private readonly ICameraRepository cameraRepository;

        public ServerAndCameraPropertiesPresenter(IServerAndCameraPropertiesView serverAndCameraPropertiesView, IServerRepository serverRepository, ICameraRepository cameraRepository)
        {
            this.serverAndCameraPropertiesView = serverAndCameraPropertiesView;
            this.serverRepository = serverRepository;
            this.cameraRepository = cameraRepository;
        }
    }
}

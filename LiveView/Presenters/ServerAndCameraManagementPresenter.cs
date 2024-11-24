using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class ServerAndCameraManagementPresenter
    {
        private readonly IServerAndCameraManagementView serverAndCameraManagementView;
        private readonly IServerRepository serverRepository;
        private readonly ICameraRepository cameraRepository;

        public ServerAndCameraManagementPresenter(IServerAndCameraManagementView serverAndCameraManagementView, IServerRepository serverRepository, ICameraRepository cameraRepository)
        {
            this.serverAndCameraManagementView = serverAndCameraManagementView;
            this.serverRepository = serverRepository;
            this.cameraRepository = cameraRepository;
        }
    }
}

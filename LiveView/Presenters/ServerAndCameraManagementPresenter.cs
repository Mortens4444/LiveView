using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Services;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class ServerAndCameraManagementPresenter : BasePresenter
    {
        private readonly IServerAndCameraManagementView serverAndCameraManagementView;
        private readonly IServerRepository<Sequence> serverRepository;
        private readonly ICameraRepository<Camera> cameraRepository;
        private readonly ILogger<ServerAndCameraManagement> logger;

        public ServerAndCameraManagementPresenter(FormFactory formFactory, IServerAndCameraManagementView serverAndCameraManagementView, IServerRepository<Sequence> serverRepository, ICameraRepository<Camera> cameraRepository, ILogger<ServerAndCameraManagement> logger)
            : base(serverAndCameraManagementView, formFactory)
        {
            this.serverAndCameraManagementView = serverAndCameraManagementView;
            this.serverRepository = serverRepository;
            this.cameraRepository = cameraRepository;
            this.logger = logger;
        }

        public void CreateNewCameraForm()
        {
            long serverId = 0;
            ShowForm<AddCameras>(serverId);
        }
    }
}

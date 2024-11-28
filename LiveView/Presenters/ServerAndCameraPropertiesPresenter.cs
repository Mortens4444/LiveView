using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class ServerAndCameraPropertiesPresenter : BasePresenter
    {
        private readonly IServerAndCameraPropertiesView serverAndCameraPropertiesView;
        private readonly IServerRepository<Server> serverRepository;
        private readonly ICameraRepository<Camera> cameraRepository;
        private readonly ILogger<ServerAndCameraProperties> logger;

        public ServerAndCameraPropertiesPresenter(IServerAndCameraPropertiesView serverAndCameraPropertiesView, IServerRepository<Server> serverRepository, ICameraRepository<Camera> cameraRepository, ILogger<ServerAndCameraProperties> logger)
            : base(serverAndCameraPropertiesView)
        {
            this.serverAndCameraPropertiesView = serverAndCameraPropertiesView;
            this.serverRepository = serverRepository;
            this.cameraRepository = cameraRepository;
            this.logger = logger;
        }
    }
}

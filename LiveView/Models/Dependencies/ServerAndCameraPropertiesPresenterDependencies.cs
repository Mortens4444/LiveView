using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class ServerAndCameraPropertiesPresenterDependencies : BasePresenterDependencies
    {
        public ServerAndCameraPropertiesPresenterDependencies(
            IGeneralOptionsRepository<GeneralOption> generalOptionsRepository,
            IServerRepository<Server> serverRepository,
            ICameraRepository<Camera> cameraRepository,
            ILogger<ServerAndCameraProperties> logger)
            : base(generalOptionsRepository)
        {
            ServerRepository = serverRepository;
            CameraRepository = cameraRepository;
            Logger = logger;
        }

        public IServerRepository<Server> ServerRepository { get; private set; }

        public ICameraRepository<Camera> CameraRepository { get; private set; }
        
        public ILogger<ServerAndCameraProperties> Logger { get; private set; }
    }
}

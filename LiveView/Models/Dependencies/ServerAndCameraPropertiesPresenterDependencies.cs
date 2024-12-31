using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class ServerAndCameraPropertiesPresenterDependencies : BasePresenterDependencies
    {
        public ServerAndCameraPropertiesPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            IServerRepository serverRepository,
            ICameraRepository cameraRepository,
            ILogger<ServerAndCameraProperties> logger)
            : base(generalOptionsRepository)
        {
            ServerRepository = serverRepository;
            CameraRepository = cameraRepository;
            Logger = logger;
        }

        public IServerRepository ServerRepository { get; private set; }

        public ICameraRepository CameraRepository { get; private set; }
        
        public ILogger<ServerAndCameraProperties> Logger { get; private set; }
    }
}

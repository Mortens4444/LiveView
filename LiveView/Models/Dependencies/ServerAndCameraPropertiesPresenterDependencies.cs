using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class ServerAndCameraPropertiesPresenterDependencies : BasePresenterDependencies
    {
        public ServerAndCameraPropertiesPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            IVideoServerRepository videoServerRepository,
            ICameraRepository cameraRepository,
            ILogger<ServerAndCameraProperties> logger)
            : base(generalOptionsRepository)
        {
            VideoServerRepository = videoServerRepository;
            CameraRepository = cameraRepository;
            Logger = logger;
        }

        public IVideoServerRepository VideoServerRepository { get; private set; }

        public ICameraRepository CameraRepository { get; private set; }
        
        public ILogger<ServerAndCameraProperties> Logger { get; private set; }
    }
}

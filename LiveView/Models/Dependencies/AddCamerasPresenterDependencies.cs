using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class AddCamerasPresenterDependencies : BasePresenterDependencies
    {
        public AddCamerasPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            ICameraRepository cameraRepository,
            IServerRepository serverRepository,
            ILogger<AddCameras> logger)
            : base(generalOptionsRepository)
        {
            ServerRepository = serverRepository;
            CameraRepository = cameraRepository;
            Logger = logger;
        }

        public IServerRepository ServerRepository { get; private set; }

        public ICameraRepository CameraRepository { get; private set; }
        
        public ILogger<AddCameras> Logger { get; private set; }
    }
}

using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class CameraMotionOptionsPresenterDependencies : BasePresenterDependencies
    {
        public CameraMotionOptionsPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            IServerRepository serverRepository,
            ICameraRepository cameraRepository,
            ILogger<CameraMotionSettings> logger)
            : base(generalOptionsRepository)
        {
            ServerRepository = serverRepository;
            CameraRepository = cameraRepository;
            Logger = logger;
        }
        
        public IServerRepository ServerRepository { get; private set; }

        public ICameraRepository CameraRepository { get; private set; }

        public ILogger<CameraMotionSettings> Logger { get; private set; }
    }
}

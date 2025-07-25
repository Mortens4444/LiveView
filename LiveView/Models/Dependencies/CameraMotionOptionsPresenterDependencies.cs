using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class CameraMotionOptionsPresenterDependencies : BasePresenterDependencies
    {
        public CameraMotionOptionsPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            IVideoServerRepository videoServerRepository,
            ICameraRepository cameraRepository,
            ILogger<CameraMotionSettings> logger)
            : base(generalOptionsRepository)
        {
            VideoServerRepository = videoServerRepository;
            CameraRepository = cameraRepository;
            Logger = logger;
        }
        
        public IVideoServerRepository VideoServerRepository { get; private set; }

        public ICameraRepository CameraRepository { get; private set; }

        public ILogger<CameraMotionSettings> Logger { get; private set; }
    }
}

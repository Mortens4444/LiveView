using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class SynchronViewPresenterDependencies : BasePresenterDependencies
    {
        public SynchronViewPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            ICameraRepository cameraRepository,
            IVideoServerRepository videoServerRepository,
            ILogger<SynchronView> logger)
            : base(generalOptionsRepository)
        {
            CameraRepository = cameraRepository;
            VideoServerRepository = videoServerRepository;
            Logger = logger;
        }

        public ICameraRepository CameraRepository { get; private set; }
        
        public IVideoServerRepository VideoServerRepository { get; private set; }

        public ILogger<SynchronView> Logger { get; private set; }
    }
}

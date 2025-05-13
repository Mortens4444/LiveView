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
            IServerRepository serverRepository,
            ILogger<SynchronView> logger)
            : base(generalOptionsRepository)
        {
            CameraRepository = cameraRepository;
            ServerRepository = serverRepository;
            Logger = logger;
        }

        public ICameraRepository CameraRepository { get; private set; }
        
        public IServerRepository ServerRepository { get; private set; }

        public ILogger<SynchronView> Logger { get; private set; }
    }
}

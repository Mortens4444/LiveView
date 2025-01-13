using Database.Interfaces;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class SyncronViewPresenterDependencies : BasePresenterDependencies
    {
        public SyncronViewPresenterDependencies(
            IGeneralOptionsRepository generalOptionsRepository,
            ICameraRepository cameraRepository,
            IServerRepository serverRepository,
            ILogger<SyncronView> logger)
            : base(generalOptionsRepository)
        {
            CameraRepository = cameraRepository;
            ServerRepository = serverRepository;
            Logger = logger;
        }

        public ICameraRepository CameraRepository { get; private set; }
        
        public IServerRepository ServerRepository { get; internal set; }

        public ILogger<SyncronView> Logger { get; private set; }
    }
}

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
            ILogger<SyncronView> logger)
            : base(generalOptionsRepository)
        {
            CameraRepository = cameraRepository;
            Logger = logger;
        }

        public ICameraRepository CameraRepository { get; private set; }
        
        public ILogger<SyncronView> Logger { get; private set; }
    }
}

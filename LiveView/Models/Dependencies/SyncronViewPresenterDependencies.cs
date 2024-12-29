using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using Microsoft.Extensions.Logging;

namespace LiveView.Models.Dependencies
{
    public class SyncronViewPresenterDependencies : BasePresenterDependencies
    {
        public SyncronViewPresenterDependencies(
            IGeneralOptionsRepository<GeneralOption> generalOptionsRepository,
            ICameraRepository<Camera> cameraRepository,
            ILogger<SyncronView> logger)
            : base(generalOptionsRepository)
        {
            CameraRepository = cameraRepository;
            Logger = logger;
        }

        public ICameraRepository<Camera> CameraRepository { get; private set; }
        
        public ILogger<SyncronView> Logger { get; private set; }
    }
}

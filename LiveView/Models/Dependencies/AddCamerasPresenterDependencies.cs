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
            IVideoServerRepository videoServerRepository,
            ILogger<AddCameras> logger)
            : base(generalOptionsRepository)
        {
            VideoServerRepository = videoServerRepository;
            CameraRepository = cameraRepository;
            Logger = logger;
        }

        public IVideoServerRepository VideoServerRepository { get; private set; }

        public ICameraRepository CameraRepository { get; private set; }
        
        public ILogger<AddCameras> Logger { get; private set; }
    }
}

using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class CameraPropertiesPresenter : BasePresenter
    {
        private readonly ICameraPropertiesView cameraPropertiesView;
        private readonly ICameraRepository<Camera> cameraRepository;
        private readonly ILogger<CameraProperties> logger;

        public CameraPropertiesPresenter(ICameraPropertiesView cameraPropertiesView, ICameraRepository<Camera> cameraRepository, ILogger<CameraProperties> logger)
            : base(cameraPropertiesView)
        {
            this.cameraPropertiesView = cameraPropertiesView;
            this.cameraRepository = cameraRepository;
            this.logger = logger;
        }
    }
}

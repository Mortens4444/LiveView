using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class AddCamerasPresenter : BasePresenter
    {
        private readonly IAddCamerasView addCamerasView;
        private readonly ICameraRepository<Camera> cameraRepository;
        private readonly ILogger<AddCameras> logger;

        public AddCamerasPresenter(IAddCamerasView addCamerasView, ICameraRepository<Camera> cameraRepository, ILogger<AddCameras> logger)
            : base(addCamerasView)
        {
            this.addCamerasView = addCamerasView;
            this.cameraRepository = cameraRepository;
            this.logger = logger;
        }
    }
}

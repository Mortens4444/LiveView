using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class CameraPropertiesPresenter : BasePresenter
    {
        private readonly ICameraPropertiesView view;
        private readonly ICameraRepository<Camera> cameraRepository;
        private readonly ILogger<CameraProperties> logger;

        public CameraPropertiesPresenter(ICameraPropertiesView view, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ICameraRepository<Camera> cameraRepository, ILogger<CameraProperties> logger)
            : base(view, generalOptionsRepository)
        {
            this.view = view;
            this.cameraRepository = cameraRepository;
            this.logger = logger;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }
    }
}

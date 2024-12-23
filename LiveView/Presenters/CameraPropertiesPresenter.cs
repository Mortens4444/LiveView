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
        private ICameraPropertiesView view;
        private readonly ICameraRepository<Camera> cameraRepository;
        private readonly ILogger<CameraProperties> logger;

        public CameraPropertiesPresenter(IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ICameraRepository<Camera> cameraRepository, ILogger<CameraProperties> logger)
            : base(generalOptionsRepository)
        {
            this.cameraRepository = cameraRepository;
            this.logger = logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as ICameraPropertiesView;
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

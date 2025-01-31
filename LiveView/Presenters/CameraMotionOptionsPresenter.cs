using Database.Interfaces;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class CameraMotionOptionsPresenter : BasePresenter
    {
        private ICameraMotionSettingsView view;
        private readonly ICameraRepository cameraRepository;
        private readonly ILogger<CameraMotionSettings> logger;

        public CameraMotionOptionsPresenter(IGeneralOptionsRepository generalOptionsRepository, ICameraRepository cameraRepository, ILogger<CameraMotionSettings> logger)
            : base(generalOptionsRepository)
        {
            this.cameraRepository = cameraRepository;
            this.logger = logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as ICameraMotionSettingsView;
        }

        public void SaveSettings()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }
    }
}

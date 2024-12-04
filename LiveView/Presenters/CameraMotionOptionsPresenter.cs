using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class CameraMotionOptionsPresenter : BasePresenter
    {
        private readonly ICameraMotionOptionsView cameraMotionOptionsView;
        private readonly ICameraRepository<Camera> cameraRepository;
        private readonly ILogger<CameraMotionOptions> logger;

        public CameraMotionOptionsPresenter(ICameraMotionOptionsView cameraMotionOptionsView, ICameraRepository<Camera> cameraRepository, ILogger<CameraMotionOptions> logger)
            : base(cameraMotionOptionsView)
        {
            this.cameraMotionOptionsView = cameraMotionOptionsView;
            this.cameraRepository = cameraRepository;
            this.logger = logger;
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

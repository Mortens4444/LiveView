using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class SyncronViewPresenter : BasePresenter
    {
        private ISyncronViewView view;
        private readonly ICameraRepository<Camera> cameraRepository;
        private readonly ILogger<SyncronView> logger;

        public SyncronViewPresenter(IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ICameraRepository<Camera> cameraRepository, ILogger<SyncronView> logger)
            : base(generalOptionsRepository)
        {
            this.cameraRepository = cameraRepository;
            this.logger = logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as ISyncronViewView;
        }

        public void Goto()
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Play()
        {
            throw new NotImplementedException();
        }

        public void StepBack()
        {
            throw new NotImplementedException();
        }

        public void StepNext()
        {
            throw new NotImplementedException();
        }

        public void ConnectToCamera()
        {
            throw new NotImplementedException();
        }

        public void SetSpeed()
        {
            throw new NotImplementedException();
        }
    }
}

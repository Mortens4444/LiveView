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
        private readonly ISyncronViewView syncronViewView;
        private readonly ICameraRepository<Camera> cameraRepository;
        private readonly ILogger<SyncronView> logger;

        public SyncronViewPresenter(ISyncronViewView syncronViewView, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ICameraRepository<Camera> cameraRepository, ILogger<SyncronView> logger)
            : base(syncronViewView, generalOptionsRepository)
        {
            this.syncronViewView = syncronViewView;
            this.cameraRepository = cameraRepository;
            this.logger = logger;
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

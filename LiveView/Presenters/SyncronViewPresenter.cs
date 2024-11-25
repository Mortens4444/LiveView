using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class SyncronViewPresenter : BasePresenter
    {
        private readonly ISyncronViewView syncronViewView;
        private readonly ICameraRepository<Camera> cameraRepository;
        private readonly ILogger<SyncronView> logger;

        public SyncronViewPresenter(ISyncronViewView syncronViewView, ICameraRepository<Camera> cameraRepository, ILogger<SyncronView> logger)
            : base(syncronViewView)
        {
            this.syncronViewView = syncronViewView;
            this.cameraRepository = cameraRepository;
            this.logger = logger;
        }
    }
}

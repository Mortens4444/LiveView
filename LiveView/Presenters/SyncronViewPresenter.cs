using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class SyncronViewPresenter
    {
        private readonly ISyncronViewView syncronViewView;
        private readonly ICameraRepository cameraRepository;

        public SyncronViewPresenter(ISyncronViewView syncronViewView, ICameraRepository cameraRepository)
        {
            this.syncronViewView = syncronViewView;
            this.cameraRepository = cameraRepository;
        }
    }
}

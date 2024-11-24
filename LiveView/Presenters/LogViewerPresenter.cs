using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class LogViewerPresenter
    {
        private readonly ILogViewerView logViewerView;
        private readonly ICameraRepository cameraRepository;

        public LogViewerPresenter(ILogViewerView logViewerView, ICameraRepository cameraRepository)
        {
            this.logViewerView = logViewerView;
            this.cameraRepository = cameraRepository;
        }
    }
}

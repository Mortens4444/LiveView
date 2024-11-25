using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class LogViewerPresenter : BasePresenter
    {
        private readonly ILogViewerView logViewerView;
        private readonly ILogRepository<Log> logRepository;
        private readonly ILogger<LogViewer> logger;

        public LogViewerPresenter(ILogViewerView logViewerView, ILogRepository<Log> logRepository, ILogger<LogViewer> logger)
            : base(logViewerView)
        {
            this.logViewerView = logViewerView;
            this.logRepository = logRepository;
            this.logger = logger;
        }
    }
}

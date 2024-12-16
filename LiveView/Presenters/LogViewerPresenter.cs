using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class LogViewerPresenter : BasePresenter
    {
        private readonly ILogViewerView logViewerView;
        private readonly ILogRepository<Log> logRepository;
        private readonly ILogger<LogViewer> logger;

        public LogViewerPresenter(ILogViewerView logViewerView, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogRepository<Log> logRepository, ILogger<LogViewer> logger)
            : base(logViewerView, generalOptionsRepository)
        {
            this.logViewerView = logViewerView;
            this.logRepository = logRepository;
            this.logger = logger;
        }

        public void DeleteAllLogs()
        {
            throw new NotImplementedException();
        }

        public void GetLogs()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }
    }
}

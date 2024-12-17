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
        private readonly ILogViewerView view;
        private readonly ILogRepository<Log> logRepository;
        private readonly ILogger<LogViewer> logger;

        public LogViewerPresenter(ILogViewerView view, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogRepository<Log> logRepository, ILogger<LogViewer> logger)
            : base(view, generalOptionsRepository)
        {
            this.view = view;
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

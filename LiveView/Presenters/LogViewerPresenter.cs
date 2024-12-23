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
        private ILogViewerView view;
        private readonly ILogRepository<LogEntry> logRepository;
        private readonly ILogger<LogViewer> logger;

        public LogViewerPresenter(IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogRepository<LogEntry> logRepository, ILogger<LogViewer> logger)
            : base(generalOptionsRepository)
        {
            this.logRepository = logRepository;
            this.logger = logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as ILogViewerView;
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

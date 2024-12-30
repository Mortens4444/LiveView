using Database.Enums;
using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class LogViewerPresenter : BasePresenter
    {
        private ILogViewerView view;
        private readonly ILogRepository<LogEntry> logRepository;
        private readonly ReadOnlyCollection<User> users;
        private readonly ILogger<LogViewer> logger;
        private readonly int currentUserId;

        public LogViewerPresenter(LogViewerPresenterDependencies logViewerPresenterDependencies)
            : base(logViewerPresenterDependencies)
        {
            currentUserId = logViewerPresenterDependencies.PermissionManager.CurrentUser.Id;
            logRepository = logViewerPresenterDependencies.LogRepository;
            logger = logViewerPresenterDependencies.Logger;
            users = logViewerPresenterDependencies.UserRepository.SelectAll();
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as ILogViewerView;
        }

        public void DeleteAllLogs()
        {
            logRepository.DeleteAll();
            //logger.LogInfo();
            logRepository.Insert(new LogEntry
            {
                Date = DateTime.UtcNow,
                UserId = currentUserId,
                LanguageElementId = (int)LogEntryType.AllLogEntryDeleted,
                OperationId = (int)LogEntryType.AllLogEntryDeleted
            });
        }

        public void GetLogs()
        {
            var filter = view.GetLogEntryFilter();
            view.ClearLogItems();
            var entries = logRepository.SelectWhere(filter);
            foreach (var entry in entries)
            {
                var item = ToListViewItem(entry);
                view.AddLogEntry(item);
            }
        }

        public override void Load()
        {
            GetLogs();
        }

        private ListViewItem ToListViewItem(LogEntry entry)
        {
            var result = new ListViewItem(Lng.Elem(entry.LogType.ToString()));
            result.SubItems.Add(entry.Date.ToLocalTime().ToString());
            result.SubItems.Add(users.FirstOrDefault(user => user.Id == entry.UserId)?.Username ?? String.Empty);
            result.SubItems.Add("Code");
            result.SubItems.Add(entry.LanguageElementId.ToString());
            result.SubItems.Add(entry.OtherInformation);
            return result;
        }
    }
}

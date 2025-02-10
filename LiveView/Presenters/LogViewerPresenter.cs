using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService;
using Mtf.MessageBoxes.Enums;
using Mtf.Permissions.Enums;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace LiveView.Presenters
{
    public class LogViewerPresenter : BasePresenter
    {
        private ILogViewerView view;
        private readonly ReadOnlyCollection<Operation> operations;
        private readonly ILogRepository logRepository;
        private readonly ReadOnlyCollection<User> users;
        private readonly ILogger<LogViewer> logger;

        public LogViewerPresenter(LogViewerPresenterDependencies dependencies)
            : base(dependencies)
        {
            operations = dependencies.OperationRepository.SelectAll();
            logRepository = dependencies.LogRepository;
            logger = dependencies.Logger;
            users = dependencies.UserRepository.SelectAll();
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as ILogViewerView;
        }

        public void DeleteAllLogs()
        {
            if (!ShowConfirm("Are you sure you want to delete item(s)?", Decide.No))
            {
                return;
            }

            logRepository.DeleteAll();
            logger.LogInfo(LogManagementPermissions.Delete, "All log entries has been deleted.");
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
            if (entry.OperationId.HasValue)
            {
                var operation = operations.First(o => o.Id == entry.OperationId);
                result.SubItems.Add($"{Lng.Elem(operation.PermissionGroup.Replace("ManagementPermissions", String.Empty))} {Lng.Elem(operation.PermissionValue)}");
            }
            else
            {
                result.SubItems.Add(String.Empty);
            }
            result.SubItems.Add(Lng.Elem(entry.OtherInformation));
            return result;
        }
    }
}

using Database.Enums;
using Database.Models;
using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class LogViewer : BaseView, ILogViewerView
    {
        private LogViewerPresenter presenter;

        public LogViewer(IServiceProvider serviceProvider) : base(serviceProvider, typeof(LogViewerPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        [RequirePermission(LogManagementPermissions.Select)]
        private void LogViewer_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as LogViewerPresenter;
            permissionManager.EnsurePermissions();
            presenter.Load();
        }

        [RequirePermission(LogManagementPermissions.Select)]
        private void BtnGetLogs_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.GetLogs();
        }

        [RequirePermission(LogManagementPermissions.Delete)]
        private void BtnDeleteAllLogs_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.DeleteAllLogs();
        }

        public LogEntryFilter GetLogEntryFilter()
        {
            return new LogEntryFilter
            {
                From = new DateTimeOffset(dtpFrom.Value, new TimeSpan((int)nudFromHour.Value, (int)nudFromMinutes.Value, 0)),
                To = new DateTimeOffset(dtpTo.Value, new TimeSpan((int)nudToHour.Value, (int)nudToMinutes.Value, 0)),
                LogType = rbAll.Checked ? LogType.Any : rbOperations.Checked ? LogType.Operation : rbEvents.Checked ? LogType.Event : LogType.Error,
                MaxRows = (ushort)nudMaxRows.Value,
                MessagePart = cbMessagePart.Text,
                OtherInformationPart = tbOtherInformationPart.Text,
                Offset = 0
            };
        }

        public void AddLogEntry(ListViewItem item)
        {
            lvOperationsEventsAndErrors.Items.Add(item);
        }

        public void ClearLogItems()
        {
            lvOperationsEventsAndErrors.Items.Clear();
        }
    }
}

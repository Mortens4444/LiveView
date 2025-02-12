using Database.Enums;
using Database.Models;
using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.Controls;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;

namespace LiveView.Forms
{
    public partial class LogViewer : BaseView, ILogViewerView
    {
        private LogViewerPresenter presenter;

        public MtfListView LvOperationsEventsAndErrors => lvOperationsEventsAndErrors;

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
            var fromDate = dtpFrom.Value.ToUniversalTime();
            var toDate = dtpTo.Value.ToUniversalTime();
            return new LogEntryFilter
            {
                From = new DateTime(fromDate.Year, fromDate.Month, fromDate.Day, (int)nudFromHour.Value, (int)nudFromMinutes.Value, 0),
                To = new DateTime(toDate.Year, toDate.Month, toDate.Day, (int)nudToHour.Value, (int)nudToMinutes.Value, 59),
                LogType = (int)(rbAll.Checked ? LogType.Any : rbOperations.Checked ? LogType.Operation : rbEvents.Checked ? LogType.Event : LogType.Error),
                MaxRows = (int)nudMaxRows.Value,
                OtherInformationPart = tbOtherInformationPart.Text,
                UserId = 0,
                Offset = 0
            };
        }

        [RequirePermission(LogManagementPermissions.Select)]
        private void TsmiCopyToClipboard_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.CopyToClipboard();
        }
    }
}

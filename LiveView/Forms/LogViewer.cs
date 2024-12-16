using Database.Interfaces;
using Database.Models;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;

namespace LiveView.Forms
{
    public partial class LogViewer : BaseView, ILogViewerView
    {
        private readonly LogViewerPresenter presenter;

        public LogViewer(PermissionManager permissionManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<LogViewer> logger, ILogRepository<Log> logRepository)
            : base(permissionManager)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            presenter = new LogViewerPresenter(this, generalOptionsRepository, logRepository, logger);
            SetPresenter(presenter);

            Translator.Translate(this);
        }

        [RequirePermission(LogManagementPermissions.Select)]
        private void LogViewer_Shown(object sender, EventArgs e)
        {
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
    }
}

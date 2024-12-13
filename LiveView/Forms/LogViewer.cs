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
        private readonly LogViewerPresenter logViewerPresenter;
        private readonly PermissionManager permissionManager;

        public LogViewer(PermissionManager permissionManager, ILogger<LogViewer> logger, ILogRepository<Log> logRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            logViewerPresenter = new LogViewerPresenter(this, logRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(LogManagementPermissions.Select)]
        private void LogViewer_Shown(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            logViewerPresenter.Load();
        }

        [RequirePermission(LogManagementPermissions.Select)]
        private void BtnGetLogs_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            logViewerPresenter.GetLogs();
        }

        [RequirePermission(LogManagementPermissions.Delete)]
        private void BtnDeleteAllLogs_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            logViewerPresenter.DeleteAllLogs();
        }
    }
}

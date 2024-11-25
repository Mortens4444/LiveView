using Database.Interfaces;
using Database.Models;
using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class LogViewer : Form, ILogViewerView
    {
        private readonly LogViewerPresenter logViewerPresenter;

        public LogViewer(PermissionManager permissionManager, ILogger<LogViewer> logger, ILogRepository<Log> logRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            logViewerPresenter = new LogViewerPresenter(this, logRepository, logger);

            Translator.Translate(this);
        }
    }
}

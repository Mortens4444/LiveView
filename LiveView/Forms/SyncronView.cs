using Database.Interfaces;
using Database.Models;
using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;

namespace LiveView.Forms
{
    public partial class SyncronView : BaseView, ISyncronViewView
    {
        private readonly SyncronViewPresenter syncronViewPresenter;
        private readonly PermissionManager permissionManager;

        public SyncronView(PermissionManager permissionManager, ILogger<SyncronView> logger, ICameraRepository<Camera> cameraRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            syncronViewPresenter = new SyncronViewPresenter(this, cameraRepository, logger);

            Translator.Translate(this);
        }
    }
}

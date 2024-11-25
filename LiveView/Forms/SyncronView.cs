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
    public partial class SyncronView : Form, ISyncronViewView
    {
        private readonly SyncronViewPresenter syncronViewPresenter;

        public SyncronView(PermissionManager permissionManager, ILogger<SyncronView> logger, ICameraRepository<Camera> cameraRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            syncronViewPresenter = new SyncronViewPresenter(this, cameraRepository, logger);

            Translator.Translate(this);
        }
    }
}

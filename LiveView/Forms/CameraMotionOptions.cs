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
    public partial class CameraMotionOptions : BaseView, ICameraMotionOptionsView
    {
        private readonly CameraMotionOptionsPresenter presenter;

        public CameraMotionOptions(PermissionManager permissionManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<CameraMotionOptions> logger, ICameraRepository<Camera> cameraRepository)
             : base(permissionManager)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            presenter = new CameraMotionOptionsPresenter(this, generalOptionsRepository, cameraRepository, logger);
            SetPresenter(presenter);

            Translator.Translate(this);
        }

        [RequirePermission(CameraManagementPermissions.MotionPopupSettings)]
        private void BtnChange_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.SaveSettings();
        }

        private void CameraMotionOptions_Shown(object sender, EventArgs e)
        {
            presenter.Load();
        }
    }
}

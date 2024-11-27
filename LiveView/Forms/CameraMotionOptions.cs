using Database.Interfaces;
using Database.Models;
using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class CameraMotionOptions : Form, ICameraMotionOptionsView
    {
        private readonly CameraMotionOptionsPresenter cameraMotionOptionsPresenter;
        private readonly PermissionManager permissionManager;

        public CameraMotionOptions(PermissionManager permissionManager, ILogger<CameraMotionOptions> logger, ICameraRepository<Camera> cameraRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            cameraMotionOptionsPresenter = new CameraMotionOptionsPresenter(this, cameraRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(CameraManagementPermissions.MotionPopupSettings)]
        private void Btn_Change_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }
    }
}

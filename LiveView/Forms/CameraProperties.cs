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

namespace LiveView.Forms
{
    public partial class CameraProperties : BaseView, ICameraPropertiesView
    {
        private readonly CameraPropertiesPresenter cameraPropertiesPresenter;
        private readonly PermissionManager permissionManager;

        public CameraProperties(PermissionManager permissionManager, ILogger<CameraProperties> logger, ICameraRepository<Camera> cameraRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            cameraPropertiesPresenter = new CameraPropertiesPresenter(this, cameraRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(CameraManagementPermissions.Update)]
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            cameraPropertiesPresenter.CloseForm();
        }
    }
}

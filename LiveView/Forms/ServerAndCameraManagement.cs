using Database.Interfaces;
using Database.Models;
using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Services;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class ServerAndCameraManagement : Form, IServerAndCameraManagementView
    {
        private readonly ServerAndCameraManagementPresenter serverAndCameraManagementPresenter;

        public ServerAndCameraManagement(PermissionManager permissionManager, ILogger<ServerAndCameraManagement> logger, FormFactory formFactory, IServerRepository<Sequence> serverRepository, ICameraRepository<Camera> cameraRepository)
        {
            InitializeComponent();

            btn_NewCamera.Tag = "Btn_NewCamera_Click";
            permissionManager.ApplyPermissionsOnControls(this);

            serverAndCameraManagementPresenter = new ServerAndCameraManagementPresenter(formFactory, this, serverRepository, cameraRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(CameraManagementPermissions.Create)]
        private void Btn_NewCamera_Click(object sender, EventArgs e)
        {
            serverAndCameraManagementPresenter.CreateNewCameraForm();
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            serverAndCameraManagementPresenter.CloseForm();
        }
    }
}

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
    public partial class AddGroup : BaseView, IAddGroupView
    {
        private readonly AddGroupPresenter presenter;

        public AddGroup(PermissionManager permissionManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<AddGroup> logger, IGroupRepository<Group> groupRepository) : base(permissionManager)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            presenter = new AddGroupPresenter(this, generalOptionsRepository, groupRepository, logger);
            SetPresenter(presenter);

            Translator.Translate(this);
        }

        [RequirePermission(GroupManagementPermissions.Create)]
        [RequirePermission(GroupManagementPermissions.Update)]
        private void BtnCreateOrModifyGroup_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.CreateOrModifyGroup();
        }

        [RequirePermission(EventManagementPermissions.Create)]
        private void BtnCreateEvent_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.CreateEvent();
        }

        [RequirePermission(EventManagementPermissions.Update)]
        private void BtnModifyEvent_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ModifyEvent();
        }

        [RequirePermission(EventManagementPermissions.Delete)]
        private void BtnDeleteEvent_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.DeleteEvent();
        }

        private void BtnSelectAllOperation_Click(object sender, EventArgs e)
        {
            presenter.SelectAllOperations();
        }

        private void BtnSelectAllCameras_Click(object sender, EventArgs e)
        {
            presenter.SelectAllCameras();
        }

        [RequirePermission(CameraManagementPermissions.Create)]
        [RequirePermission(PermissionManagementPermissions.Create)]
        private void BtnAddSelected_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.AddSelectedOperationsAndCameras();
        }

        [RequirePermission(CameraManagementPermissions.Create)]
        [RequirePermission(PermissionManagementPermissions.Create)]
        private void BtnAddAll_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.AddAllOperationsAndCameras();
        }

        [RequirePermission(CameraManagementPermissions.Delete)]
        [RequirePermission(PermissionManagementPermissions.Delete)]
        private void BtnRemoveSelected_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.RemoveSelectedOperationsAndCameras();
        }

        [RequirePermission(CameraManagementPermissions.Delete)]
        [RequirePermission(PermissionManagementPermissions.Delete)]
        private void BtnRemoveAll_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.RemoveAllOperationsAndCameras();
        }

        [RequirePermission(CameraManagementPermissions.FullControl)]
        [RequirePermission(PermissionManagementPermissions.FullControl)]
        private void BtnSavePermissions_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.SavePermissions();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }
    }
}

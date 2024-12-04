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
    public partial class AddGroup : BaseView, IAddGroupView
    {
        private readonly AddGroupPresenter addGroupPresenter;
        private readonly PermissionManager permissionManager;

        public AddGroup(PermissionManager permissionManager, ILogger<AddGroup> logger, IGroupRepository<Group> groupRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            addGroupPresenter = new AddGroupPresenter(this, groupRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(GroupManagementPermissions.Create)]
        [RequirePermission(GroupManagementPermissions.Update)]
        private void BtnCreateOrModifyGroup_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addGroupPresenter.CreateOrModifyGroup();
        }

        [RequirePermission(EventManagementPermissions.Create)]
        private void BtnCreateEvent_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addGroupPresenter.CreateEvent();
        }

        [RequirePermission(EventManagementPermissions.Update)]
        private void BtnModifyEvent_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addGroupPresenter.ModifyEvent();
        }

        [RequirePermission(EventManagementPermissions.Delete)]
        private void BtnDeleteEvent_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addGroupPresenter.DeleteEvent();
        }

        private void BtnSelectAllOperation_Click(object sender, EventArgs e)
        {
            addGroupPresenter.SelectAllOperations();
        }

        private void BtnSelectAllCameras_Click(object sender, EventArgs e)
        {
            addGroupPresenter.SelectAllCameras();
        }

        [RequirePermission(CameraManagementPermissions.Create)]
        [RequirePermission(PermissionManagementPermissions.Create)]
        private void BtnAddSelected_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addGroupPresenter.AddSelectedOperationsAndCameras();
        }

        [RequirePermission(CameraManagementPermissions.Create)]
        [RequirePermission(PermissionManagementPermissions.Create)]
        private void BtnAddAll_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addGroupPresenter.AddAllOperationsAndCameras();
        }

        [RequirePermission(CameraManagementPermissions.Delete)]
        [RequirePermission(PermissionManagementPermissions.Delete)]
        private void BtnRemoveSelected_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addGroupPresenter.RemoveSelectedOperationsAndCameras();
        }

        [RequirePermission(CameraManagementPermissions.Delete)]
        [RequirePermission(PermissionManagementPermissions.Delete)]
        private void BtnRemoveAll_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addGroupPresenter.RemoveAllOperationsAndCameras();
        }

        [RequirePermission(CameraManagementPermissions.FullControl)]
        [RequirePermission(PermissionManagementPermissions.FullControl)]
        private void BtnSavePermissions_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addGroupPresenter.SavePermissions();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            addGroupPresenter.CloseForm();
        }
    }
}

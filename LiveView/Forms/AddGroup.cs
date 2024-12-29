﻿using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class AddGroup : BaseView, IAddGroupView
    {
        private AddGroupPresenter presenter;
        private readonly Group parentGroup;

        public ComboBox CbEvents => cbEvents;

        public ListView LvAvaialableOperationsAndCameras => lvSelectableOperationsAndCameras;

        public ListView LvOperationsAndCameras => lvExecuteableOperationsAndVisibleCameras;

        public AddGroup(IServiceProvider serviceProvider, Group parentGroup) : base(serviceProvider, typeof(AddGroupPresenter))
        {
            InitializeComponent();
            this.parentGroup = parentGroup;

            permissionManager.ApplyPermissionsOnControls(this);

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

        private void AddGroup_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as AddGroupPresenter;
            presenter.Load();
        }

        public Group GetGroup()
        {
            return new Group
            {
                Name = tbGroupName.Text,
                OtherInformation = tbGroupNote.Text,
                ParentGroupId = parentGroup?.Id
            };
        }

        public UserEvent GetUserEvent()
        {
            return new UserEvent
            {
                Name = cbEvents.Text,
                Note = tbUserEventNote.Text,
            };
        }

        private void CbEvents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public bool OperationsAndCamerasHasElementWithId(IHaveId<long> item)
        {
            if (item is Operation operation)
            {
                if (LvOperationsAndCameras.Items.Any(i => i.Tag is Operation op && op.Id == operation.Id))
                {
                    return true;
                }
            }
            else if (item is Camera camera)
            {
                if (LvOperationsAndCameras.Items.Any(i => i.Tag is Camera cam && cam.Id == camera.Id))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

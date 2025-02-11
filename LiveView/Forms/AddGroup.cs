using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class AddGroup : BaseView, IAddGroupView
    {
        private AddGroupPresenter presenter;
        private Group group;
        private readonly Group parentGroup;

        public ComboBox CbEvents => cbEvents;

        public ListView LvAvaialableOperationsAndCameras => lvAvaialableOperationsAndCameras;

        public ListView LvOperationsAndCameras => lvOperationsAndCameras;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Group Group { get => group; set => group = value; }

        public Group ParentGroup => parentGroup;

        public AddGroup(IServiceProvider serviceProvider, Group parentGroup, Group group = null) : base(serviceProvider, typeof(AddGroupPresenter))
        {
            InitializeComponent();
            this.group = group;
            this.parentGroup = parentGroup;

            permissionManager.ApplyPermissionsOnControls(this);
            if (group != null)
            {
                Text = "Modify group";
                tbGroupName.Text = group.Name;
                tbGroupNote.Text = group.OtherInformation;
                btnCreateOrModifyGroup.Text = "Save";
            }
            Translator.Translate(this);
        }

        private void AddGroup_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as AddGroupPresenter;
            presenter.Load();
        }

        [RequireAnyPermission(GroupManagementPermissions.Create | GroupManagementPermissions.Update)]
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

        [RequireAnyPermission(CameraManagementPermissions.Create)]
        [RequireAnyPermission(PermissionManagementPermissions.Create)]
        private void BtnAddSelected_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.AddSelectedOperationsAndCameras();
        }

        [RequireAnyPermission(CameraManagementPermissions.Create)]
        [RequireAnyPermission(PermissionManagementPermissions.Create)]
        private void BtnAddAll_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.AddAllOperationsAndCameras();
        }

        [RequireAnyPermission(CameraManagementPermissions.Delete)]
        [RequireAnyPermission(PermissionManagementPermissions.Delete)]
        private void BtnRemoveSelected_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.RemoveSelectedOperationsAndCameras();
        }

        [RequireAnyPermission(CameraManagementPermissions.Delete)]
        [RequireAnyPermission(PermissionManagementPermissions.Delete)]
        private void BtnRemoveAll_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.RemoveAllOperationsAndCameras();
        }

        [RequireAnyPermission(CameraManagementPermissions.Create | CameraManagementPermissions.Update | CameraManagementPermissions.Delete)]
        [RequireAnyPermission(PermissionManagementPermissions.Create | PermissionManagementPermissions.Update | PermissionManagementPermissions.Delete)]
        private void BtnSavePermissions_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.SavePermissions();
        }

        public Group GetGroup()
        {
            return new Group
            {
                Id = group?.Id ?? 0,
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
            if (CbEvents.SelectedItem is UserEvent userEvent)
            {
                tbUserEventNote.Text = userEvent.Note;
                presenter.LoadForEvent(userEvent.Id);
            }
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

        private void AddGroup_Resize(object sender, EventArgs e)
        {
            var availableWidth = ClientSize.Width - pCenter.Width;
            var panelWidth = availableWidth / 2;
            pLeft.Width = panelWidth;
            pRight.Width = panelWidth;
            pCenter.Location = new Point(pLeft.Right, pRight.Location.Y);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }
    }
}

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
    public partial class UserAndGroupManagement : BaseView, IUserAndGroupManagementView
    {
        private readonly UserAndGroupManagementPresenter userAndGroupManagementPresenter;
        private readonly PermissionManager permissionManager;

        public UserAndGroupManagement(PermissionManager permissionManager, ILogger<UserAndGroupManagement> logger, IUserRepository<User> userRepository, IGroupRepository<Group> groupRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            userAndGroupManagementPresenter = new UserAndGroupManagementPresenter(this, userRepository, groupRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(GroupManagementPermissions.Create)]
        private void BtnNewGroup_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            userAndGroupManagementPresenter.ShowDialogWithReload<AddGroup>();
        }

        [RequirePermission(UserManagementPermissions.Create)]
        private void BtnNewUser_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            userAndGroupManagementPresenter.ShowDialogWithReload<AddUser>();
        }

        [RequirePermission(GroupManagementPermissions.Update)]
        [RequirePermission(UserManagementPermissions.Update)]
        private void BtnModify_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            userAndGroupManagementPresenter.Modify();
        }

        [RequirePermission(GroupManagementPermissions.Delete)]
        [RequirePermission(UserManagementPermissions.Delete)]
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            userAndGroupManagementPresenter.Delete();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            userAndGroupManagementPresenter.CloseForm();
        }

        private void UserAndGroupManagement_Shown(object sender, EventArgs e)
        {
            userAndGroupManagementPresenter.Load();
        }
    }
}

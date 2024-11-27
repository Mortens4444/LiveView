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
    public partial class UserAndGroupManagement : Form, IUserAndGroupManagementView
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
        private void Btn_NewGroup_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(UserManagementPermissions.Create)]
        private void Btn_NewUser_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(GroupManagementPermissions.Update)]
        [RequirePermission(UserManagementPermissions.Update)]
        private void Btn_Modify_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        [RequirePermission(GroupManagementPermissions.Delete)]
        [RequirePermission(UserManagementPermissions.Delete)]
        private void Btn_Remove_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            userAndGroupManagementPresenter.CloseForm();
        }
    }
}

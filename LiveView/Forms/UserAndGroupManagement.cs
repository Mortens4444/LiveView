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
    public partial class UserAndGroupManagement : BaseView, IUserAndGroupManagementView
    {
        private readonly UserAndGroupManagementPresenter presenter;

        public UserAndGroupManagement(PermissionManager permissionManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<UserAndGroupManagement> logger, IUserRepository<User> userRepository, IGroupRepository<Group> groupRepository)
            : base(permissionManager)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            presenter = new UserAndGroupManagementPresenter(this, generalOptionsRepository, userRepository, groupRepository, logger);
            SetPresenter(presenter);

            Translator.Translate(this);
        }

        [RequirePermission(GroupManagementPermissions.Create)]
        private void BtnNewGroup_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowDialogWithReload<AddGroup>();
        }

        [RequirePermission(UserManagementPermissions.Create)]
        private void BtnNewUser_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.ShowDialogWithReload<AddUser>();
        }

        [RequirePermission(GroupManagementPermissions.Update)]
        [RequirePermission(UserManagementPermissions.Update)]
        private void BtnModify_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Modify();
        }

        [RequirePermission(GroupManagementPermissions.Delete)]
        [RequirePermission(UserManagementPermissions.Delete)]
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Delete();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }

        private void UserAndGroupManagement_Shown(object sender, EventArgs e)
        {
            presenter.Load();
        }
    }
}

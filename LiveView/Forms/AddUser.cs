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
    public partial class AddUser : BaseView, IAddUserView
    {
        private readonly AddUserPresenter addUserPresenter;
        private readonly PermissionManager permissionManager;

        public AddUser(PermissionManager permissionManager, ILogger<AddUser> logger, IUserRepository<User> userRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            addUserPresenter = new AddUserPresenter(this, userRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(UserManagementPermissions.Create)]
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            addUserPresenter.CreateUser();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            addUserPresenter.CloseForm();
        }
    }
}

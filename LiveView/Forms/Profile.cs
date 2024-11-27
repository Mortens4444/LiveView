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
    public partial class Profile : Form, IProfileView
    {
        private readonly ProfilePresenter profilePresenter;
        private readonly PermissionManager permissionManager;

        public Profile(PermissionManager permissionManager, ILogger<Profile> logger, IUserRepository<User> userRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            profilePresenter = new ProfilePresenter(this, userRepository, logger);

            Translator.Translate(this);
        }

        [RequirePermission(UserManagementPermissions.Update)]
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            profilePresenter.CloseForm();
        }
    }
}

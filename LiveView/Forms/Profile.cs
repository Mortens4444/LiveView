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
    public partial class Profile : BaseView, IProfileView
    {
        private readonly ProfilePresenter presenter;

        public Profile(PermissionManager permissionManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<Profile> logger, IUserRepository<User> userRepository) : base(permissionManager)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            presenter = new ProfilePresenter(this, generalOptionsRepository, userRepository, logger);
            SetPresenter(presenter);

            Translator.Translate(this);
        }

        [RequirePermission(UserManagementPermissions.Update)]
        private void BtnSave_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.Save();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }

        [RequirePermission(UserManagementPermissions.Update)]
        private void BtnSelectPicture_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.SelectProfilePicture();
        }

        private void Profile_Shown(object sender, EventArgs e)
        {
            presenter.Load();
        }
    }
}

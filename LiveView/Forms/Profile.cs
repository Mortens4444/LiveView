using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;

namespace LiveView.Forms
{
    public partial class Profile : BaseView, IProfileView
    {
        private ProfilePresenter presenter;

        public Profile(IServiceProvider serviceProvider) : base(serviceProvider, typeof(ProfilePresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

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
            presenter = Presenter as ProfilePresenter;
            presenter.Load();
        }
    }
}

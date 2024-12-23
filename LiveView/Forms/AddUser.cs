using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;

namespace LiveView.Forms
{
    public partial class AddUser : BaseView, IAddUserView
    {
        private AddUserPresenter presenter;

        public AddUser(IServiceProvider serviceProvider) : base(serviceProvider, typeof(AddUserPresenter))
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            Translator.Translate(this);
        }

        [RequirePermission(UserManagementPermissions.Create)]
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.CreateUser();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }

        private void AddUser_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as AddUserPresenter;
        }
    }
}

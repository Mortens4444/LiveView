using Database.Models;
using LiveView.Interfaces;
using LiveView.Presenters;
using Mtf.LanguageService;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Attributes;
using Mtf.Permissions.Enums;
using System;

namespace LiveView.Forms
{
    public partial class AddUser : BaseView, IAddUserView
    {
        private readonly User user;
        private AddUserPresenter presenter;

        public AddUser(IServiceProvider serviceProvider, User user = null) : base(serviceProvider, typeof(AddUserPresenter))
        {
            InitializeComponent();
            this.user = user;

            permissionManager.ApplyPermissionsOnControls(this);

            if (user != null)
            {
                Text = Lng.Elem("Modify user");
                btnAddOrModify.Text = "Modify";
            }
            Translator.Translate(this);
        }

        [RequirePermission(UserManagementPermissions.Create)]
        private void BtnAddOrModify_Click(object sender, EventArgs e)
        {
            permissionManager.EnsurePermissions();
            presenter.CreateUser();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            presenter.CloseForm();
        }

        [RequirePermission(UserManagementPermissions.Select)]
        private void AddUser_Shown(object sender, EventArgs e)
        {
            presenter = Presenter as AddUserPresenter;
            permissionManager.EnsurePermissions();
            presenter.LoadData(user);
        }

        public User GetUser()
        {
            return new User
            {
                Username = tbUsername.Text,
                Password = tbPassword.Password,
                Email = tbEmail.Text,
                NeededSecondaryLogonPriority = (int)nudNeededSecondaryLogonPriority.Value,
                SecondaryLogonPriority = (int)nudSecondaryLogonPriority.Value
            };
        }

        public void LoadData(User user)
        {
            if (user == null)
            {
                return;
            }

            tbUsername.Text = user.Username;
            tbPassword.Password = user.Password;
            tbEmail.Text = user.Email;
            chkLoginSupervisorsRequiredPriority.Checked = user.NeededSecondaryLogonPriority == 0;
            nudNeededSecondaryLogonPriority.Value = user.NeededSecondaryLogonPriority;

            chkLoginSupervisingPriority.Checked = user.SecondaryLogonPriority == 0;
            nudSecondaryLogonPriority.Value = user.SecondaryLogonPriority;
        }
    }
}

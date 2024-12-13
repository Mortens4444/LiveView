using Database.Interfaces;
using Database.Models;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.LanguageService.Windows.Forms;
using Mtf.Permissions.Services;

namespace LiveView.Forms
{
    public partial class LoginForm : BaseView, ILoginFormView
    {
        private readonly LoginFormPresenter loginFormPresenter;
        private readonly PermissionManager permissionManager;

        public LoginForm(PermissionManager permissionManager, ILogger<LoginForm> logger, IUserRepository<User> userRepository)
        {
            InitializeComponent();
            this.permissionManager = permissionManager;

            permissionManager.ApplyPermissionsOnControls(this);

            loginFormPresenter = new LoginFormPresenter(this, userRepository, logger);

            Translator.Translate(this);
        }

        private void BtnOk_Click(object sender, System.EventArgs e)
        {
            loginFormPresenter.Login();
        }

        private void BtnClose_Click(object sender, System.EventArgs e)
        {
            loginFormPresenter.CloseForm();
        }
    }
}

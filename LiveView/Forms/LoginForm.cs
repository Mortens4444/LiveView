using Database.Interfaces;
using Database.Models;
using LanguageService.Windows.Forms;
using LiveView.Interfaces;
using LiveView.Presenters;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Services;
using System.Windows.Forms;

namespace LiveView.Forms
{
    public partial class LoginForm : Form, ILoginFormView
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

        }

        private void BtnClose_Click(object sender, System.EventArgs e)
        {
            loginFormPresenter.CloseForm();
        }
    }
}

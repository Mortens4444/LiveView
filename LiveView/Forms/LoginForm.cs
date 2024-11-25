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

        public LoginForm(PermissionManager permissionManager, ILogger<LoginForm> logger, IUserRepository<User> userRepository)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            loginFormPresenter = new LoginFormPresenter(this, userRepository, logger);

            Translator.Translate(this);
        }
    }
}

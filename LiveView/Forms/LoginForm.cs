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
        private readonly LoginFormPresenter presenter;

        public LoginForm(PermissionManager permissionManager, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, ILogger<LoginForm> logger, IUserRepository<User> userRepository)
            : base(permissionManager)
        {
            InitializeComponent();

            permissionManager.ApplyPermissionsOnControls(this);

            presenter = new LoginFormPresenter(this, generalOptionsRepository, userRepository, logger);
            SetPresenter(presenter);

            Translator.Translate(this);
        }

        private void BtnOk_Click(object sender, System.EventArgs e)
        {
            presenter.Login();
        }

        private void BtnClose_Click(object sender, System.EventArgs e)
        {
            presenter.CloseForm();
        }
    }
}

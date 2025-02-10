using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Enums;

namespace LiveView.Presenters
{
    public class LoginFormPresenter : BasePresenter
    {
        private ILoginFormView view;
        private readonly IUserRepository userRepository;
        private readonly ILogger<LoginForm> logger;

        public LoginFormPresenter(IGeneralOptionsRepository generalOptionsRepository, IUserRepository userRepository, ILogger<LoginForm> logger)
            : base(generalOptionsRepository)
        {
            this.userRepository = userRepository;
            this.logger = logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as ILoginFormView;
        }

        public User Login()
        {
            var user = userRepository.Login(view.TbUsername.Text, view.TbPassword.Password);
            if (user == null)
            {
                logger.LogWarning(UserManagementPermissions.Login, "Login failed with user '{0}'.", view.TbUsername.Text);
                ShowError("Invalid username or password");
                return null;
            }
            logger.LogInfo(UserManagementPermissions.Login, "User '{0}' logged in.", view.TbUsername.Text);
            return user;
        }
    }
}

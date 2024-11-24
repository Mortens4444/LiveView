using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class LoginFormPresenter
    {
        private readonly ILoginFormView loginFormView;
        private readonly IUserRepository userRepository;

        public LoginFormPresenter(ILoginFormView loginFormView, IUserRepository userRepository)
        {
            this.loginFormView = loginFormView;
            this.userRepository = userRepository;
        }
    }
}

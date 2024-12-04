using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class LoginFormPresenter : BasePresenter
    {
        private readonly ILoginFormView loginFormView;
        private readonly IUserRepository<User> userRepository;
        private readonly ILogger<LoginForm> logger;

        public LoginFormPresenter(ILoginFormView loginFormView, IUserRepository<User> userRepository, ILogger<LoginForm> logger)
            : base(loginFormView)
        {
            this.loginFormView = loginFormView;
            this.userRepository = userRepository;
            this.logger = logger;
        }

        public void Login()
        {
            throw new NotImplementedException();
        }
    }
}

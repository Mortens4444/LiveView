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
        private readonly ILoginFormView view;
        private readonly IUserRepository<User> userRepository;
        private readonly ILogger<LoginForm> logger;

        public LoginFormPresenter(ILoginFormView view, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IUserRepository<User> userRepository, ILogger<LoginForm> logger)
            : base(view, generalOptionsRepository)
        {
            this.view = view;
            this.userRepository = userRepository;
            this.logger = logger;
        }

        public void Login()
        {
            throw new NotImplementedException();
        }
    }
}

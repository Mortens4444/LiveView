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
        private ILoginFormView view;
        private readonly IUserRepository<User> userRepository;
        private readonly ILogger<LoginForm> logger;

        public LoginFormPresenter(IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IUserRepository<User> userRepository, ILogger<LoginForm> logger)
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

        public void Login()
        {
            throw new NotImplementedException();
        }
    }
}

using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class EnterPassPresenter : BasePresenter
    {
        private IEnterPassView view;
        private readonly IUserRepository<User> userRepository;
        private readonly ILogger<EnterPass> logger;

        public EnterPassPresenter(EnterPassPresenterDependencies enterPassPresenterDependencies)
            : base(enterPassPresenterDependencies)
        {
            userRepository = enterPassPresenterDependencies.UserRepository;
            logger = enterPassPresenterDependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IEnterPassView;
        }

        public void Login()
        {
            throw new NotImplementedException();
        }
    }
}

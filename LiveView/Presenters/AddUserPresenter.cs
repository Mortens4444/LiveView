using Database.Interfaces;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class AddUserPresenter : BasePresenter
    {
        private IAddUserView view;
        private readonly IUserRepository userRepository;
        private readonly ILogger<AddUser> logger;

        public AddUserPresenter(AddUserPresenterDependencies addUserPresenterDependencies)
            : base(addUserPresenterDependencies)
        {
            userRepository = addUserPresenterDependencies.UserRepository;
            logger = addUserPresenterDependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IAddUserView;
        }

        public void CreateUser()
        {
            var user = view.GetUser();
            userRepository.Insert(user);
            logger.LogInfo("User {0} has been created.", user.Username);
        }
    }
}

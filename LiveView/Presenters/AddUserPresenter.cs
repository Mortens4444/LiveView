using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class AddUserPresenter : BasePresenter
    {
        private IAddUserView view;
        private readonly IUserRepository userRepository;
        private readonly ILogger<AddUser> logger;

        public AddUserPresenter(IGeneralOptionsRepository generalOptionsRepository, IUserRepository userRepository, ILogger<AddUser> logger)
            : base(generalOptionsRepository)
        {
            this.userRepository = userRepository;
            this.logger = logger;
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
        }
    }
}

using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class AddUserPresenter : BasePresenter
    {
        private readonly IAddUserView addUserView;
        private readonly IUserRepository<User> userRepository;
        private readonly ILogger<AddUser> logger;

        public AddUserPresenter(IAddUserView addUserView, IUserRepository<User> userRepository, ILogger<AddUser> logger)
            : base(addUserView)
        {
            this.addUserView = addUserView;
            this.userRepository = userRepository;
            this.logger = logger;
        }
    }
}

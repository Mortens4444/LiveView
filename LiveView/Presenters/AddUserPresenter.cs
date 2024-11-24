using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class AddUserPresenter
    {
        private readonly IAddCamerasView addUserView;
        private readonly IUserRepository userRepository;

        public AddUserPresenter(IAddCamerasView addUserView, IUserRepository userRepository)
        {
            this.addUserView = addUserView;
            this.userRepository = userRepository;
        }
    }
}

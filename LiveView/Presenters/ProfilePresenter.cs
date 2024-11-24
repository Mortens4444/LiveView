using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class ProfilePresenter
    {
        private readonly IProfileView profileView;
        private readonly IUserRepository userRepository;

        public ProfilePresenter(IProfileView profileView, IUserRepository userRepository)
        {
            this.profileView = profileView;
            this.userRepository = userRepository;
        }
    }
}

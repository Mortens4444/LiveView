using Database.Interfaces;
using LiveView.Interfaces;

namespace LiveView.Presenters
{
    public class UserAndGroupManagementPresenter
    {
        private readonly IUserAndGroupManagementView userAndGroupManagementView;
        private readonly IUserRepository userRepository;
        private readonly IGroupRepository groupRepository;

        public UserAndGroupManagementPresenter(IUserAndGroupManagementView userAndGroupManagementView, IUserRepository userRepository, IGroupRepository groupRepository)
        {
            this.userAndGroupManagementView = userAndGroupManagementView;
            this.userRepository = userRepository;
            this.groupRepository = groupRepository;
        }
    }
}

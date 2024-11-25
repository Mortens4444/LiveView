using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;

namespace LiveView.Presenters
{
    public class UserAndGroupManagementPresenter : BasePresenter
    {
        private readonly IUserAndGroupManagementView userAndGroupManagementView;
        private readonly IUserRepository<User> userRepository;
        private readonly IGroupRepository<Group> groupRepository;
        private readonly ILogger<UserAndGroupManagement> logger;

        public UserAndGroupManagementPresenter(IUserAndGroupManagementView userAndGroupManagementView, IUserRepository<User> userRepository, IGroupRepository<Group> groupRepository, ILogger<UserAndGroupManagement> logger)
            : base(userAndGroupManagementView)
        {
            this.userAndGroupManagementView = userAndGroupManagementView;
            this.userRepository = userRepository;
            this.groupRepository = groupRepository;
            this.logger = logger;
        }
    }
}

using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class UserAndGroupManagementPresenter : BasePresenter
    {
        private readonly IUserAndGroupManagementView userAndGroupManagementView;
        private readonly IUserRepository<User> userRepository;
        private readonly IGroupRepository<Group> groupRepository;
        private readonly ILogger<UserAndGroupManagement> logger;

        public UserAndGroupManagementPresenter(IUserAndGroupManagementView userAndGroupManagementView, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IUserRepository<User> userRepository, IGroupRepository<Group> groupRepository, ILogger<UserAndGroupManagement> logger)
            : base(userAndGroupManagementView, generalOptionsRepository)
        {
            this.userAndGroupManagementView = userAndGroupManagementView;
            this.userRepository = userRepository;
            this.groupRepository = groupRepository;
            this.logger = logger;
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }

        public void Modify()
        {
            throw new NotImplementedException();
        }
    }
}

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
        private readonly IUserAndGroupManagementView view;
        private readonly IUserRepository<User> userRepository;
        private readonly IGroupRepository<Group> groupRepository;
        private readonly ILogger<UserAndGroupManagement> logger;

        public UserAndGroupManagementPresenter(IUserAndGroupManagementView view, IGeneralOptionsRepository<GeneralOption> generalOptionsRepository, IUserRepository<User> userRepository, IGroupRepository<Group> groupRepository, ILogger<UserAndGroupManagement> logger)
            : base(view, generalOptionsRepository)
        {
            this.view = view;
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

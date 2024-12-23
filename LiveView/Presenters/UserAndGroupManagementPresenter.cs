using Database.Interfaces;
using Database.Models;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Services;
using Microsoft.Extensions.Logging;
using System;

namespace LiveView.Presenters
{
    public class UserAndGroupManagementPresenter : BasePresenter
    {
        private IUserAndGroupManagementView view;
        private readonly IUserRepository<User> userRepository;
        private readonly IGroupRepository<Group> groupRepository;
        private readonly ILogger<UserAndGroupManagement> logger;

        public UserAndGroupManagementPresenter(IGeneralOptionsRepository<GeneralOption> generalOptionsRepository,
            IUserRepository<User> userRepository, IGroupRepository<Group> groupRepository, ILogger<UserAndGroupManagement> logger, FormFactory formfactory)
            : base(generalOptionsRepository, formfactory)
        {
            this.userRepository = userRepository;
            this.groupRepository = groupRepository;
            this.logger = logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IUserAndGroupManagementView;
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

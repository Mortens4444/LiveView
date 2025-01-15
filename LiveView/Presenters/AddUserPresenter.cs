using Database.Interfaces;
using Database.Models;
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
        private readonly IUsersInGroupsRepository usersInGroupsRepository;
        private readonly ILogger<AddUser> logger;

        public AddUserPresenter(AddUserPresenterDependencies addUserPresenterDependencies)
            : base(addUserPresenterDependencies)
        {
            userRepository = addUserPresenterDependencies.UserRepository;
            usersInGroupsRepository = addUserPresenterDependencies.UsersInGroupsRepository;
            logger = addUserPresenterDependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IAddUserView;
        }

        public void CreateUserInGroup(Group parentGroup)
        {
            var user = view.GetUser();
            int userId = userRepository.InsertAndReturnId<int>(user);
            usersInGroupsRepository.Insert(new UserGroup
            {
                UserId = userId,
                GroupId = parentGroup.Id
            });
            logger.LogInfo("User '{0}' has been created in group '{1}'.", user.Username, parentGroup.Name);
        }

        public void LoadData(User user)
        {
            view.LoadData(user);
        }
    }
}

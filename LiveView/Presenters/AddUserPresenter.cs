using Database.Interfaces;
using Database.Models;
using LiveView.Extensions;
using LiveView.Forms;
using LiveView.Interfaces;
using LiveView.Models.Dependencies;
using Microsoft.Extensions.Logging;
using Mtf.Permissions.Enums;

namespace LiveView.Presenters
{
    public class AddUserPresenter : BasePresenter
    {
        private IAddUserView view;
        private readonly IUserRepository userRepository;
        private readonly IGroupMembersRepository groupMembersRepository;
        private readonly ILogger<AddUser> logger;

        public AddUserPresenter(AddUserPresenterDependencies dependencies)
            : base(dependencies)
        {
            userRepository = dependencies.UserRepository;
            groupMembersRepository = dependencies.GroupMembersRepository;
            logger = dependencies.Logger;
        }

        public new void SetView(IView view)
        {
            base.SetView(view);
            this.view = view as IAddUserView;
        }

        public void CreateUserInGroup(Group parentGroup)
        {
            var user = view.GetUser();
            if (user.Id == 0)
            {
                int userId = userRepository.InsertAndReturnId<int>(user);
                groupMembersRepository.Insert(new GroupMember
                {
                    UserId = userId,
                    GroupId = parentGroup.Id
                });
                logger.LogInfo(UserManagementPermissions.Create, "User '{0}' has been created in group '{1}'.", user.Username, parentGroup.Name);
            }
            else
            {
                userRepository.Update(user);
                logger.LogInfo(UserManagementPermissions.Create, "User '{0}' has been modified in group '{1}'.", user.Username, parentGroup.Name);
            }
        }

        public void LoadData(User user)
        {
            view.LoadData(user);
        }
    }
}

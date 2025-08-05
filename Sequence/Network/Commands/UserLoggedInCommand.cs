using Database.Models;
using LiveView.Core.Interfaces;
using Mtf.Permissions.Services;

namespace Sequence.Network.Commands
{
    public class UserLoggedInCommand : ICommand
    {
        private readonly PermissionManager<User> permissionManager;
        private readonly User user;

        public UserLoggedInCommand(PermissionManager<User> permissionManager, User user)
        {
            this.permissionManager = permissionManager;
            this.user = user;
        }

        public void Execute()
        {
            permissionManager.Login(new Mtf.Permissions.Models.User<User> { Tag = user });
        }
    }
}

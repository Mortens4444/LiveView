using Database.Models;
using LiveView.Core.Interfaces;
using Mtf.Permissions.Services;

namespace Sequence.Network.Commands
{
    public class UserLoggedOutCommand : ICommand
    {
        private readonly PermissionManager<User> permissionManager;

        public UserLoggedOutCommand(PermissionManager<User> permissionManager)
        {
            this.permissionManager = permissionManager;
        }

        public void Execute()
        {
            permissionManager.Logout();
        }
    }
}

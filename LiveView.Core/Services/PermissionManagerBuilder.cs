using Database.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Mtf.Permissions.Services;
using System;
using System.Windows.Forms;

namespace LiveView.Core.Services
{
    public static class PermissionManagerBuilder
    {
        public static PermissionManager<Database.Models.User> Build(IServiceProvider serviceProvider, Form form, long userId)
        {
            var userRepository = serviceProvider.GetRequiredService<IUserRepository>();
            var user = userRepository.Select(userId);

            var permissionManager = serviceProvider.GetRequiredService<PermissionManager<Database.Models.User>>();
            var permissionUser = new Mtf.Permissions.Models.User<Database.Models.User>
            {
                Id = (int)user.Id, // Theoretically it could be a problem, hopefully we won't have more than 2.1 billion users
                Username = user.Username,
                Tag = user
            };
            permissionManager.LoginWithForm(permissionUser, form);
            return permissionManager;
        }
    }
}

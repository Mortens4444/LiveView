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
            var permissionUser = user == null ? null : new Mtf.Permissions.Models.User<Database.Models.User>
            {
                Id = user.Id,
                Username = user.Username,
                Tag = user
            };
            permissionManager.LoginWithForm(permissionUser, form);
            return permissionManager;
        }
    }
}

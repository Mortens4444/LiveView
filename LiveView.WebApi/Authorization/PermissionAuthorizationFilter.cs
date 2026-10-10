using Database.Interfaces;
using LiveView.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Mtf.Permissions.Enums;
using Mtf.Permissions.Models;
using System.Reflection;
using System.Security.Claims;

namespace LiveView.WebApi.Authorization
{
    /// <summary>
    /// Enforces the Mtf.Permissions requirement declared via <see cref="RequiresPermissionGroupAttribute"/>
    /// on the executing controller, evaluated against the authenticated caller's own permission set
    /// (built the same way the desktop app builds it, via PermissionSetter) rather than any shared/static state.
    /// </summary>
    public class PermissionAuthorizationFilter : IAsyncActionFilter
    {
        private static readonly Dictionary<string, string[]> CandidatesByHttpMethod = new()
        {
            ["GET"] = new[] { "Select", "Read", "View" },
            ["POST"] = new[] { "Create" },
            ["PUT"] = new[] { "Update", "Edit" },
            ["PATCH"] = new[] { "Update", "Edit" },
            ["DELETE"] = new[] { "Delete" }
        };

        private readonly IUserRepository userRepository;
        private readonly PermissionSetter permissionSetter;

        public PermissionAuthorizationFilter(IUserRepository userRepository, PermissionSetter permissionSetter)
        {
            this.userRepository = userRepository;
            this.permissionSetter = permissionSetter;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var attribute = (context.ActionDescriptor as ControllerActionDescriptor)?
                .ControllerTypeInfo.GetCustomAttribute<RequiresPermissionGroupAttribute>();

            if (attribute == null)
            {
                await next().ConfigureAwait(false);
                return;
            }

            var userIdClaim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out var userId))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var dbUser = userRepository.Select(userId);
            if (dbUser == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var permissionUser = new User<Database.Models.User>
            {
                Id = dbUser.Id,
                Username = dbUser.Username,
                Tag = dbUser
            };
            permissionSetter.SetGroups(permissionUser);

            var requiredPermission = ResolveRequiredPermission(attribute.PermissionGroup, context.HttpContext.Request.Method);
            if (permissionUser.HasPermission(requiredPermission) != AccessResult.Allowed)
            {
                context.Result = new ForbidResult();
                return;
            }

            await next().ConfigureAwait(false);
        }

        private static Enum ResolveRequiredPermission(Type permissionGroup, string httpMethod)
        {
            if (CandidatesByHttpMethod.TryGetValue(httpMethod, out var candidates))
            {
                foreach (var candidate in candidates)
                {
                    if (Enum.IsDefined(permissionGroup, candidate))
                    {
                        return (Enum)Enum.Parse(permissionGroup, candidate);
                    }
                }
            }

            return (Enum)Enum.Parse(permissionGroup, "FullControl");
        }
    }
}

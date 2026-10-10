using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Authorization;
using LiveView.WebApi.Dto;
using Mtf.Permissions.Enums;
using Mtf.Web.Interfaces;
using LiveView.WebApi.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing User entities via REST API endpoints.
    /// </summary>
    [RequiresPermissionGroup(typeof(UserManagementPermissions))]
    public class UsersController : ApiControllerBaseWithIntModelId<UserDto, User, IUserRepository, IConverter<User, UserDto>>
    {
        public UsersController(
            ILogger<UsersController> logger,
            IUserRepository repository,
            IConverter<User, UserDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
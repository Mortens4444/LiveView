using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing User entities via REST API endpoints.
    /// </summary>
    public class UsersController : ApiControllerBaseWithLongModelId<UserDto, User, IUserRepository, IConverter<User, UserDto>>
    {
        public UsersController(
            ILogger<UsersController> logger,
            IUserRepository repository,
            IConverter<User, UserDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
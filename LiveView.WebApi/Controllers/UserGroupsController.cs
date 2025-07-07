using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing UserGroup entities via REST API endpoints.
    /// </summary>
    public class UserGroupsController : ApiControllerBaseWithIntModelId<UserGroupDto, UserGroup, IUsersInGroupsRepository, IConverter<UserGroup, UserGroupDto>>
    {
        public UserGroupsController(
            ILogger<UserGroupsController> logger,
            IUsersInGroupsRepository repository,
            IConverter<UserGroup, UserGroupDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
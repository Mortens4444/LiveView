using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing Group entities via REST API endpoints.
    /// </summary>
    public class GroupsController : ApiControllerBaseWithIntModelId<GroupDto, Group, IGroupRepository, IConverter<Group, GroupDto>>
    {
        public GroupsController(
            ILogger<GroupsController> logger,
            IGroupRepository repository,
            IConverter<Group, GroupDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
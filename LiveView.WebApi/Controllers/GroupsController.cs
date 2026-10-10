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
    /// Controller for managing Group entities via REST API endpoints.
    /// </summary>
    [RequiresPermissionGroup(typeof(GroupManagementPermissions))]
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
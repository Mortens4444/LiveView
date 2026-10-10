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
    /// Controller for managing UserGroup entities via REST API endpoints.
    /// </summary>
    [RequiresPermissionGroup(typeof(GroupManagementPermissions))]
    public class GroupMembersController : ApiControllerBaseWithIntModelId<GroupMemberDto, GroupMember, IGroupMembersRepository, IConverter<GroupMember, GroupMemberDto>>
    {
        public GroupMembersController(
            ILogger<GroupMembersController> logger,
            IGroupMembersRepository repository,
            IConverter<GroupMember, GroupMemberDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
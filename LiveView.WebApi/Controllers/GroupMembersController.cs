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
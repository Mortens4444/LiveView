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
    /// Controller for managing Agent entities via REST API endpoints.
    /// Provides standard CRUD (Create, Read, Update, Delete) operations for Camera data.
    /// Sets the base route for this controller (e.g., /api/agents)
    /// </summary>
    [RequiresPermissionGroup(typeof(NetworkManagementPermissions))]
    public class AgentsController : ApiControllerBaseWithIntModelId<AgentDto, Agent, IAgentRepository, IConverter<Agent, AgentDto>>
    {
        public AgentsController(
            ILogger<AgentsController> logger,
            IAgentRepository repository,
            IConverter<Agent, AgentDto> converter)
            : base(logger, repository, converter)
        { }
    }
}

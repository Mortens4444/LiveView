using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Converters;
using LiveView.WebApi.Dto;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing Agent entities via REST API endpoints.
    /// Provides standard CRUD (Create, Read, Update, Delete) operations for Camera data.
    /// Sets the base route for this controller (e.g., /api/cameras)
    /// </summary>
    public class AgentsController : ApiControllerBaseWithLongModelId<AgentDto, Agent, IAgentRepository, AgentConverter>
    {
        public AgentsController(
            ILogger<AgentsController> logger,
            IAgentRepository repository,
            AgentConverter converter)
            : base(logger, repository, converter)
        { }
    }
}

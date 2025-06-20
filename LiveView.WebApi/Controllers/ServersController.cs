using Database.Models;
using Database.Interfaces;
using LiveView.WebApi.Converters;
using LiveView.WebApi.Dto;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing Server entities via REST API endpoints.
    /// Provides standard CRUD (Create, Read, Update, Delete) operations for Server data.
    /// Sets the base route for this controller (e.g., /api/servers)
    /// </summary>
    public class ServersController : ApiControllerBaseWithLongModelId<ServerDto, Server, IServerRepository, ServerConverter>
    {
        public ServersController(
            ILogger<ServersController> logger,
            IServerRepository repository,
            ServerConverter converter)
            : base(logger, repository, converter)
        { }
    }
}

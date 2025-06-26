using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing Server entities via REST API endpoints.
    /// Provides standard CRUD (Create, Read, Update, Delete) operations for Server data.
    /// Sets the base route for this controller (e.g., /api/servers)
    /// </summary>
    public class ServersController : ApiControllerBaseWithLongModelId<ServerDto, Server, IServerRepository, IConverter<Server, ServerDto>>
    {
        public ServersController(
            ILogger<ServersController> logger,
            IServerRepository repository,
            IConverter<Server, ServerDto> converter)
            : base(logger, repository, converter)
        { }
    }
}

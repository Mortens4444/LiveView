using Database.Models;
using Database.Interfaces;
using LiveView.WebApi.Converters;
using LiveView.WebApi.Dto;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing Server entities via REST API endpoints.
    /// Provides standard CRUD (Create, Read, Update, Delete) operations for Server data.
    /// Sets the base route for this controller (e.g., /api/server)
    /// </summary>
    public class ServerController : BaseController<ServerDto, Server, IServerRepository, ServerConverter>
    {
        public ServerController(
            ILogger<ServerController> logger,
            IServerRepository repository,
            ServerConverter converter)
            : base(logger, repository, converter)
        { }
    }
}

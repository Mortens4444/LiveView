using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing DatabaseServer entities via REST API endpoints.
    /// </summary>
    public class DatabaseServersController : ApiControllerBaseWithIntModelId<DatabaseServerDto, DatabaseServer, IDatabaseServerRepository, IConverter<DatabaseServer, DatabaseServerDto>>
    {
        public DatabaseServersController(
            ILogger<DatabaseServersController> logger,
            IDatabaseServerRepository repository,
            IConverter<DatabaseServer, DatabaseServerDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing Migration entities via REST API endpoints.
    /// </summary>
    public class MigrationsController : ApiControllerBaseWithLongModelId<MigrationDto, Migration, IMigrationRepository, IConverter<Migration, MigrationDto>>
    {
        public MigrationsController(
            ILogger<MigrationsController> logger,
            IMigrationRepository repository,
            IConverter<Migration, MigrationDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
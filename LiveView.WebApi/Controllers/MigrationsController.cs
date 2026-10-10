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
    /// Controller for managing Migration entities via REST API endpoints.
    /// </summary>
    [RequiresPermissionGroup(typeof(ApplicationManagementPermissions))]
    public class MigrationsController : ApiControllerBaseWithIntModelId<MigrationDto, Migration, IMigrationRepository, IConverter<Migration, MigrationDto>>
    {
        public MigrationsController(
            ILogger<MigrationsController> logger,
            IMigrationRepository repository,
            IConverter<Migration, MigrationDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
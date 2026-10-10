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
    /// Controller for managing DatabaseServer entities via REST API endpoints.
    /// </summary>
    [RequiresPermissionGroup(typeof(DatabaseServerManagementPermissions))]
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
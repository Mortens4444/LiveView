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
    /// Controller for managing MapActionObject entities via REST API endpoints.
    /// </summary>
    [RequiresPermissionGroup(typeof(MapManagementPermissions))]
    public class MapActionObjectsController : ApiControllerBaseWithCompositeKey<MapActionObjectDto, MapActionObject, MapActionObject, IMapActionObjectRepository, IConverter<MapActionObject, MapActionObjectDto>>
    {
        public MapActionObjectsController(
            ILogger<MapActionObjectsController> logger,
            IMapActionObjectRepository repository,
            IConverter<MapActionObject, MapActionObjectDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
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
    /// Controller for managing Map entities via REST API endpoints.
    /// </summary>
    [RequiresPermissionGroup(typeof(MapManagementPermissions))]
    public class MapsController : ApiControllerBaseWithIntModelId<MapDto, Map, IMapRepository, IConverter<Map, MapDto>>
    {
        public MapsController(
            ILogger<MapsController> logger,
            IMapRepository repository,
            IConverter<Map, MapDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
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
    /// Controller for managing MapObject entities via REST API endpoints.
    /// </summary>
    [RequiresPermissionGroup(typeof(MapManagementPermissions))]
    public class ActionObjectsController : ApiControllerBaseWithIntModelId<ActionObjectDto, ActionObject, IActionObjectRepository, IConverter<ActionObject, ActionObjectDto>>
    {
        public ActionObjectsController(
            ILogger<ActionObjectsController> logger,
            IActionObjectRepository repository,
            IConverter<ActionObject, ActionObjectDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
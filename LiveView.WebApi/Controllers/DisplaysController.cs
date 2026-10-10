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
    /// Controller for managing Display entities via REST API endpoints.
    /// </summary>
    [RequiresPermissionGroup(typeof(DisplayManagementPermissions))]
    public class DisplaysController : ApiControllerBaseWithIntModelId<DisplayDto, Display, IDisplayRepository, IConverter<Display, DisplayDto>>
    {
        public DisplaysController(
            ILogger<DisplaysController> logger,
            IDisplayRepository repository,
            IConverter<Display, DisplayDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
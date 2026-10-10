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
    /// Controller for managing GridCamera entities via REST API endpoints.
    /// </summary>
    [RequiresPermissionGroup(typeof(GridManagementPermissions))]
    public class GridCamerasController : ApiControllerBaseWithIntModelId<GridCameraDto, GridCamera, IGridCameraRepository, IConverter<GridCamera, GridCameraDto>>
    {
        public GridCamerasController(
            ILogger<GridCamerasController> logger,
            IGridCameraRepository repository,
            IConverter<GridCamera, GridCameraDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
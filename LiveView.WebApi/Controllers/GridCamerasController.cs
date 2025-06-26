using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing GridCamera entities via REST API endpoints.
    /// </summary>
    public class GridCamerasController : ApiControllerBaseWithLongModelId<GridCameraDto, GridCamera, IGridCameraRepository, IConverter<GridCamera, GridCameraDto>>
    {
        public GridCamerasController(
            ILogger<GridCamerasController> logger,
            IGridCameraRepository repository,
            IConverter<GridCamera, GridCameraDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
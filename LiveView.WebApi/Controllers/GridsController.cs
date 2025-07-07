using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing Grid entities via REST API endpoints.
    /// Provides standard CRUD (Create, Read, Update, Delete) operations for Grid data.
    /// Sets the base route for this controller (e.g., /api/grids)
    /// </summary>
    public class GridsController : ApiControllerBaseWithIntModelId<GridDto, Grid, IGridRepository, IConverter<Grid, GridDto>>
    {
        public GridsController(
            ILogger<GridsController> logger,
            IGridRepository repository,
            IConverter<Grid, GridDto> converter)
            : base(logger, repository, converter)
        { }
    }
}

using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Converters;
using LiveView.WebApi.Dto;
using Mtf.Web.Controllers;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing Grid entities via REST API endpoints.
    /// Provides standard CRUD (Create, Read, Update, Delete) operations for Grid data.
    /// Sets the base route for this controller (e.g., /api/grid)
    /// </summary>
    public class GridController : ApiControllerBaseWithLongModelId<GridDto, Grid, IGridRepository, GridConverter>
    {
        public GridController(
            ILogger<GridController> logger,
            IGridRepository repository,
            GridConverter converter)
            : base(logger, repository, converter)
        { }
    }
}

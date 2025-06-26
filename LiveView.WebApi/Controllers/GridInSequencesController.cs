using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing GridInSequence entities via REST API endpoints.
    /// </summary>
    public class GridInSequencesController : ApiControllerBaseWithLongModelId<GridInSequenceDto, GridInSequence, IGridInSequenceRepository, IConverter<GridInSequence, GridInSequenceDto>>
    {
        public GridInSequencesController(
            ILogger<GridInSequencesController> logger,
            IGridInSequenceRepository repository,
            IConverter<GridInSequence, GridInSequenceDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
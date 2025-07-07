using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing SequenceGrids entities via REST API endpoints.
    /// </summary>
    public class SequenceGridsController : ApiControllerBaseWithIntModelId<SequenceGridsDto, SequenceGrid, ISequenceGridsRepository, IConverter<SequenceGrid, SequenceGridsDto>>
    {
        public SequenceGridsController(
            ILogger<SequenceGridsController> logger,
            ISequenceGridsRepository repository,
            IConverter<SequenceGrid, SequenceGridsDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
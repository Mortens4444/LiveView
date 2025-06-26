using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing Sequence entities via REST API endpoints.
    /// Provides standard CRUD (Create, Read, Update, Delete) operations for Sequence data.
    /// Sets the base route for this controller (e.g., /api/sequences)
    /// </summary>
    public class SequencesController : ApiControllerBaseWithLongModelId<SequenceDto, Sequence, ISequenceRepository, IConverter<Sequence, SequenceDto>>
    {
        public SequencesController(
            ILogger<SequencesController> logger,
            ISequenceRepository repository,
            IConverter<Sequence, SequenceDto> converter)
            : base(logger, repository, converter)
        { }
    }
}

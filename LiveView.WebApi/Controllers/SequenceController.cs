using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Converters;
using LiveView.WebApi.Dto;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing Sequence entities via REST API endpoints.
    /// Provides standard CRUD (Create, Read, Update, Delete) operations for Sequence data.
    /// Sets the base route for this controller (e.g., /api/sequence)
    /// </summary>
    public class SequenceController : BaseController<SequenceDto, Sequence, ISequenceRepository, SequenceConverter>
    {
        public SequenceController(
            ILogger<SequenceController> logger,
            ISequenceRepository repository,
            SequenceConverter converter)
            : base(logger, repository, converter)
        { }
    }
}

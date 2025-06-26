using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing IOPort entities via REST API endpoints.
    /// </summary>
    public class IOPortsController : ApiControllerBaseWithLongModelId<IOPortDto, IOPort, IIOPortRepository, IConverter<IOPort, IOPortDto>>
    {
        public IOPortsController(
            ILogger<IOPortsController> logger,
            IIOPortRepository repository,
            IConverter<IOPort, IOPortDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
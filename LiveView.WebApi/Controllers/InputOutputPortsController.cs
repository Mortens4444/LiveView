using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing InputOutputPort entities via REST API endpoints.
    /// </summary>
    public class InputOutputPortsController : ApiControllerBaseWithIntModelId<InputOutputPortDto, InputOutputPort, IInputOutputPortRepository, IConverter<InputOutputPort, InputOutputPortDto>>
    {
        public InputOutputPortsController(
            ILogger<InputOutputPortsController> logger,
            IInputOutputPortRepository repository,
            IConverter<InputOutputPort, InputOutputPortDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
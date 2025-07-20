using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing InputOutputPortLog entities via REST API endpoints.
    /// </summary>
    public class InputOutputPortsLogController : ApiControllerBaseWithIntModelId<InputOutputPortLogDto, InputOutputPortLogEntry, IInputOutputPortLogRepository, IConverter<InputOutputPortLogEntry, InputOutputPortLogDto>>
    {
        public InputOutputPortsLogController(
            ILogger<InputOutputPortsLogController> logger,
            IInputOutputPortLogRepository repository,
            IConverter<InputOutputPortLogEntry, InputOutputPortLogDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
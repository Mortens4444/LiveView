using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing IOPortsLog entities via REST API endpoints.
    /// </summary>
    public class IOPortsLogsController : ApiControllerBaseWithLongModelId<IOPortsLogDto, IOPortsLog, IIOPortsLogRepository, IConverter<IOPortsLog, IOPortsLogDto>>
    {
        public IOPortsLogsController(
            ILogger<IOPortsLogsController> logger,
            IIOPortsLogRepository repository,
            IConverter<IOPortsLog, IOPortsLogDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
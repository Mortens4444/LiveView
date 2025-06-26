using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing LogEntry entities via REST API endpoints.
    /// </summary>
    public class LogEntriesController : ApiControllerBaseWithLongModelId<LogEntryDto, LogEntry, ILogRepository, IConverter<LogEntry, LogEntryDto>>
    {
        public LogEntriesController(
            ILogger<LogEntriesController> logger,
            ILogRepository repository,
            IConverter<LogEntry, LogEntryDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
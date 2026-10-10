using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Authorization;
using LiveView.WebApi.Dto;
using Mtf.Permissions.Enums;
using Mtf.Web.Interfaces;
using LiveView.WebApi.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing LogEntry entities via REST API endpoints.
    /// </summary>
    [RequiresPermissionGroup(typeof(LogManagementPermissions))]
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
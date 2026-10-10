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
    /// Controller for managing TemplateProcess entities via REST API endpoints.
    /// </summary>
    [RequiresPermissionGroup(typeof(TemplateManagementPermissions))]
    public class TemplateProcessesController : ApiControllerBaseWithIntModelId<TemplateProcessDto, TemplateProcess, ITemplateProcessRepository, IConverter<TemplateProcess, TemplateProcessDto>>
    {
        public TemplateProcessesController(
            ILogger<TemplateProcessesController> logger,
            ITemplateProcessRepository repository,
            IConverter<TemplateProcess, TemplateProcessDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
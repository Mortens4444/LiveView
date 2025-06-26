using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing TemplateProcess entities via REST API endpoints.
    /// </summary>
    public class TemplateProcessesController : ApiControllerBaseWithLongModelId<TemplateProcessDto, TemplateProcess, ITemplateProcessRepository, IConverter<TemplateProcess, TemplateProcessDto>>
    {
        public TemplateProcessesController(
            ILogger<TemplateProcessesController> logger,
            ITemplateProcessRepository repository,
            IConverter<TemplateProcess, TemplateProcessDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
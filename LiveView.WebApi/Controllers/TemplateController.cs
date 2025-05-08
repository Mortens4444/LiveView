using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Converters;
using LiveView.WebApi.Dto;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing Template entities via REST API endpoints.
    /// Provides standard CRUD (Create, Read, Update, Delete) operations for Template data.
    /// Sets the base route for this controller (e.g., /api/Template)
    /// </summary>
    public class TemplateController : BaseController<TemplateDto, Template, ITemplateRepository, TemplateConverter>
    {
        public TemplateController(
            ILogger<TemplateController> logger,
            ITemplateRepository repository,
            TemplateConverter converter)
            : base(logger, repository, converter)
        { }
    }
}

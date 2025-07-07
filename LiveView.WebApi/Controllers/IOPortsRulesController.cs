using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing IOPortsRule entities via REST API endpoints.
    /// </summary>
    public class IOPortsRulesController : ApiControllerBaseWithIntModelId<IOPortsRuleDto, IOPortsRule, IIOPortsRuleRepository, IConverter<IOPortsRule, IOPortsRuleDto>>
    {
        public IOPortsRulesController(
            ILogger<IOPortsRulesController> logger,
            IIOPortsRuleRepository repository,
            IConverter<IOPortsRule, IOPortsRuleDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
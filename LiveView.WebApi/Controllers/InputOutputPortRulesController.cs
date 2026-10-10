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
    /// Controller for managing InputOutputPortRule entities via REST API endpoints.
    /// </summary>
    [RequiresPermissionGroup(typeof(IODeviceManagementPermissions))]
    public class InputOutputPortRulesController : ApiControllerBaseWithIntModelId<InputOutputPortRuleDto, InputOutputPortRule, IInputOutputPortRuleRepository, IConverter<InputOutputPortRule, InputOutputPortRuleDto>>
    {
        public InputOutputPortRulesController(
            ILogger<InputOutputPortRulesController> logger,
            IInputOutputPortRuleRepository repository,
            IConverter<InputOutputPortRule, InputOutputPortRuleDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
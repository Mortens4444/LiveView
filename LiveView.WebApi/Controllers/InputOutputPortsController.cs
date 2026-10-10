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
    /// Controller for managing InputOutputPort entities via REST API endpoints.
    /// </summary>
    [RequiresPermissionGroup(typeof(IODeviceManagementPermissions))]
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
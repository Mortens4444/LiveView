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
    /// Controller for managing Operation entities via REST API endpoints.
    /// </summary>
    [RequiresPermissionGroup(typeof(PermissionManagementPermissions))]
    public class OperationsController : ApiControllerBaseWithIntModelId<OperationDto, Operation, IOperationRepository, IConverter<Operation, OperationDto>>
    {
        public OperationsController(
            ILogger<OperationsController> logger,
            IOperationRepository repository,
            IConverter<Operation, OperationDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
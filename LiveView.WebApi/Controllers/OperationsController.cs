using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing Operation entities via REST API endpoints.
    /// </summary>
    public class OperationsController : ApiControllerBaseWithLongModelId<OperationDto, Operation, IOperationRepository, IConverter<Operation, OperationDto>>
    {
        public OperationsController(
            ILogger<OperationsController> logger,
            IOperationRepository repository,
            IConverter<Operation, OperationDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
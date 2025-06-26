using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing CameraFunction entities via REST API endpoints.
    /// </summary>
    public class CameraFunctionsController : ApiControllerBaseWithLongModelId<CameraFunctionDto, CameraFunction, ICameraFunctionRepository, IConverter<CameraFunction, CameraFunctionDto>>
    {
        public CameraFunctionsController(
            ILogger<CameraFunctionsController> logger,
            ICameraFunctionRepository repository,
            IConverter<CameraFunction, CameraFunctionDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
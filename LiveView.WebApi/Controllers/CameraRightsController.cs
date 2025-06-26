using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing CameraRight entities via REST API endpoints.
    /// </summary>
    public class CameraRightsController : ApiControllerBaseWithLongModelId<CameraRightDto, CameraRight, ICameraRightRepository, IConverter<CameraRight, CameraRightDto>>
    {
        public CameraRightsController(
            ILogger<CameraRightsController> logger,
            ICameraRightRepository repository,
            IConverter<CameraRight, CameraRightDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
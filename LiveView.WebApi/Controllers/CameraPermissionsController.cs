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
    public class CameraPermissionsController : ApiControllerBaseWithIntModelId<CameraPermissionDto, CameraPermission, ICameraPermissionRepository, IConverter<CameraPermission, CameraPermissionDto>>
    {
        public CameraPermissionsController(
            ILogger<CameraPermissionsController> logger,
            ICameraPermissionRepository repository,
            IConverter<CameraPermission, CameraPermissionDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
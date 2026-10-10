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
    /// Controller for managing CameraRight entities via REST API endpoints.
    /// </summary>
    [RequiresPermissionGroup(typeof(PermissionManagementPermissions))]
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
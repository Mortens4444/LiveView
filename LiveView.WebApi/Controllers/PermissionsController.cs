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
    /// Controller for managing Right entities via REST API endpoints.
    /// </summary>
    [RequiresPermissionGroup(typeof(PermissionManagementPermissions))]
    public class PermissionsController : ApiControllerBaseWithIntModelId<PermissionDto, Permission, IPermissionRepository, IConverter<Permission, PermissionDto>>
    {
        public PermissionsController(
            ILogger<PermissionsController> logger,
            IPermissionRepository repository,
            IConverter<Permission, PermissionDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
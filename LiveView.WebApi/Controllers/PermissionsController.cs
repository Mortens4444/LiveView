using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing Right entities via REST API endpoints.
    /// </summary>
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
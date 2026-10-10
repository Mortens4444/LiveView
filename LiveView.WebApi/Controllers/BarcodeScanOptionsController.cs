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
    /// Controller for managing BarcodeScanOptions entities via REST API endpoints.
    /// </summary>
    [RequiresPermissionGroup(typeof(SerialDeviceManagementPermissions))]
    public class BarcodeScanOptionsController : ApiControllerBaseWithIntModelId<BarcodeScanOptionsDto, BarcodeScanOptions, IBarcodeScanOptionsRepository, IConverter<BarcodeScanOptions, BarcodeScanOptionsDto>>
    {
        public BarcodeScanOptionsController(
            ILogger<BarcodeScanOptionsController> logger,
            IBarcodeScanOptionsRepository repository,
            IConverter<BarcodeScanOptions, BarcodeScanOptionsDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
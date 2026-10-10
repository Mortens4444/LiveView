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
    /// Controller for managing BarcodeScanReading entities via REST API endpoints.
    /// </summary>
    [RequiresPermissionGroup(typeof(SerialDeviceManagementPermissions))]
    public class BarcodeScanReadingsController : ApiControllerBaseWithIntModelId<BarcodeScanReadingDto, BarcodeScanReading, IBarcodeScanReadingRepository, IConverter<BarcodeScanReading, BarcodeScanReadingDto>>
    {
        public BarcodeScanReadingsController(
            ILogger<BarcodeScanReadingsController> logger,
            IBarcodeScanReadingRepository repository,
            IConverter<BarcodeScanReading, BarcodeScanReadingDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
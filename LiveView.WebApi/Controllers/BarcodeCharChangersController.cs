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
    /// Controller for managing BarcodeCharChanger entities via REST API endpoints.
    /// </summary>
    [RequiresPermissionGroup(typeof(SerialDeviceManagementPermissions))]
    public class BarcodeCharChangersController : ApiControllerBaseWithIntModelId<BarcodeCharChangerDto, BarcodeCharChanger, IBarcodeCharChangerRepository, IConverter<BarcodeCharChanger, BarcodeCharChangerDto>>
    {
        public BarcodeCharChangersController(
            ILogger<BarcodeCharChangersController> logger,
            IBarcodeCharChangerRepository repository,
            IConverter<BarcodeCharChanger, BarcodeCharChangerDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
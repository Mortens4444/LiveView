using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing BarcodeScanOptions entities via REST API endpoints.
    /// </summary>
    public class BarcodeScanOptionsController : ApiControllerBaseWithLongModelId<BarcodeScanOptionsDto, BarcodeScanOptions, IBarcodeScanOptionsRepository, IConverter<BarcodeScanOptions, BarcodeScanOptionsDto>>
    {
        public BarcodeScanOptionsController(
            ILogger<BarcodeScanOptionsController> logger,
            IBarcodeScanOptionsRepository repository,
            IConverter<BarcodeScanOptions, BarcodeScanOptionsDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
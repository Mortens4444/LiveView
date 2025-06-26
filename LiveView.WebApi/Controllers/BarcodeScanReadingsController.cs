using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing BarcodeScanReading entities via REST API endpoints.
    /// </summary>
    public class BarcodeScanReadingsController : ApiControllerBaseWithLongModelId<BarcodeScanReadingDto, BarcodeScanReading, IBarcodeScanReadingRepository, IConverter<BarcodeScanReading, BarcodeScanReadingDto>>
    {
        public BarcodeScanReadingsController(
            ILogger<BarcodeScanReadingsController> logger,
            IBarcodeScanReadingRepository repository,
            IConverter<BarcodeScanReading, BarcodeScanReadingDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing BarcodeCharChanger entities via REST API endpoints.
    /// </summary>
    public class BarcodeCharChangersController : ApiControllerBaseWithLongModelId<BarcodeCharChangerDto, BarcodeCharChanger, IBarcodeCharChangerRepository, IConverter<BarcodeCharChanger, BarcodeCharChangerDto>>
    {
        public BarcodeCharChangersController(
            ILogger<BarcodeCharChangersController> logger,
            IBarcodeCharChangerRepository repository,
            IConverter<BarcodeCharChanger, BarcodeCharChangerDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
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
    public class RightsController : ApiControllerBaseWithLongModelId<RightDto, Right, IRightRepository, IConverter<Right, RightDto>>
    {
        public RightsController(
            ILogger<RightsController> logger,
            IRightRepository repository,
            IConverter<Right, RightDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
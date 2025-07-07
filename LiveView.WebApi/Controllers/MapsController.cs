using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing Map entities via REST API endpoints.
    /// </summary>
    public class MapsController : ApiControllerBaseWithIntModelId<MapDto, Map, IMapRepository, IConverter<Map, MapDto>>
    {
        public MapsController(
            ILogger<MapsController> logger,
            IMapRepository repository,
            IConverter<Map, MapDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
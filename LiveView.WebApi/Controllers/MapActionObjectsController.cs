using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing MapActionObject entities via REST API endpoints.
    /// </summary>
    public class MapActionObjectsController : ApiControllerBaseWithCompositeKey<MapActionObjectDto, MapActionObject, MapActionObject, IMapActionObjectRepository, IConverter<MapActionObject, MapActionObjectDto>>
    {
        public MapActionObjectsController(
            ILogger<MapActionObjectsController> logger,
            IMapActionObjectRepository repository,
            IConverter<MapActionObject, MapActionObjectDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
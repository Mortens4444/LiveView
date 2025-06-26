using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing MapObject entities via REST API endpoints.
    /// </summary>
    public class MapObjectsController : ApiControllerBaseWithIntModelId<MapObjectDto, MapObject, IMapObjectRepository, IConverter<MapObject, MapObjectDto>>
    {
        public MapObjectsController(
            ILogger<MapObjectsController> logger,
            IMapObjectRepository repository,
            IConverter<MapObject, MapObjectDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
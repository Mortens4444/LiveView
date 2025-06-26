using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing ObjectInMap entities via REST API endpoints.
    /// </summary>
    public class ObjectsInMapController : ApiControllerBaseWithCompositeKey<ObjectInMapDto, ObjectInMap, ObjectInMap, IObjectInMapRepository, IConverter<ObjectInMap, ObjectInMapDto>>
    {
        public ObjectsInMapController(
            ILogger<ObjectsInMapController> logger,
            IObjectInMapRepository repository,
            IConverter<ObjectInMap, ObjectInMapDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
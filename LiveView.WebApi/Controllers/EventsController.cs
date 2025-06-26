using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing Event entities via REST API endpoints.
    /// </summary>
    public class EventsController : ApiControllerBaseWithLongModelId<EventDto, Event, IEventRepository, IConverter<Event, EventDto>>
    {
        public EventsController(
            ILogger<EventsController> logger,
            IEventRepository repository,
            IConverter<Event, EventDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
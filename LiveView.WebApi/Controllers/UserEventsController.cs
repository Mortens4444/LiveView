using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing UserEvent entities via REST API endpoints.
    /// </summary>
    public class UserEventsController : ApiControllerBaseWithIntModelId<UserEventDto, UserEvent, IUserEventRepository, IConverter<UserEvent, UserEventDto>>
    {
        public UserEventsController(
            ILogger<UserEventsController> logger,
            IUserEventRepository repository,
            IConverter<UserEvent, UserEventDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
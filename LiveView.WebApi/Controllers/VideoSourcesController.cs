using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Dto;
using Mtf.Web.Interfaces;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing VideoSource entities via REST API endpoints.
    /// </summary>
    public class VideoSourcesController : ApiControllerBaseWithLongModelId<VideoSourceDto, VideoSource, IVideoSourceRepository, IConverter<VideoSource, VideoSourceDto>>
    {
        public VideoSourcesController(
            ILogger<VideoSourcesController> logger,
            IVideoSourceRepository repository,
            IConverter<VideoSource, VideoSourceDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
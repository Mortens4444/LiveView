using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Authorization;
using LiveView.WebApi.Dto;
using Mtf.Permissions.Enums;
using Mtf.Web.Interfaces;
using LiveView.WebApi.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing VideoSource entities via REST API endpoints.
    /// </summary>
    [RequiresPermissionGroup(typeof(ServerManagementPermissions))]
    public class VideoSourcesController : ApiControllerBaseWithIntModelId<VideoSourceDto, VideoSource, IVideoSourceRepository, IConverter<VideoSource, VideoSourceDto>>
    {
        public VideoSourcesController(
            ILogger<VideoSourcesController> logger,
            IVideoSourceRepository repository,
            IConverter<VideoSource, VideoSourceDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
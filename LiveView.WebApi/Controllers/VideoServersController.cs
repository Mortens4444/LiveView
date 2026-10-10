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
    /// Controller for managing Server entities via REST API endpoints.
    /// Provides standard CRUD (Create, Read, Update, Delete) operations for VideoServer data.
    /// Sets the base route for this controller (e.g., /api/videoservers)
    /// </summary>
    [RequiresPermissionGroup(typeof(ServerManagementPermissions))]
    public class VideoServersController : ApiControllerBaseWithIntModelId<VideoServerDto, VideoServer, IVideoServerRepository, IConverter<VideoServer, VideoServerDto>>
    {
        public VideoServersController(
            ILogger<VideoServersController> logger,
            IVideoServerRepository repository,
            IConverter<VideoServer, VideoServerDto> converter)
            : base(logger, repository, converter)
        { }
    }
}

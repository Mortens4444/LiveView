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
    /// Controller for managing SequenceGrids entities via REST API endpoints.
    /// </summary>
    [RequiresPermissionGroup(typeof(SequenceManagementPermissions))]
    public class SequenceGridsController : ApiControllerBaseWithIntModelId<SequenceGridsDto, SequenceGrid, ISequenceGridsRepository, IConverter<SequenceGrid, SequenceGridsDto>>
    {
        public SequenceGridsController(
            ILogger<SequenceGridsController> logger,
            ISequenceGridsRepository repository,
            IConverter<SequenceGrid, SequenceGridsDto> converter)
            : base(logger, repository, converter)
        { }
    }
}
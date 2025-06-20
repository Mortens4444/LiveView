using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Converters;
using LiveView.WebApi.Dto;
using Mtf.Web.WebAPI;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing Camera entities via REST API endpoints.
    /// Provides standard CRUD (Create, Read, Update, Delete) operations for Camera data.
    /// Sets the base route for this controller (e.g., /api/cameras)
    /// </summary>
    public class CamerasController : ApiControllerBaseWithLongModelId<CameraDto, Camera, ICameraRepository, CameraConverter>
    {
        public CamerasController(
            ILogger<CamerasController> logger,
            ICameraRepository repository,
            CameraConverter converter)
            : base(logger, repository, converter)
        { }
    }
}

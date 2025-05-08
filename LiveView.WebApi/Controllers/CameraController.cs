using Database.Interfaces;
using Database.Models;
using LiveView.WebApi.Converters;
using LiveView.WebApi.Dto;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing Camera entities via REST API endpoints.
    /// Provides standard CRUD (Create, Read, Update, Delete) operations for Camera data.
    /// Sets the base route for this controller (e.g., /api/camera)
    /// </summary>
    public class CameraController : BaseController<CameraDto, Camera, ICameraRepository, CameraConverter>
    {
        public CameraController(
            ILogger<CameraController> logger,
            ICameraRepository repository,
            CameraConverter converter)
            : base(logger, repository, converter)
        { }
    }
}

using Database.Interfaces;
using LiveView.WebApi.Converters;
using LiveView.WebApi.Dto;
using Microsoft.AspNetCore.Mvc;

// Namespace for Web API Controllers
namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing Camera entities via REST API endpoints.
    /// Provides standard CRUD (Create, Read, Update, Delete) operations for Camera data.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CameraController : ControllerBase
    {
        private readonly ILogger<CameraController> logger;
        private readonly CameraConverter cameraConverter;
        private readonly ICameraRepository cameraRepository;

        /// <summary>
        /// Constructor for the CameraController.
        /// Injects necessary dependencies: Logger, Camera Repository, and Camera Converter.
        /// </summary>
        /// <param name="logger">Logger instance provided by the dependency injection container.</param>
        /// <param name="cameraRepository">Camera Repository instance provided by the dependency injection container.</param>
        /// <param name="cameraConverter">Camera Converter instance provided by the dependency injection container.</param>
        public CameraController(ILogger<CameraController> logger, ICameraRepository cameraRepository, CameraConverter cameraConverter)
        {
            this.logger = logger;
            this.cameraConverter = cameraConverter;
            this.cameraRepository = cameraRepository;
        }

        /// <summary>
        /// Gets all Camera entities.
        /// </summary>
        /// <returns>An ActionResult containing an IEnumerable of CameraDto objects.</returns>
        [HttpGet] // Maps this action to HTTP GET requests to the controller's base route (/api/Camera)
        public ActionResult<IEnumerable<CameraDto>> GetAll()
        {
            logger.LogInformation("Getting all cameras");
            var cameraModels = cameraRepository.SelectAll();
            var result = cameraModels.Select(cameraConverter.ToDto);
            return Ok(result);
        }

        /// <summary>
        /// Gets a specific Camera entity by its unique identifier (Id).
        /// </summary>
        /// <param name="id">The long integer ID of the camera to retrieve.</param>
        /// <returns>An ActionResult containing the CameraDto object if found, otherwise NotFound.</returns>
        [HttpGet("{id:long}")] // Maps this action to HTTP GET requests like /api/Camera/123
        public ActionResult<CameraDto> GetById(long id)
        {
            logger.LogInformation($"Getting camera with id: {id}");

            var cameraModel = cameraRepository.Select(id);
            var result = cameraConverter.ToDto(cameraModel);
            return result is not null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Creates a new Camera entity.
        /// </summary>
        /// <param name="dto">The CameraDto object containing the data for the new camera.</param>
        /// <returns>An ActionResult containing the created CameraDto with its assigned ID, or BadRequest if the input data is invalid.</returns>
        [HttpPost] // Maps this action to HTTP POST requests to the controller's base route (/api/Camera)
        public ActionResult<CameraDto> Create(CameraDto dto)
        {
            logger.LogInformation("Creating a new camera");

            var camera = cameraConverter.ToModel(dto);
            if (camera == null)
            {
                logger.LogWarning("Invalid camera data received for creation.");
                return BadRequest("Invalid data");
            }

            var id = cameraRepository.InsertAndReturnId<long>(camera);
            dto.Id = id;
            logger.LogInformation($"Camera created with id: {id}");
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        /// <summary>
        /// Updates an existing Camera entity.
        /// </summary>
        /// <param name="id">The long integer ID of the camera to update.</param>
        /// <param name="dto">The CameraDto object containing the updated data.</param>
        /// <returns>An IActionResult indicating the result of the update operation (NoContent, NotFound, or BadRequest).</returns>
        [HttpPut("{id:long}")] // Maps this action to HTTP PUT requests like /api/Camera/123
        public IActionResult Update(long id, CameraDto dto)
        {
            logger.LogInformation($"Updating camera with id: {id}");

            var existing = cameraRepository.Select(id);
            if (existing == null)
            {
                logger.LogWarning($"Camera with id {id} not found for update.");
                return NotFound();
            }

            var updated = cameraConverter.ToModel(dto with { Id = id });
            if (updated == null)
            {
                logger.LogWarning($"Invalid camera data received for updating grid with id {id}.");
                return BadRequest("Invalid data");
            }

            cameraRepository.Update(updated);
            logger.LogInformation($"Camera with id {id} updated successfully.");
            return NoContent();
        }

        /// <summary>
        /// Deletes a specific Camera entity by its unique identifier (Id).
        /// </summary>
        /// <param name="id">The long integer ID of the camera to delete.</param>
        /// <returns>An IActionResult indicating the result of the delete operation (NoContent or NotFound).</returns>
        [HttpDelete("{id:long}")] // Maps this action to HTTP DELETE requests like /api/Camera/123
        public IActionResult Delete(long id)
        {
            logger.LogInformation($"Deleting camera with id: {id}");

            var existing = cameraRepository.Select(id);
            if (existing == null)
            {
                logger.LogWarning($"Camera with id {id} not found for deletion.");
                return NotFound();
            }

            cameraRepository.Delete(id);

            logger.LogInformation($"Camera with id {id} deleted successfully.");
            return NoContent();
        }
    }
}

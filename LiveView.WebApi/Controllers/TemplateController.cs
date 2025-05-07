using Database.Interfaces;
using LiveView.WebApi.Converters;
using LiveView.WebApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LiveView.WebApi.Controllers
{
    /// <summary>
    /// Controller for managing Template entities via REST API endpoints.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")] // Sets the base route for this controller (e.g., /api/Template)
    public class TemplateController : ControllerBase
    {
        private readonly ILogger<TemplateController> logger;
        private readonly TemplateConverter templateConverter;
        private readonly ITemplateRepository templateRepository;

        /// <summary>
        /// Constructor for the TemplateController.
        /// Injects dependencies: Logger, Template Repository, and Template Converter.
        /// </summary>
        /// <param name="logger">Logger instance.</param>
        /// <param name="templateRepository">Template Repository instance.</param>
        /// <param name="templateConverter">Template Converter instance.</param>
        public TemplateController(ILogger<TemplateController> logger, ITemplateRepository templateRepository, TemplateConverter templateConverter)
        {
            this.logger = logger;
            this.templateConverter = templateConverter;
            this.templateRepository = templateRepository;
        }

        /// <summary>
        /// Gets all Template entities.
        /// </summary>
        /// <returns>A list of TemplateDto objects.</returns>
        [HttpGet] // Maps this action to HTTP GET requests to /api/Template
        public ActionResult<IEnumerable<TemplateDto>> GetAll()
        {
            logger.LogInformation("Getting all templates");
            var templateModels = templateRepository.SelectAll(); // Retrieve all models from the repository
            var result = templateModels.Select(templateConverter.ToDto); // Convert models to DTOs
            return Ok(result); // Return 200 OK with the list of DTOs
        }

        /// <summary>
        /// Gets a specific Template entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the template to retrieve.</param>
        /// <returns>The TemplateDto object if found, otherwise NotFound.</returns>
        [HttpGet("{id:long}")] // Maps this action to HTTP GET requests like /api/Template/123
        public ActionResult<TemplateDto> GetById(long id)
        {
            logger.LogInformation($"Getting template with id: {id}");
            var templateModel = templateRepository.Select(id);
            var result = templateConverter.ToDto(templateModel);
            return result is not null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Creates a new Template entity.
        /// </summary>
        /// <param name="dto">The TemplateDto containing the data for the new template.</param>
        /// <returns>The created TemplateDto with its assigned ID, or BadRequest if invalid data.</returns>
        [HttpPost] // Maps this action to HTTP POST requests to /api/Template
        public ActionResult<TemplateDto> Create(TemplateDto dto)
        {
            logger.LogInformation("Creating a new template");
            var template = templateConverter.ToModel(dto);
            if (template == null)
            {
                logger.LogWarning("Invalid template data received for creation.");
                return BadRequest("Invalid data");
            }

            var id = templateRepository.InsertAndReturnId<long>(template);
            dto.Id = id;

            logger.LogInformation($"Template created with id: {id}");
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        /// <summary>
        /// Updates an existing Template entity.
        /// </summary>
        /// <param name="id">The ID of the template to update.</param>
        /// <param name="dto">The TemplateDto containing the updated data.</param>
        /// <returns>NoContent if successful, NotFound if the template does not exist, or BadRequest if invalid data.</returns>
        [HttpPut("{id:long}")] // Maps this action to HTTP PUT requests like /api/Template/123
        public IActionResult Update(long id, TemplateDto dto)
        {
            logger.LogInformation($"Updating template with id: {id}");
            var existing = templateRepository.Select(id);
            if (existing == null)
            {
                logger.LogWarning($"Template with id {id} not found for update.");
                return NotFound();
            }

            var updated = templateConverter.ToModel(dto with { Id = id });
            if (updated == null)
            {
                logger.LogWarning($"Invalid template data received for updating template with id {id}.");
                return BadRequest("Invalid data");
            }

            templateRepository.Update(updated);
            logger.LogInformation($"Template with id {id} updated successfully.");
            return NoContent();
        }

        /// <summary>
        /// Deletes a specific Template entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the template to delete.</param>
        /// <returns>NoContent if successful, or NotFound if the template does not exist.</returns>
        [HttpDelete("{id:long}")] // Maps this action to HTTP DELETE requests like /api/Template/123
        public IActionResult Delete(long id)
        {
            logger.LogInformation($"Deleting template with id: {id}");
            var existing = templateRepository.Select(id);
            if (existing == null)
            {
                logger.LogWarning($"Template with id {id} not found for deletion.");
                return NotFound();
            }

            templateRepository.Delete(id);
            logger.LogInformation($"Template with id {id} deleted successfully.");
            return NoContent();
        }
    }
}

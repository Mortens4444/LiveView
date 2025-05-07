using Database.Interfaces;
using LiveView.WebApi.Converters;
using LiveView.WebApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LiveView.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GridController : ControllerBase
    {
        private readonly ILogger<GridController> logger;
        private readonly GridConverter gridConverter;
        private readonly IGridRepository gridRepository;

        public GridController(ILogger<GridController> logger, IGridRepository gridRepository, GridConverter gridConverter)
        {
            this.logger = logger;
            this.gridConverter = gridConverter;
            this.gridRepository = gridRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GridDto>> GetAll()
        {
            logger.LogInformation("Getting all grids");
            var gridModels = gridRepository.SelectAll();
            var result = gridModels.Select(gridConverter.ToDto);
            return Ok(result);
        }

        [HttpGet("{id:long}")]
        public ActionResult<GridDto> GetById(long id)
        {
            logger.LogInformation($"Getting grid with id: {id}");
            var gridModel = gridRepository.Select(id);
            var result = gridConverter.ToDto(gridModel);
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public ActionResult<GridDto> Create(GridDto dto)
        {
            logger.LogInformation("Creating a new grid");
            var grid = gridConverter.ToModel(dto);
            if (grid == null)
            {
                logger.LogWarning("Invalid grid data received for creation.");
                return BadRequest("Invalid data");
            }

            var id = gridRepository.InsertAndReturnId<long>(grid);
            dto.Id = id;
            logger.LogInformation($"Grid created with id: {id}");
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        [HttpPut("{id:long}")]
        public IActionResult Update(long id, GridDto dto)
        {
            logger.LogInformation($"Updating grid with id: {id}");
            var existing = gridRepository.Select(id);
            if (existing == null)
            {
                logger.LogWarning($"Grid with id {id} not found for update.");
                return NotFound();
            }

            // Ensure the ID from the route is used for the update
            var updated = gridConverter.ToModel(dto with { Id = id });
            if (updated == null)
            {
                logger.LogWarning($"Invalid grid data received for updating grid with id {id}.");
                return BadRequest("Invalid data");
            }

            gridRepository.Update(updated);
            logger.LogInformation($"Grid with id {id} updated successfully.");
            return NoContent();
        }

        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id)
        {
            logger.LogInformation($"Deleting grid with id: {id}");
            var existing = gridRepository.Select(id);
            if (existing == null)
            {
                logger.LogWarning($"Grid with id {id} not found for deletion.");
                return NotFound();
            }

            gridRepository.Delete(id);
            logger.LogInformation($"Grid with id {id} deleted successfully.");
            return NoContent();
        }
    }
}

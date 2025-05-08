using Database.Interfaces;
using LiveView.WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Mtf.Database.Interfaces;

namespace LiveView.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TDto, TModel, TRepository, TConverter> : ControllerBase
        where TDto : IHaveIdWithSetter<long>?
        where TModel : IHaveId<long>?
        where TRepository : IRepository<TModel>
        where TConverter : IConverter<TModel, TDto>
    {
        protected readonly ILogger logger;
        protected readonly TRepository repository;
        protected readonly TConverter converter;

        protected BaseController(ILogger logger, TRepository repository, TConverter converter)
        {
            this.logger = logger;
            this.repository = repository;
            this.converter = converter;
        }

        [HttpGet]
        public virtual ActionResult<IEnumerable<TDto>> GetAll()
        {
            logger.LogInformation($"Getting all {typeof(TModel).Name}s");
            var models = repository.SelectAll();
            var result = models?.Select(converter.ToDto);
            return Ok(result);
        }

        [HttpGet("{id:long}")]
        public virtual ActionResult<TDto> GetById(long id)
        {
            logger.LogInformation($"Getting {typeof(TModel).Name} with id: {id}");
            var model = repository.Select(id);
            if (model == null)
            {
                return NotFound();
            }

            var dto = converter.ToDto(model);
            return Ok(dto);
        }

        [HttpPost]
        public virtual ActionResult<TDto> Create(TDto dto)
        {
            logger.LogInformation("Creating a new {Entity}", typeof(TModel).Name);
            var model = converter.ToModel(dto);
            if (model == null)
            {
                return BadRequest("Invalid data");
            }

            var id = repository.InsertAndReturnId<long>(model);
            dto.Id = id;

            logger.LogInformation("{Entity} created with id: {Id}", typeof(TModel).Name, id);
            return CreatedAtAction(nameof(GetById), new { id }, dto);

        }

        [HttpPut("{id:long}")]
        public virtual IActionResult Update(long id, TDto dto)
        {
            logger.LogInformation("Updating {Entity} with id: {Id}", typeof(TModel).Name, id);

            var existing = repository.Select(id);
            if (existing == null)
            {
                return NotFound();
            }

            dto.Id = id;

            var model = converter.ToModel(dto);
            if (model == null)
            {
                return BadRequest("Invalid data");
            }

            repository.Update(model);

            logger.LogInformation("{Entity} with id: {Id} updated successfully", typeof(TModel).Name, id);
            return NoContent();
        }

        [HttpDelete("{id:long}")]
        public virtual IActionResult Delete(long id)
        {
            logger.LogInformation("Deleting {Entity} with id: {Id}", typeof(TModel).Name, id);

            var existing = repository.Select(id);
            if (existing == null)
            {
                return NotFound();
            }

            repository.Delete(id);

            logger.LogInformation("{Entity} with id: {Id} deleted successfully", typeof(TModel).Name, id);
            return NoContent();
        }
    }
}

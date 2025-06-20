using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mtf.Database.Interfaces;
using Mtf.Extensions.Interfaces;
using Mtf.Web.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Mtf.Web.WebAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase<TDto, TModel, TIdType, TRepository, TConverter> : ControllerBase
        where TIdType : struct
        where TDto : IHaveIdWithSetter<TIdType>
        where TModel : IHaveId<TIdType>
        where TRepository : IRepository<TModel>
        where TConverter : IConverter<TModel, TDto>
    {
        protected ILogger Logger { get; }
        protected TRepository Repository { get; }
        protected TConverter Converter { get; }

        protected ApiControllerBase(ILogger logger, TRepository repository, TConverter converter)
        {
            Logger = logger;
            Repository = repository;
            Converter = converter;
        }

        [HttpGet]
        public virtual ActionResult<IEnumerable<TDto>> GetAll()
        {
            Logger.LogInformation($"Getting all {typeof(TModel).Name}s");
            var models = Repository.SelectAll();
            var result = models?.Select(Converter.ToDto);
            return Ok(result);
        }

        [HttpGet("{id:long}")]
        public virtual ActionResult<TDto> GetById(long id)
        {
            Logger.LogInformation($"Getting {typeof(TModel).Name} with id: {id}");
            var model = Repository.Select(id);
            if (model == null)
            {
                return NotFound();
            }

            var dto = Converter.ToDto(model);
            return Ok(dto);
        }

        [HttpPost]
        public virtual ActionResult<TDto> Create(TDto dto)
        {
            Logger.LogInformation("Creating a new {Entity}", typeof(TModel).Name);
            var model = Converter.ToModel(dto);
            if (model == null)
            {
                return BadRequest("Invalid data");
            }

            var id = Repository.InsertAndReturnId<TIdType>(model);
            dto.Id = id;

            Logger.LogInformation("{Entity} created with id: {Id}", typeof(TModel).Name, id);
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        [HttpPut("{id}")]
        public virtual IActionResult Update(TIdType id, TDto dto)
        {
            Logger.LogInformation("Updating {Entity} with id: {Id}", typeof(TModel).Name, id);

            var existing = Select(id);
            if (existing == null)
            {
                return NotFound();
            }

            dto.Id = id;

            var model = Converter.ToModel(dto);
            if (model == null)
            {
                return BadRequest("Invalid data");
            }

            Repository.Update(model);

            Logger.LogInformation("{Entity} with id: {Id} updated successfully", typeof(TModel).Name, id);
            return NoContent();
        }

        protected abstract TModel Select(TIdType id);

        [HttpDelete("{id:long}")]
        public virtual IActionResult Delete(long id)
        {
            Logger.LogInformation("Deleting {Entity} with id: {Id}", typeof(TModel).Name, id);

            var existing = Repository.Select(id);
            if (existing == null)
            {
                return NotFound();
            }

            Repository.Delete(id);

            Logger.LogInformation("{Entity} with id: {Id} deleted successfully", typeof(TModel).Name, id);
            return NoContent();
        }
    }
}

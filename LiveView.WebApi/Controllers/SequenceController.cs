using Database.Interfaces;
using LiveView.WebApi.Converters;
using LiveView.WebApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LiveView.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SequenceController : ControllerBase
    {
        private readonly ILogger<SequenceController> logger;
        private readonly SequenceConverter sequenceConverter;
        private readonly ISequenceRepository sequenceRepository;

        public SequenceController(ILogger<SequenceController> logger, ISequenceRepository sequenceRepository, SequenceConverter sequenceConverter)
        {
            this.logger = logger;
            this.sequenceConverter = sequenceConverter;
            this.sequenceRepository = sequenceRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SequenceDto>> GetAll()
        {
            var sequenceModels = sequenceRepository.SelectAll();
            var result = sequenceModels.Select(sequenceConverter.ToDto);
            return Ok(result);
        }

        [HttpGet("{id:long}")]
        public ActionResult<SequenceDto> GetById(long id)
        {
            var sequenceModel = sequenceRepository.Select(id);
            var result = sequenceConverter.ToDto(sequenceModel);
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public ActionResult<SequenceDto> Create(SequenceDto dto)
        {
            var sequence = sequenceConverter.ToModel(dto);
            if (sequence == null)
            {
                return BadRequest("Invalid data");
            }
            var id = sequenceRepository.InsertAndReturnId<long>(sequence);
            dto.Id = id;
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        [HttpPut("{id:long}")]
        public IActionResult Update(long id, SequenceDto dto)
        {
            var existing = sequenceRepository.Select(id);
            if (existing == null)
            {
                return NotFound();
            }

            var updated = sequenceConverter.ToModel(dto with { Id = id });
            sequenceRepository.Update(updated);
            return NoContent();
        }

        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id)
        {
            var existing = sequenceRepository.Select(id);
            if (existing == null)
            {
                return NotFound();
            }

            sequenceRepository.Delete(id);
            return NoContent();
        }
    }
}

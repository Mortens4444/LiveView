using Database.Models;
using LiveView.WebApi.Dto;
using LiveView.WebApi.Interfaces;

namespace LiveView.WebApi.Converters
{
    public class SequenceConverter : IConverter<Sequence, SequenceDto>
    {
        /// <summary>
        /// Converts a Database.Models.Sequence object to a SequenceDto object.
        /// </summary>
        /// <param name="model">The source Sequence model.</param>
        /// <returns>The converted SequenceDto, or null if the source is null.</returns>
        public SequenceDto? ToDto(Sequence? model)
        {
            if (model == null)
            {
                return null;
            }

            return new SequenceDto
            {
                Active = model.Active,
                Id = model.Id,
                Name = model.Name,
                Priority = model.Priority
            };
        }

        /// <summary>
        /// Converts a SequenceDto object to a Database.Models.Sequence object.
        /// </summary>
        /// <param name="dto">The source SequenceDto.</param>
        /// <returns>The converted Database.Models.Sequence, or null if the source DTO is null.</returns>
        public Sequence? ToModel(SequenceDto? dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new Sequence
            {
                Active = dto.Active,
                Id = dto.Id,
                Name = dto.Name,
                Priority = dto.Priority
            };
        }
    }
}

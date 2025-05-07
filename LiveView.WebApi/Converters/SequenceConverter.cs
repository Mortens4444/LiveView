using LiveView.WebApi.Dto;

namespace LiveView.WebApi.Converters
{
    public class SequenceConverter
    {
        public SequenceDto? ToDto(Database.Models.Sequence sequence)
        {
            if (sequence == null)
            {
                return null;
            }

            return new SequenceDto
            {
                Active = sequence.Active,
                Id = sequence.Id,
                Name = sequence.Name,
                Priority = sequence.Priority
            };
        }

        public Database.Models.Sequence? ToModel(SequenceDto sequence)
        {
            if (sequence == null)
            {
                return null;
            }

            return new Database.Models.Sequence
            {
                Active = sequence.Active,
                Id = sequence.Id,
                Name = sequence.Name,
                Priority = sequence.Priority
            };
        }
    }
}

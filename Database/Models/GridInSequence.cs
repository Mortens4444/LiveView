using Database.Interfaces;
using Mtf.Extensions.Interfaces;

namespace Database.Models
{
    public class GridInSequence : IHaveId<long>, IHaveNumber
    {
        public long Id { get; set; }

        public long SequenceId { get; set; }

        public long GridId { get; set; }

        public int TimeToShow { get; set; }

        public int Number { get; set; }
    }
}

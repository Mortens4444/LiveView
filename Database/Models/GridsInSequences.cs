using Database.Interfaces;

namespace Database.Models
{
    public class GridsInSequences : IHaveId<long>
    {
        public long Id { get; set; }

        public long SequenceId { get; set; }

        public long GridId { get; set; }

        public int TimeToShow { get; set; }

        public int Number { get; set; }
    }
}

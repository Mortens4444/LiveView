using Database.Interfaces;
using Mtf.Extensions.Interfaces;

namespace Database.Models
{
    public class SequenceGrid : IHaveId<int>, IHaveNumber
    {
        public int Id { get; set; }

        public int SequenceId { get; set; }

        public int GridId { get; set; }

        public int TimeToShow { get; set; }

        public int Number { get; set; }
    }
}

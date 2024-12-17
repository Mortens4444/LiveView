namespace Database.Models
{
    public class GridsInSequences
    {
        public long Id { get; set; }

        public long SequenceId { get; set; }

        public long GridId { get; set; }

        public int TimeToShow { get; set; }

        public int Number { get; set; }

        public string Checksum { get; set; }
    }
}

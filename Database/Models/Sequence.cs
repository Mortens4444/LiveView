namespace Database.Models
{
    public class Sequence
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public int? Priority { get; set; }
    }
}

using Mtf.Extensions.Interfaces;

namespace Database.Models
{
    public class Sequence : IHaveId<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public int? Priority { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

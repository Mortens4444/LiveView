using Database.Interfaces;

namespace Database.Models
{
    public class Map : IHaveId<long>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public int OriginalWidth { get; set; }

        public int OriginalHeight { get; set; }

        public byte[] MapImage { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

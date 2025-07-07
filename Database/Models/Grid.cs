using Mtf.Extensions.Interfaces;

namespace Database.Models
{
    public class Grid : IHaveId<int>
    {
        public int Id { get; set; }

        public int Rows { get; set; }

        public int Columns { get; set; }

        public int PixelsFromRight { get; set; }

        public int PixelsFromBottom { get; set; }

        public string Name { get; set; }

        public int? Priority { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

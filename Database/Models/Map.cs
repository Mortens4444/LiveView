using static System.Net.Mime.MediaTypeNames;

namespace Database.Models
{
    public class Map
    {
        public long Id { get; private set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public int OriginalWidth { get; set; }

        public int OriginalHeight { get; set; }

        public byte[] MapImage { get; set; }
    }
}

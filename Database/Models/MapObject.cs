using Database.Enums;
using Database.Interfaces;

namespace Database.Models
{
    public class MapObject : IHaveId<int>
    {
        public int Id { get; set; }

        public MapActionType ActionType { get; set; }

        public long ActionReferencedId { get; set; }

        public string Comment { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public byte[] Image { get; set; }
    }
}

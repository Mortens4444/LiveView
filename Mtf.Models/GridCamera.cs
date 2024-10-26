namespace Mtf.Models
{
    public class GridCamera
    {
        public int GridId { get; set; }

        public int CameraId { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public int RowSpan { get; set; } = 1;

        public int ColumnSpan { get; set; } = 1;
    }
}

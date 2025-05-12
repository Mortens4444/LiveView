using System.Drawing;

namespace LiveView.Dto
{
    public class LocationAndSize
    {
        public Point Location { get; set; }

        public Size Size { get; set; }

        public int Left
        {
            get { return Location.X; }
        }

        public int Top
        {
            get { return Location.Y; }
        }

        public int Width
        {
            get { return Size.Width; }
        }

        public int Height
        {
            get { return Size.Height; }
        }

        public LocationAndSize(int x, int y, int width, int height)
            : this(new Point(x, y), new Size(width, height))
        { }

        public LocationAndSize(Point location, Size size)
        {
            Location = location;
            Size = size;
        }

        public override string ToString()
        {
            return $"Location: ({Location.X}, {Location.Y}), Size: {Size.Width}x{Size.Height}";
        }
    }
}

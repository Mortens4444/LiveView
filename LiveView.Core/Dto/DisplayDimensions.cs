using System.Drawing;

namespace LiveView.Core.Dto
{
    public class DisplayDimensions
    {
        public Rectangle Bounds { get; set; }

        public Point Location { get; set; }

        public DisplayDimensions(Rectangle bounds, Point location)
        {
            Bounds = bounds;
            Location = location;
        }

        public override bool Equals(object obj)
        {
            if (obj is DisplayDimensions other)
            {
                return Bounds.Equals(other.Bounds) && Location.Equals(other.Location);
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Bounds.GetHashCode();
                hash = hash * 23 + Location.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(DisplayDimensions left, DisplayDimensions right) => Equals(left, right);

        public static bool operator !=(DisplayDimensions left, DisplayDimensions right) => !Equals(left, right);
    }
}

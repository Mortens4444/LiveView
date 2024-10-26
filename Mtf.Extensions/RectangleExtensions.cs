using System.Drawing;

namespace Mtf.Extensions
{
    public static class RectangleExtensions
    {
        public static Point GetMiddle(this Rectangle value)
        {
            return new Point
            {
                X = value.Left + (value.Width / 2),
                Y = value.Top + (value.Height / 2)
            };
        }

        public static int GetMiddleX(this Rectangle value)
        {
            return value.Left + (value.Width / 2);
        }

        public static int GetMiddleY(this Rectangle value)
        {
            return value.Top + (value.Height / 2);
        }
    }
}

using System.Drawing;
using System.Runtime.InteropServices;

namespace LiveView.Dto
{
    /// <summary>
    /// The RECT structure defines the coordinates of the upper-left and lower-right corners of a rectangle.
    /// </summary>
    /// <see cref="http://msdn.microsoft.com/en-us/library/dd162897%28VS.85%29.aspx"/>
    /// <remarks>
    /// By convention, the right and bottom edges of the rectangle are normally considered exclusive. 
    /// In other words, the pixel whose coordinates are ( right, bottom ) lies immediately outside of the the rectangle. 
    /// For example, when RECT is passed to the FillRect function, the rectangle is filled up to, but not including, 
    /// the right column and bottom row of pixels. This structure is identical to the RECTL structure.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        /// <summary>
        /// The x-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public int Left;
        /// <summary>
        /// The y-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public int Top;
        /// <summary>
        /// The x-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        public int Right;
        /// <summary>
        /// The y-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        public int Bottom;

        public RECT(int x, int y, int width, int height)
        {
            Left = x;
            Top = y;
            Right = x + width;
            Bottom = y + height;
        }

        public static implicit operator Rectangle(RECT r)
        {
            return new Rectangle(r.Left, r.Right, r.Right - r.Left, r.Bottom - r.Top);
        }

        public static implicit operator RECT(Rectangle r)
        {
            return new RECT(r.Left, r.Top, r.Width, r.Height);
        }
    }
}

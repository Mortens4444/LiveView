using Mtf.Enums.Color;
using System;
using System.Drawing;

namespace Mtf.Models.Colors
{
    public class YUVColor
    {
        private readonly int C;
        private readonly int D;
        private readonly int E;

        public byte Y { get; private set; }
        public byte U { get; private set; }
        public byte V { get; private set; }
        public byte R { get; private set; }
        public byte G { get; private set; }
        public byte B { get; private set; }

        public YUVColor(Color color)
            : this(color.R, color.G, color.B, ColorSpaceType.RGB)
        {
        }

        public YUVColor(int rCY, int gDU, int bEV, ColorSpaceType type)
        {
            switch (type)
            {
                case ColorSpaceType.RGB:
                    C = Convert.ToInt32(((66 * rCY) + (129 * gDU) + (25 * bEV) + 128) >> 8);
                    D = Convert.ToInt32(((-38 * rCY) - (74 * gDU) + (112 * bEV) + 128) >> 8);
                    E = Convert.ToInt32(((112 * rCY) - (94 * gDU) - (18 * bEV) + 128) >> 8);
                    Y = Convert.ToByte(C + 16);
                    U = Convert.ToByte(D + 128);
                    V = Convert.ToByte(E + 128);
                    R = Convert.ToByte(rCY);
                    G = Convert.ToByte(gDU);
                    B = Convert.ToByte(bEV);
                    break;
                case ColorSpaceType.CDE:
                    C = rCY;
                    D = gDU;
                    E = bEV;
                    Y = Convert.ToByte(C + 16);
                    U = Convert.ToByte(D + 128);
                    V = Convert.ToByte(E + 128);
                    R = Clip(((298 * C) + (409 * E) + 128) >> 8);
                    G = Clip(((298 * C) - (100 * D) - (208 * E) + 128) >> 8);
                    B = Clip(((298 * C) + (516 * D) + 128) >> 8);
                    break;
                case ColorSpaceType.YUV:
                    Y = Convert.ToByte(rCY);
                    U = Convert.ToByte(gDU);
                    V = Convert.ToByte(bEV);
                    C = Convert.ToInt32(Y - 16);
                    D = Convert.ToInt32(U - 128);
                    E = Convert.ToInt32(V - 128);
                    R = Clip(((298 * C) + (409 * E) + 128) >> 8);
                    G = Clip(((298 * C) - (100 * D) - (208 * E) + 128) >> 8);
                    B = Clip(((298 * C) + (516 * D) + 128) >> 8);
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        private static byte Clip(int value)
        {
            return Convert.ToByte(Math.Max(Math.Min(value, 255), 0));
        }

        public Color ToColor()
        {
            return ConvertToColor(this);
        }

        public static Color ConvertToColor(YUVColor yuvColor)
        {
            return yuvColor == null ? throw new ArgumentNullException(nameof(yuvColor)) : Color.FromArgb(yuvColor.R, yuvColor.G, yuvColor.B);
        }

        public override string ToString()
        {
            return $"RGB = ({R}, {G}, {B}); YUV = ({Y}, {U}, {V})";
        }
    }

}

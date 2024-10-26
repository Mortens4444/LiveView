using Mtf.Enums.Color;
using System;
using System.Drawing;

namespace Mtf.Models.Colors
{
    public class YUV_Color
    {
        public byte Y;
        public byte U;
        public byte V;

        private int C;
        private int D;
        private int E;

        public byte R;
        public byte G;
        public byte B;

        public YUV_Color(Color color)
            : this(color.R, color.G, color.B, ColorSpaceType.RGB)
        {
        }

        public YUV_Color(int r_c_y, int g_d_u, int b_e_v, ColorSpaceType type)
        {
            switch (type)
            {
                case ColorSpaceType.RGB:
                    this.C = Convert.ToInt32((66 * r_c_y + 129 * g_d_u + 25 * b_e_v + 128) >> 8);
                    this.D = Convert.ToInt32((-38 * r_c_y - 74 * g_d_u + 112 * b_e_v + 128) >> 8);
                    this.E = Convert.ToInt32((112 * r_c_y - 94 * g_d_u - 18 * b_e_v + 128) >> 8);
                    this.Y = Convert.ToByte(this.C + 16);
                    this.U = Convert.ToByte(this.D + 128);
                    this.V = Convert.ToByte(this.E + 128);
                    this.R = Convert.ToByte(r_c_y);
                    this.G = Convert.ToByte(g_d_u);
                    this.B = Convert.ToByte(b_e_v);
                    break;
                case ColorSpaceType.CDE:
                    this.C = r_c_y;
                    this.D = g_d_u;
                    this.E = b_e_v;
                    this.Y = Convert.ToByte(this.C + 16);
                    this.U = Convert.ToByte(this.D + 128);
                    this.V = Convert.ToByte(this.E + 128);
                    this.R = Clip((298 * this.C + 409 * this.E + 128) >> 8);
                    this.G = Clip((298 * this.C - 100 * this.D - 208 * this.E + 128) >> 8);
                    this.B = Clip((298 * this.C + 516 * this.D + 128) >> 8);
                    break;
                case ColorSpaceType.YUV:
                    this.Y = Convert.ToByte(r_c_y);
                    this.U = Convert.ToByte(g_d_u);
                    this.V = Convert.ToByte(b_e_v);
                    this.C = Convert.ToInt32(this.Y - 16);
                    this.D = Convert.ToInt32(this.U - 128);
                    this.E = Convert.ToInt32(this.V - 128);
                    this.R = Clip((298 * this.C + 409 * this.E + 128) >> 8);
                    this.G = Clip((298 * this.C - 100 * this.D - 208 * this.E + 128) >> 8);
                    this.B = Clip((298 * this.C + 516 * this.D + 128) >> 8);
                    break;
            }
        }

        private byte Clip(int value)
        {
            return Convert.ToByte(Math.Max(Math.Min(value, 255), 0));
        }

        public Color ToColor()
        {
            return ConvertToColor(this);
        }

        public static Color ConvertToColor(YUV_Color yuv_color)
        {
            return Color.FromArgb(yuv_color.R, yuv_color.G, yuv_color.B);
        }

        public override string ToString()
        {
            return String.Format("RGB = ({0}, {1}, {2})", this.R, this.G, this.B);
            //return String.Format("YUV = ({0}, {1}, {2})", this.Y, this.U, this.V);
        }
    }

}

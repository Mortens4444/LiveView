using System;
using System.Drawing;

namespace Mtf.Models.Colors
{
    public class CMYColor
    {
        public Color Color { get; private set; }
        public int A { get; private set; }
        public int R { get; private set; }
        public int G { get; private set; }
        public int B { get; private set; }

        public int C { get; private set; }
        public int M { get; private set; }
        public int Y { get; private set; }

        public CMYColor(Color color)
        {
            A = color.A;
            R = color.R;
            G = color.G;
            B = color.B;
            Color = color;

            var (c, m, y) = RgbToCmy(color);
            C = (int)Math.Round(c);
            M = (int)Math.Round(m);
            Y = (int)Math.Round(y);
        }

        public CMYColor(double C, double M, double Y)
        {
            this.C = (int)Math.Round(C);
            this.M = (int)Math.Round(M);
            this.Y = (int)Math.Round(Y);

            A = 255;
            Color = CmyToRgb(C, M, Y);
            R = Color.R;
            G = Color.G;
            B = Color.B;
        }

        public override string ToString()
        {
            return $"RGB = ({R}, {G}, {B}); CMY = ({C}, {M}, {Y})";
        }

        public static (double C, double M, double Y) RgbToCmy(Color rgbColor)
        {
            var r = rgbColor.R / 255.0;
            var g = rgbColor.G / 255.0;
            var b = rgbColor.B / 255.0;

            var c = 1 - r;
            var m = 1 - g;
            var y = 1 - b;

            return (c, m, y);
        }

        public static Color CmyToRgb(double c, double m, double y)
        {
            var r = (int)((1 - c) * 255);
            var g = (int)((1 - m) * 255);
            var b = (int)((1 - y) * 255);

            return Color.FromArgb(r, g, b);
        }
    }
}

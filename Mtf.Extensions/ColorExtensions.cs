using Mtf.Enums.Color;
using Mtf.Models.Colors;
using System;
using System.Drawing;
using System.Security.Cryptography;

namespace Mtf.Extensions
{
    public static class ColorExtensions
    {
        public static double GetBT601Value(this Color value)
        {
            return GetBT601Value(GetNonLinearGammaCorrectedValue(value.R), GetNonLinearGammaCorrectedValue(value.G), GetNonLinearGammaCorrectedValue(value.B));
        }

        public static double GetBT709Value(this Color value)
        {
            return GetBT709Value(GetNonLinearGammaCorrectedValue(value.R), GetNonLinearGammaCorrectedValue(value.G), GetNonLinearGammaCorrectedValue(value.B));
        }

        public static double GetBT601Value(double red, double green, double blue)
        {
            return (0.299 * red) + (0.587 * green) + (0.114 * blue);
        }

        public static double GetBT709Value(double red, double green, double blue)
        {
            return (0.2125 * red) + (0.7154 * green) + (0.0721 * blue);
        }

        public static double GetNormalizedValue(ColorComponent component, Color c)
        {
            return GetNormalizedValue(component, c.R, c.G, c.B);
        }

        public static double GetNormalizedValue(ColorComponent component, int red, int green, int blue)
        {
            switch (component)
            {
                case ColorComponent.Red:
                    return (double)red / (red + green + blue);
                case ColorComponent.Green:
                    return (double)green / (red + green + blue);
                case ColorComponent.Blue:
                    return (double)blue / (red + green + blue);
                default: throw new NotImplementedException();
            }
        }

        public static double GetNonLinearGammaCorrectedValue(int component)
        {
            return (double)component / 255;
        }

        public static int GetComponentValue(double nonLinearGammaCorrectedValue)
        {
            return (int)Math.Round(nonLinearGammaCorrectedValue * 255);
        }

        public static Color InverseColor(this Color value)
        {
            return Color.FromArgb(value.A, (Byte)~value.R, (Byte)~value.G, (Byte)~value.B);
        }

        public static bool IsColorBetweenColors(this Color value, Color from, Color to)
        {

            int minA = Math.Min(from.A, to.A);
            if ((value.A >= minA) && (value.A <= Math.Abs(from.A - to.A) + minA))
            {
                int minR = Math.Min(from.R, to.R);
                if ((value.R >= minR) && (value.R <= Math.Abs(from.R - to.R) + minR))
                {
                    int minG = Math.Min(from.G, to.G);
                    if ((value.G >= minG) && (value.G <= Math.Abs(from.G - to.G) + minG))
                    {
                        int minB = Math.Min(from.B, to.B);
                        if ((value.B >= minB) && (value.B <= Math.Abs(from.B - to.B) + minB))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static Color ConvertToBlackOrWhite(this Color value)
        {
            var distance = value.GetBT709Value();
            return (distance < 128) ? Color.Black : Color.White;
        }

        public static Color ConvertToSimpleAvarageGrayscale(this Color value)
        {
            int grayValue = (byte)Math.Round((double)(value.R + value.G + value.B) / 3);
            return Color.FromArgb(grayValue, grayValue, grayValue);
        }

        public static Color ConvertToWeightedAvarageGrayscale(this Color value)
        {
            int grayValue = (byte)Math.Round((double)((3 * value.R) + (2 * value.G) + (4 * value.B)) / 9);
            return Color.FromArgb(grayValue, grayValue, grayValue);
        }

        public static Color ConvertToGrayscale1(this Color value)
        {
            int grayValue = (byte)Math.Round((double)((77 * value.R) + (150 * value.G) + (28 * value.B)) / 255);
            return Color.FromArgb(grayValue, grayValue, grayValue);
        }

        public static Color ConvertToGrayscale2(this Color value)
        {
            int gray_value = (byte)Math.Round((double)((222 * value.R) + (707 * value.G) + (71 * value.B)) / 1000);
            return Color.FromArgb(gray_value, gray_value, gray_value);
        }

        public static Color ConvertToBT601Grayscale(this Color value)
        {
            var gray_value = (int)Math.Round(value.GetBT601Value()); // NTSC, PAL
            return Color.FromArgb(gray_value, gray_value, gray_value);
        }

        public static Color ConvertToGrayscale4(this Color value)
        {
            int gray_value = (byte)Math.Round((0.197 * value.R) + (0.701 * value.G) + (0.07 * value.B));
            return Color.FromArgb(gray_value, gray_value, gray_value);
        }

        public static Color ConvertToBT609Grayscale(this Color value)
        {
            int gray_value = (byte)Math.Round((0.21 * value.R) + (0.71 * value.G) + (0.08 * value.B));
            return Color.FromArgb(gray_value, gray_value, gray_value);
        }

        public static Color ConvertToBT709Grayscale(this Color value)
        {
            int gray_value = (byte)Math.Round(value.GetBT709Value());
            return Color.FromArgb(gray_value, gray_value, gray_value);
        }

        public static Color ConvertToRMYGrayscale(this Color value)
        {
            int gray_value = (byte)Math.Round((0.5 * value.R) + (0.419 * value.G) + (0.081 * value.B));
            return Color.FromArgb(gray_value, gray_value, gray_value);
        }

        public static Color ConvertToRedscale(this Color value)
        {
            return Color.FromArgb(value.R, 0, 0);
        }

        public static Color ConvertToGreenscale(this Color value)
        {
            return Color.FromArgb(0, value.G, 0);
        }

        public static Color ConvertToBluescale(this Color value)
        {
            return Color.FromArgb(0, 0, value.B);
        }

        public static Color ConvertToRedGreenscale(this Color value)
        {
            return Color.FromArgb(value.R, value.G, 0);
        }

        public static Color ConvertToGreenBluescale(this Color value)
        {
            return Color.FromArgb(0, value.G, value.B);
        }

        public static Color ConvertToRedBluescale(this Color value)
        {
            return Color.FromArgb(value.R, 0, value.B);
        }

        public static YUVColor ConvertToYUVColor(this Color value)
        {
            return new YUVColor(value);
        }

        public static Color ConvertToYUVYScale(this Color value)
        {
            var yuv_color = ConvertToYUVColor(value);
            return Color.FromArgb(yuv_color.Y, 0, 0);
        }

        public static Color ConvertToCMYCScale(this Color value)
        {
            var cmy_color = new CMYColor(value);
            return Color.FromArgb(cmy_color.C, 0, 0);
        }

        public static Color ConvertToCMYMScale(this Color value)
        {
            var cmy_color = new CMYColor(value);
            return Color.FromArgb(0, cmy_color.M, 0);
        }

        public static Color ConvertToCMYYScale(this Color value)
        {
            var cmy_color = new CMYColor(value);
            return Color.FromArgb(0, 0, cmy_color.Y);
        }

        public static Color ConvertToCMYCMScale(this Color value)
        {
            var cmy_color = new CMYColor(value);
            return Color.FromArgb(cmy_color.C, cmy_color.M, 0);
        }

        public static Color ConvertToCMYMYScale(this Color value)
        {
            var cmy_color = new CMYColor(value);
            return Color.FromArgb(0, cmy_color.M, cmy_color.Y);
        }

        public static Color ConvertToCMYCYScale(this Color value)
        {
            var cmy_color = new CMYColor(value);
            return Color.FromArgb(cmy_color.C, 0, cmy_color.Y);
        }

        public static Color ConvertToYUVUScale(this Color value)
        {
            var yuv_color = ConvertToYUVColor(value);
            return Color.FromArgb(0, yuv_color.U, 0);
        }

        public static Color ConvertToYUVVScale(this Color value)
        {
            var yuv_color = ConvertToYUVColor(value);
            return Color.FromArgb(0, 0, yuv_color.V);
        }

        public static Color ConvertToYUVYUScale(this Color value)
        {
            var yuv_color = ConvertToYUVColor(value);
            return Color.FromArgb(yuv_color.Y, yuv_color.U, 0);
        }

        public static Color ConvertToYUVUVScale(this Color value)
        {
            var yuv_color = ConvertToYUVColor(value);
            return Color.FromArgb(0, yuv_color.U, yuv_color.V);
        }

        public static Color ConvertToYUVYVScale(this Color value)
        {
            var yuv_color = ConvertToYUVColor(value);
            return Color.FromArgb(yuv_color.Y, 0, yuv_color.V);
        }

        public static Color ConvertToInverse(this Color value)
        {
            return Color.FromArgb(byte.MaxValue - value.R, byte.MaxValue - value.G, byte.MaxValue - value.B);
        }

        public static Color ConvertToInverseRed(this Color value)
        {
            return Color.FromArgb(byte.MaxValue - value.R, value.G, value.B);
        }

        public static Color ConvertToInverseGreen(this Color value)
        {
            return Color.FromArgb(value.R, byte.MaxValue - value.G, value.B);
        }

        public static Color ConvertToInverseBlue(this Color value)
        {
            return Color.FromArgb(value.R, value.G, byte.MaxValue - value.B);
        }

        public static Color ConvertToInverseRedBlue(this Color value)
        {
            return Color.FromArgb(byte.MaxValue - value.R, value.G, byte.MaxValue - value.B);
        }

        public static Color ConvertToInverseGreenBlue(this Color value)
        {
            return Color.FromArgb(byte.MaxValue - value.R, byte.MaxValue - value.G, byte.MaxValue - value.B);
        }

        public static Color ConvertToInverseRedGreen(this Color value)
        {
            return Color.FromArgb(byte.MaxValue - value.R, byte.MaxValue - value.G, byte.MaxValue - value.B);
        }

        public static Color ConvertToRBG(this Color value)
        {
            return Color.FromArgb(value.R, value.B, value.G);
        }

        public static Color ConvertToBGR(this Color value)
        {
            return Color.FromArgb(value.B, value.G, value.R);
        }

        public static Color ConvertToGRB(this Color value)
        {
            return Color.FromArgb(value.G, value.R, value.B);
        }

        public static Color ConvertToGBR(this Color value)
        {
            return Color.FromArgb(value.G, value.B, value.R);
        }

        public static Color ConvertToBRG(this Color value)
        {
            return Color.FromArgb(value.B, value.R, value.G);
        }

        public static Color ConvertFromYUVToRGB(this Color value)
        {
            var yuv_color = new YUVColor(value.R, value.G, value.B, ColorSpaceType.YUV);
            return Color.FromArgb(yuv_color.R, yuv_color.G, yuv_color.B);
        }

        public static Color ConvertFromCMYToRGB(this Color value)
        {
            var cmy_color = new CMYColor(value.R, value.G, value.B);
            return Color.FromArgb(cmy_color.R, cmy_color.G, cmy_color.B);
        }

        public static Color ConvertToExp(this Color value)
        {
            return Color.FromArgb(IntExtensions.LimitMe((int)Math.Round(Math.Exp(value.R)) % 255, 0, 255), IntExtensions.LimitMe((int)Math.Round(Math.Exp(value.G)) % 255, 0, 255), IntExtensions.LimitMe((int)Math.Round(Math.Exp(value.B)) % 255, 0, 255));
        }

        public static Color ConvertToPow(this Color value)
        {
            return Color.FromArgb(IntExtensions.LimitMe((int)Math.Round(Math.Abs(Math.Exp(value.R))) % 255, 0, 255), IntExtensions.LimitMe((int)Math.Round(Math.Abs(Math.Exp(value.G))) % 255, 0, 255), IntExtensions.LimitMe((int)Math.Round(Math.Abs(Math.Exp(value.B))) % 255, 0, 255));
        }

        public static Color GetRandomColor()
        {
            var rgb = new byte[3];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(rgb);
            }
            return Color.FromArgb(rgb[0], rgb[1], rgb[2]);
        }

        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            Color c;
            var h = hue / 60;
            var croma = value * saturation;

            var x = croma * (1 - Math.Abs((h % 2) - 1));

            var hi = Convert.ToInt32(Math.Round(h)) % 6;
            var f = h - Math.Round(h);

            var m = value * (1 - saturation);

            value *= 255;
            var v = Convert.ToInt32(value);
            var p = Convert.ToInt32(m);
            var q = Convert.ToInt32(value * (1 - (f * saturation)));
            var t = Convert.ToInt32(value * (1 - ((1 - f) * saturation)));

            switch (hi)
            {
                case 0:
                    c = Color.FromArgb(255, Convert.ToInt32(croma * 255), Convert.ToInt32(x * 255), 0);
                    //c = Color.FromArgb(255, v, t, p);
                    break;
                case 1:
                    c = Color.FromArgb(255, q, v, p);
                    break;
                case 2:
                    c = Color.FromArgb(255, p, v, t);
                    break;
                case 3:
                    c = Color.FromArgb(255, p, q, v);
                    break;
                case 4:
                    c = Color.FromArgb(255, t, p, v);
                    break;
                default:
                    c = Color.FromArgb(255, v, p, q);
                    break;
            }

            var delta = Convert.ToInt32(c.R + (m * c.G) + (m * c.B) + m);
            return Color.FromArgb(255, c.R + delta, c.G + delta, c.B + delta);
        }

        public static Color TransformColor(this Color value, ColorTransformMethod method)
        {
            switch (method)
            {
                case ColorTransformMethod.BlackAndWhite:
                    return value.ConvertToBlackOrWhite();
                case ColorTransformMethod.SimpleAvarageGrayscale:
                    return value.ConvertToSimpleAvarageGrayscale();
                case ColorTransformMethod.WeightedAvarageGrayscale:
                    return value.ConvertToWeightedAvarageGrayscale();
                case ColorTransformMethod.Grayscale_1:
                    return value.ConvertToGrayscale1();
                case ColorTransformMethod.Grayscale_2:
                    return value.ConvertToGrayscale2();
                case ColorTransformMethod.BT_601_Grayscale:
                    return value.ConvertToBT601Grayscale();
                case ColorTransformMethod.Grayscale_4:
                    return value.ConvertToGrayscale4();
                case ColorTransformMethod.BT_609_Grayscale:
                    return value.ConvertToBT609Grayscale();
                case ColorTransformMethod.BT_709_Grayscale:
                    return value.ConvertToBT709Grayscale();
                case ColorTransformMethod.RMY_Grayscale:
                    return value.ConvertToRMYGrayscale();
                case ColorTransformMethod.Redscale:
                    return value.ConvertToRedscale();
                case ColorTransformMethod.Greenscale:
                    return value.ConvertToGreenscale();
                case ColorTransformMethod.Bluescale:
                    return value.ConvertToBluescale();
                case ColorTransformMethod.RedGreenscale:
                    return value.ConvertToRedGreenscale();
                case ColorTransformMethod.GreenBluescale:
                    return value.ConvertToGreenBluescale();
                case ColorTransformMethod.RedBluescale:
                    return value.ConvertToRedBluescale();
                case ColorTransformMethod.YUV_Y_scale:
                    return value.ConvertToYUVYScale();
                case ColorTransformMethod.YUV_U_scale:
                    return value.ConvertToYUVUScale();
                case ColorTransformMethod.YUV_V_scale:
                    return value.ConvertToYUVVScale();
                case ColorTransformMethod.YUV_YU_scale:
                    return value.ConvertToYUVYUScale();
                case ColorTransformMethod.YUV_UV_scale:
                    return value.ConvertToYUVUVScale();
                case ColorTransformMethod.YUV_YV_scale:
                    return value.ConvertToYUVYVScale();
                case ColorTransformMethod.CMY_C_scale:
                    return value.ConvertToCMYCScale();
                case ColorTransformMethod.CMY_M_scale:
                    return value.ConvertToCMYMScale();
                case ColorTransformMethod.CMY_Y_scale:
                    return value.ConvertToCMYYScale();
                case ColorTransformMethod.CMY_CM_scale:
                    return value.ConvertToCMYCMScale();
                case ColorTransformMethod.CMY_MY_scale:
                    return value.ConvertToCMYMYScale();
                case ColorTransformMethod.CMY_CY_scale:
                    return value.ConvertToCMYCYScale();
                case ColorTransformMethod.Inverse:
                    return value.ConvertToInverse();
                case ColorTransformMethod.Inverse_Red:
                    return value.ConvertToInverseRed();
                case ColorTransformMethod.Inverse_Green:
                    return value.ConvertToInverseGreen();
                case ColorTransformMethod.Inverse_Blue:
                    return value.ConvertToInverseBlue();
                case ColorTransformMethod.Inverse_Red_Green:
                    return value.ConvertToInverseRedGreen();
                case ColorTransformMethod.Inverse_Red_Blue:
                    return value.ConvertToInverseRedBlue();
                case ColorTransformMethod.Inverse_Green_Blue:
                    return value.ConvertToInverseGreenBlue();
                case ColorTransformMethod.Swap_RGB_To_GRB:
                    return value.ConvertToGRB();
                case ColorTransformMethod.Swap_RGB_To_GBR:
                    return value.ConvertToGBR();
                case ColorTransformMethod.Swap_RGB_To_RBG:
                    return value.ConvertToRBG();
                case ColorTransformMethod.Swap_RGB_To_BGR:
                    return value.ConvertToBGR();
                case ColorTransformMethod.Swap_RGB_To_BRG:
                    return value.ConvertToBRG();
                case ColorTransformMethod.RGB_To_YUV:
                    var yuv_color = value.ConvertToYUVColor();
                    return Color.FromArgb(yuv_color.Y, yuv_color.U, yuv_color.V);
                case ColorTransformMethod.YUV_To_RGB:
                    return value.ConvertFromYUVToRGB();
                case ColorTransformMethod.CMY_To_RGB:
                    return value.ConvertFromCMYToRGB();
                case ColorTransformMethod.RGB_To_CMY:
                    var cmy_color = new CMYColor(value);
                    return Color.FromArgb(cmy_color.C, cmy_color.M, cmy_color.Y);
                case ColorTransformMethod.Exp:
                    return value.ConvertToExp();
                case ColorTransformMethod.Pow:
                    return value.ConvertToPow();
                case ColorTransformMethod.Random:
                    return GetRandomColor();
                case ColorTransformMethod.Original:
                    return value;
                default: throw new NotImplementedException();
            }
        }
    }
}

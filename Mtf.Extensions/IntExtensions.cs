using System;
using System.Text;

namespace Mtf.Extensions
{
    public static class IntExtensions
    {
        public static string ToString(uint value)
        {
            var v = value;
            var result = new StringBuilder();
            _ = result.Append((char)((v & 0xFF000000) >> 24))
                .Append((char)((v & 0x00FF0000) >> 16))
                .Append((char)((v & 0x0000FF00) >> 8))
                .Append((char)(v & 0x000000FF));
            return result.ToString();
        }

        public static bool IsEven(this int value)
        {
            return value.IsDivisible(2);
        }

        public static bool IsOdd(this int value)
        {
            return !value.IsDivisible(2);
        }

        public static string ToBinary(this int value)
        {
            return value.ToBinary(0);
        }

        public static string ToBinary(this int value, byte minimumLength)
        {
            return minimumLength == 0 ? Convert.ToString(value, 2) : Convert.ToString(value, 2).PadLeft(minimumLength, '0');
        }

        public static int GetBitValue(this int value, int bitIndex)
        {
            return value & (int)Math.Pow(2, bitIndex);
        }

        public static bool IsDivisible(this int value, int divider)
        {
            return value % divider == 0;
        }

        public static bool IsBetweenExclusive(this int value, int minimum, int maximum)
        {
            if (maximum < minimum)
            {
                Swap(ref maximum, ref minimum);
            }

            return (value > minimum) && (value < maximum);
        }

        public static bool IsBetweenInclusive(this int value, int minimum, int maximum)
        {
            if (maximum < minimum)
            {
                Swap(ref maximum, ref minimum);
            }

            return (value >= minimum) && (value <= maximum);
        }

        public static int LimitMe(this int value, int minimum, int maximum)
        {
            if (maximum < minimum)
            {
                Swap(ref maximum, ref minimum);
            }

            return Math.Max(minimum, Math.Min(maximum, value));
        }

        public static void Swap(ref int a, ref int b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }

        public static bool IsBitSet(this int value, int bitIndex)
        {
            return (value & (int)Math.Pow(2, bitIndex)) != 0;
        }

        public static int GetSubBitCombinationValue(this int value, int bitIndex, int numberOfBits)
        {
            var result = 0;
            for (var i = bitIndex; i < bitIndex + numberOfBits; i++)
            {
                if (value.IsBitSet(i))
                {
                    result += (int)Math.Pow(2, i - bitIndex);
                }
            }

            return result;
        }
    }
}

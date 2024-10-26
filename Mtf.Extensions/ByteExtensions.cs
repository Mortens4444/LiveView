using System;

namespace Mtf.Extensions
{
    public static class ByteExtensions
    {
        public static bool IsEven(this byte value)
        {
            return IsDivisible(value, 2);
        }

        public static bool IsOdd(this byte value)
        {
            return !IsDivisible(value, 2);
        }

        public static bool IsDivisible(byte number, byte divider)
        {
            return number % divider == 0;
        }

        public static byte LimitMe(this byte value, byte minimum, byte maximum)
        {
            if (maximum < minimum)
            {
                Swap(ref maximum, ref minimum);
            }

            return Math.Max(minimum, Math.Min(maximum, value));
        }

        public static bool IsBetweenExclusive(this byte value, byte minimum, byte maximum)
        {
            if (maximum < minimum)
            {
                Swap(ref maximum, ref minimum);
            }

            return (value > minimum) && (value < maximum);
        }

        public static bool IsBetweenInclusive(this byte value, byte minimum, byte maximum)
        {
            if (maximum < minimum)
            {
                Swap(ref maximum, ref minimum);
            }

            return (value >= minimum) && (value <= maximum);
        }

        public static void Swap(ref byte a, ref byte b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
            /*a += b;
			b = a - b;
			a -= b;*/
        }

        /// <summary>MSB ---------------------- LSB
        /// <para>| 7 | 6 | 5 | 4 | 3 | 2 | 1 | 0 |</para>
        /// <para>---------------------------------</para></summary>
        /// <param name="value">The examined number.</param>
        /// <param name="bitIndex">The examined bit index.</param>
        /// <returns>2 ^ bit_index, for example GetBitValue(37, 2) will return 8.</returns>
        public static byte GetBitValue(this byte value, int bitIndex)
        {
            return (byte)(value & (byte)Math.Pow(2, bitIndex));
        }

        public static bool IsBitSet(this byte value, int bitIndex)
        {
            return (byte)(value & (byte)Math.Pow(2, bitIndex)) != 0;
        }

        public static byte GetSubBitConbinationValue(this byte value, int bitIndex, int numberOfBits)
        {
            byte result = 0;
            for (var i = bitIndex; i < bitIndex + numberOfBits; i++)
            {
                if (value.IsBitSet(i))
                {
                    result += (byte)Math.Pow(2, i - bitIndex);
                }
            }

            return result;
        }
    }
}

using Mtf.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Mtf.Extensions
{
    public static class ByteArrayExtensions
    {
        public static byte[] AppendArrays(this byte[] value, params byte[][] arrays)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (arrays == null)
            {
                throw new ArgumentNullException(nameof(arrays));
            }

            var newLength = value.Length + arrays.Sum(t => t.Length);
            var result = new byte[newLength];
            Array.Copy(value, 0, result, 0, value.Length);
            newLength = value.Length;
            for (var i = 0; i < arrays.Length; i++)
            {
                Array.Copy(arrays[i], 0, result, newLength, arrays[i].Length);
                newLength += arrays[i].Length;
            }
            return result;
        }

        public static int Find(this byte[] array, byte[] subArray)
        {
            return array.Find(subArray, 0);
        }

        public static void Replace(this byte[] array, byte oldValue, byte newValue)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            for (var i = 0; i < array.Length; i++)
            {
                if (array[i] == oldValue)
                {
                    array[i] = newValue;
                }
            }
        }

        public static string ToArrayString(this byte[] array, int startIndex, int endIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            var result = new StringBuilder();
            for (var i = startIndex; i < endIndex; i++)
            {
                result.AppendFormat(CultureInfo.InvariantCulture, "[{0}]", array[i]);
            }

            return result.ToString();
        }

        /// <summary>
        /// Creates a byte array from a string if it's in the correct format. Ex: [12][243][124][68]
        /// </summary>
        /// <param name="toString">String representation of the byte array. Ex: [12][243][124][68]</param>
        /// <returns>A byte array. Ex: new byte[] { 12, 243, 124, 68 };</returns>
        public static byte[] CreateArray(string toString)
        {
            return toString.ArrayStringToArray();
        }

        public static int Find(this byte[] array, byte[] subArray, int startIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if ((subArray == null) || (subArray.Length == 0) || (subArray.Length > array.Length))
            {
                return Constants.NotFound;
            }

            var index = startIndex - 1;

            while (index < array.Length)
            {
                index = Array.IndexOf(array, subArray[0], index + 1);
                if (index == Constants.NotFound)
                {
                    return Constants.NotFound;
                }

                var notFound = false;
                var i = 1;
                while (i < subArray.Length)
                {
                    index++;
                    if (index >= array.Length)
                    {
                        return Constants.NotFound;
                    }

                    if (array[index] == subArray[i++])
                    {
                        continue;
                    }

                    notFound = true;
                    break;
                }
                if (notFound)
                {
                    continue;
                }

                return index - subArray.Length + 1;
            }
            return Constants.NotFound;
        }

        public static int Find(this byte[] array, byte[] subArray, int startIndex, int count)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (subArray == null)
            {
                throw new ArgumentNullException(nameof(subArray));
            }

            int index, i, p;

            while (count >= subArray.Length)
            {
                if (startIndex > Constants.NotFound)
                {
                    index = Array.IndexOf(array, subArray[0], startIndex, count - subArray.Length + 1);
                    if (index == Constants.NotFound)
                    {
                        return Constants.NotFound;
                    }

                    for (i = 0, p = index; i < subArray.Length; i++, p++)
                    {
                        if (array[p] != subArray[i])
                        {
                            break;
                        }
                    }

                    if (i == subArray.Length)
                    {
                        return index;
                    }

                    count -= index - startIndex + 1;
                    startIndex = index + 1;
                }
                else
                {
                    startIndex = 0; // FIX of ArgumentOutOfRangeException
                }
            }
            return Constants.NotFound;
        }

        public static string ToASCIIString(this byte[] value)
        {
            return Encoding.ASCII.GetString(value);
        }

        public static string ASCIIGetString(this byte[] value)
        {
            return Encoding.ASCII.GetString(value);
        }

        public static string UTF8GetString(this byte[] value)
        {
            return Encoding.UTF8.GetString(value);
        }

        /// <summary>
        /// From a byte array creates a string
        /// </summary>
        /// <param name="array">The byte array</param>
        /// <returns>Ex.: [12][23][64][78]</returns>
        public static string ToArrayString(this byte[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            var result = new StringBuilder();
            for (var i = 0; i < array.Length; i++)
            {
                result.AppendFormat(CultureInfo.InvariantCulture, "[{0}]", array[i]);
            }

            return result.ToString();
        }

        public static string ToASCIIStringZeroByteTerminated(this byte[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            var str = new StringBuilder();
            for (var i = 0; (i < array.Length) && (array[i] != 0); i++)
            {
                str.Append(Convert.ToChar(array[i]));
            }

            return str.ToString();
        }

        public static byte[] SubArray(this byte[] value, int index, int length)
        {
            return value.CreateArray(index, length);
        }

        public static byte[] CreateArray(this byte[] array, int index, int length)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            var result = new byte[length];
            for (var i = 0; i < length; i++)
            {
                result[i] = array[i + index];
            }

            return result;
        }

        public static Percent EqualsPercent(this byte[] array1, byte[] array2)
        {
            return EqualInPercent(array1, array2);
        }

        public static Percent EqualInPercent(byte[] array1, byte[] array2)
        {
            if ((array1 == null) && (array2 == null))
            {
                return 0;
            }

            if ((array1 == null) || (array2 == null))
            {
                return 0;
            }

            if ((array1.Length == 0) && (array2.Length == 0))
            {
                return 100;
            }

            int min_length, max_length;
            if (array1.Length <= array2.Length)
            {
                min_length = array1.Length;
                max_length = array2.Length;
            }
            else
            {
                max_length = array1.Length;
                min_length = array2.Length;
            }

            var same = 0;
            for (var i = 0; i < min_length; i++)
            {
                if (array1[i] == array2[i])
                {
                    same++;
                }
            }

            return ((double)same / max_length * 100).LimitMeWithRound(0, 100);
        }

        public static bool IsEqual(byte[] array1, byte[] array2)
        {
            if ((array1 == null) && (array2 == null))
            {
                return true;
            }

            if ((array1 == null) || (array2 == null))
            {
                return false;
            }

            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (var i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}

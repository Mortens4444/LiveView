using Mtf.Extensions.Services;
using System;
using System.Globalization;

namespace Mtf.Extensions
{
    public static class CharExtensions
    {
        public static readonly string Chars = "aábcdeéfghiíjklmnoóöőpqrstuúüűvwxyzAÁBCDEÉFGHIÍJKLMNOÓÖŐPQRSTUÚÜŰVWXYZ0123456789§'\"+!%/=(),.-?:_;*<>#&@{}[]đĐ\\|€~ˇ^˘°˛`˙´˝¨¸÷×$ß¤łŁ";
        public static readonly char[] Base64CharArray = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/' };

        public static char GenerateCharByHungarianStatistics()
        {
            var hungarian_character_statistics_values = new[] { 9.90596040747228, 7.72572927165797, 8.60741161159006, 5.97606442837432, 5.89484396864695, 5.37620729809866, 4.43776849233298, 4.13930776682878, 4.11484377293499, 3.80072609133877, 3.78017633646799, 3.66568484504506, 3.63730661212827, 3.56880742922567, 2.8984939965359, 2.6059046295662, 2.31429382235226, 2.02659725416133, 1.6782299811138, 1.64887318844125, 1.50111066532278, 1.10283684473192, 0.912996252116136, 0.880703780176336, 0.814161716785236, 0.812204597273733, 0.730984137546359, 0.684013269270288, 0.376745505964322, 0.461880204714701, 0.394359581567848, 0.313139121840475, 0.310203442573221, 0.302374964527209, 0.220175945044084, 0.21724026577683, 0.211368907242321, 0.199626190173303, 0.187883473104285, 0.182990674325528, 0.155591001164486, 0.143848284095468, 0.137976925560959, 0.133084126782202, 0.116448610934427, 0.116448610934427, 0.112534371911421, 0.094920296307894, 0.066542063391101, 0.0596921451008406, 0.0518636670548287, 0.032292471939799, 0.0313139121840475, 0.0293567926725445, 0.0244639938937871, 0.0215283146265327, 0.0166355158477752, 0.0127212768247693, 0.00684991829026039, 0.00587135853450891, 0.00489279877875743, 0.00489279877875743 };
            var hungarian_character_by_statistics = new[] { 'e', 't', 'a', 'n', 'l', 's', 'k', 'o', 'r', 'z', 'á', 'g', 'i', 'm', 'é', 'y', 'd', 'v', 'b', 'h', 'j', 'ö', 'u', 'f', 'c', 'p', 'ó', 'ő', 'A', 'M', 'ü', 'H', 'í', 'S', 'N', 'E', 'ú', 'J', 'K', 'T', 'B', 'ű', 'I', 'D', 'V', 'L', 'É', 'F', 'C', 'R', 'O', 'P', 'U', 'G', 'Ö', 'Á', 'Í', 'Ő', 'Ó', 'Z', 'Ú', 'Ü' };

            double d = RandomProvider.GetSecureRandomDouble(), summ = 0;
            for (var i = 0; i < hungarian_character_statistics_values.Length; i++)
            {
                summ += hungarian_character_statistics_values[i];
                if (d < summ)
                {
                    return hungarian_character_by_statistics[i];
                }
            }
            return ' ';
        }

        public static string CharToHexaRepresentation(this char value)
        {
            return ((int)value).ToString("X", CultureInfo.InvariantCulture);
        }

        public static byte CharToBase64Code(this char value)
        {
            for (var i = 0; i < 64; i++)
            {
                if (Base64CharArray[i] == value)
                {
                    return (byte)i;
                }
            }

            return 0;
        }

        public static char Base64CodeToChar(byte code)
        {
            return code >= 64
                ? throw new ArgumentException("Parameter code value cannot be bigger than 64.", nameof(code))
                : Base64CharArray[code];
        }

        /// <summary>
        /// Is this character is a vowel?
        /// </summary>
        /// <param name="value">Examined character</param>
        /// <returns>True if the character is a vowel, otherwise false.</returns>
        public static bool IsVowel(this char value)
        {
            for (var i = 0; i < Password.Vowels.Length; i++)
            {
                if (Password.Vowels[i] == value)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsHexadecimalDigit(this char value)
        {
            return value.IsDigit() || ((value >= 'a') && (value <= 'f')) || ((value >= 'A') && (value <= 'F'));
        }

        /// <summary>
        /// Is this character is a consonant?
        /// </summary>
        /// <param name="value">Examined character</param>
        /// <returns>True if the character is a consonant, otherwise false.</returns>
        public static bool IsConsonant(this char value)
        {
            for (var i = 0; i < Password.Consonants.Length; i++)
            {
                if (Password.Consonants[i] == value)
                {
                    return true;
                }
            }

            return false;
        }

        public static char GetCodedChar(this char value)
        {
            switch (value)
            {
                case '0': return '0';
                case '1': return 'l';
                case '3': return 'e';
                case '4': return 'a';
                case '5': return 's';
                case 'a':
                case 'A': return '4';
                case 'o':
                case 'O':
                case 'D': return '0';
                case 'E':
                case 'e': return '3';
                case 'i': return '!';
                case 'I':
                case 'l': return '1';
                case 's':
                case 'S': return '5';
                default: return value;
            }
        }

        public static bool IsBadPasswordChar(this char value)
        {
            for (var i = 0; i < Password.BadPasswordChars.Length; i++)
            {
                if (Password.BadPasswordChars[i] == value)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsDigit(this char value)
        {
            return Char.IsDigit(value);
        }

        public static bool IsControl(this char value)
        {
            return Char.IsControl(value);
        }

        public static bool IsHighSurrogate(this char value)
        {
            return Char.IsHighSurrogate(value);
        }

        public static bool IsLetter(this char value)
        {
            return Char.IsLetter(value);
        }

        public static bool IsLetterOrDigit(this char value)
        {
            return Char.IsLetterOrDigit(value);
        }

        public static bool IsLower(this char value)
        {
            return Char.IsLower(value);
        }

        public static bool IsLowSurrogate(this char value)
        {
            return Char.IsLowSurrogate(value);
        }

        public static bool IsNumber(this char value)
        {
            return Char.IsNumber(value);
        }

        public static bool IsPunctuation(this char value)
        {
            return Char.IsPunctuation(value);
        }

        public static bool IsSeparator(this char value)
        {
            return Char.IsSeparator(value);
        }

        public static bool IsSurrogate(this char value)
        {
            return Char.IsSurrogate(value);
        }

        public static bool IsSymbol(this char value)
        {
            return Char.IsSymbol(value);
        }

        public static bool IsUpper(this char value)
        {
            return Char.IsUpper(value);
        }

        public static bool IsWhiteSpace(this char value)
        {
            return Char.IsWhiteSpace(value);
        }

        // $D000 - $D7FF - Shape of characters
        // $D000 - $D007 - @
        // $D008 - $D00F - A
        // $D000 - $D3FF - Uppercase/graphics charset
        // $D400 - $D7FF - Lowercase/uppercase charset

        // 0 0 1 1 1 1 0 0		  0000		3C
        // 0 1 1 0 0 1 1 0		 00  00		66
        // 0 1 1 0 1 1 1 0		 00 000		6E
        // 0 1 1 0 1 1 1 0		 00 000		6E
        // 0 1 1 0 0 0 0 0		 00			60
        // 0 1 1 0 0 0 1 0		 00   0		62
        // 0 1 1 1 1 1 0 0		  0000		3C
        // 0 0 0 0 0 0 0 0					00
    }
}
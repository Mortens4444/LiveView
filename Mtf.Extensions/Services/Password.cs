using System.Linq;

namespace Mtf.Extensions.Services
{
    public static class Password
    {
        public static readonly char[] BinaryNumbers = { '0', '1' };
        public static readonly char[] DecimalNumbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public static readonly char[] HexadecimalNumbersLower = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
        public static readonly char[] HexadecimalNumbersUpper = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        public static readonly char[] HexadecimalNumbersMixed = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'A', 'B', 'C', 'D', 'E', 'F' };
        public static readonly char[] LowercaseAlphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        public static readonly char[] UppercaseAlphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        public static readonly char[] MixedAlphabet = LowercaseAlphabet.Concat(UppercaseAlphabet).ToArray();
        public static readonly char[] Alphanumeric = MixedAlphabet.Concat(DecimalNumbers).ToArray();
        public static readonly char[] SpecialCharacters = { ' ', '§', '\'', '"', '+', '!', '%', '/', '=', '(', ')', '~', 'ˇ', '^', '˘', '°', '˛', '`', '˙', '´', '˝', '¨', '¸', '÷', '×', '€', '$', '¤', ',', '.', '-', ';', '>', '*', '<', '{', '}', '[', ']', '?', ':', '_', '#', '&', '@', '\\', '|' };

        public static readonly char[] HungarianLetters = { 'á', 'é', 'í', 'ó', 'ö', 'ő', 'ú', 'ü', 'ű', 'Á', 'É', 'Í', 'Ó', 'Ö', 'Ő', 'Ú', 'Ü', 'Ű' };
        public static readonly char[] NationalLetters = { 'ä', 'Ä', 'â', 'Â', 'ą', 'Ą', 'ă', 'Ă', 'ß', 'č', 'Č', 'ć', 'Ć', 'ç', 'Ç', 'đ', 'Đ', 'ď', 'Ď', 'ě', 'Ě', 'ę', 'Ę', 'ë', 'Ë', 'î', 'Î', 'ł', 'Ł', 'ĺ', 'Ĺ', 'ľ', 'Ľ', 'ń', 'Ń', 'ň', 'Ň', 'ô', 'Ô', 'ŕ', 'Ŕ', 'ř', 'Ř', 'š', 'Š', 'ş', 'Ş', 'ś', 'Ś', 'ť', 'Ť', 'ţ', 'Ţ', 'ů', 'Ů', 'ý', 'Ý', 'ż', 'Ż', 'ž', 'Ž', 'ź', 'Ź' };

        public static readonly char[] Vowels = { 'a', 'A', 'á', 'Á', 'e', 'E', 'é', 'É', 'i', 'I', 'í', 'Í', 'o', 'O', 'ó', 'Ó', 'ö', 'Ö', 'ő', 'Ő', 'u', 'U', 'ú', 'Ú', 'ü', 'Ü', 'ű', 'Ű' };
        public static readonly char[] Consonants = MixedAlphabet.Except(Vowels).ToArray();
        public static readonly char[] BadPasswordChars = { '0', 'O', 'I', 'l' };

        public static readonly char[] PasswordGeneratorCharacters = { '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'm', 'n', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
    }
}

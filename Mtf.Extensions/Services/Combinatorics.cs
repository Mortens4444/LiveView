using System;
using System.Collections;
using System.Text;

namespace Mtf.Extensions.Services
{
    public static class Combinatorics
    {
        public static string BruteForce(ref string basicPassword, char firstChar, char lastChar)
        {
            return BruteForce(ref basicPassword, Convert.ToInt32(firstChar), Convert.ToInt32(lastChar));
        }

        public static string BruteForce(ref string basicPassword, char[] chars)
        {
            if (basicPassword == null)
            {
                throw new ArgumentNullException(nameof(basicPassword));
            }
            if (chars == null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            var firstChar = chars[0];
            var lastChar = chars[chars.Length - 1];

            var password = new StringBuilder();
            var lastCharacterIndex = basicPassword.Length - 1;

            if (lastCharacterIndex > Constants.NotFound)
            {
                while ((lastCharacterIndex > Constants.NotFound) && (basicPassword[lastCharacterIndex] == lastChar))
                {
                    _ = password.Append(firstChar);
                    lastCharacterIndex--;
                }

                if (lastCharacterIndex > Constants.NotFound)
                {
                    var charIndex = Array.IndexOf(chars, basicPassword[lastCharacterIndex--]);
                    _ = password.Append(chars[++charIndex]);
                }
                else
                {
                    _ = password.Append(firstChar);
                }

                for (var i = lastCharacterIndex; i >= 0; i--)
                {
                    _ = password.Append(basicPassword[i]);
                }
            }
            else
            {
                _ = password.Append(firstChar);
            }

            return StringExtensions.Reverse(password.ToString());
        }

        public static string BruteForce(ref string basicPassword, int firstCharcode, int lastCharcode)
        {
            if (basicPassword == null)
            {
                return String.Empty;
            }

            if (firstCharcode > lastCharcode)
            {
                IntExtensions.Swap(ref firstCharcode, ref lastCharcode);
            }

            var firstChar = (char)firstCharcode;
            var lastChar = (char)lastCharcode;

            var password = new StringBuilder();
            var lastCharacterIndex = basicPassword.Length - 1;

            if (lastCharacterIndex > Constants.NotFound)
            {
                while ((lastCharacterIndex > Constants.NotFound) && (basicPassword[lastCharacterIndex] == lastChar))
                {
                    _ = password.Append(firstChar);
                    lastCharacterIndex--;
                }

                if (lastCharacterIndex > Constants.NotFound)
                {
                    var code = basicPassword[lastCharacterIndex--];
                    var new_ch = ++code;
                    _ = password.Append(new_ch);
                }
                else
                {
                    _ = password.Append(firstChar);
                }

                for (var i = lastCharacterIndex; i >= 0; i--)
                {
                    _ = password.Append(basicPassword[i]);
                }
            }
            else
            {
                _ = password.Append(firstChar);
            }

            return StringExtensions.Reverse(password.ToString());
        }

        public static void GetPermutations(string letters, ref ArrayList result, string fixedLetters)
        {
            if (letters == null)
            {
                throw new ArgumentNullException(nameof(letters));
            }
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            var i = 0;
            while (i < letters.Length)
            {
                var tmp = fixedLetters + letters;
                if (!result.Contains(tmp))
                {
                    _ = result.Add(tmp);
                }

                if (letters.Substring(1).Length > 1)
                {
                    GetPermutations(letters.Substring(1), ref result, fixedLetters + letters[0]);
                }

                int k = 1, l = 0;
                var sb = new StringBuilder(letters);
                while (l < letters.Length)
                {
                    if (k >= letters.Length)
                    {
                        k -= letters.Length;
                    }

                    sb[l] = letters[k];
                    k++;
                    l++;
                }
                letters = sb.ToString();

                i++;
            }
        }
    }
}

using Mtf.Extensions.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Mtf.Extensions
{
    public static partial class StringExtensions
    {
        private static readonly Regex UppercaseCharacters = new Regex("(?<!^)(?=[A-Z])", RegexOptions.Compiled);
        private static readonly string[] separator = new[] { "\r\n", "\r" };
        private static readonly string[] separatorArray = new[] { "\r\n\r\n" };

        public static int NumberOfOccurrences(this string source, string word)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (word == null)
            {
                throw new ArgumentNullException(nameof(word));
            }
            var count = 0;
            var index = 0;

            while ((index = source.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                count++;
                index += word.Length;
            }

            return count;
        }

        public static string SplitByUppercase(this string input)
        {
            var words = UppercaseCharacters.Split(input);
            var result = string.Join(" ", words).ToLower(CultureInfo.CurrentCulture);

            if (result.Length > 1)
            {
                result = string.Concat(char.ToUpper(result[0], CultureInfo.CurrentCulture), result.Substring(1));
            }

            return result;
        }

        public static string ChangeExpanderText(this string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            var newTextStarter = text.StartsWith("-", StringComparison.CurrentCulture) ? '+' : '-';
            return text.Length > 0 ? String.Concat(newTextStarter, text.Substring(1)) : String.Empty;
        }

        public static char FirstChar(this string value)
        {
            return String.IsNullOrEmpty(value) ? throw new ArgumentException("String cannot be null or empty", nameof(value)) : value[0];
        }

        public static char LastChar(this string value)
        {
            return String.IsNullOrEmpty(value) ? throw new ArgumentException("String cannot be null or empty", nameof(value)) : value[value.Length - 1];
        }

        public static string ConvertBinaryToText(this string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return String.Empty;
            }

            var sb = new StringBuilder();
            while (value.Length > 0)
            {
                string byteStr;
                if (value.Length > 7)
                {
                    byteStr = value.Substring(0, 8);
                    value = value.Substring(8);
                }
                else
                {
                    byteStr = value;
                    value = String.Empty;
                }
                _ = sb.Append(Convert.ToChar(BinaryToDecimalByte(byteStr)));
            }
            return sb.ToString();
        }

        public static byte BinaryToDecimalByte(string binary)
        {
            return Convert.ToByte(binary, 2);
        }


        public static string ConvertTextToBinary(this string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return String.Empty;
            }

            var sb = new StringBuilder();
            for (var i = 0; i < value.Length; i++)
            {
                _ = sb.Append(Convert.ToString(value[i], 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        public static string ConvertHexaToText(this string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return String.Empty;
            }

            var sb = new StringBuilder();
            while (value.Length > 0)
            {
                string byteStr;
                if (value.Length > 2)
                {
                    byteStr = value.Substring(0, 2);
                    value = value.Substring(2);
                }
                else
                {
                    byteStr = value;
                    value = String.Empty;
                }
                _ = sb.Append(Convert.ToChar(Convert.ToByte(byteStr, 16)));
            }
            return sb.ToString();
        }

        public static string ConvertTextToHexa(this string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return String.Empty;
            }

            var sb = new StringBuilder();
            for (var i = 0; i < value.Length; i++)
            {
                _ = sb.Append(Convert.ToString(value[i], 16).PadLeft(2, '0'));
            }

            return sb.ToString();
        }

        public static bool IsStartsAndEndWith(this string value, char startCh, char endCh)
        {
            return value.IsStartsWith(startCh) && value.IsEndWith(endCh);
        }

        public static string ReplaceHtmlCharacterEntities(this string value)
        {
            value = Regex.Replace(value, "&micro;", "µ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&reg;", "®", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&quot;", "\"", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&lt;", "<", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&gt;", ">", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&OElig;", "Œ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&oelig;", "œ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Scaron;", "Š", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&scaron;", "š", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&circ;", "ˆ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&tilde;", "~", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&ndash;", "–", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&mdash;", "—", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&lsquo;", "‘", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&rsquo;", "’", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&sbquo;", "‚", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&ldquo;", "“", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&rdquo;", "”", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&bdquo;", "„", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&dagger;", "†", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Dagger;", "‡", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&permil;", "‰", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&lsaquo;", "‹", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&rsaquo", "›", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&euro;", "€", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&ensp;", "\u2002", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&emsp;", "\u2003", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&thinsp;", "\u2009", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&zwnj;", "\u200C", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&zwj;", "\u200D", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&lrm;", "\u200E", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&rlm;", "\u200F", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&nbsp;", " ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&iexcl;", "¡", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&cent;", "¢", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&pound;", "£", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&curren;", "¤", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&yen;", "¥", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&brvbar;", "¦", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&sect;", "§", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&uml;", "¨", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&copy;", "©", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&ordf;", "ª", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&laquo;", "«", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&not;", "¬", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&shy;", "", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&macr;", "¯", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&deg;", "°", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&plusmn;", "±", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&sup2;", "²", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&sup3;", "³", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&acute;", "´", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&para;", "¶", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&middot;", "·", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&cedil;", "¸", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&sup1;", "¹", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&ordm;", "º", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&raquo;", "»", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&frac14;", "¼", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&frac12;", "½", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&frac34;", "¾", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&iquest;", "¿", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Agrave;", "À", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Aacute;", "Á", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Acirc;", "Â", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Atilde;", "Ã", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Auml;", "Ä", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Aring;", "Å", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&AElig;", "Æ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Ccedil;", "Ç", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Egrave;", "È", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Eacute;", "É", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Ecirc;", "Ê", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Euml;", "Ë", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Igrave;", "Ì", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Iacute;", "Í", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Icirc;", "Î", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Iuml;", "Ï", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&ETH;", "Ð", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Ntilde;", "Ñ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Ograve;", "Ò", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Oacute;", "Ó", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Ocirc;", "Ô", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Otilde;", "Õ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Ouml;", "Ö", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&times;", "×", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Oslash;", "Ø", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Ugrave;", "Ù", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Uacute;", "Ú", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Ucirc;", "Û", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Uuml;", "Ü", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Yacute;", "Ý", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Yuml;", "Ÿ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&THORN;", "Þ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&szlig;", "ß", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&agrave;", "à", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&aacute;", "á", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&acirc;", "â", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&atilde;", "ã", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&auml;", "ä", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&aring;", "å", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&aelig;", "æ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&ccedil;", "ç", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&egrave;", "è", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&eacute;", "é", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&ecirc;", "ê", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&euml;", "ë", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&igrave;", "ì", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&iacute;", "í", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&icirc;", "î", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&iuml;", "ï", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&eth;", "ð", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&ntilde;", "ñ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&ograve;", "ò", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&oacute;", "ó", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&ocirc;", "ô", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&otilde;", "õ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&ouml;", "ö", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&divide;", "÷", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&oslash;", "ø", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&ugrave;", "ù", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&uacute;", "ú", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&ucirc;", "û", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&uuml;", "ü", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&yacute;", "ý", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&thorn;", "þ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&yuml;", "ÿ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&fnof;", "ƒ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Alpha;", "Α", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Beta;", "Β", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Gamma;", "Γ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Delta;", "Δ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Epsilon;", "Ε", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Zeta;", "Ζ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Eta;", "Η", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Theta;", "Θ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Iota;", "Ι", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Kappa;", "Κ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Lambda;", "Λ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Mu;", "Μ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Nu;", "Ν", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Xi;", "Ξ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Omicron;", "Ο", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Pi;", "Π", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Rho;", "Ρ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Sigma;", "Σ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Tau;", "Τ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Upsilon;", "Υ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Phi;", "Φ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Chi;", "Χ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Psi;", "Ψ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Omega;", "Ω", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&alpha;", "α", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&beta;", "β", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&gamma;", "γ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&delta;", "δ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&epsilon;", "ε", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&zeta;", "ζ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&eta;", "η", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&theta;", "θ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&iota;", "ι", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&kappa;", "κ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&lambda;", "λ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&mu;", "μ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&nu;", "ν", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&xi;", "ξ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&omicron;", "ο", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&pi;", "π", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&rho;", "ρ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&sigmaf;", "ς", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&sigma;", "σ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&tau;", "τ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&upsilon;", "υ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&phi;", "φ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&chi;", "χ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&psi;", "ψ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&omega;", "ω", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&thetasym;", "ϑ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&upsih;", "ϒ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&piv;", "ϖ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&bull;", "•", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&hellip;", "…", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&prime;", "′", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&Prime;", "″", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&oline;", "‾", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&frasl;", "⁄", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&weierp;", "℘", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&image;", "ℑ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&real;", "ℜ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&trade;", "™", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&alefsym;", "ℵ", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&larr;", "←", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&uarr;", "↑", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&rarr;", "→", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&darr;", "↓", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&harr;", "↔", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&crarr;", "↵", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&lArr;", "⇐", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&uArr;", "⇑", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&rArr;", "⇒", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&dArr;", "⇓", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&hArr;", "⇔", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&forall;", "∀", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&part;", "∂", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&exist;", "∃", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&empty;", "∅", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&nabla;", "∇", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&isin;", "∈", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&notin;", "∉", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&ni;", "∋", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&prod;", "∏", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&sum;", "∑", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&minus;", "−", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&lowast;", "∗", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&radic;", "√", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&prop;", "∝", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&infin;", "∞", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&ang;", "∠", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&and;", "∧", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&or;", "∨", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&cap;", "∩", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&cup;", "∪", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&int;", "∫", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&there4;", "∴", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&sim;", "∼", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&cong;", "≅", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&asymp;", "≈", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&ne;", "≠", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&equiv;", "≡", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&le;", "≤", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&ge;", "≥", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&sub;", "⊂", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&sup;", "⊃", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&nsub;", "⊄", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&sube;", "⊆", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&supe;", "⊇", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&oplus;", "⊕", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&otimes;", "⊗", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&perp;", "⊥", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&sdot;", "⋅", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&loz;", "◊", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&spades;", "♠", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&clubs;", "♣", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&hearts;", "♥", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&diams;", "♦", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&lceil;", "⌈", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&rceil;", "⌉", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&lfloor;", "⌊", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&rfloor;", "⌋", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&lang;", "〈", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&rang;", "〉", RegexOptions.IgnoreCase);
            value = Regex.Replace(value, "&amp;", "&", RegexOptions.IgnoreCase);
            return value;
        }

        public static bool IsStartsWith(this string value, char ch)
        {
            return !String.IsNullOrEmpty(value) && value[0] == ch;
        }

        public static bool IsEndWith(this string value, char ch)
        {
            return !String.IsNullOrEmpty(value) && value[value.Length - 1] == ch;
        }

        public static bool IsNumber(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            for (var i = 0; i < value.Length; i++)
            {
                if (!value[i].IsDigit())
                {
                    return false;
                }
            }
            return true;
        }

        public static string ToLower(string value)
        {
            return String.IsNullOrEmpty(value) ? String.Empty : value.ToLower(CultureInfo.CurrentCulture);
        }

        public static string ToUpper(string value)
        {
            return String.IsNullOrEmpty(value) ? String.Empty : value.ToUpper(CultureInfo.CurrentCulture);
        }

        public static string ToName(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return value;
            }
            var result = new StringBuilder();
            _ = result.Append(value.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture)).
                Append(value.Substring(1).ToLower(CultureInfo.CurrentCulture));
            return result.ToString();
        }

        public static string[] GetProgramAndParameters(this string command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            string parameter;
            var result = new List<string>();

            var i = 0;
            while (i < command.Length)
            {
                switch (command[i])
                {
                    case '"':
                        var nextQuotIndex = command.IndexOf('"', i + 1);
                        if (nextQuotIndex == -1)
                        {
                            throw new InvalidOperationException("Could not find closing quotation mark");
                        }
                        parameter = command.Substring(i + 1, nextQuotIndex - i - 1);
                        result.Add(parameter);
                        i = nextQuotIndex;
                        break;
                    case ' ':
                        break;
                    default:
                        var nextParamEndIndex = command.IndexOf(' ', i + 1);
                        parameter = nextParamEndIndex == -1 ? command.Substring(i) : command.Substring(i, nextParamEndIndex - i);
                        result.Add(parameter);
                        i = nextParamEndIndex == -1 ? command.Length : nextParamEndIndex;
                        break;
                }
                i++;
            }
            return result.ToArray();
        }

        public static string UrlDecode(this string value)
        {
            return WebUtility.UrlDecode(value);
        }

        public static string UrlEncode(this string value)
        {
            return WebUtility.UrlEncode(value);
        }

        public static string HtmlDecode(this string value)
        {
            return WebUtility.HtmlDecode(value);
        }

        public static string HtmlEncode(this string value)
        {
            return WebUtility.HtmlEncode(value);
        }

        public static string Substring(this string value, string firstElement)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("String cannot be null or empty", nameof(value));
            }
            if (String.IsNullOrEmpty(firstElement))
            {
                throw new ArgumentException("String cannot be null or empty", nameof(firstElement));
            }

            var startIndex = value.IndexOf(firstElement, StringComparison.CurrentCulture);
            if (startIndex != Constants.NotFound)
            {
                startIndex += firstElement.Length;
                var endIndex = value.IndexOf(',', startIndex + 1);
                return endIndex == Constants.NotFound ? value.Substring(startIndex) : value.Substring(startIndex, endIndex - startIndex);
            }
            return String.Empty;
        }

        public static string Substring(this string value, string firstElement, string secondElement)
        {
            return value.Substring(firstElement, secondElement, false, 0);
        }

        public static string Substring(this string value, string firstElement, string secondElement, bool caseInsensitive)
        {
            return value.Substring(firstElement, secondElement, caseInsensitive, 0);
        }

        public static string Substring(this string value, string firstElement, string secondElement, int startIndex)
        {
            return value.Substring(firstElement, secondElement, false, startIndex);
        }

        public static string Substring(this string value, string firstElement, string secondElement, bool caseInsensitive, int startIndex)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("String cannot be null or empty", nameof(value));
            }
            if (String.IsNullOrEmpty(firstElement))
            {
                throw new ArgumentException("String cannot be null or empty", nameof(firstElement));
            }

            var comparison = caseInsensitive ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;

            var sIndex = value.IndexOf(firstElement, startIndex, comparison);
            if (sIndex == -1)
            {
                return String.Empty;
            }

            sIndex += firstElement.Length;
            var eIndex = value.IndexOf(secondElement, sIndex, comparison);

            return eIndex == -1 ? value.Substring(sIndex) : value.Substring(sIndex, eIndex - sIndex);
        }

        public static string HungarianToEnglish(this string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return String.Empty;
            }

            var sb = new StringBuilder();
            for (var i = 0; i < value.Length; i++)
            {
                switch (value[i])
                {
                    case 'á':
                        _ = sb.Append('a');
                        break;
                    case 'Á':
                        _ = sb.Append('A');
                        break;
                    case 'é':
                        _ = sb.Append('e');
                        break;
                    case 'É':
                        _ = sb.Append('E');
                        break;
                    case 'í':
                        _ = sb.Append('i');
                        break;
                    case 'Í':
                        _ = sb.Append('I');
                        break;
                    case 'ó':
                    case 'ö':
                    case 'ő':
                        _ = sb.Append('o');
                        break;
                    case 'Ó':
                    case 'Ö':
                    case 'Ő':
                        _ = sb.Append('O');
                        break;
                    case 'ú':
                    case 'ü':
                    case 'ű':
                        _ = sb.Append('u');
                        break;
                    case 'Ú':
                    case 'Ü':
                    case 'Ű':
                        _ = sb.Append('U');
                        break;
                    default:
                        _ = sb.Append(value[i]);
                        break;
                }
            }
            return sb.ToString();
        }

        public static string GetSpecialStringWithoutAccent(this string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return String.Empty;
            }

            var specials = "áâäąăÁÂÄĄĂßçčćÇČĆďđĎĐęéëěĘÉËĚíîÍÎĺľłĹĽŁóöőôÓÖŐÔµňńŇŃŕřŔŘşšśŞŠŚţťŢŤúůüűÚŮÜŰýÝźżžŹŻŽ";
            var sb = new StringBuilder();
            var i = 0;
            int index;

            while (i < text.Length)
            {
                index = specials.IndexOf(text[i].ToString(), StringComparison.Ordinal);
                switch (index)
                {
                    case -1: _ = sb.Append(text[i]); break;
                    case 0: case 1: case 2: case 3: case 4: _ = sb.Append('a'); break;
                    case 5: case 6: case 7: case 8: case 9: _ = sb.Append('A'); break;
                    case 10: _ = sb.Append("ss"); break;
                    case 11: case 12: case 13: _ = sb.Append('c'); break;
                    case 14: case 15: case 16: _ = sb.Append('C'); break;
                    case 17: case 18: _ = sb.Append('d'); break;
                    case 19: case 20: _ = sb.Append('D'); break;
                    case 21: case 22: case 23: case 24: _ = sb.Append('e'); break;
                    case 25: case 26: case 27: case 28: _ = sb.Append('E'); break;
                    case 29: case 30: _ = sb.Append('i'); break;
                    case 31: case 32: _ = sb.Append('I'); break;
                    case 33: case 34: case 35: _ = sb.Append('l'); break;
                    case 36: case 37: case 38: _ = sb.Append('L'); break;
                    case 39: case 40: case 41: case 42: _ = sb.Append('o'); break;
                    case 43: case 44: case 45: case 46: _ = sb.Append('O'); break;
                    case 47: _ = sb.Append('u'); break;
                    case 48: case 49: _ = sb.Append('n'); break;
                    case 50: case 51: _ = sb.Append('N'); break;
                    case 52: case 53: _ = sb.Append('r'); break;
                    case 54: case 55: _ = sb.Append('R'); break;
                    case 56: case 57: case 58: _ = sb.Append('s'); break;
                    case 59: case 60: case 61: _ = sb.Append('S'); break;
                    case 62: case 63: _ = sb.Append('t'); break;
                    case 64: case 65: _ = sb.Append('T'); break;
                    case 66: case 67: case 68: case 69: _ = sb.Append('u'); break;
                    case 70: case 71: case 72: case 73: _ = sb.Append('U'); break;
                    case 74: _ = sb.Append('y'); break;
                    case 75: _ = sb.Append('Y'); break;
                    case 76: case 77: case 78: _ = sb.Append('z'); break;
                    case 79: case 80: case 81: _ = sb.Append('Z'); break;
                    default: _ = sb.Append(text[i]); break;
                }
                i++;
            }
            return sb.ToString();
        }

        public static string Reverse(this string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return String.Empty;
            }

            var charArray = new char[value.Length];
            for (var i = 0; i < value.Length; i++)
            {
                charArray[i] = value[value.Length - 1 - i];
            }
            return new string(charArray);
        }

        public static string EscapeString(this string value)
        {
            return SecurityElement.Escape(value);
        }

        public static string Remove(this string value, string removable)
        {
            return Regex.Replace(value, removable, String.Empty, RegexOptions.IgnoreCase);
        }

        public static string GetCodedString(this string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return String.Empty;
            }

            var result = new StringBuilder();
            for (var i = 0; i < value.Length; i++)
            {
                _ = result.Append(value[i].GetCodedChar());
            }

            return result.ToString();
        }

        public static string Base64Encode(this string value)
        {
            var bytesToEncode = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytesToEncode);
        }

        public static string Base64Decode(this string value)
        {
            var bytesToDecode = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(bytesToDecode);
        }

        /// <summary>
        /// Creates a byte array from a string if it's in the correct format. Ex: [12][243][124][68]
        /// </summary>
        /// <param name="value">String representation of the byte array. Ex: [12][243][124][68]</param>
        /// <returns>A byte array. Ex: new byte[] { 12, 243, 124, 68 };</returns>
        public static byte[] ArrayStringToArray(this string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return Array.Empty<byte>();
            }

            var byte_strings = value.Split('[', ']');
            var bytes = new byte[byte_strings.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(byte_strings[(2 * i) + 1], CultureInfo.InvariantCulture);
            }

            return bytes;
        }

        public static string SplitedWithIndex(this string value, char separator, int index)
        {
            if (String.IsNullOrEmpty(value))
            {
                return String.Empty;
            }

            var resultArray = value.Split(new[] { separator }, StringSplitOptions.None);
            return resultArray[index];
        }

        public static string SplitedWithIndex(this string value, string separator, int index)
        {
            if (String.IsNullOrEmpty(value))
            {
                return String.Empty;
            }
            var resultArray = value.Split(new[] { separator }, StringSplitOptions.None);
            return resultArray[index];
        }

        public static string[] Split(this string value, string separator)
        {
            return String.IsNullOrEmpty(value) ? Array.Empty<String>() : value.Split(new[] { separator }, StringSplitOptions.None);
        }

        public static string[] Split(this string value, string separator, StringSplitOptions options)
        {
            return String.IsNullOrEmpty(value) ? Array.Empty<String>() : value.Split(new[] { separator }, options);
        }

        public static string[] SplitOnNewLines(this string value)
        {
            return value.SplitOnNewLines(StringSplitOptions.None);
        }

        public static string[] SplitOnNewLines(this string value, StringSplitOptions options)
        {
            return String.IsNullOrEmpty(value) ? Array.Empty<string>() : value.Split(separator, options);
        }

        public static string[] SplitOnDoubleNewLines(this string value)
        {
            return String.IsNullOrEmpty(value) ? Array.Empty<String>() : value.Split(separatorArray, StringSplitOptions.None);
        }

        public static string GetNext(this string value)
        {
            return Combinatorics.BruteForce(ref value, 0, 255);
        }

        public static string GetNext(this string value, int firstCharcode, int lastCharcode)
        {
            return Combinatorics.BruteForce(ref value, firstCharcode, lastCharcode);
        }

        public static string GetNext(this string value, char firstChar, char lastChar)
        {
            return Combinatorics.BruteForce(ref value, firstChar, lastChar);
        }

        public static string GetNext(this string value, char[] chars)
        {
            return Combinatorics.BruteForce(ref value, chars);
        }

        public static bool IsContainsNumber(this string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return false;
            }

            for (var i = 0; i < value.Length; i++)
            {
                if (Char.IsDigit(value[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsContainsLowerLetter(this string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return false;
            }

            for (var i = 0; i < value.Length; i++)
            {
                if (Char.IsLetter(value[i]) && Char.IsLower(value[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsContainsUpperLetter(this string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return false;
            }

            for (var i = 0; i < value.Length; i++)
            {
                if (Char.IsLetter(value[i]) && Char.IsUpper(value[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsContainsLetter(this string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return false;
            }

            for (var i = 0; i < value.Length; i++)
            {
                if (Char.IsLetter(value[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsContainsSpecial(this string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return false;
            }

            for (var i = 0; i < value.Length; i++)
            {
                if (!Char.IsLetterOrDigit(value[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsContainsSpecialLetterAndDigit(this string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return false;
            }

            var special = value.IsContainsSpecial();
            if (special)
            {
                for (var i = 0; i < value.Length; i++)
                {
                    if (Char.IsLetterOrDigit(value[i]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static string HexaToDecimal(this string value)
        {
            return Convert.ToInt64(value, 16).ToString(CultureInfo.InvariantCulture);
        }

        public static int HexaToInteger(this string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return 0;
            }

            var result = 0;
            const string hex = "0123456789ABCDEF";
            for (var i = 0; i < value.Length; i++)
            {
                result = (result * 16) + hex.IndexOf(Char.ToUpper(value[i], CultureInfo.CurrentCulture).ToString(), StringComparison.Ordinal);
            }

            return result;
        }

        public static string HexaStringToASCII(this string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return String.Empty;
            }

            if (value.Length % 2 != 0)
            {
                throw new ArgumentException("'value' length must be even.", nameof(value));
            }

            var result = new StringBuilder();
            for (var i = 0; i < value.Length / 2; i++)
            {
                _ = result.Append((char)Convert.ToInt32(value.Substring(i * 2, 2), 16));
            }

            return result.ToString();
        }

        public static string ASCIIToHexaString(this string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return String.Empty;
            }

            var result = new StringBuilder();
            for (var i = 0; i < value.Length; i++)
            {
                _ = result.Append(value[i].CharToHexaRepresentation());
            }

            return result.ToString();
        }

        public static bool IsStrongPassword(this string value)
        {
            return !String.IsNullOrEmpty(value) &&
                (value.Length > 8) &&
                value.IsContainsSpecialLetterAndDigit() &&
                value.IsContainsLowerLetter() &&
                value.IsContainsUpperLetter();
        }

        public static bool IsLessThan(this string a, string b)
        {
            return a is null ? throw new ArgumentNullException(nameof(a)) :
                b is null ? throw new ArgumentNullException(nameof(b)) :
                String.Compare(a, b, StringComparison.Ordinal) < 0;
        }

        public static bool IsLessOrEqualThan(this string a, string b)
        {
            return a is null ? throw new ArgumentNullException(nameof(a)) :
                b is null ? throw new ArgumentNullException(nameof(b)) :
                String.Compare(a, b, StringComparison.Ordinal) <= 0;
        }

        public static bool IsGreaterThan(this string a, string b)
        {
            return a is null ? throw new ArgumentNullException(nameof(a)) :
                b is null ? throw new ArgumentNullException(nameof(b)) :
                String.Compare(a, b, StringComparison.Ordinal) > 0;
        }

        public static bool IsGreaterOrEqualThan(this string a, string b)
        {
            return a is null ? throw new ArgumentNullException(nameof(a)) :
                b is null ? throw new ArgumentNullException(nameof(b)) :
                String.Compare(a, b, StringComparison.Ordinal) >= 0;
        }

        public static string TruncateOnChars(this string value, params char[] chars)
        {
            if (String.IsNullOrEmpty(value))
            {
                return String.Empty;
            }
            if (chars == null)
            {
                return value;
            }

            var minLength = value.Length;
            for (var i = 0; i < chars.Length; i++)
            {
                var index = value.IndexOf(chars[i].ToString(), StringComparison.Ordinal);
                if ((index > Constants.NotFound) && (minLength > index))
                {
                    minLength = index;
                }
            }
            return value.Substring(0, minLength);
        }

        public static bool ToBool(this string value)
        {
            return Convert.ToBoolean(value, CultureInfo.InvariantCulture);
        }

        public static byte ToByte(this string value)
        {
            return Convert.ToByte(value, CultureInfo.InvariantCulture);
        }

        public static char ToChar(this string value)
        {
            return Convert.ToChar(value, CultureInfo.InvariantCulture);
        }

        public static DateTime ToDateTime(this string value)
        {
            return Convert.ToDateTime(value, CultureInfo.InvariantCulture);
        }

        public static int ToInt(this string value)
        {
            return Convert.ToInt32(value, CultureInfo.InvariantCulture);
        }

        public static Int64 ToInt64(this string value)
        {
            return Convert.ToInt64(value, CultureInfo.InvariantCulture);
        }

        public static void SimulateKeys(this string value)
        {
            SendKeys.Send(value);
        }

        public static bool IsEqualOneOfThis(this string value, params string[] values)
        {
            return Generics.IsEqualOneOfThis<string>(value, values);
        }

    }
}

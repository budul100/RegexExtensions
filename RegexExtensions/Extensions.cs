using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RegexExtensions
{
    public static class Extensions
    {
        #region Private Fields

        private const string NewLineSeparators = "\r\n";
        private const string RegexOr = "|";

        private static readonly char[] newLineSeparators = NewLineSeparators.ToCharArray();

        #endregion Private Fields

        #region Public Methods

        public static string GetFullmatchPattern(this IEnumerable<string> inputs)
        {
            var result = string.Empty;

            var relevants = inputs?
                .Where(i => !string.IsNullOrWhiteSpace(i))
                .SelectMany(i => i.Split(newLineSeparators))
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Distinct().ToArray();

            if (relevants?.Any() ?? false)
            {
                var pattern = default(string);

                if (relevants.Length == 1)
                {
                    pattern = relevants.Single();
                }
                else
                {
                    pattern = string.Join(
                        separator: RegexOr,
                        value: relevants);
                }

                result = $@"\A(?:{pattern})\z";
            }

            return result;
        }

        public static string GetFullmatchPattern(this string input)
        {
            var inputs = new string[] { input };

            var result = inputs.GetFullmatchPattern();

            return result;
        }

        public static bool IsMatch(this string input, string pattern,
            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Multiline)
        {
            var result = false;

            if (!string.IsNullOrWhiteSpace(input) && !string.IsNullOrWhiteSpace(pattern))
            {
                var fullMatchPattern = pattern.GetFullmatchPattern();

                result = Regex.IsMatch(
                    input: input,
                    pattern: fullMatchPattern,
                    options: options);
            }

            return result;
        }

        public static bool IsMatchOrEmptyPattern(this string input, string pattern,
            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Multiline)
        {
            var result = string.IsNullOrWhiteSpace(pattern)
                || input.IsMatch(
                    pattern: pattern,
                    options: options);

            return result;
        }

        public static bool IsMatchOrEmptyPatternOrEmptyValue(this string input, string pattern,
            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Multiline)
        {
            var result = string.IsNullOrWhiteSpace(input)
                || string.IsNullOrWhiteSpace(pattern)
                || input.IsMatch(
                    pattern: pattern,
                    options: options);

            return result;
        }

        #endregion Public Methods
    }
}
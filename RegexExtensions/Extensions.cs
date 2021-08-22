using System;
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

        public static string GetFullmatchPattern(this string input)
        {
            var result = input ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(input))
            {
                var pattern = input;

                var splits = input.Split(
                    separator: newLineSeparators,
                    options: StringSplitOptions.RemoveEmptyEntries);

                if (splits.Length > 1)
                {
                    pattern = string.Join(
                        separator: RegexOr,
                        value: splits);
                }

                result = $@"\A(?:{pattern})\z";
            }

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
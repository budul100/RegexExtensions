using System;
using System.Text.RegularExpressions;

namespace Extensions
{
    public static class RegexExtensions
    {
        #region Public Methods

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

        public static bool IsMatchOrEmpty(this string input, string pattern,
            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Multiline)
        {
            var result = string.IsNullOrWhiteSpace(pattern);

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

        public static bool IsMatchOrEmptyOrDefault(this string input, string pattern,
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

        #region Private Methods

        private static string GetFullmatchPattern(this string input)
        {
            var result = string.Empty;

            if (!string.IsNullOrWhiteSpace(input))
            {
                var split = input.Split(
                    separator: new char[] { '\n', '\r' },
                    options: StringSplitOptions.RemoveEmptyEntries);
                var splitOr = string.Join("|", split);

                result = $@"\A(?:{splitOr})\z";
            }

            return result;
        }

        #endregion Private Methods
    }
}
using NUnit.Framework;
using RegexExtensions;

namespace RegexExtensionsTest
{
    public class Tests
    {
        #region Public Methods

        [Test]
        public void FullMatchPatternEmpty()
        {
            const string pattern = default;

            pattern.GetFullmatchPattern();
        }

        [Test]
        public void FullMatchPatternMultiple()
        {
            var pattern = new string[] { "Buss Nordlandsbanen\nBuss Saltenpendelen", "Buss Nordlandsbanen" };

            var result = pattern.GetFullmatchPattern();

            Assert.True(result.Contains('|'));
        }

        [Test]
        public void FullMatchPatternMultipleDuplicates()
        {
            var pattern = new string[] { "Buss Nordlandsbanen", "Buss Nordlandsbanen" };

            var result = pattern.GetFullmatchPattern();

            Assert.False(result.Contains('|'));
        }

        [Test]
        public void FullMatchPatternSingleWithBreak()
        {
            const string pattern = "Buss Nordlandsbanen\nBuss Saltenpendelen";

            var result = pattern.GetFullmatchPattern();

            Assert.True(result.Contains('|'));
        }

        [Test]
        public void FullMatchPatternSingleWithoutBreak()
        {
            const string pattern = "Buss Nordlandsbanen";

            var result = pattern.GetFullmatchPattern();

            Assert.False(result.Contains('|'));
        }

        [Test]
        public void IsMatchFalse()
        {
            const string text = "abc";
            const string pattern = ".{2}";

            var result = text.IsMatch(pattern);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsMatchOrEmptyPatternBoth()
        {
            const string text = default;
            const string pattern = default;

            var result = text.IsMatchOrEmptyPattern(pattern);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsMatchOrEmptyPatternOrEmptyValueBoth()
        {
            const string text = default;
            const string pattern = default;

            var result = text.IsMatchOrEmptyPatternOrEmptyValue(pattern);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsMatchOrEmptyPatternOrEmptyValuePattern()
        {
            const string text = "abc";
            const string pattern = default;

            var result = text.IsMatchOrEmptyPatternOrEmptyValue(pattern);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsMatchOrEmptyPatternOrEmptyValueText()
        {
            const string text = default;
            const string pattern = ".{2}";

            var result = text.IsMatchOrEmptyPatternOrEmptyValue(pattern);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsMatchOrEmptyPatternPattern()
        {
            const string text = "abc";
            const string pattern = default;

            var result = text.IsMatchOrEmptyPattern(pattern);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsMatchOrEmptyPatternText()
        {
            const string text = default;
            const string pattern = ".{2}";

            var result = text.IsMatchOrEmptyPattern(pattern);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsMatchTrue()
        {
            const string text = "abc";
            const string pattern = ".{3}";

            var result = text.IsMatch(pattern);

            Assert.IsTrue(result);
        }

        #endregion Public Methods
    }
}
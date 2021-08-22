using NUnit.Framework;
using RegexExtensions;

namespace RegexExtensionsTest
{
    public class Tests
    {
        #region Public Methods

        [Test]
        public void FullMatchPatternWithBreak()
        {
            var pattern = "Buss Nordlandsbanen\nBuss Saltenpendelen";
            var result = pattern.GetFullmatchPattern();

            Assert.True(result.Contains("|"));
        }

        [Test]
        public void FullMatchPatternWithoutBreak()
        {
            var pattern = "Buss Nordlandsbanen";
            var result = pattern.GetFullmatchPattern();

            Assert.False(result.Contains("|"));
        }

        [Test]
        public void IsMatchFalse()
        {
            var text = "abc";
            var pattern = ".{2}";
            var result = text.IsMatch(pattern);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsMatchOrEmptyPatternBoth()
        {
            var text = default(string);
            var pattern = default(string);
            var result = text.IsMatchOrEmptyPattern(pattern);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsMatchOrEmptyPatternOrEmptyValueBoth()
        {
            var text = default(string);
            var pattern = default(string);
            var result = text.IsMatchOrEmptyPatternOrEmptyValue(pattern);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsMatchOrEmptyPatternOrEmptyValuePattern()
        {
            var text = "abc";
            var pattern = default(string);
            var result = text.IsMatchOrEmptyPatternOrEmptyValue(pattern);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsMatchOrEmptyPatternOrEmptyValueText()
        {
            var text = default(string);
            var pattern = ".{2}";
            var result = text.IsMatchOrEmptyPatternOrEmptyValue(pattern);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsMatchOrEmptyPatternPattern()
        {
            var text = "abc";
            var pattern = default(string);
            var result = text.IsMatchOrEmptyPattern(pattern);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsMatchOrEmptyPatternText()
        {
            var text = default(string);
            var pattern = ".{2}";
            var result = text.IsMatchOrEmptyPattern(pattern);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsMatchTrue()
        {
            var text = "abc";
            var pattern = ".{3}";
            var result = text.IsMatch(pattern);

            Assert.IsTrue(result);
        }

        #endregion Public Methods
    }
}
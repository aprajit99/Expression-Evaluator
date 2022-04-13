using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class ConcatenateTests
    {
        private Expression func;

        [SetUp]
        public void init() { func = new Expression(""); }

        [TearDown]
        public void clear() { func.Clear(); }

        [Test]
        public void Addition_StringsAndNumbers001_CorrectValue()
        {
            func.Function = @"'a' + 1";
            Assert.AreEqual("a1", func.Evaluate<string>());
        }

        [Test]
        public void Addition_StringsAndNumbers002_CorrectValue()
        {
            func.Function = @"1 + 'a'";
            Assert.AreEqual("1a", func.Evaluate<string>());
        }

        [Test]
        public void Addition_StringsAndNumbers003_CorrectValue()
        {
            func.Function = @"'a' + 'b'";
            Assert.AreEqual("ab", func.Evaluate<string>());
        }

        [Test]
        public void Concatenate_AllStrings_CorrectValue()
        {
            func.Function = @"concatenate('a', 'b')";
            Assert.AreEqual("ab", func.Evaluate<string>());
        }

        [Test]
        public void Concatenate_StringsAndNumbers_CorrectValue()
        {
            func.Function = @"concatenate('a', 1)";
            Assert.AreEqual("a1", func.Evaluate<string>());
        }

        [Test]
        public void Concatenate_WithEmptyVariables_CorrectValue()
        {
            func.Function = @"concatenate('a', 1, a)";
            Assert.AreEqual("a1", func.Evaluate<string>());
        }

        [Test]
        public void Concatenate_WithVariables_CorrectValue()
        {
            func.Function = @"concatenate('a', 1, a)";
            func.AddSetVariable("a", "word");
            Assert.AreEqual("a1word", func.Evaluate<string>());
        }
        
    }
}

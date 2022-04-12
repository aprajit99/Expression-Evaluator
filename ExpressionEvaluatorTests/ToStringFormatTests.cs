using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class ToStringFormatTests
    {
        private Expression func;

        [SetUp]
        public void init() { func = new Expression(""); }

        [TearDown]
        public void clear() { func.Clear(); }

        [Test]
        public void ToStringFormat_PreceedingZero_CorrectValue()
        {
            func.Function = @"ToStringFormat(10, '000')";
            Assert.AreEqual("010", func.Evaluate<string>());
        }

        [Test]
        public void ToStringFormat_TrailingZeroExceeded_CorrectValue()
        {
            func.Function = @"ToStringFormat(10.123, '0.00')";
            Assert.AreEqual("10.12", func.Evaluate<string>());
        }

        [Test]
        public void ToStringFormat_TrailingZero_CorrectValue()
        {
            func.Function = @"ToStringFormat(10.1, '0.00')";
            Assert.AreEqual("10.10", func.Evaluate<string>());
        }
        
    }
}

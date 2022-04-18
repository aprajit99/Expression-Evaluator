using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class ContainsTests
    {
        private Expression _func;

        [SetUp]
        public void Init() { _func = new Expression(""); }

        [TearDown]
        public void Clear() { _func.Clear(); }

        [Test]
        public void Contains_CaseMismatchCapInVariable_True()
        {
            _func.Function = @"Contains('abcd', a)";
            _func.AddSetVariable("a", "Cd");
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void Contains_CaseMismatchCapitolInFunction_True()
        {
            _func.Function = @"Contains('abCd', a)";
            _func.AddSetVariable("a", "cd");
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void Contains_CaseMismatchCapitolInVariabl_True()
        {
            _func.Function = @"Contains('abCd', a)";
            _func.AddSetVariable("a", "Ab");
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void Contains_CaseMismatch_True()
        {
            _func.Function = @"Contains('abCd','cd')";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void Contains_StringBegins_True()
        {
            _func.Function = @"Contains('abcd','ab')";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void Contains_StringEnds_True()
        {
            _func.Function = @"Contains('abcd','cd')";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void Contains_StringIsASubstring_True()
        {
            _func.Function = @"Contains('abcd','bc')";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }
        
    }
}

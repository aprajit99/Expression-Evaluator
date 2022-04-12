using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class DateTimeTests
    {
        private Expression _func;
        private DateTime _now;

        [SetUp]
        public void Init()
        {
            _func = new Expression("");
            _now = DateTime.Now;
        }

        [TearDown]
        public void Clear() { _func.Clear(); }

        [Test]
        public void Addition_DateTimeTimeSpan_IsCorrect()
        {
            _func.Function = "a + days(1)";
            _func.AddSetVariable("a", _now);
            Assert.AreEqual(_now.AddDays(1), _func.Evaluate<DateTime>());
        }

        [Test]
        public void Addition_TimeSpanDateTime_IsCorrect()
        {
            _func.Function = "days(1) + a";
            _func.AddSetVariable("a", _now);
            Assert.AreEqual(_now.AddDays(1), _func.Evaluate<DateTime>());
        }

        [Test]
        public void Addition_TimeSpanTimeSpan_IsCorrect()
        {
            _func.Function = "days(1) + days(1)";
            _func.AddSetVariable("a", _now);
            Assert.AreEqual(new TimeSpan(2, 0, 0, 0), _func.Evaluate<TimeSpan>());
        }

        [Test]
        public void Days_DifferenceGreaterThanEqual_IsTrue()
        {
            _func.Function = "totalDays(a - b) >= 2";
            _func.AddSetVariable("a", new DateTime(2014, 12, 09, 3, 23, 00));
            _func.AddSetVariable("b", new DateTime(2014, 12, 07, 3, 23, 00));
            Assert.IsTrue(_func.EvaluateBoolean());
        }

        [Test]
        public void Days_DifferenceGreaterThan_IsTrue()
        {
            _func.Function = "totalDays(a - b) > 1";
            _func.AddSetVariable("a", new DateTime(2014, 12, 09, 3, 23, 00));
            _func.AddSetVariable("b", new DateTime(2014, 12, 07, 3, 23, 00));
            Assert.IsTrue(_func.EvaluateBoolean());
        }

        [Test]
        public void Days_DifferenceLessThanEqual_IsTrue()
        {
            _func.Function = "totalDays(a - b) <= 2";
            _func.AddSetVariable("a", new DateTime(2014, 12, 09, 3, 23, 00));
            _func.AddSetVariable("b", new DateTime(2014, 12, 07, 3, 23, 00));
            Assert.IsTrue(_func.EvaluateBoolean());
        }

        [Test]
        public void Days_DifferenceLessThan_IsTrue()
        {
            _func.Function = "totalDays(a - b) < 3";
            _func.AddSetVariable("a", new DateTime(2014, 12, 09, 1, 23, 00));
            _func.AddSetVariable("b", new DateTime(2014, 12, 07, 3, 23, 00));
            Assert.IsTrue(_func.EvaluateBoolean());
        }

        [Test]
        public void Days_Timespan_IsCorrect()
        {
            _func.Function = "totaldays(a)";
            _func.AddSetVariable("a", new TimeSpan(2, 0, 0, 0));
            Assert.AreEqual(2, _func.EvaluateNumeric());
        }

        [Test]
        public void Equal_DateTimeEqual_True()
        {
            _func.Function = "a == b";
            _func.AddSetVariable("a", _now);
            _func.AddSetVariable("b", _now);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void Equal_DateTime_False()
        {
            _func.Function = "a == b";
            _func.AddSetVariable("a", _now.AddDays(1));
            _func.AddSetVariable("b", _now);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void Equal_TimeSpan_False()
        {
            _func.Function = "days(1) == minutes(1)";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void Equal_TimeSpan_True()
        {
            _func.Function = "days(1) == days(1)";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqual_DateTimeEqual_True()
        {
            _func.Function = "a >= b";
            _func.AddSetVariable("a", _now);
            _func.AddSetVariable("b", _now);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqual_DateTime_False()
        {
            _func.Function = "a >= b";
            _func.AddSetVariable("a", _now);
            _func.AddSetVariable("b", _now.AddDays(1));
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqual_DateTime_True()
        {
            _func.Function = "a >= b";
            _func.AddSetVariable("a", _now.AddDays(1));
            _func.AddSetVariable("b", _now);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqual_TimeSpanEqual_True()
        {
            _func.Function = "days(1) >= days(1)";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqual_TimeSpan_False()
        {
            _func.Function = "seconds(1) >= days(1)";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqual_TimeSpan_True()
        {
            _func.Function = "days(1) >= seconds(1)";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThan_DateTime_False()
        {
            _func.Function = "a > b";
            _func.AddSetVariable("a", _now);
            _func.AddSetVariable("b", _now.AddDays(1));
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThan_DateTime_True()
        {
            _func.Function = "a > b";
            _func.AddSetVariable("a", _now.AddDays(1));
            _func.AddSetVariable("b", _now);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThan_TimeSpan_False()
        {
            _func.Function = "seconds(1) > days(1)";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThan_TimeSpan_True()
        {
            _func.Function = "days(1) > seconds(1)";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void Hours_DifferenceEqual_IsFalse()
        {
            _func.Function = "totalHours(a - b) == 2";
            _func.AddSetVariable("a", new DateTime(2014, 12, 09, 3, 23, 20));
            _func.AddSetVariable("b", new DateTime(2014, 12, 09, 1, 23, 00));
            Assert.IsFalse(_func.EvaluateBoolean());
        }

        [Test]
        public void Hours_DifferenceGreaterThanEqual_IsTrue()
        {
            _func.Function = "totalHours(a - b) >= 2";
            _func.AddSetVariable("a", new DateTime(2014, 12, 09, 3, 23, 00));
            _func.AddSetVariable("b", new DateTime(2014, 12, 09, 1, 23, 00));
            Assert.IsTrue(_func.EvaluateBoolean());
        }

        [Test]
        public void Hours_DifferenceGreaterThan_IsTrue()
        {
            _func.Function = "totalHours(a - b) > 1";
            _func.AddSetVariable("a", new DateTime(2014, 12, 09, 3, 23, 00));
            _func.AddSetVariable("b", new DateTime(2014, 12, 09, 1, 23, 00));
            Assert.IsTrue(_func.EvaluateBoolean());
        }

        [Test]
        public void Hours_DifferenceLessThanEqual_IsTrue()
        {
            _func.Function = "totalHours(a - b) <= 2";
            _func.AddSetVariable("a", new DateTime(2014, 12, 09, 3, 23, 00));
            _func.AddSetVariable("b", new DateTime(2014, 12, 09, 1, 23, 00));
            Assert.IsTrue(_func.EvaluateBoolean());
        }

        [Test]
        public void Hours_DifferenceLessThan_IsTrue()
        {
            _func.Function = "totalHours(a - b) < 3";
            _func.AddSetVariable("a", new DateTime(2014, 12, 09, 1, 23, 00));
            _func.AddSetVariable("b", new DateTime(2014, 12, 09, 1, 23, 00));
            Assert.IsTrue(_func.EvaluateBoolean());
        }

        [Test]
        public void Hours_Timespan_IsCorrect()
        {
            _func.Function = "totalhours(a)";
            _func.AddSetVariable("a", new TimeSpan(1, 0, 0, 0));
            Assert.AreEqual(24, _func.EvaluateNumeric());
        }

        [Test]
        public void LesserEqual_DateTimeEqual_True()
        {
            _func.Function = "a <= b";
            _func.AddSetVariable("a", _now);
            _func.AddSetVariable("b", _now);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqual_DateTime_False()
        {
            _func.Function = "a <= b";
            _func.AddSetVariable("a", _now.AddDays(1));
            _func.AddSetVariable("b", _now);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqual_DateTime_True()
        {
            _func.Function = "a <= b";
            _func.AddSetVariable("a", _now);
            _func.AddSetVariable("b", _now.AddDays(1));
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqual_TimeSpanEqual_True()
        {
            _func.Function = "days(1) <= days(1)";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqual_TimeSpan_False()
        {
            _func.Function = "days(1) <= seconds(1)";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqual_TimeSpan_True()
        {
            _func.Function = "seconds(1) <= days(1)";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThan_DateTime_False()
        {
            _func.Function = "a < b";
            _func.AddSetVariable("a", _now.AddDays(1));
            _func.AddSetVariable("b", _now);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThan_DateTime_True()
        {
            _func.Function = "a < b";
            _func.AddSetVariable("a", _now);
            _func.AddSetVariable("b", _now.AddDays(1));
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThan_TimeSpan_False()
        {
            _func.Function = "days(1) < seconds(1)";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void LesserThan_TimeSpan_True()
        {
            _func.Function = "seconds(1) < days(1)";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void Minutes_Timespan_IsCorrect()
        {
            _func.Function = "totalminutes(a)";
            _func.AddSetVariable("a", new TimeSpan(1, 0, 0));
            Assert.AreEqual(60, _func.EvaluateNumeric());
        }

        [Test]
        public void Munits_DifferenceEqual_IsFalse()
        {
            _func.Function = "totalMinutes(a - b) == 2";
            _func.AddSetVariable("a", new DateTime(2014, 12, 09, 1, 23, 20));
            _func.AddSetVariable("b", new DateTime(2014, 12, 09, 1, 21, 00));
            Assert.IsFalse(_func.EvaluateBoolean());
        }

        [Test]
        public void Munits_DifferenceGreaterThanEqual_IsTrue()
        {
            _func.Function = "totalMinutes(a - b) >= 2";
            _func.AddSetVariable("a", new DateTime(2014, 12, 09, 1, 23, 00));
            _func.AddSetVariable("b", new DateTime(2014, 12, 09, 1, 21, 00));
            Assert.IsTrue(_func.EvaluateBoolean());
        }

        [Test]
        public void Munits_DifferenceGreaterThan_IsTrue()
        {
            _func.Function = "totalMinutes(a - b) > 1";
            _func.AddSetVariable("a", new DateTime(2014, 12, 09, 1, 23, 00));
            _func.AddSetVariable("b", new DateTime(2014, 12, 09, 1, 21, 00));
            Assert.IsTrue(_func.EvaluateBoolean());
        }

        [Test]
        public void Munits_DifferenceLessThanEqual_IsTrue()
        {
            _func.Function = "totalMinutes(a - b) <= 2";
            _func.AddSetVariable("a", new DateTime(2014, 12, 09, 1, 23, 00));
            _func.AddSetVariable("b", new DateTime(2014, 12, 09, 1, 21, 00));
            Assert.IsTrue(_func.EvaluateBoolean());
        }

        [Test]
        public void Munits_DifferenceLessThan_IsTrue()
        {
            _func.Function = "totalMinutes(a - b) < 3";
            _func.AddSetVariable("a", new DateTime(2014, 12, 09, 1, 23, 00));
            _func.AddSetVariable("b", new DateTime(2014, 12, 09, 1, 21, 00));
            Assert.IsTrue(_func.EvaluateBoolean());
        }

        [Test]
        public void NotEqual_DateTimeEqual_True()
        {
            _func.Function = "a != b";
            _func.AddSetVariable("a", _now.AddDays(1));
            _func.AddSetVariable("b", _now);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqual_DateTime_False()
        {
            _func.Function = "a != b";
            _func.AddSetVariable("a", _now);
            _func.AddSetVariable("b", _now);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqual_TimeSpan_False()
        {
            _func.Function = "days(1) != days(1)";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqual_TimeSpan_True()
        {
            _func.Function = "days(1) != minutes(1)";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void Seconds_DifferenceEqual_IsFalse()
        {
            _func.Function = "totalSeconds(a - b) == 2";
            _func.AddSetVariable("a", new DateTime(2014, 12, 09, 3, 23, 20));
            _func.AddSetVariable("b", new DateTime(2014, 12, 09, 3, 23, 00));
            Assert.IsFalse(_func.EvaluateBoolean());
        }

        [Test]
        public void Seconds_DifferenceGreaterThanEqual_IsTrue()
        {
            _func.Function = "totalSeconds(a - b) >= 2";
            _func.AddSetVariable("a", new DateTime(2014, 12, 09, 3, 23, 02));
            _func.AddSetVariable("b", new DateTime(2014, 12, 09, 3, 23, 00));
            Assert.IsTrue(_func.EvaluateBoolean());
        }

        [Test]
        public void Seconds_DifferenceGreaterThan_IsTrue()
        {
            _func.Function = "totalSeconds(a - b) > 1";
            _func.AddSetVariable("a", new DateTime(2014, 12, 09, 3, 23, 02));
            _func.AddSetVariable("b", new DateTime(2014, 12, 09, 3, 23, 00));
            Assert.IsTrue(_func.EvaluateBoolean());
        }

        [Test]
        public void Seconds_DifferenceLessThanEqual_IsTrue()
        {
            _func.Function = "totalSeconds(a - b) <= 2";
            _func.AddSetVariable("a", new DateTime(2014, 12, 09, 3, 23, 02));
            _func.AddSetVariable("b", new DateTime(2014, 12, 09, 3, 23, 00));
            Assert.IsTrue(_func.EvaluateBoolean());
        }

        [Test]
        public void Seconds_DifferenceLessThan_IsTrue()
        {
            _func.Function = "totalSeconds(a - b) < 3";
            _func.AddSetVariable("a", new DateTime(2014, 12, 09, 1, 23, 02));
            _func.AddSetVariable("b", new DateTime(2014, 12, 09, 3, 23, 00));
            Assert.IsTrue(_func.EvaluateBoolean());
        }

        [Test]
        public void Seconds_Timespan_IsCorrect()
        {
            _func.Function = "totalseconds(a)";
            _func.AddSetVariable("a", new TimeSpan(0, 1, 0));
            Assert.AreEqual(60, _func.EvaluateNumeric());
        }

        [Test]
        public void Subtraction_DateTimeDateTime_IsCorrect()
        {
            _func.Function = "a - b";
            _func.AddSetVariable("a", _now.AddDays(1));
            _func.AddSetVariable("b", _now);
            Assert.AreEqual(new TimeSpan(1, 0, 0, 0), _func.Evaluate<TimeSpan>());
        }

        [Test]
        public void Subtraction_DateTimeTimeSpan_IsCorrect()
        {
            _func.Function = "a - days(1)";
            _func.AddSetVariable("a", _now);
            Assert.AreEqual(_now.AddDays(-1), _func.Evaluate<DateTime>());
        }

        [Test]
        public void Subtraction_TimeSpanTimeSpan_IsCorrect()
        {
            _func.Function = "days(2) - days(1)";
            _func.AddSetVariable("a", _now);
            Assert.AreEqual(new TimeSpan(1, 0, 0, 0), _func.Evaluate<TimeSpan>());
        }
        [Test]
        public void Now_test() {
            _func.Function = "a";
            _func.AddSetVariable("a", _now);
            Assert.AreEqual(_now, _func.Evaluate<DateTime>());
        }
    }
}

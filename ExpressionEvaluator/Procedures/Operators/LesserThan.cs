using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Operators
{
    internal class LesserThan : Operator
    {
        public LesserThan(int precedance)
            : base("<", precedance, 2, false)
        {
            _name2 = "LessThan";
            Category = "Relational";
            Description = "Check if the first operand is lesser than the second.";
            DecimalDecimalBool = (x, y) => x < y;
            TimespanTimespanBool = (x, y) => x < y;
            DatetimeDatetimeBool = (x, y) => x < y;
            DecimalDoubleDouble = (x, y) => double.NaN;
            DoubleDecimalDouble = (x, y) => double.NaN;
        }
    }
}

using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Operators
{
    internal class GreaterThan : Operator
    {
        public GreaterThan(int precedance)
            : base(">", precedance, 2, false)
        {
            _name2 = "GreaterThan";
            Category = "Relational";
            Description = "Check if the first operand is greater than the second.";
            DecimalDecimalBool = (x, y) => x > y;
            TimespanTimespanBool = (x, y) => x > y;
            DatetimeDatetimeBool = (x, y) => x > y;
            DecimalDoubleDouble = (x, y) => double.NaN;
            DoubleDecimalDouble = (x, y) => double.NaN;
        }
    }
}

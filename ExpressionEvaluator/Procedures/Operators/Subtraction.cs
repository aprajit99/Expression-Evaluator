using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Operators
{
    internal class Subtraction : Operator
    {
        public Subtraction(int precedance)
            : base("-", precedance, 2, false)
        {
            _name2 = "Subtraction";
            Category = "Arithmetic";
            Description = "Subtract two operands.";
            DecimalDecimalDecimal = (x, y) => x - y;
            TimespanTimespanTimespan = (x, y) => x - y;
            DatetimeTimespanDatetime = (x, y) => x - y;
            DatetimeDatetimeTimespan = (x, y) => x - y;
        }
    }
}

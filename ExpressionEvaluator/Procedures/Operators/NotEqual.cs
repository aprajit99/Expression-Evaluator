using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Operators
{
    internal class NotEqual : Operator
    {
        public NotEqual(int precedance)
            : base("!=", precedance, 2, false)
        {
            _name2 = "NotEqual";
            Category = "Relational";
            Description = "Check if both operands are not equal.";
            DecimalDecimalBool = (x, y) => x != y;
            BoolBoolBool = (x, y) => x != y;
            StringStringBool = (x, y) => x != y;
            TimespanTimespanBool = (x, y) => x != y;
            DatetimeDatetimeBool = (x, y) => x != y;
            DecimalDoubleDouble = (x, y) => double.NaN;
            DoubleDecimalDouble = (x, y) => double.NaN;
            ObjectObjectBool = (x, y) => x != y;
            AnyAnyBool = (x, y) => {
                if (x.GetType() != y.GetType()) {
                    return true;
                }
                throw new ExpressionException(_name2 + " unsupported type for comparison.");
            };
        }
    }
}

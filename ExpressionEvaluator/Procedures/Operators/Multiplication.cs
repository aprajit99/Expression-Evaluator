using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Operators
{
    internal class Multiplication : Operator
    {
        public Multiplication(int precedance)
            : base("*", precedance, 2, false)
        {
            _name2 = "Multiplication";
            Category = "Arithmetic";
            Description = "Multiply two operands.";
            DecimalDecimalDecimal = (x, y) =>x*y;
        }
    }
}

using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Operators
{
    internal class Modulo : Operator
    {
        public Modulo(int precedance)
            : base("%", precedance, 2, false)
        {
            _name2 = "Modulo";
            Category = "Arithmetic";
            Description = " Find the remains of two integers and gives the remainder after the division.";
            DecimalDecimalDecimal = (x, y) => x % y;
        }
    }
}
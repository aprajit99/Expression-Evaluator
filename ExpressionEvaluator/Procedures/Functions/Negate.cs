using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class Negate : Function
    {
        public Negate(int precedance)
            : base("neg", precedance, 1, false)
        {
            _name2 = "Negate";
            Category = "Mathematical Function";
            Description = "Returns the result of multiplying the specified value by negative one";
            DecimalDecimal = x => -1 * x;
        }
    }
}

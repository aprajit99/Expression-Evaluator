using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class Sign : Function
    {
        public Sign(int precedance)
            : base("sign", precedance, 1, false)
        {
            _name2 = "Sign";
            Category = "Mathematical Function";
            Description = "Returns an integer that specify the sign of the number";
            DecimalDecimal = x => x >= 0 ? 1 : -1;
        }
    }
}

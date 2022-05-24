using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class ToStringFormat : Function
    {
        public ToStringFormat(int precedance)
            : base("tostringformat", precedance, 2, false)
        {
            _name2 = "ToStringFormat";
            Category = "String";
            Description = "Adds leading or trailing zeros to a no. and returns the string equivalent.";
            DecimalStringString = (x, y) => x.ToString(y);
        }
    }
}
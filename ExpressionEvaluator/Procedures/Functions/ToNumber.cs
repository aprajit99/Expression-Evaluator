using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class ToNumber : Function
    {
        public ToNumber(int precedance)
            : base("tonumber", precedance, 1, false)
        {
            _name2 = "ToNumber";
            Category = "String";
            Description = "Returns the number equivalent of the given string.";
            StringDecimal = x => {
                try {
                    return decimal.Parse(x);
                }
                catch {
                    throw new NotFiniteNumberException();
                }
            };
        }
    }
}

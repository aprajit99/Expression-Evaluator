using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class Round : Function
    {
        public Round(int precedance)
            : base("round", precedance, 2, false)
        {
            _name2 = "Round";
            Category = "Mathematical Function";
            Description = "Rounds the number to a specified number of digits";
            DecimalDecimalDecimal = (x, y) => Math.Round(x, (int)y, MidpointRounding.AwayFromZero);
        }
    }
}

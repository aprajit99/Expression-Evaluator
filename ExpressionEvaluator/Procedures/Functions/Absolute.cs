using System;
using System.Globalization;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class Absolute : Function
    {
        public Absolute(int precedance)
            : base("abs", precedance, 1, false)
        {
            _name2 = "Absolute";
            Category = "Mathematical Function";
            Description = "Return the absolute value of a specified number";
            DecimalDecimal = x => {
                double dblResult = Math.Abs((double)x);
                if (double.IsNaN(dblResult)) {
                    throw new NotFiniteNumberException("Not a number");
                }
                return Decimal.Parse(dblResult.ToString("R"), NumberStyles.Any);
            };
        }
    }
}

using System;
using System.Globalization;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class NaturalLog : Function
    {
        public NaturalLog(int precedance)
            : base("ln", precedance, 1, false)
        {
            _name2 = "NaturalLog";
            Category = "Mathematical Function";
            Description = "Returns the natural (base e) logarithm of a specified number.";
            DecimalDecimal = x => {
                double dblResult = Math.Log((double)x);
                if (double.IsNaN(dblResult)) {
                    throw new NotFiniteNumberException("Not a number");
                }
                return Decimal.Parse(dblResult.ToString("R"), NumberStyles.Any);
            };
        }
    }
}

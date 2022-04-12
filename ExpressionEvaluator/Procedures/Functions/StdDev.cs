using System;
using System.Linq;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class StdDev : Function
    {
        public StdDev(int precedance)
            : base("stddev", precedance, 1, true)
        {
            _name2 = "StdDev";
            Category = "Mathematical Function";
            Description = "Returns the standard deviation of the given numbers";
            DecimalDecimalOperandList = x => {
                var avg = (double)x.Average();
                return (decimal)Math.Sqrt(x.Average(v => Math.Pow((double)v - avg, 2)));
            };
        }
    }
}

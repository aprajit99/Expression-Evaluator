using System;
using System.Globalization;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Operators
{
    internal class Power : Operator
    {
        public Power(int precedance)
            : base("^", precedance, 2, false)
        {
            _name2 = "Power";
            Category = "Arithmetic";
            Description = "Raise the number on the left to the power of the exponent of the right.";
            DecimalDecimalDecimal = (x, y) => {
                double dblResult = Math.Pow((double)x, (double)y);
                if (double.IsNaN(dblResult)) {
                    throw new NotFiniteNumberException("Not a number");
                }
                return Decimal.Parse(dblResult.ToString("R"), NumberStyles.Any);
            };
        }
    }
}

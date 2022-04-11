using System;
using System.Globalization;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Operators
{
    internal class Division : Operator
    {
        public Division(int precedance)
            : base("/", precedance, 2, false)
        {
            _name2 = "Division";
           
            DecimalDecimalDecimal = (x, y) => {
                if (y == 0) {
                    throw new DivideByZeroException();
                }

                return x/y;
            };
        }
    }
}

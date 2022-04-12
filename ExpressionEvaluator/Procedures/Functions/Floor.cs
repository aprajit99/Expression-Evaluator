using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class Floor : Function
    {
        public Floor(int precedance)
            : base("floor", precedance, 2, true)
        {
            _name2 = "Floor";
            Category = "Mathematical Function";
            Description = "Return the largest integer, which is less than or equal to the passed argument";
            DecimalDecimalOperandList = x => {
                if (x.Count > 2)
                    throw new ExpressionException("Floor only takes one or two paramters.");
                decimal op1 = x[0];
                decimal op2 = 0;
                if (x.Count == 2)
                    op2 = x[1];
                decimal offset = (decimal)Math.Pow(10, (int)op2);
                return Math.Floor(op1 * offset) / offset;
            };
        }
    }
}

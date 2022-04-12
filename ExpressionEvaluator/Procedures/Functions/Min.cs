using System.Linq;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class Min : Function
    {
        public Min(int precedance)
            : base("min", precedance, 1, true)
        {
            _name2 = "Min";
            Category = "Mathematical Function";
            Description = "Returns the minimum of the specified numbers";
            DecimalDecimalOperandList = x => x.Min();
        }
    }
}

using System.Linq;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class Max : Function
    {
        public Max(int precedance)
            : base("max", precedance, 1, true)
        {
            _name2 = "Max";
            Category = "Mathematical Function";
            Description = "Returns the larger of the specified numbers.";
            DecimalDecimalOperandList = x => x.Max();
        }
    }
}

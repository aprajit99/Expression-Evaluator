using System.Linq;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class Avg : Function
    {
        public Avg(int precedance)
            : base("avg", precedance, 1, true)
        {
            _name2 = "Avg";
            Category = "Mathematical Function";
            Description = "Calculates the average of the values.";
            DecimalDecimalOperandList = x => x.Average();
        }
    }
}

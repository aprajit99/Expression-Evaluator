using System.Linq;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class Concatenate : Function
    {
        public Concatenate(int precedance)
            : base("concatenate", precedance, 1, true)
        {
            _name2 = "Concatenate";
            Category = "String";
            Description = "Appending one string to the end of another string";
            ObjectStringOperandList = x => x.Aggregate("", (current, i) => current + i);
        }
    }
}

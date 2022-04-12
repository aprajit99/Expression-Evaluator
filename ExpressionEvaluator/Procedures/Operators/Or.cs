using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Operators
{
    internal class Or : Operator
    {
        public Or(int precedance)
            : base("||", precedance, 2, false)
        {
            _name2 = "Or";
            Category = "Logical";
            Description = "Check if at least one of the operand is true.";
            BoolBoolBool = (x, y) => x || y;
        }
    }
}

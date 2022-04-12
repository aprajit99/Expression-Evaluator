using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Operators
{
    internal class And : Operator
    {
        public And(int precedance)
            : base("&&", precedance, 2, false)
        {
            _name2 = "And";
            Category = "Logical";
            Description = "Check if at least one of the operand is true.";
            BoolBoolBool = (x, y) => x && y;
        }
    }
}

using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class Length : Function
    {
        public Length(int precedance)
            : base("length", precedance, 1, false)
        {
            _name2 = "Length";
            Category = "String";
            Description = "Returns the length of given string.";
            StringDecimal = x => x.Length;
        }
    }
}

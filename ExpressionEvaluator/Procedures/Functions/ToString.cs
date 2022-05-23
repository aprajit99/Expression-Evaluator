using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class ToString : Function
    {
        public ToString(int precedance)
            : base("tostring", precedance, 1, false)
        {
            _name2 = "ToString";
            Category = "String";
            Description = "Returns the string equivalent of the given number.";
            DecimalString = x => x.ToString();
            DateTimeString = x => x.ToString();
            BoolString = x => x.ToString();
            StringString = x => x;
            AnyString = x => x == null ? "null" : x.ToString();
        }
    }
}

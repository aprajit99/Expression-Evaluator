using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class Contains : Function
    {
        public Contains(int precedance)
            : base("contains", precedance, 2, false)
        {
            _name2 = "Contains";
            Category = "String";
            Description = "Checks if the string contains the given substring.";
            StringStringBool = (x, y) => x.ToLower()
                .Contains(y.ToLower());
        }
    }
}

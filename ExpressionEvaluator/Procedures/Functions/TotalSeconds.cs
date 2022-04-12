using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class TotalSeconds : Function
    {
        public TotalSeconds(int precedance)
            : base("totalseconds", precedance, 1, false)
        {
            _name2 = "TotalSeconds";
            Category = "Date/Time";
            TimespanDecimal = x => (decimal)x.TotalSeconds;
        }
    }
}

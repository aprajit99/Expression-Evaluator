using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class TotalMinutes : Function
    {
        public TotalMinutes(int precedance)
            : base("totalminutes", precedance, 1, false)
        {
            _name2 = "TotalMinutes";
            Category = "Date/Time";
            Description = "Returns the total no. of minutes between two given timestamps.";
            TimespanDecimal = x => (decimal)x.TotalMinutes;
        }
    }
}

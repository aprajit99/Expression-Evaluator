using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class TotalDays : Function
    {
        public TotalDays(int precedance)
            : base("totaldays", precedance, 1, false)
        {
            _name2 = "TotalDays";
            Category = "Date/Time";
            Description = "Returns the total no. of days between two given timestamps.";
            TimespanDecimal = x => (decimal)x.TotalDays;
        }
    }
}

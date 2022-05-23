using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class TotalHours : Function
    {
        public TotalHours(int precedance)
            : base("totalhours", precedance, 1, false)
        {
            _name2 = "TotalHours";
            Category = "Date/Time";
            Description = "Returns the total no. of hours between two given timestamps.";
            TimespanDecimal = x => (decimal)x.TotalHours;
        }
    }
}

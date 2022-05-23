using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class HoursComponent : Function
    {
        public HoursComponent(int precedance)
            : base("hourscomponent", precedance, 1, false)
        {
            _name2 = "HoursComponent";
            Category = "Date/Time";
            Description = "Returns the no. of hours between two given times.";
            TimespanDecimal = x => (decimal)x.Hours;
        }
    }
}
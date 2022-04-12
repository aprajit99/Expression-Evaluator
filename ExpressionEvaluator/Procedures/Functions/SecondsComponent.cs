using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class SecondsComponent : Function
    {
        public SecondsComponent(int precedance)
            : base("secondscomponent", precedance, 1, false)
        {
            _name2 = "SecondsComponent";
            Category = "Date/Time";
            Description = "Returns the no. of seconds between two given dates";
            TimespanDecimal = x => (decimal)x.Seconds;
        }
    }
}

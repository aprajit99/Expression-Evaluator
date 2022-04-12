using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class MinutesComponent : Function
    {
        public MinutesComponent(int precedance)
            : base("minutescomponent", precedance, 1, false)
        {
            _name2 = "MinutesComponent";
            Category = "Date/Time";
            Description = "Returns the no. of minutes between two given dates";
            TimespanDecimal = x => (decimal)x.Minutes;
        }
    }
}
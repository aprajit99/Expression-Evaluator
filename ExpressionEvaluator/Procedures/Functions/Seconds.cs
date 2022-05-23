using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class Seconds : Function
    {
        public Seconds(int precedance)
            : base("seconds", precedance, 1, false)
        {
            _name2 = "Seconds";
            Category = "Date/Time";
            Description = "Given the seconds as input, returns the seconds in DD:HH:MM:SS format.";
            DecimalTimespan = x => new TimeSpan((long)(x * TimeSpan.TicksPerSecond));
        }
    }
}

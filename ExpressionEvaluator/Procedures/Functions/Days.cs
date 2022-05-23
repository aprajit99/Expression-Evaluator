using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class Days : Function
    {
        public Days(int precedance)
            : base("days", precedance, 1, false)
        {
            _name2 = "Days";
            Category = "Date/Time";
            Description = "Given the days as input, returns the days in DD:HH:MM:SS format.";
            DecimalTimespan = x => new TimeSpan((long)(x * TimeSpan.TicksPerDay));
        }
    }
}

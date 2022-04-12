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
            DecimalTimespan = x => new TimeSpan((long)(x * TimeSpan.TicksPerSecond));
        }
    }
}

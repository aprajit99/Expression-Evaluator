using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class Now : Function
    {
        public Now(int precedance)
            : base("now", precedance, 0, false)
        {
            _name2 = "Now";
            Category = "Date/Time";
            Datetime = () => DateTime.Now;
        }
    }
}

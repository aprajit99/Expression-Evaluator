using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionEvaluatorUi.Model
{
    public interface IVariable
    {
        string Name { get; set; }
        string Type { get; set; }
        string Description { get; set; }
        object Value { get; set; }
    }
}

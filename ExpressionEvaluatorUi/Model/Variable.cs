﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionEvaluatorUi.Model
{
    public class Variable:IVariable
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public object Value { get; set; }
    }
}

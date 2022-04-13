using ExpressionEvaluatorUi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using exp = Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorUi.ViewModels.Helpers
{
    public class ListViewHelper
    {
        public static List<Operator> getOperatorList()
        {
            List<Operator> operators = new List<Operator>();
            var _operators = from t in exp.ExpressionKeywords.Keywords.OfType<exp.Operator>()
                             select t;
            foreach(var opr in _operators)
            {
                var new_operator = new Operator()
                {
                    Category = opr.Category,
                    Type=opr.Name,
                    Description=opr.Description
                };
                operators.Add(new_operator);
            }
            var _functions = from t in exp.ExpressionKeywords.Keywords.OfType<exp.Function>()
                             select t;
            foreach (var func in _functions)
            {
                var new_operator = new Operator()
                {
                    Category = func.Category,
                    Type = func.Name,
                    Description = func.Description
                };
                operators.Add(new_operator);
            }
            return operators;
        }
        public static List<string> getVariableTypeList()
        {
            List<string> VariableTypes = new List<string>() {"int","float","double","char","string","bool","object","DateTime","TimeSpan" };
            return VariableTypes;
        }
        public static List<string> getOutputTypeList()
        {
            List<string> OutputTypes = new List<string>() {"numeric","string","boolean","DateTime","TimeSpan" };
            return OutputTypes;
        }
    }
}

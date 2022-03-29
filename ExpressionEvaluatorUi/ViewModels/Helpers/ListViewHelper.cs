using ExpressionEvaluatorUi.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionEvaluatorUi.ViewModels.Helpers
{
    public class ListViewHelper
    {
        public static List<Operator> getOperatorList()
        {
            List<Operator> operators = new List<Operator>();
            operators.Add(new Operator()
            {
                Category = "Arithmetic",
                Type = "+",
                Description = "Used to add two operands."

            });
            operators.Add(new Operator()
            {
                Category = "Arithmetic",
                Type = "-",
                Description = "Used to subtract two operands."

            });
            operators.Add(new Operator()
            {
                Category = "Relational",
                Type = "==",
                Description = "Used to check if both operands are equal."

            });

            operators.Add(new Operator()
            {
                Category = "Relational",
                Type = "!=",
                Description = "Can check if both operands are not equal."

            });

            operators.Add(new Operator()
            {
                Category = "Logical",
                Type = "&&",
                Description = "Used to check if both the operands are true."

            });
            operators.Add(new Operator()
            {
                Category = "Logical",
                Type = "||",
                Description = "Used to check if at least one of the operand is true."

            });

            return operators;
        }
        public static List<Variable> getVariableList()
        {
            List<Variable> variables = new List<Variable>();
            variables.Add(new Variable()
            {
                Name = "Variable1Name",
                Type = "Variable1Type",
                Description = "Variable1Description"


            });
            variables.Add(new Variable()
            {
                Name = "Variable2Name",
                Type = "Variable2Type",
                Description = "Variable2Description"


            });
            variables.Add(new Variable()
            {
                Name = "Variable3Name",
                Type = "Variable3Type",
                Description = "Variable3Description"


            });
            variables.Add(new Variable()
            {
                Name = "Variable4Name",
                Type = "Variable4Type",
                Description = "Variable4Description"


            });
            return variables;
        }
        public static List<string> getVariableTypeList()
        {
            List<string> VariableTypes = new List<string>() {"int","float","double","char","string","bool","object" };
            return VariableTypes;
        }
        public static List<string> getOutputTypeList()
        {
            List<string> OutputTypes = new List<string>() {"numeric","string","boolean" };
            return OutputTypes;
        }
    }
}

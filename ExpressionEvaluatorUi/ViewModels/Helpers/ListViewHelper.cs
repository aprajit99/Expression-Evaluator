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
            
            //Type[] types= Assembly.GetExecutingAssembly().GetTypes().Where(t => String.Equals(t.Namespace, "ExpressionEvaluator.Procedures.Operators", StringComparison.Ordinal)).ToArray();
            //foreach (var type in types)
            //{
            //    Console.WriteLine(type.Name);
            //}
            List<Operator> operators = new List<Operator>();
            operators.Add(new Operator()
            {
                Category = "Arithmetic",
                Type = "+",
                Description = "Add two operands."

            });
            operators.Add(new Operator()
            {
                Category = "Arithmetic",
                Type = "-",
                Description = "Subtract two operands."

            });
            operators.Add(new Operator()
            {
                Category = "Arithmetic",
                Type = "*",
                Description = "Multiply two operands."

            });
            operators.Add(new Operator()
            {
                Category = "Arithmetic",
                Type = "/",
                Description = "Divide two operands and gives the quotient as the answer."

            });
            operators.Add(new Operator()
            {
                Category = "Arithmetic",
                Type = "%",
                Description = " Find the remains of two integers and gives the remainder after the division."

            });


            operators.Add(new Operator()
            {
                Category = "Relational",
                Type = "==",
                Description = "Check if both operands are equal."

            });

            operators.Add(new Operator()
            {
                Category = "Relational",
                Type = "!=",
                Description = "Check if both operands are not equal."

            });
            operators.Add(new Operator()
            {
                Category = "Relational",
                Type = ">",
                Description = "Check if the first operand is greater than the second."

            });
            operators.Add(new Operator()
            {
                Category = "Relational",
                Type = "<",
                Description = "Check if the first operand is lesser than the second."

            });
            operators.Add(new Operator()
            {
                Category = "Relational",
                Type = ">=",
                Description = "Check if the first operand is greater than or equal to the second."

            });
            operators.Add(new Operator()
            {
                Category = "Relational",
                Type = "<=",
                Description = "Check if the first operand is lesser than or equal to the second."

            });

            operators.Add(new Operator()
            {
                Category = "Logical",
                Type = "&&",
                Description = "Check if both the operands are true."

            });
            operators.Add(new Operator()
            {
                Category = "Logical",
                Type = "||",
                Description = "Check if at least one of the operand is true."

            });
            operators.Add(new Operator()
            {
                Category = "Logical",
                Type = "!",
                Description = "Check if the operand is false"

            });

            return operators;
        }
        //public Type[] GetOperators()
        //{
            
        //    return Assembly.GetExecutingAssembly().GetTypes().Where(t => String.Equals(t.Namespace, "ExpressionEvaluator.Procedures.Operators", StringComparison.Ordinal)).ToArray();
        //}
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

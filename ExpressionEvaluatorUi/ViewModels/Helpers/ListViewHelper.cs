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
        public static List<Step> getStepList()
        {
            List<Step> steps = new List<Step>();
            steps.Add(new Step()
            {
                Name = "Step1Name",
                Type = "Step1Type",
                Description = "Step1Description"


            });
            steps.Add(new Step()
            {
                Name = "Step2Name",
                Type = "Step2Type",
                Description = "Step2Description"


            });
            steps.Add(new Step()
            {
                Name = "Step3Name",
                Type = "Step3Type",
                Description = "Step3Description"


            });
            steps.Add(new Step()
            {
                Name = "Step4Name",
                Type = "Step4Type",
                Description = "Step4Description"


            });
            return steps;
        }
    }
}

using ExpressionEvaluatorUi.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using NSwag.Collections;

namespace ExpressionEvaluatorUi.ViewModels.Helpers
{
    public class FormulaEditorHelper : IFormulaEditorHelper
    {
        public Action AddVariable_CloseWindow { get; set; }
        public Action EditVariable_CloseWindow { get; set; }
        public ObservableDictionary<string,Variable> Variables { get; set; }
        public Variable SelectedVariableTemp { get; set; }
        public bool InputNull { get; set; }
        public List<string> GetVariableTypeList()
        {
            List<string> VariableTypes = new List<string>() { "int", "float", "double", "char", "string", "bool", "object", "DateTime", "TimeSpan" };
            return VariableTypes;
        }
        public FormulaEditorHelper() 
        {
            Variables = new ObservableDictionary<string, Variable>();
        }
        private static FormulaEditorHelper instance = null;
        public static FormulaEditorHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormulaEditorHelper();
                }
                return instance;
            }
        }
    }
}

using ExpressionEvaluatorUi.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ExpressionEvaluatorUi.ViewModels.Helpers
{
    public class FormulaEditorHelper : IFormulaEditorHelper
    {
        public ObservableCollection<Variable> Variables { get; set; }
        public Variable SelectedVariableTemp { get; set; }
        public bool InputNull { get; set; }
        public Action AddVariable_CloseWindow { get; set; }
        public Action EditVariable_CloseWindow { get; set; }
        public List<string> GetVariableTypeList()
        {
            List<string> VariableTypes = new List<string>() { "int", "float", "double", "char", "string", "bool", "object", "DateTime", "TimeSpan" };
            return VariableTypes;
        }
        public FormulaEditorHelper() 
        {
            Variables = new ObservableCollection<Variable>();
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

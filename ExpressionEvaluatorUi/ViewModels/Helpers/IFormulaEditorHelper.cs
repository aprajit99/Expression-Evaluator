using ExpressionEvaluatorUi.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ExpressionEvaluatorUi.ViewModels.Helpers
{
    public interface IFormulaEditorHelper
    {
        public ObservableCollection<Variable> Variables { get; set; }
        public Variable SelectedVariableTemp { get; set; }
        public bool InputNull { get; set; }
        public Action AddVariable_CloseWindow { get; set; }
        public Action EditVariable_CloseWindow { get; set; }
        public List<string> GetVariableTypeList();
    }
}

using ExpressionEvaluatorUi.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ExpressionEvaluatorUi.ViewModels.Helpers
{
    public interface IFormulaEditorHelper
    {
        public Action AddEditVariable_CloseWindow { get; set; }
        public ObservableCollection<IVariable> Variables { get; set; }
        public Variable SelectedVariable_Copy { get; set; }
        public bool InputNull { get; set; }
        public BaseViewModel SelectedViewModel { get; set; }
        public List<string> GetVariableTypeList();
    }
}

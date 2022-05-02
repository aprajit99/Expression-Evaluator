using ExpressionEvaluatorUi.Model;
using ExpressionEvaluatorUi.ViewModels.Commands;
using ExpressionEvaluatorUi.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace ExpressionEvaluatorUi.ViewModels
{
    public class VariableInputViewModel : BaseViewModel
    {
        private string variableName;
        private object variableInput;
        private bool nullInput;
        public VariableInputViewModel()
        {
            NullInput = true;
            ClearVariableCommand = new RelayCommand((object parameter)=> { VariableInput = null; }, (object parameter)=> { return !string.IsNullOrEmpty((string)parameter); });
        }
        public RelayCommand ClearVariableCommand { get; set; }
        public string VariableName
        {
            get { return variableName; }
            set
            {
                variableName = value;
                OnPropertyChanged(nameof(VariableName));
            }
        }
        public object VariableInput
        {
            get { return variableInput; }
            set
            {
                variableInput = value;
                OnPropertyChanged(nameof(VariableInput));
                Variable var = (Variable)FormulaEditorHelper.Instance.Variables.FirstOrDefault(v => v.Name == VariableName);
                if (var != null)
                {
                    var.Value = variableInput;
                }
                NullInput = VariableInput == null;

                if (VariableInput == null || (VariableInput.ToString()).Length==0)
                {
                    FormulaEditorHelper.Instance.InputNull = true;
                }
            }
        }
        public bool NullInput
        {
            get { return nullInput; }
            set 
            { 
                nullInput = value;
                OnPropertyChanged(nameof(NullInput));
            }
        }
    }
}

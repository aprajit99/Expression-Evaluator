using ExpressionEvaluatorUi.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace ExpressionEvaluatorUi.ViewModels
{
    public class VariableInputViewModel : INotifyPropertyChanged
    {
        public ClearVariableCommand ClearVariableCommand { get; set; }
        private string variableName;

        public string VariableName
        {
            get { return variableName; }
            set
            {
                variableName = value;
                OnPropertyChanged(nameof(VariableName));
            }
        }
        private object variableInput;

        public object VariableInput
        {
            get { return variableInput; }
            set
            {
                variableInput = value;
                OnPropertyChanged(nameof(VariableInput));
                foreach(var variable in FormulaEditorViewModel.Variables)
                {
                    if (variable.Name == VariableName)
                    {
                        variable.Value = VariableInput;
                        break;
                    }
                }
                if(VariableInput==null || string.IsNullOrEmpty(VariableInput.ToString()))
                {
                    FormulaEditorViewModel.FormulaEditorVM.InputNull = true;
                }

            }
        }
        public VariableInputViewModel()
        {
            ClearVariableCommand = new ClearVariableCommand(this);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

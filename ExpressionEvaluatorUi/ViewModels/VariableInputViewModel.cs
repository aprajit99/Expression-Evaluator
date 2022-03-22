using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace ExpressionEvaluatorUi.ViewModels
{
    public class VariableInputViewModel : INotifyPropertyChanged
    {
        private string variableName;

        public string VariableName
        {
            get { return variableName; }
            set
            {
                variableName = value;
                OnPropertyChanged("VariableName");
            }
        }
        private object variableInput;

        public object VariableInput
        {
            get { return variableInput; }
            set
            {
                variableInput = value;
                OnPropertyChanged("VariableInput");
                foreach(var variable in FormulaEditorViewModel.Variables)
                {
                    if (variable.Name == VariableName)
                    {
                        variable.Value = VariableInput;
                        break;
                    }
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

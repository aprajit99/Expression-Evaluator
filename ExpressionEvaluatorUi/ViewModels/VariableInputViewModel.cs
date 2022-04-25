using ExpressionEvaluatorUi.ViewModels.Commands;
using ExpressionEvaluatorUi.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace ExpressionEvaluatorUi.ViewModels
{
    public class VariableInputViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string variableName;
        private object variableInput;
        private bool nullInput;
        public VariableInputViewModel()
        {
            NullInput = true;
            ClearVariableCommand = new ClearVariableCommand(this);
        }
        public ClearVariableCommand ClearVariableCommand { get; set; }
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
                if (FormulaEditorHelper.Instance.Variables.ContainsKey(VariableName))
                {
                    FormulaEditorHelper.Instance.Variables[VariableName].Value = variableInput;
                }
                if (VariableInput == null)
                    NullInput = true;
                else
                    NullInput = false;

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
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

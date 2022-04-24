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
                //foreach(var variable in FormulaEditorHelper.Instance.Variables)
                //{
                //    if (variable.Name == VariableName)
                //    {
                //        variable.Value = VariableInput;
                //        break;
                //    }
                //}
                if (FormulaEditorHelper.Instance.Variables.ContainsKey(VariableName))
                {
                    FormulaEditorHelper.Instance.Variables[VariableName].Value = variableInput;
                }
                if (VariableInput == null)
                    NullInput = true;
                else
                    NullInput = false;

                //if(VariableInput==null || string.IsNullOrEmpty(VariableInput.ToString()))
                if (VariableInput == null || (VariableInput.ToString()).Length==0)
                {
                    //FormulaEditorViewModel.FormulaEditorVM.InputNull = true;
                    FormulaEditorHelper.Instance.InputNull = true;
                }

            }
        }
        private bool nullInput;

        public bool NullInput
        {
            get { return nullInput; }
            set 
            { 
                nullInput = value;
                OnPropertyChanged(nameof(NullInput));
            }
        }

        public VariableInputViewModel()
        {
            NullInput = true;
            ClearVariableCommand = new ClearVariableCommand(this);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ExpressionEvaluatorUi.ViewModels.Commands
{
    public class ClearVariableCommand : ICommand
    {
        public VariableInputViewModel _variableInputViewModel;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public ClearVariableCommand(VariableInputViewModel variableInputViewModel)
        {
            _variableInputViewModel = variableInputViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty((string)parameter);
        }
        public void Execute(object parameter)
        {
            _variableInputViewModel.VariableInput = null;
        }
    }
}

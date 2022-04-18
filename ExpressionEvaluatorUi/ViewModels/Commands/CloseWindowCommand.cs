using ExpressionEvaluatorUi.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ExpressionEvaluatorUi.ViewModels.Commands
{
    public class CloseWindowCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //AddVariableViewModel.CloseWindow?.Invoke();
            //EditVariableViewModel.CloseWindow?.Invoke();

            FormulaEditorHelper.Instance.AddVariable_CloseWindow?.Invoke();
            FormulaEditorHelper.Instance.EditVariable_CloseWindow?.Invoke();
        }
    }
}

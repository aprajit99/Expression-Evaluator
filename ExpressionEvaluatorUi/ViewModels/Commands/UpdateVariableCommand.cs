using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ExpressionEvaluatorUi.ViewModels.Commands
{
    public class UpdateVariableCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public EditVariableViewModel EditVariableViewModel { get; set; }
        public UpdateVariableCommand(EditVariableViewModel editVariableViewModel)
        {
            EditVariableViewModel = editVariableViewModel;
        }

        public bool CanExecute(object parameter)
        {
            bool IsChanged = (bool)parameter;
            return IsChanged;
        }

        public void Execute(object parameter)
        {
            EditVariableViewModel.CreateUpdatedVariable();
        }
    }
}

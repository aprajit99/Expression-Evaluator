using ExpressionEvaluatorUi.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ExpressionEvaluatorUi.ViewModels.Commands
{
    public class SaveNewVariableCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public AddVariableViewModel AddVariableViewModel;
        public SaveNewVariableCommand(AddVariableViewModel addVariableViewModel)
        {
            AddVariableViewModel = addVariableViewModel;
        }

        public bool CanExecute(object parameter)
        {
            bool test = (bool)parameter;
            if (test == true)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public void Execute(object parameter)
        {

            AddVariableViewModel.CreateNewVariable();
        }
    }
}

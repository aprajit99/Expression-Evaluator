using ExpressionEvaluatorUi.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ExpressionEvaluatorUi.ViewModels.Commands
{
    public class AddVariableCommand : ICommand
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
            AddVariableView addVariableView = new AddVariableView();
            addVariableView.ShowDialog();
        }
    }
}

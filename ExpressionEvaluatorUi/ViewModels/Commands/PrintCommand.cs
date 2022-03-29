using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ExpressionEvaluatorUi.ViewModels.Commands
{
    public class PrintCommand : ICommand
    {
        public FormulaEditorViewModel _formulaEditorViewModel;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public PrintCommand(FormulaEditorViewModel formulaEditorViewModel)
        {
            _formulaEditorViewModel = formulaEditorViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty((string)parameter);
        }

        public void Execute(object parameter)
        {
            Clipboard.SetText(_formulaEditorViewModel.TestOutput);
            MessageBox.Show("Result copied to clipboard!", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

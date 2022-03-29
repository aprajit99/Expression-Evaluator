using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ExpressionEvaluatorUi.ViewModels.Commands
{
    public class RunTestCommand : ICommand
    {
        public FormulaEditorViewModel _formulaEditorViewModel;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public RunTestCommand(FormulaEditorViewModel formulaEditorViewModel)
        {
            _formulaEditorViewModel = formulaEditorViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return (bool)parameter;
        }

        public void Execute(object parameter)
        {
            _formulaEditorViewModel.RunTest();
        }
    }
}

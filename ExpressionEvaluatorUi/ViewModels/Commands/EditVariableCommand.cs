using ExpressionEvaluatorUi.Model;
using ExpressionEvaluatorUi.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ExpressionEvaluatorUi.ViewModels.Commands
{
    public class EditVariableCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        
        public FormulaEditorViewModel formulaEditorVM { get; set; }
        public bool CanExecute(object parameter)
        {
            bool test = (bool)parameter;
            return test;
            
            //return true;
        }
        public EditVariableCommand(FormulaEditorViewModel formulaEditorViewModel)
        {  
            formulaEditorVM = formulaEditorViewModel;
        }
        public void Execute(object parameter)
        {
            EditVariableView editVariableView = new EditVariableView();
            ((EditVariableViewModel)editVariableView.DataContext).FormulaEditorVM = formulaEditorVM;
            ((EditVariableViewModel)editVariableView.DataContext).LoadVariableDetails();
            editVariableView.ShowDialog();
            editVariableView.Close();
        }
    }
}

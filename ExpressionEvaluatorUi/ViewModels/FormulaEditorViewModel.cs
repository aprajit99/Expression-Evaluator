using ExpressionEvaluatorUi.Model;
using ExpressionEvaluatorUi.View;
using ExpressionEvaluatorUi.ViewModels.Commands;
using ExpressionEvaluatorUi.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Data;

namespace ExpressionEvaluatorUi.ViewModels
{
    public class FormulaEditorViewModel:INotifyPropertyChanged
    {
        private string formula;

        public string Formula
        {
            get { return formula; }
            set
            {
                formula = value;
                OnPropertyChanged("Formula");
            }
        }

        private Variable selectedVariable;

        public Variable SelectedVariable
        {
            get { return selectedVariable; }
            set
            {
                selectedVariable = value;
                OnPropertyChanged("SelectedVariable");
                if (SelectedVariable != null)
                {
                    bool isPresent = false;
                    foreach (var variable in VariableInputViewModels)
                    {
                        if (variable.VariableName == SelectedVariable.Name)
                        {
                            isPresent = true;
                            break;
                        }
                    }
                    if (!isPresent)
                    {
                        VariableInputViewModels.Add(new VariableInputViewModel()
                        {
                            VariableName = SelectedVariable.Name
                        });
                    }
                    AddVariableToFormula();
                }
                
            }
        }

        private Operator selectedOperator;

        public Operator SelectedOperator
        {
            get { return selectedOperator; }
            set
            {
                selectedOperator = value;
                OnPropertyChanged("SelectedOperator");
                if (SelectedOperator != null)
                {
                    AddOperatorToFormula();
                }
            }
        }



        public static ObservableCollection<Variable> Variables { get; set; }

        public ListCollectionView operatorcollectionView { get; set; }
        
        public AddVariableCommand AddVariableCommand { get; set; }

        public ObservableCollection<VariableInputViewModel> VariableInputViewModels { get; set; }



        public FormulaEditorViewModel()
        {
            Variables = new ObservableCollection<Variable>();
            VariableInputViewModels = new ObservableCollection<VariableInputViewModel>();
            LoadOperators();
            AddVariableCommand = new AddVariableCommand();

        }
        public static void AddNewVariableToList(Variable Variable)
        {
            Variables.Add(Variable);
        }
 
        private void AddVariableToFormula()
        {
            Formula = Formula + SelectedVariable.Name.ToString();
            SelectedVariable = null;
        }
        private void LoadOperators()
        {

            List<Operator> operatorlist = ListViewHelper.getOperatorList();
            operatorcollectionView = new ListCollectionView(operatorlist);
            operatorcollectionView.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
        }
        private void AddOperatorToFormula()
        {
            Formula = Formula + SelectedOperator.Type.ToString();
            selectedOperator = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

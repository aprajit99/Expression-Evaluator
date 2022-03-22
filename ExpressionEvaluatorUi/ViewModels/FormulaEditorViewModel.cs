using ExpressionEvaluatorUi.Model;
using ExpressionEvaluatorUi.View;
using ExpressionEvaluatorUi.ViewModels.Commands;
using ExpressionEvaluatorUi.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace ExpressionEvaluatorUi.ViewModels
{
    public class FormulaEditorViewModel:INotifyPropertyChanged
    {
        //TODO: make a property for the same
        public static Variable selectedVariableTemp;

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set 
            { 
                isSelected = value;
                OnPropertyChanged("IsSelected");
               // OnPropertyChanged(nameof(IsSelected));
            }
        }




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
                IsSelected = true;
                
                
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
        public EditVariableCommand EditVariableCommand { get; set; }
        

        public static ObservableCollection<VariableInputViewModel> VariableInputViewModels { get; set; }



        public FormulaEditorViewModel()
        {
            Variables = new ObservableCollection<Variable>();
            VariableInputViewModels = new ObservableCollection<VariableInputViewModel>();
            LoadOperators();
            AddVariableCommand = new AddVariableCommand();
            EditVariableCommand = new EditVariableCommand(this);
            
        }
        public static void AddNewVariableToList(Variable Variable)
        {
            Variables.Add(Variable);
            
        }
        public static void UpdateVariable(Variable NewVariable)
        {
            
            foreach (var variable in VariableInputViewModels)
            {
                if (variable.VariableName == selectedVariableTemp.Name)
                {
                    
                    NewVariable.Value = variable.VariableInput;
                    VariableInputViewModels.Remove(variable);
                    VariableInputViewModels.Add(new VariableInputViewModel()
                    {
                        VariableName = NewVariable.Name,
                        VariableInput = NewVariable.Value
                    });
                    break;
                }
            }
            
            foreach (var Variable in Variables)
            {
                if (Variable.Name == selectedVariableTemp.Name)
                {
                     
                    Variables.Remove(Variable);
                    Variables.Add(NewVariable);
                    break;
                }
            }
             
            
        }

        private void AddVariableToFormula()
        {
            Formula += SelectedVariable.Name.ToString();
            selectedVariableTemp = SelectedVariable;
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
            Formula += SelectedOperator.Type.ToString();
            selectedOperator = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

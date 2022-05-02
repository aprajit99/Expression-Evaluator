﻿using ExpressionEvaluatorUi.Model;
using ExpressionEvaluatorUi.View;
using ExpressionEvaluatorUi.ViewModels.Commands;
using ExpressionEvaluatorUi.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using exp=Vanderbilt.Biostatistics.Wfccm2;
using ExpressionEvaluator.Procedures.Operators;

namespace ExpressionEvaluatorUi.ViewModels
{
    public class FormulaEditorViewModel: BaseViewModel
    {
        private Variable selectedVariable;
        private Operator selectedOperator;
        private string formula;
        private string testOutput;
        private string selectedOutputType;
        private bool canValidate;
        private bool isSelected;
        private bool canRunTest;
        public List<string> UsedVariables;
        public ListViewHelper ListViewHelper;
        public exp.Expression _func;
        public FormulaEditorViewModel()
        {
            VariableInputViewModels = new ObservableCollection<VariableInputViewModel>();
            OutputTypes = new ObservableCollection<string>();
            UsedVariables = new List<string>();
            ListViewHelper = new ListViewHelper();
            AddVariableCommand = new RelayCommand(AddVariableExecute);
            EditVariableCommand = new RelayCommand(EditVariableExecute, (object parameter) =>{ return (bool)parameter; });
            ValidateFormulaCommand = new RelayCommand((object parameter)=>ValidateForumla(), (object parameter) => { return (bool)parameter; });
            RunTestCommand = new RelayCommand((object parameter) => RunTest(), (object parameter) => { return (bool)parameter; });
            PrintCommand = new RelayCommand(PrintExecute, (object parameter) => { return !string.IsNullOrEmpty((string)parameter); });
            Variable_Selected += AddVariable;
            Operator_Selected += AddOperator;
            LoadOperators();
            LoadOutputTypes();
        }
        public ObservableCollection<VariableInputViewModel> VariableInputViewModels { get; set; }
        public ObservableCollection<string> OutputTypes { get; set; }
        public ListCollectionView OperatorcollectionView { get; set; }
        public RelayCommand AddVariableCommand { get; set; }
        public RelayCommand EditVariableCommand { get; set; }
        public RelayCommand ValidateFormulaCommand { get; set; }
        public RelayCommand RunTestCommand { get; set; }
        public RelayCommand PrintCommand { get; set; }
        public Action Variable_Selected { get; set; }
        public Action Operator_Selected { get; set; }
        public bool IsSelected
        {
            get { return isSelected; }
            set 
            { 
                isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }
        public bool CanValidate
        {
            get { return canValidate; }
            set 
            { 
                canValidate = value;
                OnPropertyChanged(nameof(CanValidate));
            }
        }
        public bool CanRunTest
        {
            get { return canRunTest; }
            set 
            { 
                canRunTest = value;
                OnPropertyChanged(nameof(CanRunTest));
            }
        }
        public string Formula
        {
            get { return formula; }
            set
            {
                formula = value;
                OnPropertyChanged(nameof(Formula));
                CanRunTest = false;
                TestOutput = null;
            }
        }  
        public string SelectedOutputType
        {
            get { return selectedOutputType; }
            set 
            {
                selectedOutputType = value;
                OnPropertyChanged(nameof(SelectedOutputType));
                CanValidate = true;               
            }
        }     
        public string TestOutput
        {
            get { return testOutput; }
            set 
            { 
                testOutput = value;
                OnPropertyChanged(nameof(TestOutput));
            }
        }
        public Variable SelectedVariable
        {
            get { return selectedVariable; }
            set
            {
                selectedVariable = value;
                OnPropertyChanged(nameof(SelectedVariable));
                Variable_Selected?.Invoke();
            }
        }
        public Operator SelectedOperator
        {
            get { return selectedOperator; }
            set
            {
                selectedOperator = value;
                OnPropertyChanged(nameof(SelectedOperator));
                Operator_Selected?.Invoke();
            }
        }
        private void AddVariableToFormula()
        {
            Formula += SelectedVariable.Name.ToString();
            FormulaEditorHelper.Instance.SelectedVariable_Copy = SelectedVariable;
            SelectedVariable = null;
        }
        private void LoadOperators()
        {
            List<Operator> operatorlist = ListViewHelper.GetOperatorList();
            OperatorcollectionView = new ListCollectionView(operatorlist);
            OperatorcollectionView.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
        }
        private void LoadOutputTypes()
        {
            List<string> outputlist = ListViewHelper.GetOutputTypeList();
            foreach (string type in outputlist)
            {
                OutputTypes.Add(type);
            }
        }
        private void AddOperatorToFormula()
        {
            Formula += SelectedOperator.Type.ToString();
            selectedOperator = null;
        }
        private void AddVariable()
        {
            IsSelected = true;
            if (SelectedVariable != null)
            {
                if (!UsedVariables.Contains(SelectedVariable.Name))
                {
                    VariableInputViewModels.Add(new VariableInputViewModel()
                    {
                        VariableName = SelectedVariable.Name
                    });
                    UsedVariables.Add(SelectedVariable.Name);
                }
                AddVariableToFormula();
            }
        }
        private void AddOperator()
        {
            if (SelectedOperator != null)
            {
                AddOperatorToFormula();
            }
        }
        public void AddVariableExecute(object parameter)
        {
            FormulaEditorHelper.Instance.SelectedViewModel = new AddVariableViewModel();
            AddEditVariableView addEditVariableView = new AddEditVariableView();
            addEditVariableView.ShowDialog();
        }
        public void EditVariableExecute(object parameter)
        {
            FormulaEditorHelper.Instance.SelectedViewModel = new EditVariableViewModel();
            AddEditVariableView addEditVariableView = new AddEditVariableView();
            ((EditVariableViewModel)addEditVariableView.DataContext).FormulaEditorVM = this;
            ((EditVariableViewModel)addEditVariableView.DataContext).LoadVariableDetails();
            addEditVariableView.ShowDialog();
        }
        public void PrintExecute(object parameter)
        {
            Clipboard.SetText(TestOutput);
            MessageBox.Show("Result copied to clipboard!", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public void UpdateVariable(Variable NewVariable)
        {
            string Name = FormulaEditorHelper.Instance.SelectedVariable_Copy.Name;
            VariableInputViewModel _var = VariableInputViewModels.FirstOrDefault(v => v.VariableName == Name);
            if (_var!=null)
            {
                NewVariable.Value = _var.VariableInput;
                VariableInputViewModels.Remove(_var);
                UsedVariables.Remove(Name);
                VariableInputViewModels.Add(new VariableInputViewModel()
                {
                    VariableName = NewVariable.Name,
                    VariableInput = NewVariable.Value
                });
                UsedVariables.Add(NewVariable.Name);
            }
            Variable var = (Variable)FormulaEditorHelper.Instance.Variables.FirstOrDefault(v => v.Name == Name);
            if(var!=null)
            {
                FormulaEditorHelper.Instance.Variables.Remove(var);
                FormulaEditorHelper.Instance.Variables.Add(NewVariable);
            }
            IsSelected = false;
        } 
        public void ValidateForumla()
        {
            if (string.IsNullOrEmpty(Formula))
            {
                MessageBox.Show("Enter a formula", "Formula Error",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            try
            {
                _func = new exp.Expression("")
                {
                    Function = Formula
                };
                CanRunTest = true;
                MessageBox.Show("Formula is successfully validated.", "Validation Successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Formula Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            } 
        }
        public void RunTest()
        {
            if (FormulaEditorHelper.Instance.InputNull)
            {
                _func.Function = Formula;
                FormulaEditorHelper.Instance.InputNull = false;
            }
           
            StringBuilder msg = new StringBuilder("");
            foreach (var variable in FormulaEditorHelper.Instance.Variables)
            {  
                if (!UsedVariables.Contains(variable.Name))
                    continue;
                if (variable.Value == null)
                {
                    continue;
                }
                else if (variable.Value.ToString().Length == 0)
                {
                    if (variable.Type != "string")
                        continue;
                }

                try
                {
                    switch (variable.Type)
                    {
                        case "int":
                            variable.Value = Convert.ChangeType(variable.Value, typeof(int));
                            _func.AddSetVariable(variable.Name, (int)variable.Value);
                            break;
                        case "float":
                            variable.Value = Convert.ChangeType(variable.Value, typeof(float));
                            _func.AddSetVariable(variable.Name, (float)variable.Value);
                            break;
                        case "double":
                            variable.Value = Convert.ChangeType(variable.Value, typeof(double));
                            _func.AddSetVariable(variable.Name, (double)variable.Value);
                            break;
                        case "string":
                            variable.Value = Convert.ChangeType(variable.Value, typeof(string));
                            _func.AddSetVariable(variable.Name, (string)variable.Value);
                            break;
                        case "bool":
                            variable.Value = Convert.ChangeType(variable.Value, typeof(bool));
                            _func.AddSetVariable(variable.Name, (bool)variable.Value);
                            break;
                        case "DateTime":
                            variable.Value = Convert.ToDateTime(variable.Value);
                            _func.AddSetVariable(variable.Name, (DateTime)variable.Value);
                            break;
                        case "TimeSpan":
                            variable.Value = TimeSpan.Parse((string)variable.Value);
                            _func.AddSetVariable(variable.Name, (TimeSpan)variable.Value);
                            break;
                    }
                }
                catch (Exception e)
                {
                    msg.AppendLine($"Variable \"{variable.Name}\" : {e.Message}");
                }
            }
            if (msg.ToString().Length != 0)
            {
                MessageBox.Show(msg.ToString(), "Variable Input Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                if (SelectedOutputType == "numeric")
                {
                    TestOutput = _func.EvaluateNumeric().ToString();
                }
                else if (SelectedOutputType == "string")
                {
                    TestOutput = _func.Evaluate<string>();
                }
                else if (SelectedOutputType == "boolean")
                {
                    TestOutput = _func.EvaluateBoolean().ToString(); 
                }
                else if (SelectedOutputType == "DateTime")
                {
                    TestOutput = _func.Evaluate<DateTime>().ToString();
                }
                else if (SelectedOutputType == "TimeSpan")
                {
                    TestOutput = _func.Evaluate<TimeSpan>().ToString();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Output Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }   
    }
}

using ExpressionEvaluatorUi.Model;
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
using NSwag.Collections;

namespace ExpressionEvaluatorUi.ViewModels
{
    public class FormulaEditorViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Variable selectedVariable;
        private Operator selectedOperator;
        private string formula;
        private string testOutput;
        private string selectedOutputType;
        private bool canValidate;
        private bool isSelected;
        private bool canRunTest;
        public HashSet<string> UsedVariables;
        public ListViewHelper ListViewHelper;
        public exp.Expression _func;
        public FormulaEditorViewModel()
        {
            VariableInputViewModels = new ObservableDictionary<string, VariableInputViewModel>();
            OutputTypes = new ObservableCollection<string>();
            UsedVariables = new HashSet<string>();
            ListViewHelper = new ListViewHelper();
            AddVariableCommand = new AddVariableCommand();
            EditVariableCommand = new EditVariableCommand(this);
            ValidateFormulaCommand = new ValidateFormulaCommand(this);
            RunTestCommand = new RunTestCommand(this);
            PrintCommand = new PrintCommand(this);
            LoadOperators();
            LoadOutputTypes();
        }
        public ObservableDictionary<string, VariableInputViewModel> VariableInputViewModels { get; set; }
        public ObservableCollection<string> OutputTypes { get; set; }
        public ListCollectionView operatorcollectionView { get; set; }
        public AddVariableCommand AddVariableCommand { get; set; }
        public EditVariableCommand EditVariableCommand { get; set; }
        public ValidateFormulaCommand ValidateFormulaCommand { get; set; }
        public RunTestCommand RunTestCommand { get; set; }
        public PrintCommand PrintCommand { get; set; }
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
            }
        }
        public Operator SelectedOperator
        {
            get { return selectedOperator; }
            set
            {
                selectedOperator = value;
                OnPropertyChanged(nameof(SelectedOperator));
            }
        }
        private void AddVariableToFormula()
        {
            Formula += SelectedVariable.Name.ToString();
            FormulaEditorHelper.Instance.SelectedVariableTemp = SelectedVariable;
            SelectedVariable = null;
        }
        private void LoadOperators()
        {
            List<Operator> operatorlist = ListViewHelper.GetOperatorList();
            operatorcollectionView = new ListCollectionView(operatorlist);
            operatorcollectionView.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
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
        private void SelectedVariableFunctionality()
        {
            IsSelected = true;
            if (SelectedVariable != null)
            {
                if (!UsedVariables.Contains(SelectedVariable.Name))
                {
                    VariableInputViewModels.Add(SelectedVariable.Name, new VariableInputViewModel()
                    {
                        VariableName = SelectedVariable.Name
                    });
                    UsedVariables.Add(SelectedVariable.Name);
                }
                AddVariableToFormula();
            }
        }
        private void SelectedOperatorFunctionality()
        {
            if (SelectedOperator != null)
            {
                AddOperatorToFormula();
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (propertyName == nameof(SelectedVariable))
            {
                this.SelectedVariableFunctionality();
            }
            if (propertyName == nameof(SelectedOperator))
            {
                this.SelectedOperatorFunctionality();
            }
        }
        public void UpdateVariable(Variable NewVariable)
        {
            string Name = FormulaEditorHelper.Instance.SelectedVariableTemp.Name;
            if (VariableInputViewModels.ContainsKey(Name))
            {
                NewVariable.Value = VariableInputViewModels[Name].VariableInput;
                VariableInputViewModels.Remove(Name);
                UsedVariables.Remove(Name);
                VariableInputViewModels.Add(NewVariable.Name, new VariableInputViewModel()
                {
                    VariableName = NewVariable.Name,
                    VariableInput = NewVariable.Value
                });
                UsedVariables.Add(NewVariable.Name);
            }
            if (FormulaEditorHelper.Instance.Variables.ContainsKey(Name))
            {
                FormulaEditorHelper.Instance.Variables.Remove(Name);
                FormulaEditorHelper.Instance.Variables.Add(NewVariable.Name, NewVariable);
            }
            IsSelected = false;
        } 
        public void ValidatingForumla()
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
                MessageBox.Show("Proceed to Run Test", "Validation Successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(exp.ExpressionException e)
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
                if (!UsedVariables.Contains(variable.Value.Name))
                    continue;
                if (variable.Value.Value == null)
                {
                    continue;
                }
                else if (variable.Value.Value.ToString().Length == 0)
                {
                    if (variable.Value.Type != "string")
                        continue;
                }

                try
                {
                    switch (variable.Value.Type)
                    {
                        case "int":
                            variable.Value.Value = Convert.ChangeType(variable.Value.Value, typeof(int));
                            _func.AddSetVariable(variable.Value.Name, (int)variable.Value.Value);
                            break;
                        case "float":
                            variable.Value.Value = Convert.ChangeType(variable.Value.Value, typeof(float));
                            _func.AddSetVariable(variable.Value.Name, (float)variable.Value.Value);
                            break;
                        case "double":
                            variable.Value.Value = Convert.ChangeType(variable.Value.Value, typeof(double));
                            _func.AddSetVariable(variable.Value.Name, (double)variable.Value.Value);
                            break;
                        case "string":
                            variable.Value.Value = Convert.ChangeType(variable.Value.Value, typeof(string));
                            _func.AddSetVariable(variable.Value.Name, (string)variable.Value.Value);
                            break;
                        case "bool":
                            variable.Value.Value = Convert.ChangeType(variable.Value.Value, typeof(bool));
                            _func.AddSetVariable(variable.Value.Name, (bool)variable.Value.Value);
                            break;
                        case "DateTime":
                            variable.Value.Value = Convert.ToDateTime(variable.Value.Value);
                            _func.AddSetVariable(variable.Value.Name, (DateTime)variable.Value.Value);
                            break;
                        case "TimeSpan":
                            variable.Value.Value = TimeSpan.Parse((string)variable.Value.Value);
                            _func.AddSetVariable(variable.Value.Name, (TimeSpan)variable.Value.Value);
                            break;
                    }
                }
                catch (Exception e)
                {
                    msg.AppendLine($"Variable \"{variable.Value.Name}\" : {e.Message}");
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
            catch(exp.ExpressionException e)
            {
                MessageBox.Show(e.Message, "Output Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(InvalidCastException e)
            {
                MessageBox.Show(e.Message, "Output Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }   
    }
}

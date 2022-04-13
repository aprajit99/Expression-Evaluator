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

namespace ExpressionEvaluatorUi.ViewModels
{
    public class FormulaEditorViewModel:INotifyPropertyChanged
    {
        
        public static Variable selectedVariableTemp;
        public HashSet<string> UsedVariables;

        public exp.Expression _func;
        private bool isSelected;

        public static FormulaEditorViewModel FormulaEditorVM { get; set; }
        public ListViewHelper ListViewHelper;
        public bool InputNull { get; set; }

        public bool IsSelected
        {
            get { return isSelected; }
            set 
            { 
                isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }
        private bool canValidate;

        public bool CanValidate
        {
            get { return canValidate; }
            set 
            { 
                canValidate = value;
                OnPropertyChanged(nameof(CanValidate));
            }
        }
        private bool canRunTest;

        public bool CanRunTest
        {
            get { return canRunTest; }
            set 
            { 
                canRunTest = value;
                OnPropertyChanged(nameof(CanRunTest));
            }
        }

        private string formula;

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
        
        private Variable selectedVariable;

        public Variable SelectedVariable
        {
            get { return selectedVariable; }
            set
            {   
                selectedVariable = value;
                OnPropertyChanged(nameof(SelectedVariable));
            }
        }

        private Operator selectedOperator;

        public Operator SelectedOperator
        {
            get { return selectedOperator; }
            set
            {
                selectedOperator = value;
                OnPropertyChanged(nameof(SelectedOperator));  
            }
        }
        private string selectedOutputType;

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
        private string testOutput;
       
        public string TestOutput
        {
            get { return testOutput; }
            set 
            { 
                testOutput = value;
                OnPropertyChanged(nameof(TestOutput));
            }
        }





        public static ObservableCollection<Variable> Variables { get; set; }
        public ObservableCollection<string> OutputTypes { get; set; }

        public ListCollectionView operatorcollectionView { get; set; }
        
        public AddVariableCommand AddVariableCommand { get; set; }
        public EditVariableCommand EditVariableCommand { get; set; }
        public ValidateFormulaCommand ValidateFormulaCommand { get; set; }
        public RunTestCommand RunTestCommand { get; set; }
        public PrintCommand PrintCommand { get; set; }



        public static ObservableCollection<VariableInputViewModel> VariableInputViewModels { get; set; }



        public FormulaEditorViewModel()
        {
            FormulaEditorVM = this;
            Variables = new ObservableCollection<Variable>();
            VariableInputViewModels = new ObservableCollection<VariableInputViewModel>();
            OutputTypes = new ObservableCollection<string>();
            UsedVariables = new HashSet<string>();
            ListViewHelper = new ListViewHelper();
            LoadOperators();
            LoadOutputTypes();
            AddVariableCommand = new AddVariableCommand();
            EditVariableCommand = new EditVariableCommand(this);
            ValidateFormulaCommand = new ValidateFormulaCommand(this);
            RunTestCommand = new RunTestCommand(this);
            PrintCommand = new PrintCommand(this);
        }
        public static void AddNewVariableToList(Variable Variable)
        {
            Variables.Add(Variable); 
        }
        public void UpdateVariable(Variable NewVariable)
        { 
            foreach (var variable in VariableInputViewModels)
            {
                if (variable.VariableName == selectedVariableTemp.Name)
                {
                    
                    NewVariable.Value = variable.VariableInput;
                    VariableInputViewModels.Remove(variable);
                    UsedVariables.Remove(variable.VariableName); 
                    VariableInputViewModels.Add(new VariableInputViewModel()
                    {
                        VariableName = NewVariable.Name,
                        VariableInput = NewVariable.Value
                    });
                    UsedVariables.Add(NewVariable.Name); 
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
        private void LoadOutputTypes()
        {
            List<string> outputlist = ListViewHelper.getOutputTypeList();
            foreach(string type in outputlist)
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
                if(!UsedVariables.Contains(SelectedVariable.Name))
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
        private void SelectedOperatorFunctionality()
        {
            if (SelectedOperator != null)
            {
                AddOperatorToFormula();
            }
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
            if (InputNull)
            {
                _func.Function = Formula;
                InputNull = false;
            }
           
            StringBuilder msg = new StringBuilder("");
            foreach (var variable in Variables)
            {
                
                if (!UsedVariables.Contains(variable.Name))
                    continue;

                //if (variable.Value == null || string.IsNullOrEmpty(variable.Value.ToString()))
                //{
                //    continue;
                //}
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

        public event PropertyChangedEventHandler PropertyChanged;
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
    }
}

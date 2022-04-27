using ExpressionEvaluatorUi.Model;
using ExpressionEvaluatorUi.ViewModels.Commands;
using ExpressionEvaluatorUi.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace ExpressionEvaluatorUi.ViewModels
{
    public class AddVariableViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string variableName;
        private string variableType;
        private string variableDescription;
        private bool nameTypeChanged;
        public bool VariableNameChanged;
        public bool VariableTypeChanged;
        public AddVariableViewModel()
        {
            SaveNewVariableCommand = new RelayCommand(SaveVariableExecute, SaveVariableCanExecute);
            CloseWindowCommand = new RelayCommand(CloseWindowExecute);
            VariableTypes = new ObservableCollection<string>();
            LoadVariableTypes();
        }
        public ObservableCollection<string> VariableTypes { get; set; }
        public RelayCommand SaveNewVariableCommand { get; set; }
        public RelayCommand CloseWindowCommand { get; set; }
        public bool NameTypeChanged
        {
            get { return nameTypeChanged; }
            set 
            {
                nameTypeChanged = value;
                OnPropertyChanged(nameof(NameTypeChanged));
            }
        }
        public string VariableName
        {
            get { return variableName; }
            set 
            { 
                variableName = value;
                OnPropertyChanged(nameof(VariableName));
                VariableNameChanged = true;
                NameTypeChanged = VariableNameChanged & VariableTypeChanged;       
            }
        }      
        public string VariableType
        {
            get { return variableType; }
            set
            {
                variableType = value;
                OnPropertyChanged(nameof(VariableType));
                VariableTypeChanged = true;
                NameTypeChanged = VariableNameChanged & VariableTypeChanged;
            }
        }
        public string VariableDescription
        {
            get { return variableDescription; }
            set
            {
                variableDescription = value;
                OnPropertyChanged(nameof(VariableDescription));
            }
        }
        private void LoadVariableTypes()
        {
            List<string> types = FormulaEditorHelper.Instance.GetVariableTypeList();
            foreach (var type in types)
            {
                VariableTypes.Add(type);
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void CloseWindowExecute(object parameter)
        {
            FormulaEditorHelper.Instance.AddVariable_CloseWindow?.Invoke();
        }
        public void SaveVariableExecute(object parameter)
        {
            CreateNewVariable();
        }
        public bool SaveVariableCanExecute(object parameter)
        {
            return (bool)parameter;
        }
        public void CreateNewVariable()
        {
            if(!FormulaEditorHelper.Instance.Variables.ContainsKey(variableName))
            {
                Variable Variable = new Variable
                {
                    Name = variableName,
                    Type = variableType,
                    Description = variableDescription,
                    Value=null
                };
                FormulaEditorHelper.Instance.Variables.Add(variableName,Variable);
            }
            else
            {
                MessageBox.Show("This Variable already exists!",
                                "Invalid Variable Name",
                                MessageBoxButton.OK,MessageBoxImage.Error);
            }
            VariableName = String.Empty;
            VariableType = String.Empty;
            VariableDescription = String.Empty;
            VariableNameChanged = false;
            VariableTypeChanged = false;
            NameTypeChanged = false;  
        }
    }
}

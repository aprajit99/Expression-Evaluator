using ExpressionEvaluatorUi.Model;
using ExpressionEvaluatorUi.ViewModels.Commands;
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
        public bool VariableNameChanged;
        public bool VariableTypeChanged;
        private bool nameTypeChanged;

        //
        public static Action CloseWindow { get; set; }
        //

        public bool NameTypeChanged
        {
            get { return nameTypeChanged; }
            set 
            {
                nameTypeChanged = value;
                OnPropertyChanged(nameof(NameTypeChanged));
            }
        }



        private  string variableName;

        public  string VariableName
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
        
        public  ObservableCollection<string> VariableTypes { get; set; }
        

        private string variableType;
        

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
        private string variableDescription;

        public string VariableDescription
        {
            get { return variableDescription; }
            set
            {
                variableDescription = value;
                OnPropertyChanged(nameof(VariableDescription));
            }
        }
        public SaveNewVariableCommand SaveNewVariableCommand { get; set; }
        public CloseWindowCommand CloseWindowCommand { get; set; }
        public AddVariableViewModel()
        {
            
            SaveNewVariableCommand = new SaveNewVariableCommand(this);
            CloseWindowCommand = new CloseWindowCommand();
            VariableTypes = new ObservableCollection<string>();
            LoadVariableTypes();
        }
        public void CreateNewVariable()
        {
            //TODO: use dictionary
            //check if already present or not
            bool isPresent = false;
            foreach(var variable in FormulaEditorViewModel.Variables)
            {
                if (variable.Name == variableName)
                {
                    isPresent = true;
                    break;
                }
            }
            if (!isPresent)
            {
                Variable Variable = new Variable
                {
                    Name = variableName,
                    Type = variableType,
                    Description = variableDescription
                };
                FormulaEditorViewModel.AddNewVariableToList(Variable);
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

        private void LoadVariableTypes()
        {
            List<string> types = Helpers.ListViewHelper.getVariableTypeList();
            foreach(var type in types)
            {
                VariableTypes.Add(type);
            }

        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

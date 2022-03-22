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
    public class EditVariableViewModel : INotifyPropertyChanged
    {
        
        public static ObservableCollection<string> VariableTypes { get; set; }
        public FormulaEditorViewModel FormulaEditorVM;
        public static Action CloseWindow { get; set; }

        public UpdateVariableCommand UpdateVariableCommand { get; set; }
        public CloseWindowCommand CloseWindowCommand { get; set; }
        private bool isChanged;

        public bool IsChanged
        {
            get { return isChanged; }
            set 
            { 
                isChanged = value;
                OnPropertyChanged("IsChanged");
            }
        }


        private string variableNewName;

        public string VariableNewName
        {
            get { return variableNewName; }
            set 
            { 
                variableNewName = value;
                OnPropertyChanged("VariableNewName");
                IsChanged = true;
            }
        }
        private string variableNewType;

        public string VariableNewType
        {
            get { return variableNewType; }
            set
            {
                variableNewType = value;
                OnPropertyChanged("variableNewType");
                IsChanged = true;
                
            }
        }
        private string variableNewDescription;

        public string VariableNewDescription
        {
            get { return variableNewDescription; }
            set 
            { 
                variableNewDescription = value;
                OnPropertyChanged("VariableNewDescription");
                IsChanged = true;
            }
        }
        public EditVariableViewModel()
        {
            VariableTypes=new ObservableCollection<string>();
            LoadVariableTypes();
            UpdateVariableCommand = new UpdateVariableCommand(this);
            CloseWindowCommand = new CloseWindowCommand();
            
        }
        private void LoadVariableTypes()
        {
            List<string> types = Helpers.ListViewHelper.getVariableTypeList();
            foreach (var type in types)
            {
                VariableTypes.Add(type);
            }

        }
        public void LoadVariableDetails()
        {
            VariableNewName = FormulaEditorViewModel.selectedVariableTemp.Name;
            VariableNewType = FormulaEditorViewModel.selectedVariableTemp.Type;
            VariableNewDescription = FormulaEditorViewModel.selectedVariableTemp.Description;
            IsChanged = false;
        }
        public void CreateUpdatedVariable()
        {
            Variable NewVariable = new Variable
            {
                Name = VariableNewName,
                Type = VariableNewType,
                Description = VariableNewDescription
            };
            FormulaEditorViewModel.UpdateVariable(NewVariable);
            CloseWindow();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

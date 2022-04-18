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
    public class EditVariableViewModel : INotifyPropertyChanged
    {
        
        public ObservableCollection<string> VariableTypes { get; set; }
        public FormulaEditorViewModel FormulaEditorVM;
        //public static Action CloseWindow { get; set; }

        public UpdateVariableCommand UpdateVariableCommand { get; set; }
        public CloseWindowCommand CloseWindowCommand { get; set; }
        private bool isChanged;

        public bool IsChanged
        {
            get { return isChanged; }
            set 
            { 
                isChanged = value;
                OnPropertyChanged(nameof(IsChanged));
            }
        }


        private string variableNewName;

        public string VariableNewName
        {
            get { return variableNewName; }
            set 
            { 
                variableNewName = value;
                OnPropertyChanged(nameof(VariableNewName));
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
                OnPropertyChanged(nameof(variableNewType));
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
                OnPropertyChanged(nameof(VariableNewDescription));
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
            List<string> types = FormulaEditorHelper.Instance.GetVariableTypeList();
            foreach (var type in types)
            {
                VariableTypes.Add(type);
            }

        }
        public void LoadVariableDetails()
        {
            VariableNewName = FormulaEditorHelper.Instance.SelectedVariableTemp.Name;
            VariableNewType = FormulaEditorHelper.Instance.SelectedVariableTemp.Type;
            VariableNewDescription = FormulaEditorHelper.Instance.SelectedVariableTemp.Description;
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
            FormulaEditorVM.UpdateVariable(NewVariable);
            // CloseWindow();
            FormulaEditorHelper.Instance.InputNull = true;
            FormulaEditorHelper.Instance.EditVariable_CloseWindow?.Invoke();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

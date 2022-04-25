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
        public event PropertyChangedEventHandler PropertyChanged;
        private bool isChanged;
        private string variableNewName;
        private string variableNewType;
        private string variableNewDescription;
        public EditVariableViewModel()
        {
            VariableTypes = new ObservableCollection<string>();
            LoadVariableTypes();
            UpdateVariableCommand = new UpdateVariableCommand(this);
            CloseWindowCommand = new CloseWindowCommand();
        }
        public ObservableCollection<string> VariableTypes { get; set; }
        public FormulaEditorViewModel FormulaEditorVM;
        public UpdateVariableCommand UpdateVariableCommand { get; set; }
        public CloseWindowCommand CloseWindowCommand { get; set; }
        public bool IsChanged
        {
            get { return isChanged; }
            set 
            { 
                isChanged = value;
                OnPropertyChanged(nameof(IsChanged));
            }
        }
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
            FormulaEditorHelper.Instance.InputNull = true;
            FormulaEditorHelper.Instance.EditVariable_CloseWindow?.Invoke();
        }   
    }
}

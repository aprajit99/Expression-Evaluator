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
    public class EditVariableViewModel : BaseViewModel
    {
        private bool isEnabled;
        private string _name;
        private string _type;
        private string _description;
        public EditVariableViewModel()
        {
            VariableTypes = new ObservableCollection<string>();
            LoadVariableTypes();
            UpdateVariableCommand = new RelayCommand(UpdateVariableExecute, (object parameter)=> { return (bool)parameter; });
            ButtonCommand = UpdateVariableCommand;
            CloseWindowCommand = new RelayCommand((object parameter)=> { FormulaEditorHelper.Instance.AddEditVariable_CloseWindow?.Invoke(); });
        }
        public ObservableCollection<string> VariableTypes { get; set; }
        public FormulaEditorViewModel FormulaEditorVM;
        public RelayCommand UpdateVariableCommand { get; set; }
        public RelayCommand CloseWindowCommand { get; set; }
        public RelayCommand ButtonCommand { get; set; }
        public string ButtonContent { get; set; } = "Update";
        public bool IsEnabled
        {
            get { return isEnabled; }
            set 
            { 
                isEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }
        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value;
                OnPropertyChanged(nameof(Name));
                IsEnabled = true;
            }
        }
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
                IsEnabled = true;           
            }
        } 
        public string Description
        {
            get { return _description; }
            set 
            { 
                _description = value;
                OnPropertyChanged(nameof(Description));
                IsEnabled = true;
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
        public void UpdateVariableExecute(object parameter)
        {
            CreateUpdatedVariable();
            FormulaEditorHelper.Instance.AddEditVariable_CloseWindow?.Invoke();
        }
        public void LoadVariableDetails()
        {
            Name = FormulaEditorVM.OldVariable.Name;
            Type = FormulaEditorVM.OldVariable.Type;
            Description = FormulaEditorVM.OldVariable.Description;
            IsEnabled = false;
        }
        public void CreateUpdatedVariable()
        {
            Variable NewVariable = new Variable
            {
                Name = Name,
                Type = Type,
                Description = Description
            };
            FormulaEditorVM.UpdateVariable(NewVariable);
            FormulaEditorHelper.Instance.InputNull = true;
        }   
    }
}

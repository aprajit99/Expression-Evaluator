﻿using ExpressionEvaluatorUi.Model;
using ExpressionEvaluatorUi.ViewModels.Commands;
using ExpressionEvaluatorUi.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace ExpressionEvaluatorUi.ViewModels
{
    public class AddVariableViewModel : BaseViewModel
    {
        private string _name;
        private string _type;
        private string _description;
        private bool isEnabled;
        public bool VariableNameChanged;
        public bool VariableTypeChanged;
        public AddVariableViewModel()
        {
            SaveNewVariableCommand = new RelayCommand((object parameter)=> CreateNewVariable(), (object parameter)=> { return (bool)parameter; });
            ButtonCommand = SaveNewVariableCommand;
            CloseWindowCommand = new RelayCommand((object parameter)=> { FormulaEditorHelper.Instance.AddEditVariable_CloseWindow?.Invoke(); });
            VariableTypes = new ObservableCollection<string>();
            LoadVariableTypes();
        }
        public ObservableCollection<string> VariableTypes { get; set; }
        public RelayCommand SaveNewVariableCommand { get; set; }
        public RelayCommand CloseWindowCommand { get; set; }
        public RelayCommand ButtonCommand { get; set; }
        public string ButtonContent { get; set; } = "Save";
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
                VariableNameChanged = true;
                IsEnabled = VariableNameChanged & VariableTypeChanged;       
            }
        }      
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
                VariableTypeChanged = true;
                IsEnabled = VariableNameChanged & VariableTypeChanged;
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        private void Clear()
        {
            Name = String.Empty;
            Type = String.Empty;
            Description = String.Empty;
            VariableNameChanged = false;
            VariableTypeChanged = false;
            IsEnabled = false;
        }
        private void LoadVariableTypes()
        {
            List<string> types = FormulaEditorHelper.Instance.GetVariableTypeList();
            foreach (var type in types)
            {
                VariableTypes.Add(type);
            }
        }
        public void CreateNewVariable()
        {
            Variable var = (Variable)FormulaEditorHelper.Instance.Variables.FirstOrDefault(v => v.Name == _name);
            if(var==null)
            {
                Variable Variable = new Variable
                {
                    Name = _name,
                    Type = _type,
                    Description = _description,
                    Value=null
                };
                FormulaEditorHelper.Instance.Variables.Add(Variable);
            }
            else
            {
                MessageBox.Show("This Variable already exists!",
                                "Invalid Variable Name",
                                MessageBoxButton.OK,MessageBoxImage.Error);
            }
            Clear();
        }
    }
}

using ExpressionEvaluatorUi.Model;
using ExpressionEvaluatorUi.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Data;

namespace ExpressionEvaluatorUi.ViewModels
{
    public class FormulaEditorViewModel:INotifyPropertyChanged
    {
        private string formula;

        public string Formula
        {
            get { return formula; }
            set
            {
                formula = value;
                OnPropertyChanged("Formula");
            }
        }

        private Variable selectedVariable;

        public Variable SelectedVariable
        {
            get { return selectedVariable; }
            set
            {
                selectedVariable = value;
                OnPropertyChanged("SelectedVariable");
                addVariable();
            }
        }

        private Operator selectedOperator;

        public Operator SelectedOperator
        {
            get { return selectedOperator; }
            set
            {
                selectedOperator = value;
                OnPropertyChanged("SelectedOperator");
                addOperator();
            }
        }



        public ObservableCollection<Variable> Variables { get; set; }

        public ListCollectionView operatorcollectionView { get; set; }



        public FormulaEditorViewModel()
        {
            Variables = new ObservableCollection<Variable>();

            LoadVariables();
            LoadOperators();

        }
        private void LoadVariables()
        {

            List<Variable> variablelist = ListViewHelper.getVariableList();
            foreach (var variable in variablelist)
            {
                Variables.Add(variable);
            }
        }
        private void addVariable()
        {
            Formula = Formula + SelectedVariable.Name.ToString();
        }
        private void LoadOperators()
        {

            List<Operator> operatorlist = ListViewHelper.getOperatorList();
            operatorcollectionView = new ListCollectionView(operatorlist);
            operatorcollectionView.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
        }
        private void addOperator()
        {
            Formula = Formula + SelectedOperator.Type.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

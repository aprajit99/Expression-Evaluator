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

        private Step selectedStep;

        public Step SelectedStep
        {
            get { return selectedStep; }
            set
            {
                selectedStep = value;
                OnPropertyChanged("SelectedStep");
                addStep();
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



        public ObservableCollection<Step> Steps { get; set; }

        public ListCollectionView operatorcollectionView { get; set; }



        public FormulaEditorViewModel()
        {
            Steps = new ObservableCollection<Step>();

            LoadSteps();
            LoadOperators();

        }
        private void LoadSteps()
        {

            List<Step> steplist = ListViewHelper.getStepList();
            foreach (var step in steplist)
            {
                Steps.Add(step);
            }
        }
        private void addStep()
        {
            Formula = Formula + SelectedStep.Name.ToString();
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

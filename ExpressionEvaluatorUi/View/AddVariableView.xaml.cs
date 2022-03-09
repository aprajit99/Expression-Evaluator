using ExpressionEvaluatorUi.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ExpressionEvaluatorUi.View
{
    /// <summary>
    /// Interaction logic for AddVariableView.xaml
    /// </summary>
    public partial class AddVariableView : Window
    {
        public AddVariableView()
        {
            InitializeComponent();
            this.DataContext = new AddVariableViewModel();
        }
    }
}

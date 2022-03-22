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
    /// Interaction logic for EditVariableView.xaml
    /// </summary>
    public partial class EditVariableView : Window
    {
        public EditVariableView()
        {
            InitializeComponent();
            this.DataContext = new EditVariableViewModel();
            EditVariableViewModel.CloseWindow = Close;
        }
    }
}

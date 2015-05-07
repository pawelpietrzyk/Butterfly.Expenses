using Butterfly.Client.Expenses.Wpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Butterfly.Client.Expenses.Wpf.View
{
    /// <summary>
    /// Interaction logic for ExpenseCategoriesView.xaml
    /// </summary>
    public partial class ExpenseCategoriesView : UserControl
    {
        ExpenseCategoriesViewModel model;
        public ExpenseCategoriesView()
        {
            InitializeComponent();
            this.model = new ExpenseCategoriesViewModel();
            this.DataContext = this.model;
        }

        private void btnCancel_Click_1(object sender, RoutedEventArgs e)
        {
            this.model.BeginGetExpenseCategories();
        }
    }
}

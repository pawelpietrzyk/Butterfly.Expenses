using Butterfly.Client.Expenses.Wpf.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Butterfly.Client.Expenses.Wpf.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ExpenseCategoriesView expenseView;
        public MainViewModel()
        {
            this.expenseView = new ExpenseCategoriesView();
            this.Content = this.expenseView;
        }
        private ContentControl content;

        public ContentControl Content
        {
            get { return content; }
            set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}

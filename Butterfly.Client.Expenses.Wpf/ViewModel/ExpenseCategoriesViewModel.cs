using butterfly.com.rest;
using Butterfly.Client.Expenses.Wpf.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Butterfly.Client.Expenses.Wpf.ViewModel
{
    public class ExpenseCategoriesViewModel : INotifyPropertyChanged
    {
        protected string url;
        protected HttpParams httpParameters;
        protected string httpContentType;
        protected int timeout;

        public ExpenseCategoriesViewModel()
        {
            this.httpParameters = new HttpParams();
            this.httpContentType = "application/json";
            this.timeout = 10000;
            this.url = "http://localhost:49183/ExpenseCategories";
        }
        public List<ExpenseCategory> ExpenseCategories { get; set; }

        private ICollectionView dataView;
        public ICollectionView DataView
        {
            get { return this.dataView; }
            set
            {
                this.dataView = value;
                OnPropertyChanged("DataView");
            }
        }

        public void BeginGetExpenseCategories()
        {
            Http.get(url, httpParameters, httpContentType, timeout).then(EndGetExpenseCategories).Async();
        }
        protected void EndGetExpenseCategories(object sender, HttpResponseEventArgs e)
        {
            if (e.StatusCode == System.Net.HttpStatusCode.OK)
            {
                this.ExpenseCategories = ExpenseCategory.deserialize(e.Content);
                this.DataView = CollectionViewSource.GetDefaultView(this.ExpenseCategories);                   
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;    
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}

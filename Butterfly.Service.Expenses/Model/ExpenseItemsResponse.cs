using Butterfly.Service.Expenses.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Butterfly.Service.Expenses.Model
{
    [DataContract(Name = "ExpenseItemsResponse", Namespace = "http://butterfly.service/expenses")]
    public class ExpenseItemsResponse
    {
        [DataMember]
        public List<ExpenseItem> Items { get; set; }
    }
    
}
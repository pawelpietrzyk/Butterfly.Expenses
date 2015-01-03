using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Butterfly.Service.Expenses.Model
{
    [DataContract(Name = "ExpenseCategoryResponse", Namespace = "http://butterfly.service/expenses")]
    public class ExpenseCategoryResponse
    {
        [DataMember]
        public List<ExpenseCategoryGroupSum> Items { get; set; }
    }
}
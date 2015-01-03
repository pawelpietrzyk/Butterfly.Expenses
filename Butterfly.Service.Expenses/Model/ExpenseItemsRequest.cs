using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Butterfly.Service.Expenses.Model
{
    [DataContract(Name = "ExpenseItemsRequest", Namespace = "http://butterfly.service/expenses")]
    public class ExpenseItemsRequest
    {
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public string Category { get; set; }

    }
}
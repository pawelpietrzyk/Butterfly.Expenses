using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Butterfly.Service.Expenses.Model
{
    [DataContract(Name="CreateExpenseItemRequest", Namespace="http://butterfly.service/expenses")]
    public class CreateExpenseItemRequest
    {
        [DataMember(Order=4, IsRequired=false)]
        public string ProductCategory { get; set; }

        [DataMember(Order = 3)]
        public decimal Price { get; set; }

        [DataMember(Order=2)]
        public decimal Qty { get; set; }

        [DataMember(Order = 1)]
        public string ProductName { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;


namespace Butterfly.Service.Expenses.Model
{
    [DataContract(Name = "CreateExpenseCategoryBatchRequest", Namespace = "http://butterfly.service/expenses")]
    public class CreateExpenseCategoryBatchRequest
    {
        [DataMember]
        public List<CreateExpenseCategoryRequest> Requests { get; set; }
    }
}

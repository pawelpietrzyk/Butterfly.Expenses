using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Butterfly.Service.Expenses.Model
{
    [DataContract]
    public class CreateExpenseCategoryRequest
    {
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public string Account { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public decimal Value { get; set; }
        [DataMember]
        public bool Planned { get; set; }
    }    
}
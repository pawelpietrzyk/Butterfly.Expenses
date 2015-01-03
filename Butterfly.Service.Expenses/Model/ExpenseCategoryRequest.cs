using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Butterfly.Service.Expenses.Model
{
    [DataContract]
    public class ExpenseCategoryRequest
    {
        [DataMember]
        public DateTime BeginDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public PeriodType PeriodType { get; set; }
    }
}
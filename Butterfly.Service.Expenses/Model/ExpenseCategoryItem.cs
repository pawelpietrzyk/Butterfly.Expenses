using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Butterfly.Service.Expenses.Model
{
    public class ExpenseCategoryItem
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Week { get; set; }        
        public string CategoryName { get; set; }
        public decimal Value { get; set; }

    }
    
    public class ExpenseCategoryGroup
    {
        [DataMember(Order = 2)]
        public string CategoryName { get; set; }
        [DataMember(Order = 0)]
        public int Year { get; set; }
        [DataMember(Order = 1)]
        public int Month { get; set; }        
    }
    
    public class ExpenseCategoryGroupSum : ExpenseCategoryGroup
    {
        [DataMember(Order = 3)]
        public decimal Value { get; set; }

        [DataMember(Order = 4)]
        public decimal ValuePlanned { get; set; }
    }
}
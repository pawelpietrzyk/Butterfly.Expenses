//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Butterfly.Service.Expenses.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class ExpenseCategory
    {
        public long Id { get; set; }
        public string CategoryName { get; set; }
        public decimal Value { get; set; }
        public System.DateTime Date { get; set; }
        public decimal ValuePlan { get; set; }
        public string Account { get; set; }
    }
}

using Butterfly.Service.Expenses.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Butterfly.Service.Expenses.Model
{
    [DataContract(Name = "CreateExpenseItemResponse", Namespace = "http://butterfly.service/expenses/create")]
    public class CreateExpenseItemResponse : Response
    {
        private long id;
        [DataMember(Order = 3)]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        [DataMember]
        public string Category { get; set; }

        public override void SetSUCCESS(object obj)
        {
            ExpenseItem item = obj as ExpenseItem;
            if (obj != null)
            {
                this.id = item.Id;
                this.Category = item.ProductCategory;
            }
            base.SetSUCCESS(obj);
        }

    }
}
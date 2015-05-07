using butterfly.com.rest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Butterfly.Client.Expenses.Wpf.Model
{
    public class ExpenseCategory
    {
        public long Id { get; set; }
        public string CategoryName { get; set; }
        public decimal Value { get; set; }
        public System.DateTime Date { get; set; }
        public decimal ValuePlan { get; set; }
        public string Account { get; set; }

        public static List<ExpenseCategory> deserialize(string content)
        {            
            byte[] bytes = Encoding.ASCII.GetBytes(content);
            MemoryStream memory = new MemoryStream(bytes);            
            List<ExpenseCategory> list = Serializer.Deserialize(memory, typeof(List<ExpenseCategory>)) as List<ExpenseCategory>;
            return list;
        }
    }
}

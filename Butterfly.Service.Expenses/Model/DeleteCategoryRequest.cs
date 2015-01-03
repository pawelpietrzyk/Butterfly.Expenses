using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Butterfly.Service.Expenses.Model
{
    
    [DataContract]
    public class DeleteCategoryRequest
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool WithChild { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Butterfly.Service.Expenses.Model
{
    [DataContract]
    public class CategoryTagsRequest
    {
        [DataMember]
        public string Tag { get; set; }
        [DataMember]
        public string Category { get; set; }

    }
}
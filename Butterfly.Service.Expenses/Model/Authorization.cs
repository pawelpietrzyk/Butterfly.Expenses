using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Butterfly.Service.Expenses.Model
{
    [DataContract]
    public class Authorization
    {
        [DataMember]
        public string Account { get; set; }
        [DataMember]
        public string Token { get; set; }
    }
}
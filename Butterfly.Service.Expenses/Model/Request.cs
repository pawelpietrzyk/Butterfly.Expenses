using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Butterfly.Service.Expenses.Model
{
    [DataContract(Namespace = "http://butterfly.service/expenses")]
    public class Request
    {        
        [DataMember]
        public Authorization Athorization { get; set; }
        [DataMember]
        public RequestData Data { get; set; }
    }
}
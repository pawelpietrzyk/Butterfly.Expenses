using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Butterfly.Service.Expenses.Model
{
    [DataContract(Name = "AuthUserRequest", Namespace = "http://butterfly.service/expenses")]
    public class AuthUserRequest
    {
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public string Token { get; set; }
    }
}
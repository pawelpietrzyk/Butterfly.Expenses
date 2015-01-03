using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Butterfly.Service.Expenses.Model
{
    [DataContract(Name = "CreateUserRequest", Namespace = "http://butterfly.service/expenses")]
    public class CreateUserRequest
    {
        [DataMember(Order = 1)]
        public string UserId { get; set; }
        [DataMember(Order = 2)]
        public string UserName { get; set; }
        [DataMember(Order = 3)]
        public string Token { get; set; }
    }
}
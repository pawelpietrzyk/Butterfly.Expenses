﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Butterfly.Service.Expenses.Model
{
    [DataContract]
    public class DeleteExpenseCategoryRequest
    {
        [DataMember]
        public long Id { get; set; }
    }
}
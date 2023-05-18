using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trial.Models
{
    public class Person
    {
        public string Name { get; set; }
        public HttpPostedFileBase File{ get; set; }
    }
}
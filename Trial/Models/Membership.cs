using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Trial.Models
{
    public class Membership
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
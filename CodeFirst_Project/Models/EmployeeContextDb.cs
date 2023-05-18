using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CodeFirst_Project.Models
{
    public class EmployeeContextDb : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
      
    }
}
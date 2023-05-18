using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trial.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string EmpName { get; set; }
        [Required]
        [Range(10000, 10000000, ErrorMessage = "Employee Salary minimum 10000 ")]
        public int Salary { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public System.DateTime DateOfJoining { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public string City { get; set; }
        public int DepartmentId { get; set; }
       /* public string DepartmentName { get; set; }

        public virtual Department Department { get; set; }*/
    }
}

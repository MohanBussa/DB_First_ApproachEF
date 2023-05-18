using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trial.Interface
{
    public interface IEmployeeService 
    {
        List<Employee> GetList();
        List<Department> GetDept();
        Employee AddAndUpadateEmployee(Employee employee);
        Employee DeleteEmployee(Employee employee);
        Employee GetEmployeeById(int Id);



    }

}
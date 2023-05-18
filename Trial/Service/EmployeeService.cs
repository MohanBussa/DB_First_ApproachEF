using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trial.Interface;
using System.Data.Entity;

namespace Trial.Service
{
    public class EmployeeService : IEmployeeService
    {
        private IGenericRepository<Employee> managementEntities;
        private IGenericRepository<Department> Entities;
        public EmployeeService(IGenericRepository<Employee> managementEntities, IGenericRepository<Department> Entities)
        {
            this.managementEntities = managementEntities;
            this.Entities = Entities;
        }
        public List<Employee> GetList()
        {
            List<Department> departmentList = new List<Department>();
            var deparment = Entities.GetAllList();
            List<Employee> employeesList = new List<Employee>();
            var employees = managementEntities.GetAllList();
            foreach (var emp in employees)
            {
                Department dp = deparment.FirstOrDefault(p => p.Id == emp.DepartmentId);
                Employee employee = new Employee();
                employee.Id = emp.Id;
                employee.EmpName = emp.EmpName;
                employee.Salary = emp.Salary;
                employee.Email = emp.Email;
                employee.DateOfJoining = emp.DateOfJoining;
                employee.Designation = emp.Designation;
                employee.City = emp.City;
                employee.DepartmentName = dp.Name;
                employeesList.Add(employee);
            }
            return employeesList;
        }
        public List<Department> GetDept()
        {
            List<Department> departmentlist = new List<Department>();
            var department = Entities.GetAllList();      
            foreach (var dept in department)
            {
                if (dept.IsActive == true)
                {
                    departmentlist.Add(dept);
                }
            }
            return departmentlist;
        }

        public Employee AddAndUpadateEmployee(Employee employee)
        {
            var empdata = managementEntities.GetById(employee.Id);
            if (empdata == null)
            {
                Employee emp = new Employee();
                emp.EmpName = employee.EmpName;
                emp.Salary = employee.Salary;
                emp.Email = employee.Email;
                emp.DateOfJoining = employee.DateOfJoining;
                emp.Designation = employee.Designation;
                emp.City = employee.City;
                emp.DepartmentId = employee.DepartmentId;
                managementEntities.Insert(emp);
                managementEntities.Save();
                return employee;
            }
            else
            {
                empdata.EmpName = employee.EmpName;
                empdata.Salary = employee.Salary;
                empdata.Email = employee.Email;
                empdata.DateOfJoining = employee.DateOfJoining;
                empdata.Designation = employee.Designation;
                empdata.City = employee.City;
                empdata.DepartmentId = employee.DepartmentId;
                managementEntities.Save();
                return employee;
            }
        }
        public Employee DeleteEmployee(Employee employee)
        {
            if (employee != null)
            {
                managementEntities.Delete(employee.Id);
                managementEntities.Save();
            }
            return employee;
        }
        public Employee GetEmployeeById(int Id)
        {
            Employee employee = new Employee();
            Employee data = managementEntities.GetById(Id);
            if (data != null)
            {
                employee.Id = data.Id;
                employee.City = data.City;
                employee.EmpName = data.EmpName;
                employee.Email = data.Email;
                employee.DateOfJoining = data.DateOfJoining;
                employee.DepartmentId = data.DepartmentId;
                employee.Salary = data.Salary;
                employee.Designation = data.Designation;
            }
            return employee;
        }
    }

}

















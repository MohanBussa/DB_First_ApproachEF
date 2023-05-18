using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trial.Interface;

namespace Trial.Service
{

    public class DepartmentService : IDepartmentService
    {
        private IGenericRepository<Department> managementEntities;

        public DepartmentService(IGenericRepository<Department> managementEntities)
        {
            this.managementEntities = managementEntities;
        }
        public List<Department> GetDepartmentList()
        {
            List<Department> departmentlist = new List<Department>();
            var deparment = managementEntities.GetAllList();
            foreach (var dept in deparment)
            {
                Department department = new Department();
                department.Id = dept.Id;
                department.Name = dept.Name;
                department.IsActive = dept.IsActive;
                departmentlist.Add(department);
            }
            return departmentlist;
        }


        public Department AddOrUpdateDepartment(Department department)
        {
            var DeptData =managementEntities.GetById(department.Id);
            if (DeptData == null)
            {

                Department dept = new Department();

                dept.Name = department.Name;
                dept.IsActive = department.IsActive == true ? true : false;
                managementEntities.Insert(dept);
                managementEntities.Save();
                return department;
            }

            else
            {
                DeptData.IsActive = department.IsActive;
                DeptData.Name = department.Name;
                managementEntities.Save();
                return department;
            }
        }
        public Department DeleteDepartment(Department department)
        {
            if (department != null)
            {
                Department dept = managementEntities.GetById(department.Id);
                dept.IsActive = false;
                managementEntities.Save();
                return department;
            }
            return department;
        }
        public Department GetDepartmentById(int id)
        {
            Department department = new Department();
            var data = managementEntities.GetById(id);

            if (data != null)
            {
                department.Id = data.Id;
                department.Name = data.Name;
                department.IsActive = data.IsActive;
            }
            return department;
        }

    }
}
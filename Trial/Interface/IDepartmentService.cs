using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trial.Interface
{
     public interface IDepartmentService
    {
        List<Department> GetDepartmentList();
        Department AddOrUpdateDepartment(Department department);
        Department DeleteDepartment(Department department);
        Department GetDepartmentById(int id);

    }
}
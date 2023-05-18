using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trial;
using Trial.Interface;
using Trial.Models;

namespace Trial.Controllers
{
    [Authorize]
    [RoutePrefix("Departments")]
    public class DepartmentsController : Controller
    {
        private IDepartmentService _departmentService = null;
        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

          public ActionResult GetDepartmentList()
       {
           var dept = _departmentService.GetDepartmentList();
           return Json(new { data = dept }, JsonRequestBehavior.AllowGet);
       }
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            _departmentService.AddOrUpdateDepartment(department);
            if (department.Id == 0)
            {
                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult Edit(int id)
        {
            var dept = _departmentService.GetDepartmentById(id);
            return Json(new { data = dept, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(Department department)
        {
            _departmentService.DeleteDepartment(department);
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
        }

    }
}

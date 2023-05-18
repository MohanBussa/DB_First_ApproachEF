using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trial.Interface;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using Trial;

namespace Trial.Controllers
{
    [Authorize]
    [RoutePrefix("Employee")]
    public class EmployeeController : Controller
    {
        public IEmployeeService _employeeService = null;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [Route("")]
        public ActionResult Index()
        {
            var Dept = _employeeService.GetDept();
            ViewBag.DepartmentId = new SelectList(Dept, "Id", "Name");
            ViewBag.GetList = _employeeService.GetList();
            return View();
        }
        public ActionResult GetEmployeeList()
        {

          
            var emplist = _employeeService.GetList();

            return Json(new { data = emplist }, JsonRequestBehavior.AllowGet);
        }
        [Route("Create")]
        public ActionResult Create()
        {
            var Dept = _employeeService.GetDept();
            ViewBag.DepartmentId = new SelectList(Dept, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            var Dept = _employeeService.GetDept();
            ViewBag.DepartmentId = new SelectList(Dept, "Id", "Name");
            _employeeService.AddAndUpadateEmployee(employee);
            if (employee.Id == 0)
            {
                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = true, message = "Upadated Successfully" }, JsonRequestBehavior.AllowGet);
            }
            
        }
        
        public ActionResult Edit(int id)
        {
            Employee emp = _employeeService.GetEmployeeById(id);
            return Json(new { data = emp}, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.AddAndUpadateEmployee(employee);
                return Json(new { success = true, message = "Upadated Successfully" }, JsonRequestBehavior.AllowGet);
            }
            var Dept = _employeeService.GetDept();
            ViewBag.DepartmentId = new SelectList(Dept, "Id", "Name", employee.DepartmentId);
            return Json(new { data = employee, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }
       
        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
            _employeeService.DeleteEmployee(employee);
            return Json(new { success=true, message="Deleted Successfully"}, JsonRequestBehavior.AllowGet);
        }
      
    }
}
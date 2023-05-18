using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB_First_ApproachEF.Controllers
{
    public class DepartmentController : Controller
    {
        Employee_ManagementEntities2 db = new Employee_ManagementEntities2();
        // GET: Department
        public ActionResult Index()
        {
            return View(db.Departments.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View();
        }
        public ActionResult Edit(int id)
        {
            db.Departments.Where(model => model.Id == id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Edit()
        {
            
            return View();
        }
    }
}
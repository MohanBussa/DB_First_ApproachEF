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
    [RoutePrefix("Students")]
    public class StudentsController : Controller
    {
        private IStudentService _studentService = null;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [Route("")]
        public ActionResult Index()
        {
            var std = _studentService.GetStd();
            ViewBag.StandardId = new SelectList(std, "Id", "Name");

            var countrycode = _studentService.GetCountryCode();
            ViewBag.CountryCodeId = new SelectList(countrycode, "Id", "Code");

            ViewBag.GetList = _studentService.GetStudentList();
            return View();
        }
        public ActionResult GetList()
        {
            var stdlist = _studentService.GetStudentList();
            return Json(new { data = stdlist }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            var std = _studentService.GetStd();
            ViewBag.StandardId = new SelectList(std, "Id", "Name");

            var countrycode = _studentService.GetCountryCode();
            ViewBag.CountryCodeId = new SelectList(countrycode, "Id", "Code");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            var std = _studentService.GetStd();
            ViewBag.StandardId = new SelectList(std, "Id", "Name");

            var countrycode = _studentService.GetCountryCode();
            ViewBag.CountryCodeId = new SelectList(countrycode, "Id", "Code");

            _studentService.AddOrEditStudent(student);
            if (student.Id==0)
            {
                return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { success = true, message = "Upadate Successfully" }, JsonRequestBehavior.AllowGet);
            }   
        }
        public ActionResult Edit(int id)
        {
           
            Student student = _studentService.GetByStudentId(id);
            return Json(new { data = student }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.AddOrEditStudent(student);
                return Json(new { success = true, message = "Upadated Successfully" }, JsonRequestBehavior.AllowGet);
            }
            var std = _studentService.GetStd();
            ViewBag.StandardId = new SelectList(std, "Id", "Name");
            var countrycode = _studentService.GetCountryCode();
            ViewBag.CountryCodeId = new SelectList(countrycode, "Id", "Code");
            return Json(new { data = student, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            _studentService.DeleteStudent(student);
            return Json(new { success = true, message = "Delete Successfully" }, JsonRequestBehavior.AllowGet);
        }
    }
}

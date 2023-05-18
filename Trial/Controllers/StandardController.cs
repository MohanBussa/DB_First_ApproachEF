using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trial.Interface;

namespace Trial.Controllers
{
    [Authorize]
    [RoutePrefix("Standard")]
    public class StandardController : Controller
    {
        private IStandardService _standardService = null;
        public StandardController(IStandardService standardService)
        {
            _standardService = standardService;
        }
        // GET: Standard
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetStandardList()
        {
            var std = _standardService.GetStandardList();
            return Json(new { data = std }, JsonRequestBehavior.AllowGet);
        }
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Standard standard)
        {
            _standardService.AddOrUpdateStandard(standard);
            if (standard.Id == 0)
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
            var std = _standardService.GetStandardById(id);
            return Json(new { data = std}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(Standard standard)
        {
            _standardService.DeleteStandard(standard);
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
        }

    }
}
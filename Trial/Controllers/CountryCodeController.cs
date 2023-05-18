using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trial.Interface;

namespace Trial.Controllers
{
    [Authorize]
    [RoutePrefix("CountryCode")]
    public class CountryCodeController : Controller
    {
        private ICountryCodeService _countryCodeService = null;
        public CountryCodeController(ICountryCodeService countryCodeService)
        {
            _countryCodeService = countryCodeService;
        }
        // GET: Standard
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCountryCodeList()
        {
            var countrycode = _countryCodeService.GetCountryCodeList();
            return Json(new { data = countrycode }, JsonRequestBehavior.AllowGet);
        }
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CountryCode countrycode)
        {
            _countryCodeService.AddOrUpdateCountryCode(countrycode);
            if (countrycode.Id == 0)
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
            var countrycode = _countryCodeService.GetCountryCodeById(id);
            return Json(new { data = countrycode}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(CountryCode countrycode)
        {
            _countryCodeService.DeleteCountryCode(countrycode);
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
        }
    }
}
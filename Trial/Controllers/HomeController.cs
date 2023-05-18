using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Trial.Models;
using Trial.Service;

namespace Trial.Controllers
{
    [Authorize]
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
        [Route("About")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Route("Contact")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
        [Route("FileUpload")]
        public ActionResult FileUpload()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if(file != null)
            {
                string path = Server.MapPath("~/FileUpload");
                string fileName = Path.GetFileName(file.FileName);
                string fullPath = Path.Combine(path, fileName);
                file.SaveAs(fullPath);
                TempData["message"] = "Successfully Uploaded";
                TempData["red"] = "green";
            }
            else
            {
                TempData["red"] = "red";
                TempData["Msg"] = "Please Upload the File";
            }
           
            return View();
        }
        
        public FileResult Download()
        {
            string path = Server.MapPath("~/FileUpload");
            string fileName = Path.GetFileName("Image2.jpg");
            string fullPath = Path.Combine(path, fileName);
            return File(fullPath, "image/pdf", "mohan.jpg");
        }
      
        public ActionResult DownloadFile(string fileName)
        {
         
            string filePath = Server.MapPath("~/File/" + fileName);
            if (!System.IO.File.Exists(filePath))
            {
                return HttpNotFound();
            }

            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.ContentType = "application/octet-stream";

            Response.WriteFile(filePath);

            return new EmptyResult();
        }
        

    }
}
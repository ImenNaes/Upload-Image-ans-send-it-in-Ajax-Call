using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UploadImageAjaxAccess.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
        
            //string path = Server.MapPath("~/images/computer.png");
            //byte[] imageByteData = System.IO.File.ReadAllBytes(path);
            //string imageBase64Data = Convert.ToBase64String(imageByteData);
            //string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
            //ViewBag.ImageData = imageDataURL;
            return View();
        }

      
        public ActionResult SaveImage(HttpPostedFileBase file)
        {
            String fileName = "";

            if (file != null)
            {
                fileName = System.Guid.NewGuid().ToString() + System.IO.Path.GetExtension(file.FileName);
                string physicalPath = Path.Combine(Server.MapPath("~/Images"), fileName);
                // save image in folder
                file.SaveAs(physicalPath);
            }
            return RedirectToAction("Index");
        }

      public string EstractImageFromFolder()
        {
            string Filename = "";
            string[] Files = System.IO.Directory.GetFiles(@"C:\Users\ImenNrnaes\source\repos\UploadImageAjaxAccess\UploadImageAjaxAccess\Images", "*.jpg", SearchOption.AllDirectories);
            foreach (var item in Files)
            {
                Filename = item;
            }
            return Filename;
        }

        [HttpGet]
        public ActionResult GetBase64Image()
        {
            string s = EstractImageFromFolder();          
            string path= s;
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] data = new byte[(int)fileStream.Length];
            fileStream.Read(data, 0, data.Length);

            return Json(new { base64imgage = Convert.ToBase64String(data) }
                , JsonRequestBehavior.AllowGet);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
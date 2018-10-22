using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework4.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MileConverter()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("MileConverter")]
        public ActionResult MileConverterResult(FormCollection fc)
        {
            double miles = Convert.ToDouble(Request.Form["miles"]);

            if (fc["toconvert"] == "mm")
            {
                ViewBag.results = miles * 1609344;
            }
            else if (fc["toconvert"] == "cm")
            {
                ViewBag.results = miles * 160934;
            }
            else if (fc["toconvert"] == "m")
            {
                ViewBag.results = miles * 1609.34;
            }
            else if (fc["toconvert"] == "km")
            {
                ViewBag.results = miles * 1.60934;
            }
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Color()
        {
            ViewBag.Message = "Color Choser.";

            return View();
        }
    }
}
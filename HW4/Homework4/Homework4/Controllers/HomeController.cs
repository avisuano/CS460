using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
            string inputmiles = Request.QueryString["miles"];

            if (Request.QueryString["mm"] != null)
            {
                decimal converted = Convert.ToDecimal(inputmiles) * Convert.ToDecimal(1609344);
                string message = inputmiles + " miles is equal to: " + converted + "millimeters.";
                ViewBag.ConversionResults = message;
            }
            else if (Request.QueryString["cm"] != null)
            {
                decimal converted = Convert.ToDecimal(inputmiles) * Convert.ToDecimal(160934.4);
                string message = inputmiles + " miles is equal to: " + converted + "centimeters.";
                ViewBag.ConversionResults = message;
            }
            else if (Request.QueryString["m"] != null)
            {
                decimal converted = Convert.ToDecimal(inputmiles) * Convert.ToDecimal(1609.344);
                string message = inputmiles + " miles is equal to: " + converted + "meters.";
                ViewBag.ConversionResults = message;
            }
            else if (Request.QueryString["km"] != null)
            {
                decimal converted = Convert.ToDecimal(inputmiles) * Convert.ToDecimal(1.609344);
                string message = inputmiles + " miles is equal to: " + converted + "kilometers.";
                ViewBag.ConversionResults = message;
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
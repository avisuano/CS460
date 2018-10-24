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
        /// Start page
        /// </summary>
        /// <returns>standard view</returns>
        public ActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        /// Takes user input in miles and converts that into a metric unit
        /// </summary>
        /// <returns>converted miles</returns>
        [HttpGet]
        public ActionResult MileConverter()
        {
            // This fixed many a View.Bag problem I was having
            ViewBag.ConversionResult = false;

            // Initialize the Query Strings and the conversion results variable
            double inputmiles = Convert.ToDouble(Request.QueryString["inputmiles"]);
            string units = Request.QueryString["units"];
            double conversion;
            
            // Originally was using if/else if ... but switch case was much easier
            // Also ran into many unreachable issues with if/else if
            switch (units)
            {
                case "mm":
                    conversion = inputmiles * 1609344;
                    ViewBag.ConversionResult = true;
                    break;
                case "cm":
                    conversion = inputmiles * 160934.4;
                    ViewBag.ConversionResult = true;
                    break;
                case "m":
                    conversion = inputmiles * 1609.344;
                    ViewBag.ConversionResult = true;
                    break;
                case "km":
                    conversion = inputmiles * 1.609344;
                    ViewBag.ConversionResult = true;
                    break;
                default:
                    conversion = -1;
                    break;
            }

            // Used this for testing that parameters were being passed correctly
            Debug.WriteLine(inputmiles);
            Debug.WriteLine(conversion);

            // This is what gets returned to the page after the conversion is completed
            string message = inputmiles + " miles converts to: " + conversion + units;
            ViewBag.Results = message;

            return View();
        }
    }
}
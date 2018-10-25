using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
                // Important to have this one... fixes a lot of errors
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Colors()
        {       
            ViewBag.ColorResult = false;
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FirstColor"></param>
        /// <param name="SecondColor"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Colors")]
        public ActionResult Colors(string FirstColor, string SecondColor)
        {
            ViewBag.ColorResult = false;

            // Grab the hexadecimal values from the user
            FirstColor = Request.Form["FirstColor"];
            SecondColor = Request.Form["SecondColor"];

            // This converts the hexadecimal values into their alpha, red, blue, and green values
            Color color1 = ColorTranslator.FromHtml(FirstColor);
            Color color2 = ColorTranslator.FromHtml(SecondColor);

            // Initialize the values needed for error checking
            int color_alpha, color_red, color_blue, color_green;

            // This is needed to check for values above 255 -- lots of errors if these aren't checked
            // Started with alpha...
            if (color1.A + color2.A >= 255)
            {
                color_alpha = 255;
            }
            else
            {
                color_alpha = color1.A + color2.A;
            }
            // Next the red values are checked
            if (color1.R + color2.R >= 255)
            {
                color_red = 255;
            }
            else
            {
                color_red = color1.R + color2.R;
            }
            // Next the blue values are checked
            if (color1.B + color2.B >= 255)
            {
                color_blue = 255;
            }
            else
            {
                color_blue = color1.B + color2.B;
            }
            // Finally the green values are checked
            if (color1.G + color2.G >= 255)
            {
                color_green = 255;
            }
            else
            {
                color_green = color1.G + color2.G;
            }
            // Take the alpha, red, blue, and green values and combine them into ARGB format
            // After being combined, they are repacked into a HTML format to be viewed
            string MixedColors = ColorTranslator.ToHtml(Color.FromArgb(color_alpha, color_red, color_blue, color_green));

            Debug.WriteLine(FirstColor);
            Debug.WriteLine(SecondColor);
            Debug.WriteLine(color1);
            Debug.WriteLine(color2);
            Debug.WriteLine(MixedColors);

            // After the values are checked and put together, they will be pushed to the Colors view page
            if (FirstColor != null && SecondColor != null)
            {
                ViewBag.ColorResult = true;
                ViewBag.Color1 = "width:50px; height:50px; border: 1px soild #000; background:" + FirstColor;
                ViewBag.Color2 = "width:50px; height:50px; border: 1px soild #000; background:" + SecondColor;
                ViewBag.MixedColors = "width:50px; height:50px; border: 1px soild #000; background:" + MixedColors;
            }

            return View();
        }
    }
}
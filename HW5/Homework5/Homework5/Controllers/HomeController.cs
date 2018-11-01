using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework5.Models;
using Homework5.DAL;

namespace Homework5.Controllers
{
    public class HomeController : Controller
    {
        public RequestContext rc = new RequestContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SubmitRequest()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SubmitRequest([Bind(Include ="FirstName, LastName, Phone, Apt_Name, Unit, Req_Box, Req_Date")] Request requests)
        {
            if (ModelState.IsValid)
            {
                
                rc.Requests.Add(requests);
                rc.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult RequestQueue()
        {
            return View(rc.Requests);
        }
    }
}
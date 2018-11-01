using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework5.Models;
using Homework5.DAL;

namespace Homework5.Controllers
{
    /// <summary>
    /// Controller for all pages
    /// </summary>
    public class HomeController : Controller
    {
        private RequestContext rc = new RequestContext();

        // Default landing page
        public ActionResult Index()
        {
            return View();
        }

        // GET: Submit Request
        [HttpGet]
        public ActionResult SubmitRequest()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitRequest(Request requests)
        {
            if (ModelState.IsValid)
            {
                
                rc.Requests.Add(requests);
                rc.SaveChanges();

                RedirectToAction("RequestQueue");
            }

            return View(requests);
        }

        // GET: List of table elements
        public ActionResult RequestQueue()
        {
            return View(rc.Requests.ToList());
        }
    }
}
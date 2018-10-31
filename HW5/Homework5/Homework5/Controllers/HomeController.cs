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

        public ActionResult RequestQueue()
        {
            return View(rc.Requests);
        }
    }
}
using System.Web.Mvc;
using System.Net;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
using System;

namespace Homework7.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
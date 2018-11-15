using System.Web.Mvc;
using Homework7.DAL;

namespace Homework7.Controllers
{
    public class HomeController : Controller
    {
        private SearchLogContext sc = new SearchLogContext();

        public ActionResult Index()
        {
            return View();
        }
    }
}
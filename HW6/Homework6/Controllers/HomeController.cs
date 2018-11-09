using System.Linq;
using System.Web.Mvc;
using Homework6.Models;
using Homework6.Models.Required;

namespace Homework6.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeController : Controller
    {
        // 
        WideWorldImportersEntity db = new WideWorldImportersEntity();

        // 
        public ActionResult Customer(string searchResults)
        {
            // 
            WWViewModel vm = new WWViewModel();

            // 
            if (searchResults == null || searchResults == "")
            {
                ViewBag.Customer = false;
                return View();
            }
            // 
            else
            {
                ViewBag.Customer = true;
                return View(db.People.Where(a => a.FullName.ToUpper().Contains(searchResults.ToUpper())).ToList());
            }            
        }

        //
        public ActionResult Details(int? id)
        {
            //
            WWViewModel vmd = new WWViewModel { GetPerson = db.People.Find(id) };
            ViewBag.Found = false;

            if (vmd.GetPerson.Customers2.Count() > 0)
            {
                ViewBag.Found = true;
                // 
                int GetCustomerID = vmd.GetPerson.Customers2.FirstOrDefault().CustomerID;
                vmd.GetCustomer = db.Customers.Find(GetCustomerID);

                // 
                ViewBag.GrossSales = vmd.GetCustomer.Orders.SelectMany(b => b.Invoices).SelectMany(c => c.InvoiceLines).Sum(d => d.ExtendedPrice);
                ViewBag.GrossProfit = vmd.GetCustomer.Orders.SelectMany(e => e.Invoices).SelectMany(f => f.InvoiceLines).Sum(g => g.LineProfit);
                vmd.GetInvoiceLine = vmd.GetCustomer.Orders.SelectMany(h => h.Invoices).SelectMany(i => i.InvoiceLines).OrderByDescending(j => j.LineProfit).Take(10).ToList();
            }

            //
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }

            //
            return View("Details",vmd);
        }
    }
}